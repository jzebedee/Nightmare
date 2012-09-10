using System;
using System.Threading;
using System.Windows;
using Bloodstream.Lib.Injection;
using Utils;

namespace Bloodstream
{
    static class EntryPoint
    {
        static Mutex SingleInstanceMutex = new Mutex(true);
        static void Main()
        {
            try
            {
                if (!SingleInstanceMutex.WaitOne(0))
                {
                    MessageBox.Show("There is already an instance of {0} running in this WoW.", Helper.ProductName);
                    return;
                }

                var UIThread = new Thread(new ThreadStart(() =>
                {
                    try
                    {
                        var app = new App();
                        app.DispatcherUnhandledException += (sender, e) =>
                        {
                            Log.Debug(e.Exception);
                            e.Handled = true;
                        };
                        app.Run(new MainWindow());
                    }
                    catch (Exception e)
                    {
                        Log.Debug(e, false);
                        MessageBox.Show(string.Format("Unrecoverable failure. {0} will now close.", Helper.ProductName));
                    }
                }));
                UIThread.SetApartmentState(ApartmentState.STA);

                using (var core = new Core())
                    core.RunLifetime(UIThread);
            }
            finally
            {
                SingleInstanceMutex.ReleaseMutex();
                SingleInstanceMutex.Dispose();
            }
        }
    }
}