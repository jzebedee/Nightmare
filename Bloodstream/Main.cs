using System;
using System.Threading;
using System.Windows;
using System.Runtime.InteropServices;
using RGiesecke.DllExport;
//using Utils;

namespace Bloodstream
{
    public static class EntryPoint
    {
        [DllExport("Main", CallingConvention = CallingConvention.Cdecl)]
        public static int Main()
        {
            try
            {
                MessageBox.Show("Hello, from within!");
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
            catch
            {
                return -1;
            }
        }
    }
}