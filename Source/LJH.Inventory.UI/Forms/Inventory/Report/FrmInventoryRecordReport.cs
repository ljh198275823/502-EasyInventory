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

        #region 重写基类方法
        protected override void Init()
        {
            ucDateTimeInterval1.ShowTime = false;
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
            base.Init();
        }

        protected override List<object> GetDataSource()
        {
            StackInRecordSearchCondition con = new StackInRecordSearchCondition();
            con.LastActiveDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            con.States = new List<SheetState>();
            con.States.Add(SheetState.Inventory);
            con.SheetTypes = new List<StackInSheetType>();
            con.SheetTypes.Add(StackInSheetType.InventorySheet);
            if (txtCustomer.Tag != null) con.SupplierID = (txtCustomer.Tag as CompanyInfo).ID;
            if (txtProductCategory.Tag != null) con.CategoryID = (txtProductCategory.Tag as ProductCategory).ID;
            if (txtProduct.Tag != null) con.ProductID = (txtProduct.Tag as Product).ID;
            List<StackInRecord> items = (new StackInSheetBLL(AppSettings.Current.ConnStr)).GetInventoryRecords(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                return (from item in items orderby item.LastActiveDate ascending, item.ProductID ascending select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            StackInRecord sir = item as StackInRecord;
            row.Cells["colDeliveryDate"].Value = sir.LastActiveDate.ToString("yyyy-MM-dd");
            row.Cells["colSheetNo"].Value = sir.SheetNo;
            row.Cells["colCustomerName"].Value = sir.Supplier.Name;
            row.Cells["colOrderID"].Value = sir.PurchaseOrder;
            row.Cells["colProductID"].Value = sir.ProductID;
            row.Cells["colProductName"].Value = sir.Product.Name;
            row.Cells["colCategoryID"].Value = sir.Product.Category.Name;
            row.Cells["colPrice"].Value = sir.Price;
            row.Cells["colCount"].Value = sir.Count;
            row.Cells["colAmount"].Value = sir.Amount.Trim();
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

        private void lnkProduct_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmProductMaster frm = new FrmProductMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Product p = frm.SelectedItem as Product;
                txtProduct.Text = p != null ? p.Name : string.Empty;
                txtProduct.Tag = p;
            }
        }

        private void txtProduct_DoubleClick(object sender, EventArgs e)
        {
            txtProduct.Text = string.Empty;
            txtProduct.Tag = null;
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
