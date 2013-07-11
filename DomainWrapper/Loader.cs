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
            int inv = 0;
            var path = Marshal.PtrToStringUni(tps.pPath + 4);

            MessageBox.Show("in" + (inv++));

            Trace.Assert(Directory.Exists(path));

            MessageBox.Show("in" + (inv++));

            AppDomain newDomain = null;
            try
            {
                var setupInfo = new AppDomainSetup() { ApplicationBase = path, PrivateBinPath = path };
                MessageBox.Show("in" + (inv++));
                newDomain = AppDomain.CreateDomain(APP_NAME, AppDomain.CurrentDomain.Evidence, setupInfo);
                MessageBox.Show("in" + (inv++));

                var dllPath = Path.Combine(path, Path.ChangeExtension(APP_NAME, "dll"));
                MessageBox.Show("in" + (inv++));

                newDomain.CreateInstanceFromAndUnwrap(dllPath, APP_NAME + ".EntryPoint");
            }
            catch (Exception e)
            {
                MessageBox.Show("in" + (inv++));
                Trace.TraceError(e.ToString());
                MessageBox.Show(e.ToString());
            }
            finally
            {
                MessageBox.Show("in" + (inv++));
                if (newDomain != null)
                    AppDomain.Unload(newDomain);
                MessageBox.Show("in" + (inv++));
            }

            MessageBox.Show("in" + (inv++));
            return 0;
        }
    }
}
