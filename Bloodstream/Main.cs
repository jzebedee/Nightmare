using System;
using System.Threading;
using System.Windows;
using System.Runtime.InteropServices;
using System.Diagnostics;
//using Utils;

namespace Bloodstream
{
    public static class EntryPoint
    {
        public static int Main(params string[] args)
        {
            try
            {
                MessageBox.Show("[Inner] Hello, from within!\r\nThis ADID: " + AppDomain.CurrentDomain.Id);

                var imp = new GreyMagic.InProcessMemoryReader(System.Diagnostics.Process.GetCurrentProcess());
                MessageBox.Show(imp.ImageBase.ToString());
                //var t = new Utils.ReadyTimer(5000);
                //while (!t.Ready)
                //{
                //    Thread.Sleep(100);
                //}
                //if (t.Ready)
                //{
                //    MessageBox.Show("Ready and waiting!");
                //}
                return 1;
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                MessageBox.Show("[InnerEx] " + e.ToString());
                return -1;
            }
        }
    }
}