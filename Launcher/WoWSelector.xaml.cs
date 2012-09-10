using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Launcher
{
    /// <summary>
    /// Interaction logic for WoWSelector.xaml
    /// </summary>
    public partial class WoWSelector : Window
    {
        private const string
            BootstrapperPath = "NetLoader.dll",
            InjectedLibPath = "DomainStub.dll";

        private readonly bool v_series = false;
        private Action<FrameworkElement, int> attachCallback;

        public WoWSelector()
        {
            InitializeComponent();

            attachCallback = (sender, i) =>
            {
                IsEnabled = false;

                Task.Factory.StartNew(() => Injector.Inject(i, BootstrapperPath, InjectedLibPath));

                LoadingPanel.Visibility = System.Windows.Visibility.Visible;
                Thumbnail_SelectedWoW.Visibility = System.Windows.Visibility.Hidden;

                Thumbnail_SelectedWoW.Source = IntPtr.Zero;
                Thumbnail_SelectedWoW.Tag = 0;
            };

            var os = Environment.OSVersion;
            if (os.Platform == PlatformID.Win32NT && os.Version.Major == 6)
                v_series = true;// ^ force_nonvseries;

            Listbox_WoWs.DataContext = new RunningWowList();
        }
        private void Listbox_WoWs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var WAV = Listbox_WoWs.SelectedItem as RunningWowList.WoWAttachVisual;
            if (WAV == null) return;

            if (v_series)
            {
                Thumbnail_SelectedWoW.Source = WAV.DWM;
                Thumbnail_SelectedWoW.Tag = WAV.PID;
            }
            else
                attachCallback(sender as FrameworkElement, WAV.PID);
        }

        //DWM = Devil's Window to Madness
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (!v_series || Thumbnail_SelectedWoW.Source == IntPtr.Zero) return;

            Point mouse = e.GetPosition(Thumbnail_SelectedWoW);
            if (mouse.X >= 0 && mouse.Y >= 0)
                e.MouseDevice.SetCursor(Cursors.Hand);
            else
                e.MouseDevice.UpdateCursor();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point mouse = e.GetPosition(Thumbnail_SelectedWoW);
            if (mouse.X >= 0 && mouse.Y >= 0 && Thumbnail_SelectedWoW.Tag != null)
                attachCallback(sender as FrameworkElement, (int)Thumbnail_SelectedWoW.Tag);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!v_series)
                Thumbnail_SelectedWoW.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Listbox_WoWs_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            (sender as ListBox).SelectedIndex = -1;
        }
    }
}
