using System;
using System.Drawing;
using System.Drawing.Printing;

namespace 盘锦运输公司
{
    class Prints
    {
        public static void Print_Bills()
        {
            try
            {
                PrintDocument Print_Bills = new PrintDocument();
                Print_Bills.PrinterSettings.PrinterName = AppSetter.Printing_Name;
                Print_Bills.PrintPage += new PrintPageEventHandler(Print_Bills_PrintPage);
                Print_Bills.Print();
            }
            catch (Exception Ex)
            {
                Public.Sys_MsgBox(Ex.Message);
            }
        }

        private static void Print_Bills_PrintPage(object sender, PrintPageEventArgs e)
        {
            var pen = new Pen(Brushes.Black, 1);

            var dotpen = new Pen(Brushes.Black, 1)
            {
                DashStyle = System.Drawing.Drawing2D.DashStyle.Custom,
                DashPattern = new float[] { 8, 1 }
            };

            Font font = new Font("宋体", 12);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center; //居中
            format.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString("中油辽河石化分公司出库证", new Font("宋体", 18, FontStyle.Bold), Brushes.Black, 210, 0);

            e.Graphics.DrawLine(dotpen, new Point(0, 30), new Point(755, 30));
            e.Graphics.DrawLine(dotpen, new Point(0, 33), new Point(755, 33));

            e.Graphics.DrawString(AppSetter.Bills.Item, font, Brushes.Black, 0, 42);
            e.Graphics.DrawString(AppSetter.Bills.DateTime.ToString("yyyy年M月d日"), font, Brushes.Black, 390, 42);
            e.Graphics.DrawString("编号：" + AppSetter.Bills.Order_ID, font, Brushes.Black, 580, 42);

            e.Graphics.DrawLine(pen, new Point(0, 60), new Point(755, 60));
            e.Graphics.DrawLine(pen, new Point(0, 210), new Point(755, 210));
            e.Graphics.DrawLine(pen, new Point(0, 60), new Point(0, 210));
            e.Graphics.DrawLine(pen, new Point(755, 60), new Point(755, 210));

            e.Graphics.DrawLine(pen, new Point(85, 80), new Point(580, 80));
            e.Graphics.DrawLine(pen, new Point(630, 80), new Point(755, 80));

            e.Graphics.DrawLine(pen, new Point(0, 100), new Point(755, 100));
            e.Graphics.DrawLine(pen, new Point(0, 120), new Point(755, 120));
            e.Graphics.DrawLine(pen, new Point(0, 140), new Point(755, 140));

            e.Graphics.DrawString("购 户", font, Brushes.Black, 20, 70);
            e.Graphics.DrawString(AppSetter.Bills.Customer_Name, font, Brushes.Black, new Rectangle(85, 60, 495, 20), format);
            e.Graphics.DrawString(AppSetter.Bills.Customer_Code, font, Brushes.Black, new Rectangle(85, 80, 495, 20), format);

            e.Graphics.DrawString("车号", font, Brushes.Black, 585, 70);
            e.Graphics.DrawString(AppSetter.Bills.Carrier_ID, font, Brushes.Black, new Rectangle(630, 60, 125, 20), format);
            e.Graphics.DrawString(AppSetter.Bills.Carrier_Code, font, Brushes.Black, new Rectangle(630, 80, 125, 20), format);

            e.Graphics.DrawString("皮重", font, Brushes.Black, 24, 100);
            e.Graphics.DrawString(AppSetter.Bills.Weight_PZ.ToString(), font, Brushes.Black, new Rectangle(85, 100, 215, 20), format);

            e.Graphics.DrawString("毛重", font, Brushes.Black, 325, 100);
            e.Graphics.DrawString(AppSetter.Bills.Weight_MZ.ToString(), font, Brushes.Black, new Rectangle(390, 100, 60, 20), format);

            e.Graphics.DrawString("净重", font, Brushes.Black, 460, 100);
            e.Graphics.DrawString(AppSetter.Bills.Weight.ToString(), font, Brushes.Black, new Rectangle(510, 100, 70, 20), format);

            e.Graphics.DrawString("余额", font, Brushes.Black, 585, 100);
            e.Graphics.DrawString(AppSetter.Bills.Balance.ToString(), font, Brushes.Black, new Rectangle(630, 100, 125, 20), format);

            e.Graphics.DrawString("拉运数量", font, Brushes.Black, 5, 120);
            e.Graphics.DrawString(AppSetter.Bills.Weight.ToString(), font, Brushes.Black, new Rectangle(85, 120, 215, 20), format);

            e.Graphics.DrawString("时间", font, Brushes.Black, 325, 120);
            e.Graphics.DrawString(AppSetter.Bills.DateTime.ToString("HH:mm:ss"), font, Brushes.Black, new Rectangle(390, 120, 120, 20), format);

            e.Graphics.DrawString("提货人", font, Brushes.Black, 515, 120);
            e.Graphics.DrawString(AppSetter.Bills.Carrier_Person, font, Brushes.Black, 585, 120);

            e.Graphics.DrawString("说明", font, Brushes.Black, 24, 160);
            e.Graphics.DrawString(AppSetter.Bills.Remark, font, Brushes.Black, 90, 140);

            e.Graphics.DrawLine(pen, new Point(85, 60), new Point(85, 210));
            e.Graphics.DrawLine(pen, new Point(300, 100), new Point(300, 140));
            e.Graphics.DrawLine(pen, new Point(390, 100), new Point(390, 140));
            e.Graphics.DrawLine(pen, new Point(450, 100), new Point(450, 120));
            e.Graphics.DrawLine(pen, new Point(510, 100), new Point(510, 140));
            e.Graphics.DrawLine(pen, new Point(580, 60), new Point(580, 140));
            e.Graphics.DrawLine(pen, new Point(630, 60), new Point(630, 120));

            e.Graphics.DrawString("检斤地点：" + AppSetter.Bills.Weight_Place, font, Brushes.Black, 0, 212);
            e.Graphics.DrawString("检斤人：" + AppSetter.Bills.Weight_Person, font, Brushes.Black, 400, 212);
            e.Graphics.DrawString("单位：" + AppSetter.Bills.Weight_Unit, font, Brushes.Black, 630, 212);

            e.Graphics.DrawString("防伪查询：编辑车号（如辽L12345），移动用户发送到10650976715004，联通电信用户发送到10691221631812153，即可查询车辆最新拉运记录。", new Font("宋体", 9), Brushes.Black, 0, 240);
        }
    }
}
