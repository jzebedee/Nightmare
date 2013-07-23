//#define LAUNCH_MDA
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Diagnostics;
using RGiesecke.DllExport;
using System.Threading;
using System.Reflection;
using System.Linq;

namespace DomainWrapper
{
    public static class Loader
    {
        const string APP_NAME = "Bloodstream";

        public static string basePath { get; private set; }

        [DllExport]
        //public static unsafe int Start(IntPtr* pPath)
        public static int Init(IntPtr ppPath)
        {
#if LAUNCH_MDA
            System.Diagnostics.Debugger.Launch();
#endif

            basePath = Marshal.PtrToStringUni(Marshal.ReadIntPtr(ppPath));
            Trace.Assert(Directory.Exists(basePath));

            return -1;
        }

        [DllExport]
        public static void Host()
        {
#if LAUNCH_MDA
            System.Diagnostics.Debugger.Break();
#endif

            try
            {
                using (var host = new PathedDomainHost(APP_NAME, basePath))
                {
                    host.Execute();
                }
                //var asm_bytes = File.ReadAllBytes(_dllPath);

                //var args = new Object[] {
                //    new String[] {
                //        path
                //    }
                //};

                //var asm = Assembly.Load(asm_bytes);
                //return Convert.ToInt32(asm.EntryPoint.Invoke(null, args));
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                MessageBox.Show(e.ToString());
            }
        }
    }
}