using System;
using System.Data.SqlClient;

namespace 盘锦运输公司
{
    class AppSetter
    {
        public static string strApplicationName = "中油辽河石化分公司单据系统";

        public static SqlConnection SqlConn = new SqlConnection($"Server={"127.0.0.1"},{"1433"};Database={"pj_Transport"};Uid={"sa"};Pwd={"23long"};Persist Security Info=True");

        public static Bill Bills;

        public static string Printing_Name = "OKI MICROLINE 210F";

        public class Bill
        {
            public string Order_ID { get; set; }
            public DateTime DateTime { get; set; }
            public string Item { get; set; }
            public string Customer_Name { get; set; }
            public string Customer_Code { get; set; }
            public string Carrier_ID { get; set; }
            public string Carrier_Code { get; set; }
            public decimal Weight_PZ { get; set; }
            public decimal Weight_MZ { get; set; }
            public decimal Balance { get; set; }
            public decimal Weight { get; set; }
            public string Carrier_Person { get; set; }
            public string Remark { get; set; }
            public string Weight_Place { get; set; }
            public string Weight_Person { get; set; }
            public string Weight_Unit { get; set; }
        }
    }
}