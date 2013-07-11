using System;
using System.Threading;
using System.Windows;
using System.Runtime.InteropServices;
using DomainWrapper;
//using Utils;

namespace Bloodstream
{
    public class EntryPoint : MarshalByRefObject
    {
        public EntryPoint()
        {
            try
            {
                MessageBox.Show("Hello, from within deux!");
                //var t = new Utils.ReadyTimer(5000);
                //while (!t.Ready)
                //{
                //    Thread.Sleep(100);
                //}
                //if (t.Ready)
                //{
                //    MessageBox.Show("Ready and waiting!");
                //}
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}