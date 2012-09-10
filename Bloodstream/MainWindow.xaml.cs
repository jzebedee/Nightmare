using System;
using System.Windows;
using Bloodstream.Lib.Memory;
using Bloodstream.Lib;

namespace Bloodstream
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_StartEngine_Click(object sender, RoutedEventArgs e)
        {
            Engine.Instance.Start();
        }

        private void Button_StopEngine_Click(object sender, RoutedEventArgs e)
        {
            Engine.Instance.Stop();
        }

        private void Button_TogglePauseEngine_Click(object sender, RoutedEventArgs e)
        {
            Engine.Instance.TogglePause();
        }
    }
}