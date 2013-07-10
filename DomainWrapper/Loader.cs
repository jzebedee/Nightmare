using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;

namespace DomainWrapper
{
    public static class Loader
    {
        [DllExport("Main", CallingConvention = CallingConvention.Cdecl)]
        public static void Start()
        {

        }
    }
}
