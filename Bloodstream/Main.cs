using System;
using System.Threading;
using System.Windows;
using System.Runtime.InteropServices;
using RGiesecke.DllExport;
//using Utils;

namespace Bitchstream
{
    public static class EntryPoint
    {
        [DllExport("Main", CallingConvention = CallingConvention.Cdecl)]
        public static int Main()
        {
            try
            {
                MessageBox.Show("Hello, from within!");
                return 1;
            }
            catch
            {
                return -1;
            }
        }
    }
}