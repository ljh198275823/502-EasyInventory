using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.GeneralLibrary;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.Inventory.UI.Forms;
using LJH.Inventory.UI.Forms.General;
using LJH.Inventory.UI.Forms.Sale;

namespace LJH.Inventory.UI.Forms.Inventory.Report
{
    public partial class FrmDeliveryRecordReport : FrmReportBase
    {
        public FrmDeliveryRecordReport()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            StackOutRecord sor = item as StackOutRecord;
            row.Cells["colDeliveryDate"].Value = sor.SheetDate.ToString("yyyy-MM-dd");
            row.Cells["colSheetNo"].Value = sor.SheetNo;
            row.Cells["colCustomerName"].Value = sor.Customer.Name;
            row.Cells["colOrderID"].Value = sor.OrderID;
            row.Cells["colThick"].Value = SpecificationHelper.GetWrittenThick(sor.Specification);
            row.Cells["colWidth"].Value = SpecificationHelper.GetWrittenWidth(sor.Specification);
            row.Cells["colModel"].Value = sor.Product.Model;
            row.Cells["colCategoryID"].Value = sor.Product.Category.Name;
            row.Cells["colLength"].Value = sor.Length;
            row.Cells["colWeight"].Value = sor.Weight;
            row.Cells["colPrice"].Value = sor.Price;
            row.Cells["colCount"].Value = sor.Count;
            row.Cells["colAmount"].Value = sor.Amount.Trim();
            row.Cells["colSourceRollWeight"].Value = sor.SourceRollWeight;
        }

        protected override List<object> GetDataSource()
        {
            StackOutRecordSearchCondition con = new StackOutRecordSearchCondition();
            con.SheetDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            con.States = new List<SheetState>();
            con.States.Add(SheetState.Shipped);
            con.SheetTypes = new List<StackOutSheetType>();
            con.SheetTypes.Add(StackOutSheetType.DeliverySheet);
            if (txtCustomer.Tag != null) con.CustomerID = (txtCustomer.Tag as CompanyInfo).ID;
            if (txtProductCategory.Tag != null) con.CategoryID = (txtProductCategory.Tag as ProductCategory).ID;
            List<StackOutRecord> items = (new StackOutSheetBLL(AppSettings.Current.ConnStr)).GetDeliveryRecords(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                decimal length = txtLength.DecimalValue;
                if (length != 0) items = items.Where(it => it.Length.HasValue && it.Length == length).ToList();
                decimal weight = txtWeight.DecimalValue;
                if (weight != 0) items = items.Where(it => it.Weight.HasValue && it.Weight == weight).ToList();
                decimal sourceRollWeight = txtSourceRollWeight.DecimalValue;
                if (sourceRollWeight != 0) items = items.Where(it => it.SourceRollWeight.HasValue && it.SourceRollWeight == sourceRollWeight).ToList();
                decimal? width = SpecificationHelper.GetWrittenWidth(cmbSpecification.Specification);
                decimal? thick = SpecificationHelper.GetWrittenThick(cmbSpecification.Specification);
                return (from item in items
                        orderby item.SheetDate ascending, item.ProductID ascending
                        where (!width.HasValue || SpecificationHelper.GetWrittenWidth(item.Specification) == width) &&
                              (!thick.HasValue || SpecificationHelper.GetWrittenThick(item.Specification) == thick)
                        select (object)item).ToList();
            }
            return base.GetDataSource();
        }

        protected override void Init()
        {
            ucDateTimeInterval1.ShowTime = false;
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
            cmbSpecification.Init();
            base.Init();
        }
        #endregion

        #region 事件处理程序
        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomerMaster frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CompanyInfo customer = frm.SelectedItem as CompanyInfo;
                txtCustomer.Text = customer != null ? customer.Name : string.Empty;
                txtCustomer.Tag = customer;
            }
        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            txtCustomer.Text = string.Empty;
            txtCustomer.Tag = null;
        }

        private void lnkProductCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmProductCategoryMaster frm = new FrmProductCategoryMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ProductCategory pc = frm.SelectedItem as ProductCategory;
                txtProductCategory.Text = pc != null ? pc.Name : string.Empty;
                txtProductCategory.Tag = pc;
            }
        }

        private void txtProductCategory_DoubleClick(object sender, EventArgs e)
        {
            txtProductCategory.Text = string.Empty;
            txtProductCategory.Tag = null;
        }
        #endregion
    }
}
