using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace 盘锦运输公司
{
    /// <summary>
    /// Bills_Insert.xaml 的交互逻辑
    /// </summary>
    public partial class Bills_Detail : Page
    {
        public Bills_Detail()
        {
            InitializeComponent();
        }

        public int intID = 0;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            tb_DateTime.Text = DateTime.Now.ToString();

            tb_Weight_Unit.Text = "吨";

            tb_Balance.Text = tb_Weight.Text = tb_Weight_JZ.Text = tb_Weight_MZ.Text = tb_Weight_PZ.Text = "0.00";

            tb_Order_ID.Text = DateTime.Now.ToString("yyyy") + "006700000";

            if (intID > 0)
            {
                DataSet Ds = new DataSet();

                Ds = DB_Work.DataSetCmd($"SELECT 编号, 日期, 品名, 购户_名称, 购户_编号, 车号_名称, 车号_编号, 皮重, 毛重, 余额, 拉运数量, 提货人, 说明, 检斤地点, 检斤人, 单位 FROM 出库单据 WHERE id = {intID}");

                if (Ds.Tables[0].Rows.Count > 0)
                {
                    tb_Order_ID.Text = Ds.Tables[0].Rows[0][0].ToString();
                    tb_DateTime.Text = Convert.ToDateTime(Ds.Tables[0].Rows[0][1]).ToString("yyyy-MM-dd HH:mm:ss");
                    tb_Item.Text = Ds.Tables[0].Rows[0][2].ToString();
                    tb_Customer_Name.Text = Ds.Tables[0].Rows[0][3].ToString();
                    tb_Customer_Code.Text = Ds.Tables[0].Rows[0][4].ToString();
                    tb_Carrier_ID.Text = Ds.Tables[0].Rows[0][5].ToString();
                    tb_Carrier_Code.Text = Ds.Tables[0].Rows[0][6].ToString();
                    tb_Weight_PZ.Text = Ds.Tables[0].Rows[0][7].ToString();
                    tb_Weight_MZ.Text = Ds.Tables[0].Rows[0][8].ToString();
                    tb_Balance.Text = Ds.Tables[0].Rows[0][9].ToString();
                    tb_Weight_JZ.Text = tb_Weight.Text = Ds.Tables[0].Rows[0][10].ToString();
                    tb_Weight_Person.Text = Ds.Tables[0].Rows[0][11].ToString();
                    tb_Remark.Text = Ds.Tables[0].Rows[0][12].ToString();
                    tb_Weight_Place.Text = Ds.Tables[0].Rows[0][13].ToString();
                    tb_Weight_Person.Text = Ds.Tables[0].Rows[0][14].ToString();
                    tb_Weight_Unit.Text = Ds.Tables[0].Rows[0][15].ToString();
                }
            }
        }

        private void bt_Close_Click(object sender, RoutedEventArgs e)
        {
            Bills_List bills_List = new Bills_List();
            NavigationService.Navigate(bills_List);
        }

        private void bt_Ok_Click(object sender, RoutedEventArgs e)
        {
            if (intID > 0)
            {
                DB_Work.ExecuteCmd($"UPDATE 出库单据 SET 编号 = '{tb_Order_ID.Text}', " +
                    $"日期 = '{tb_DateTime.Text}', " +
                    $"品名 = '{tb_Item.Text}', " +
                    $"购户_名称 = '{tb_Customer_Name.Text}', " +
                    $"购户_编号 = '{tb_Customer_Code.Text}', " +
                    $"车号_名称 = '{tb_Carrier_ID.Text}', " +
                    $"车号_编号 = '{tb_Carrier_Code.Text}', " +
                    $"皮重 = {tb_Weight_PZ.Text}, " +
                    $"毛重 = {tb_Weight_MZ.Text}, " +
                    $"拉运数量 = {tb_Weight.Text}, " +
                    $"余额 = {tb_Balance.Text}, " +
                    $"提货人 = '{tb_Carrier_Person.Text}', " +
                    $"说明 = '{tb_Remark.Text}', " +
                    $"检斤地点 = '{tb_Weight_Place.Text}', " +
                    $"检斤人 = '{tb_Weight_Person.Text}', " +
                    $"单位 = '{tb_Weight_Unit.Text}' " +
                    $"WHERE id = {intID}");
            }
            else
            {
                DB_Work.ExecuteCmd("INSERT INTO 出库单据(编号, 日期, 品名, 购户_名称, 购户_编号, 车号_名称, 车号_编号, 皮重, 毛重, 余额, 拉运数量, 提货人, 说明, 检斤地点, 检斤人, 单位, 打印机) " +
                $"VALUES('{tb_Order_ID.Text}', '{tb_DateTime.Text}', '{tb_Item.Text}', '{tb_Customer_Name.Text}', '{tb_Customer_Code.Text}', " +
                $"'{tb_Carrier_ID.Text}', '{tb_Carrier_Code.Text}', {tb_Weight_PZ.Text}, {tb_Weight_MZ.Text}, " +
                $"{tb_Balance.Text}, {tb_Weight.Text}, '{tb_Carrier_Person.Text}', '{tb_Remark.Text}', '{tb_Weight_Place.Text}', '{tb_Weight_Person.Text}', '{tb_Weight_Unit.Text}', '{AppSetter.Printing_Name}')");
            }

            AppSetter.Bills = new AppSetter.Bill
            {
                Order_ID = tb_Order_ID.Text,
                DateTime = Convert.ToDateTime(tb_DateTime.Text),
                Item = tb_Item.Text,
                Customer_Name = tb_Customer_Name.Text,
                Customer_Code = tb_Customer_Code.Text,
                Carrier_ID = tb_Carrier_ID.Text,
                Carrier_Code = tb_Carrier_Code.Text,
                Weight_PZ = Convert.ToDecimal(tb_Weight_PZ.Text),
                Weight_MZ = Convert.ToDecimal(tb_Weight_MZ.Text),
                Balance = Convert.ToDecimal(tb_Balance.Text),
                Weight = Convert.ToDecimal(tb_Weight.Text),
                Carrier_Person = tb_Carrier_Person.Text,
                Remark = tb_Remark.Text,
                Weight_Place = tb_Weight_Place.Text,
                Weight_Person = tb_Weight_Person.Text,
                Weight_Unit = tb_Weight_Unit.Text
            };

            bt_Close_Click(null, null);
        }

        private void bt_Print_Click(object sender, RoutedEventArgs e)
        {
            bt_Ok_Click(null, null);

            Prints.Print_Bills();
        }

        private void tb_Weight_PZ_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (tb_Weight_MZ.Text != string.Empty && tb_Weight_PZ.Text != string.Empty)
                {
                    tb_Weight.Text = tb_Weight_JZ.Text = (Convert.ToDecimal(tb_Weight_MZ.Text) - Convert.ToDecimal(tb_Weight_PZ.Text)).ToString();
                }
            }
            catch
            {

            }
        }

        private void tb_Weight_MZ_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (tb_Weight_MZ.Text != string.Empty && tb_Weight_PZ.Text != string.Empty)
                {
                    tb_Weight.Text = tb_Weight_JZ.Text = (Convert.ToDecimal(tb_Weight_MZ.Text) - Convert.ToDecimal(tb_Weight_PZ.Text)).ToString();
                }
            }
            catch
            {

            }
        }

        private void tb_Weight_JZ_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb_Weight_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
