using System;
using System.Windows;

namespace 盘锦运输公司
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class frmMain : Window
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title = AppSetter.strApplicationName;

            fMain.Source = new Uri("Login.xaml", UriKind.Relative);
        }
    }
}
