using System;
using System.Diagnostics;
using System.IO;
using Bloodstream.Lib.Injection;
using Microsoft.Win32;
using Utils.Memory;

namespace Launcher
{
    static class Injector
    {
        const string subKeyPath = @"SOFTWARE\Nightmare";
        public static bool Inject(int startedPID, string dllLoaderPath, string dllPath)
        {
            dllLoaderPath = Path.GetFullPath(dllLoaderPath);
            dllPath = Path.GetFullPath(dllPath);

            string keyPath = startedPID.ToString();
            using (var subKey = Registry.LocalMachine.CreateSubKey(subKeyPath))
            {
                foreach (var key in subKey.GetSubKeyNames())
                    try
                    {
                        if (Process.GetProcessById(Convert.ToInt32(key)).HasExited)
                            subKey.DeleteSubKeyTree(key);
                    }
                    catch (ArgumentException)
                    {
                        subKey.DeleteSubKeyTree(key);
                    }

                using (var wowKey = subKey.CreateSubKey(keyPath))
                {
                    wowKey.SetValue("DLLPATH", dllPath);
                    wowKey.SetValue("PARENTID", Process.GetCurrentProcess().Id);
                }
            }

            IntPtr procHandle = IntPtr.Zero;
            try
            {
                procHandle = Invokes.OpenProcess(0x001F0FFF, true, startedPID);
                return SInject.InjectDllCreateThread(procHandle, dllLoaderPath) > 0;
            }
            finally
            {
                if (procHandle != IntPtr.Zero)
                    Invokes.CloseHandle(procHandle);
            }
        }
    }
}