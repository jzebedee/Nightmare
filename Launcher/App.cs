using GreyMagic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;

namespace Launcher
{
    public static class App
    {
        private const string
            InjectedLibPath = "DomainWrapper.dll",
            //TargetString = "Notepad++"
            TargetString = "Borderlands2"
        ;

        private const bool
            EjectOnUnload = true
        ;

        public static int Main(params string[] args)
        {
            try
            {
                var targetProc = Process.GetProcessesByName(TargetString).FirstOrDefault();
                if (targetProc == null)
                {
                    Console.WriteLine(TargetString + " is not running.");
                    return -1;
                }

                Console.WriteLine("Found {0} (PID {1})", TargetString, targetProc.Id);
                using (var mem = new ExternalProcessReader(targetProc))
                {

                }

                if (targetProc != null)
                {
                    Console.WriteLine("Press to kill.");
                    Console.ReadKey();
                    targetProc.Kill();
                }
                else
                {
                    Console.WriteLine("No target process.");
                }

                return 0;
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}