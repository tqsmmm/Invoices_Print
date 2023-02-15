using System.Windows.Controls;

namespace 盘锦运输公司
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            tb_Title.Text = AppSetter.strApplicationName;
        }

        private void bt_Login_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (pb_Password.Password == "123456")
            {
                Bills_List bills = new Bills_List();
                NavigationService.Navigate(bills);
            }
        }

        private void bt_Cancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
