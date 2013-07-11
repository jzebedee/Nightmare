using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows;
using System.Diagnostics;
using System.Reflection;

namespace DomainWrapper
{
    public static class Loader
    {
        const string APP_NAME = "Bloodstream";

        [StructLayout(LayoutKind.Sequential)]
        public struct TransferPathStruct
        {
            public IntPtr pPath;
        }

        [DllExport("Start", CallingConvention = CallingConvention.Cdecl)]
        public static int Start(TransferPathStruct tps)
        {
            var path = Marshal.PtrToStringUni(tps.pPath + 4);

            Trace.Assert(Directory.Exists(path));

            AppDomain newDomain = null;
            try
            {
                var setupInfo = new AppDomainSetup() { ApplicationBase = path, PrivateBinPath = path };
                newDomain = AppDomain.CreateDomain(APP_NAME, AppDomain.CurrentDomain.Evidence, setupInfo);

                MessageBox.Show("This ADID: " + AppDomain.CurrentDomain.Id);

                var dllPath = Path.Combine(path, Path.ChangeExtension(APP_NAME, "exe"));

                newDomain.ExecuteAssembly(dllPath);
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                MessageBox.Show(e.ToString());
            }
            finally
            {
                if (newDomain != null)
                    AppDomain.Unload(newDomain);
            }

            return 0;
        }
    }
}