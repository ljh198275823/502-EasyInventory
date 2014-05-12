using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using LJH.Inventory .BLL ;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory .BusinessModel .SearchCondition ;

namespace LJH.Inventory.UI.Forms.Inventory.Print
{
    public partial class FrmDeliverySheetPrint : Form
    {
        public FrmDeliverySheetPrint()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置要打印的送货单
        /// </summary>
        public DeliverySheet Sheet { get; set; }
        #endregion

        #region　私有方法
        private void RenderSheet(DeliverySheet sheet)
        {
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("CompanyName", UserSettings.Current.CompanyName));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("ForeignName", UserSettings.Current.ForeignName));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("MyAddress", UserSettings.Current.Address));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("MyTelphone", UserSettings.Current.TelPhone));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("MyFax", UserSettings.Current.Fax));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("MyWeb", UserSettings.Current.Website));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("SheetNo", sheet.ID));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("ShipDate", sheet.LastActiveDate.ToString("yyyy年MM月dd日")));
            CompanyInfo customer = (new CompanyBLL(AppSettings.Current.ConnStr)).GetByID(sheet.CustomerID).QueryObject;
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Customer", customer != null ? customer.Name : sheet.CustomerID));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Linker", sheet.Linker));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("LinkerPhone", sheet.LinkerPhoneCall));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Address", sheet.Address));
            DeliveryRecordSearchCondition con = new DeliveryRecordSearchCondition();
            con.SheetNo = new List<string>();
            con.SheetNo.Add(sheet.ID);
            List<DeliveryRecord> items = (new DeliverySheetBLL(AppSettings.Current.ConnStr)).GetDeliveryRecords(con).QueryObjects;
            ReportDataSource sr = new ReportDataSource();
            sr.Name = "Items";
            sr.Value = items;
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(sr);
            this.reportViewer1.RefreshReport();
            //设置打印布局模式,显示物理页面大小
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            //缩放模式为百分比,以100%方式显示
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
        }
        #endregion

        private void FrmDeliverySheetPrint_Load(object sender, EventArgs e)
        {
            if (Sheet != null) RenderSheet(Sheet);
        }

        private void FrmDeliverySheetPrint_FormClosed(object sender, FormClosedEventArgs e)
        {
            reportViewer1.LocalReport.Dispose();
            this.Dispose();
        }
    }
}
