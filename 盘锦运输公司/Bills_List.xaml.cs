using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Controls;

namespace 盘锦运输公司
{
    /// <summary>
    /// Bills_List.xaml 的交互逻辑
    /// </summary>
    public partial class Bills_List : Page
    {
        public Bills_List()
        {
            InitializeComponent();
        }

        ObservableCollection<Bill> bills = new ObservableCollection<Bill>();

        public class Bill
        {
            public int id { get; set; }
            public string 编号 { get; set; }
            public string 日期 { get; set; }
            public string 品名 { get; set; }
            public string 购户_名称 { get; set; }
            public string 车号_名称 { get; set; }
            public decimal 毛重 { get; set; }
            public decimal 皮重 { get; set; }
            public decimal 拉运数量 { get; set; }
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            bt_Refresh_Click(null, null);
        }

        private void bt_Refresh_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DataSet Ds = DB_Work.DataSetCmd($"SELECT id, 编号, CONVERT(VARCHAR(16), 日期, 120) AS [日期], 品名, 购户_名称, 车号_名称, 毛重, 皮重, 拉运数量 FROM 出库单据 WHERE 打印机 = '{AppSetter.Printing_Name}' OR 打印机 IS NULL ORDER BY [日期]");

            bills.Clear();

            for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
            {
                bills.Add(new Bill
                {
                    id = Convert.ToInt32(Ds.Tables[0].Rows[i][0]),
                    编号 = Ds.Tables[0].Rows[i][1].ToString(),
                    日期 = Ds.Tables[0].Rows[i][2].ToString(),
                    品名 = Ds.Tables[0].Rows[i][3].ToString(),
                    购户_名称 = Ds.Tables[0].Rows[i][4].ToString(),
                    车号_名称 = Ds.Tables[0].Rows[i][5].ToString(),
                    毛重 = Convert.ToDecimal(Ds.Tables[0].Rows[i][6]),
                    皮重 = Convert.ToDecimal(Ds.Tables[0].Rows[i][7]),
                    拉运数量 = Convert.ToDecimal(Ds.Tables[0].Rows[i][8])
                });
            }

            lvList.ItemsSource = bills;
        }

        private void bt_Del_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (lvList.SelectedItems.Count > 0)
            {
                if (Public.Sys_MsgYN("是否确定删除选定项目？"))
                {
                    Bill b = (Bill)lvList.SelectedItem;

                    DB_Work.ExecuteCmd($"DELETE FROM 出库单据 WHERE id = {b.id}");

                    bt_Refresh_Click(null, null);
                }
            }
        }

        private void bt_Edit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (lvList.SelectedItems.Count > 0)
            {
                Bill b = (Bill)lvList.SelectedItem;

                Bills_Detail bills = new Bills_Detail
                {
                    intID = b.id
                };

                bills.bt_Print.IsEnabled = true;
                NavigationService.Navigate(bills);
            }
        }

        private void bt_New_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Bills_Detail bills = new Bills_Detail();
            bills.bt_Print.IsEnabled = false;
            NavigationService.Navigate(bills);
        }

        private void lvList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            bt_Edit_Click(null, null);
        }
    }
}
