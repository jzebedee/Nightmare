using System;
using System.Threading;
using System.Windows;
using System.Runtime.InteropServices;
using DomainWrapper;
//using Utils;

namespace Bloodstream
{
    public static class EntryPoint
    {
        public static int Main(params string[] args)
        {
            try
            {
                MessageBox.Show("Hello, from within!\r\nThis ADID: " + AppDomain.CurrentDomain.Id);
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