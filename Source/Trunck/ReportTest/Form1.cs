using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;

namespace ReportTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string _connStr = "SQLITE:" + "Data Source=" + Path.Combine(Application.StartupPath, "Inventory.db");

        private void Form1_Load(object sender, EventArgs e)
        {
            UserSettings.Current = SysParaSettingsBll.GetOrCreateSetting<UserSettings>(_connStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<DeliverySheet> items = (new DeliverySheetBLL(_connStr)).GetItems(null).QueryObjects;
            if (items != null && items.Count > 0)
            {
                DeliverySheet sheet = items[0];
                NewMethod(sheet);
            }
        }

        private void NewMethod(DeliverySheet sheet)
        {
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("SheetHeader", UserSettings.Current.CompanyName));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("SheetNo", sheet.ID));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("ShipDate", sheet.LastActiveDate.ToString("yyyy年MM月dd日")));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Customer", sheet.CustomerID));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Linker", sheet.Linker));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("LinkerPhone", sheet.LinkerPhoneCall));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Address", sheet.Address));
            DeliveryRecordSearchCondition con = new DeliveryRecordSearchCondition();
            con.SheetNo = new List<string>();
            con.SheetNo.Add(sheet.ID);
            List<DeliveryRecord> items = (new DeliverySheetBLL(_connStr)).GetDeliveryRecords(con).QueryObjects;
            ReportDataSource sr = new ReportDataSource();
            sr.Name = "Items";
            sr.Value = items;
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(sr);
            this.reportViewer1.RefreshReport();
        }
    }
}
