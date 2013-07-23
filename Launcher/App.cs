#define LAUNCH
using Syringe;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;

namespace Launcher
{
    public static class App
    {
        private const string
            InjectedLibPath = "DomainWrapper.dll",
            //TargetString = "Notepad++"
            TargetString = "Borderlands2"
        ;

        private const bool
            EjectOnUnload = true
        ;

        [StructLayout(LayoutKind.Sequential)]
        public struct TransferPathStruct
        {
            [CustomMarshalAs(CustomUnmanagedType.LPWStr)]
            public string path;
        }

        public static int Main(params string[] args)
        {
            try
            {
                var principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                Debug.Assert(principal.IsInRole(WindowsBuiltInRole.Administrator));

                Process.EnterDebugMode();

#if LAUNCH
                var si = new Syringe.Win32.STARTUPINFO();
                var pi = new Syringe.Win32.PROCESS_INFORMATION();
#endif

                var targetProc = Process.GetProcessesByName(TargetString).FirstOrDefault();
                if (targetProc == null)
                {
#if LAUNCH
                    var launchPath = @"X:\Games\BL2\Binaries\Win32\Borderlands2.exe";
                    var launchDir = @"X:\Games\BL2\Binaries\Win32\";

                    if (Syringe.Win32.Imports.CreateProcessW(launchPath, null, IntPtr.Zero, IntPtr.Zero, false, Syringe.Win32.ProcessCreationFlags.CreateSuspended, IntPtr.Zero, launchDir, ref si, out pi))
                    {
                        targetProc = Process.GetProcessById(pi.dwProcessId);
                    }
                    else
                    {
                        throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
                    }
#else
                    Console.WriteLine(TargetString + " is not running.");
                    return -1;
#endif
                }

                Console.WriteLine("Found {0} (PID {1})", TargetString, targetProc.Id);
                using (var inj = new Injector(targetProc, EjectOnUnload))
                {
                    Console.WriteLine("Built injector.");
                    var tps = new TransferPathStruct
                    {
                        path = Path.GetDirectoryName(Path.GetFullPath(InjectedLibPath))
                    };

                    inj.InjectLibrary(InjectedLibPath);
                    Console.WriteLine("Injected library: " + InjectedLibPath);

                    Console.WriteLine("Calling Init export...");
                    inj.CallExport<TransferPathStruct>(InjectedLibPath, "Init", tps);

                    Console.WriteLine("Calling Host export...");
                    inj.CallExport(InjectedLibPath, "Host");
                }
                Console.WriteLine("Unloaded injector.{0}", EjectOnUnload ? " [Ejected]" : "");

#if LAUNCH
                Console.WriteLine("Press to resume.");
                Console.ReadKey();
                int ret = Syringe.Win32.Imports.ResumeThread(pi.hThread);
                if (ret == -1)
                {
                    throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
                }
                else
                {
                    Console.WriteLine("Resumed ({0}).", ret);
                }
#endif

                if (targetProc != null)
                {
                    Console.WriteLine("Press to kill.");
                    Console.ReadKey();
                    targetProc.Kill();
                }
                else
                {
                    Console.WriteLine("No target process.");
                }

                return 0;
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();

                Process.LeaveDebugMode();
            }
        }
    }
}