using System;
using System.Windows.Controls;

namespace Utils
{
    /// <summary>
    /// Interaction logic for LogDisplay.xaml
    /// </summary>
    public partial class LogDisplay : TabControl
    {
        public LogDisplay()
        {
            InitializeComponent();

            DataContext = Log.Logs;

            SelectedIndex = 0;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedIndex < 0)
                SelectedIndex = 0;

            Dispatcher.BeginInvoke((Action)(() =>
            {
                var box = Helper.FindChild<TextBox>(this);
                if (box != null)
                    box.ScrollToEnd();
            }), System.Windows.Threading.DispatcherPriority.Background);
        }

        private void TextBox_TargetUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            (sender as TextBox).ScrollToEnd();
        }
    }
}