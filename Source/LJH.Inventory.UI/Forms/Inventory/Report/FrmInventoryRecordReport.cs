using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.Inventory.UI.Forms;
using LJH.Inventory.UI.Forms.General;
using LJH.Inventory.UI.Forms.Purchase;
using LJH.GeneralLibrary;

namespace LJH.Inventory.UI.Forms.Inventory.Report
{
    public partial class FrmInventoryRecordReport : FrmReportBase
    {
        public FrmInventoryRecordReport()
        {
            InitializeComponent();
        }

        private List<CompanyInfo> _AllSuppliers = null;

        #region 重写基类方法
        protected override void Init()
        {
            ucDateTimeInterval1.ShowTime = false;
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
            cmbSpecification.Init();
            base.Init();
        }

        protected override List<object> GetDataSource()
        {
            _AllSuppliers = new CompanyBLL(AppSettings.Current.ConnStr).GetAllSuppliers().QueryObjects;

            ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
            con.AddDateRange = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            List<ProductInventoryItem> items = (new ProductInventoryItemBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                items.RemoveAll(it => it.State == ProductInventoryState.Nullified && it.Status == "整卷");
                items = items.Where(it => it.SourceID == null && it.SourceRoll == null).ToList(); //首先排除作废的，库存项分项和加工而来的项
                if (txtCustomer.Tag != null) items = items.Where(it => it.Supplier == (txtCustomer.Tag as CompanyInfo).ID).ToList();
                if (txtProductCategory.Tag != null) items = items.Where(it => it.Product.CategoryID == (txtProductCategory.Tag as ProductCategory).ID).ToList();
                decimal length = txtLength.DecimalValue;
                if (length != 0) items = items.Where(it => (it.OriginalLength.HasValue && it.OriginalLength == txtLength.DecimalValue) || (it.Product.Length.HasValue && it.Product.Length == length)).ToList();
                decimal weight = txtWeight.DecimalValue;
                if (weight != 0) items = items.Where(it => it.Weight.HasValue && it.Weight == weight).ToList();
                decimal? width = SpecificationHelper.GetWrittenWidth(cmbSpecification.Specification);
                decimal? thick = SpecificationHelper.GetWrittenThick(cmbSpecification.Specification);
                return (from item in items
                        orderby item.AddDate ascending, item.Product.Specification ascending
                        where (!width.HasValue || SpecificationHelper.GetWrittenWidth(item.Product.Specification) == width) &&
                              (!thick.HasValue || SpecificationHelper.GetWrittenThick(item.Product.Specification) == thick)
                        select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            ProductInventoryItem info = item as ProductInventoryItem;
            row.Tag = info;
            row.Cells["colAddDate"].Value = info.AddDate.ToString("yyyy-MM-dd");
            row.Cells["colCategoryID"].Value = info.Product.Category == null ? info.Product.CategoryID : info.Product.Category.Name;
            row.Cells["colModel"].Value = info.Product.Model;
            row.Cells["colThick"].Value = SpecificationHelper.GetWrittenThick(info.Product.Specification);
            row.Cells["colWidth"].Value = SpecificationHelper.GetWrittenWidth(info.Product.Specification);
            row.Cells["colOriginalWeight"].Value = info.OriginalWeight;
            row.Cells["colLength"].Value = info.OriginalLength.HasValue ? info.OriginalLength : info.Product.Length;
            row.Cells["colCustomer"].Value = info.Customer;
            row.Cells["colManufacturer"].Value = info.Manufacture;
            if (_AllSuppliers != null)
            {
                var s = _AllSuppliers.SingleOrDefault(it => it.ID == info.Supplier);
                row.Cells["colSupplier"].Value = s != null ? s.Name : null;
            }
            row.Cells["colPurchasePrice"].Value = info.PurchasePrice;
            row.Cells["colPurchaseTax"].Value = info.WithTax;
            row.Cells["colTransCost"].Value = info.TransCost;
            row.Cells["colOtherCost"].Value = info.OtherCost;
        }
        #endregion

        #region 事件处理程序
        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSupplierMaster frm = new FrmSupplierMaster();
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
