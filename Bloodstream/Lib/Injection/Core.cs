using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using Bloodstream.Lib.Memory;
using Bloodstream.Patchables;
using Microsoft.Win32;
using Utils;
using AccessRights = Utils.Memory.AccessRights;

namespace Bloodstream.Lib.Injection
{
    public class Core : CriticalFinalizerObject, IDisposable
    {
        public Core()
        {

        }
        ~Core()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {

        }

        static WowBase Wow
        {
            get
            {
                return WowBase.Instance;
            }
            set
            {
                WowBase.Instance = value;
            }
        }

        static readonly int CurrentProcessID = Process.GetCurrentProcess().Id;

        /// <summary>
        /// Kills the Launcher associated with the current MeatHook and returns the path of the Launcher executable on success, and string.Empty on failure.
        /// </summary>
        /// <returns></returns>
        static string KillParent()
        {
            var subKeyPath = @"SOFTWARE\Bloodstream\WOW" + CurrentProcessID;
            using (var subKey = Registry.LocalMachine.OpenSubKey(subKeyPath, true))
            {
                var parentID = (int)subKey.GetValue("PARENTID");

                var parent = Process.GetProcessById(parentID); //can't use HasExited when we don't have full trust
                try
                {
                    if (!parent.CloseMainWindow())
                        parent.Kill();

                    return parent.MainModule.FileName;
                }
                catch (Exception pe)
                {
                    if (!(pe is InvalidOperationException || pe is ArgumentException))
                        throw;
                }
            }

            return "";
        }

        static Bridge Bridge;
        static EndSceneDelegate origEndScene, hookEndScene;
        static Hooker endSceneHook;

        public void RunLifetime(Thread observing)
        {
            if (AppDomain.CurrentDomain.IsDefaultAppDomain())
            {
                MessageBox.Show(string.Format("{0} may not be started directly. Please use the launcher.", Helper.ProductName));
                return;
            }

            try
            {
                try
                {
                    SMemory.ProcHandle = Invokes.OpenProcess(AccessRights.PROCESS_VM_WRITE | AccessRights.PROCESS_VM_READ | AccessRights.PROCESS_VM_OPERATION, true, CurrentProcessID);
                }
                catch (System.ComponentModel.Win32Exception we)
                {
                    //System.ComponentModel.Win32Exception (0x80004005)
                    if (we.NativeErrorCode != 1300)
                        throw;

                    var res = MessageBox.Show(string.Format("{0} does not have the necessary privileges to run. Would you like to restart WoW as administrator?", Helper.ProductName), "Invalid Permissions", MessageBoxButton.YesNo);
                    switch (res)
                    {
                        case MessageBoxResult.Yes:
                            var currentStartInfo = Process.GetCurrentProcess().StartInfo;
                            currentStartInfo.Verb = "runas";
                            currentStartInfo.FileName = Process.GetCurrentProcess().MainModule.FileName;
                            Process.Start(currentStartInfo);

                            Environment.Exit(1);
                            return;
                        default:
                            return;
                    }
                }

                var EndSceneInit = new ScheduledActionPulse(() => InMainThread = true);
                pulseFunctions.Add(EndSceneInit);

                var pD3D9 = Invokes.GetModuleHandle("d3d9");
                Trace.Assert(pD3D9 != IntPtr.Zero, "Could not locate D3D9 module");

                var pD3DDevice = Invokes.GetD3DDevicePointer(pD3D9);
                Trace.Assert(pD3DDevice != IntPtr.Zero, "Could not locate D3D Device");

                IntPtr endSceneAddr = (IntPtr)SMemory.GetVFT((uint)pD3DDevice, (uint)VFTIndices.DXEndScene);

                origEndScene = Marshal.GetDelegateForFunctionPointer(endSceneAddr, typeof(EndSceneDelegate)) as EndSceneDelegate;
                hookEndScene = new EndSceneDelegate(Pulse);

                endSceneHook = new Hooker(origEndScene, hookEndScene);
                endSceneHook.Hook();

                using (Bridge = new Bridge())
                {
                    EndSceneInit.Signal.WaitOne();
                    Bridge.Initialize();
                    using (Wow = new WowBase(Bridge))
                    {
                        Bridge.Show("{0} has connected", Helper.ProductName);

                        KillParent();

                        observing.Start();
                        observing.Join();

                        Bridge.Show("{0} has disconnected", Helper.ProductName);

                        pulseFunctions.CompleteAdding();
                        while (!pulseFunctions.IsCompleted) //finish up any remaining PulseFunctions
                            Thread.Sleep(100);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                if (endSceneHook != null)
                    endSceneHook.Dispose();

                _id = 0;
                pulseFunctions.Dispose();

                if (SMemory.ProcHandle != IntPtr.Zero)
                    Invokes.CloseHandle(SMemory.ProcHandle);
            }
        }

        #region Pulse scheduling
        static object lock_id = new object();
        static uint _id = 0;
        static uint ID
        {
            get
            {
                lock (lock_id)
                {
                    unchecked
                    {
                        return ++_id;
                    }
                }
            }
        }

        static BlockingCollection<IPulseExecutor> pulseFunctions = new BlockingCollection<IPulseExecutor>();

        internal static void RunPulse(Action toExec, bool Sync = true)
        {
            if (InMainThread && Sync)
            {
                try
                {
                    toExec();
                }
                catch (Exception e)
                {
                    Log.Debug(e);
                }
            }
            else
            {
                var pulse = new ScheduledActionPulse(toExec);

                if (!pulseFunctions.IsAddingCompleted && pulseFunctions.TryAdd(pulse) && Sync)
                    pulse.Signal.WaitOne();
            }
        }
        internal static T RunPulse<T>(Func<T> toExec, bool Sync = true)
        {
            if (InMainThread && Sync)
            {
                try
                {
                    return toExec();
                }
                catch (Exception e)
                {
                    Log.Debug(e);
                }
            }
            else
            {
                var pulse = new ScheduledPulse<T>(toExec);

                if (!pulseFunctions.IsAddingCompleted && pulseFunctions.TryAdd(pulse) && Sync)
                {
                    pulse.Signal.WaitOne();
                    return pulse.Result;
                }
            }

            return default(T);
        }
        #endregion

        [ThreadStatic]
        static bool InMainThread;
        internal static bool IsInMainThread
        {
            get
            {
                return InMainThread;
            }
        }

        internal static uint FrameCount { get; private set; }

        static object hookLocker = new object();
        static int Pulse(IntPtr instance)
        {
            if (InMainThread || FrameCount == 0)
            {
                try
                {
                    unchecked { FrameCount++; }

                    if (Wow != null)
                    {
                        bool InGame = Bridge.InGame;
                        if (Wow.InGame != InGame)
                        {
                            Bridge.Initialize();
                            Wow.InGame = InGame;
                        }

                        if (InGame)
                        {
                            if (FrameCount % 1000 == 0)
                                WowMemory.Write<uint>((uint)Pointers.LastHardwareAction, (uint)Bridge.PerformanceCounter());
                        }

                        if (FrameCount % 10 == 0)
                            WowBase.Instance.ObjectRefresh();
                    }

                    IPulseExecutor Pulse;
                    while (pulseFunctions.TryTake(out Pulse))
                        Pulse.Execute();
                }
                catch (Exception e)
                {
                    Log.Debug(e);
                }
            }

            lock (hookLocker)
            {
                try
                {
                    while (!endSceneHook.Unhook())
                        continue; //this really can happen
                    return origEndScene(instance);
                }
                finally
                {
                    if (!pulseFunctions.IsCompleted)
                        endSceneHook.Hook();
                }
            }
        }
    }
}