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

namespace LJH.Inventory.UI.Forms.Print
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
    }
}
