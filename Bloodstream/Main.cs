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
        const int
            SUCCESS = 0,
            FAIL_UNKNOWN = -1,
            FAIL_ALREADY_RUNNING = -2;

        static Mutex SingleInstanceMutex = new Mutex(true);

        [DllExport("Main", CallingConvention = CallingConvention.Cdecl)]
        public static int Main(string argument)
        {
            try
            {
                MessageBox.Show("Hello, from within!", argument);
                return 1;
            }
            catch
            {
                return -1;
            }

            try
            {
                if (!SingleInstanceMutex.WaitOne(0))
                {
                    //MessageBox.Show("There is already an instance of {0} running in this WoW.", Helper.ProductName);
                    return FAIL_ALREADY_RUNNING;
                }

                var UIThread = new Thread(new ThreadStart(() =>
                {
                    try
                    {
                        var app = new App();
                        app.DispatcherUnhandledException += (sender, e) =>
                        {
                            //Log.Debug(e.Exception);
                            e.Handled = true;
                        };
                        app.Run(new MainWindow());
                    }
                    catch (Exception e)
                    {
                        //Log.Debug(e, false);
                        //MessageBox.Show(string.Format("Unrecoverable failure. {0} will now close.", Helper.ProductName));
                    }
                }));
                UIThread.SetApartmentState(ApartmentState.STA);

                //var timer = new ReadyTimer(30000);
                //while (!timer.Ready)
                Thread.Sleep(5000);
                //using (var core = new Core())
                //    core.RunLifetime(UIThread);
            }
            finally
            {
                SingleInstanceMutex.ReleaseMutex();
                //SingleInstanceMutex.Dispose();
            }

            return SUCCESS;
        }
    }
}