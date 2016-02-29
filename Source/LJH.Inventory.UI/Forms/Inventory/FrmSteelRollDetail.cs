using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;
using LJH.Inventory.UI.Controls;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;
using LJH.GeneralLibrary;
using LJH.Inventory.UI.Forms.General;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmSteelRollDetail : FrmDetailBase
    {
        public FrmSteelRollDetail()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (txtCategory.Tag == null)
            {
                MessageBox.Show("产品类别没有指定");
                return false;
            }
            if (string.IsNullOrEmpty(cmbSpecification.Specification))
            {
                MessageBox.Show("没有指定规格");
                return false;
            }
            if (SpecificationHelper.GetWrittenThick(cmbSpecification.Specification) == null || SpecificationHelper.GetWrittenWidth(cmbSpecification.Specification) == null)
            {
                MessageBox.Show("规格设置不正确,  规格格式为 \"厚度*宽度\" ");
                return false;
            }
            if (this.txtWeight.DecimalValue <= 0)
            {
                MessageBox.Show("原材料的剩余重量不正确");
                return false;
            }
            if (this.txtLength.DecimalValue < 0)
            {
                MessageBox.Show("原材料的剩余长度不正确");
                return false;
            }
            if (txtOriginalLength.DecimalValue < txtLength.DecimalValue)
            {
                MessageBox.Show("剩余长度大于入库长度");
                return false;
            }
            if (txtOriginalWeight.DecimalValue < txtWeight.DecimalValue)
            {
                MessageBox.Show("剩余重量大于入库重量");
                return false;
            }
            //if (string.IsNullOrEmpty(txtCustomer.Text))
            //{
            //    MessageBox.Show("没有指定客户");
            //    return false;
            //}
            //if (txtSupplier.Tag == null)
            //{
            //    MessageBox.Show("没有指定供货商");
            //    return false;
            //}
            //if (string.IsNullOrEmpty(cmbBrand.Text))
            //{
            //    MessageBox.Show("没有输入厂商");
            //    cmbBrand.Focus();
            //    return false;
            //}
            return true;
        }

        protected override void InitControls()
        {
            this.dtStorageDateTime.Value = DateTime.Now;
            if (IsAdding)
            {
                if (UserSettings.Current != null && !string.IsNullOrEmpty(UserSettings.Current.DefaultWarehouse))
                {
                    List<WareHouse> ws = new WareHouseBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
                    var w = ws.FirstOrDefault(it => it.Name == UserSettings .Current .DefaultWarehouse );
                    if (w != null)
                    {
                        txtWareHouse.Text = w.Name;
                        txtWareHouse.Tag = w;
                    }
                }
                if (UserSettings.Current != null && !string.IsNullOrEmpty(UserSettings.Current.DefaultProductCategory))
                {
                    List<ProductCategory> cs = new ProductCategoryBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
                    var c = cs.FirstOrDefault(it => it.Name ==UserSettings .Current .DefaultProductCategory );
                    if (c != null)
                    {
                        txtCategory.Text = c.Name;
                        txtCategory.Tag = c;
                    }
                }
                if (UserSettings.Current != null) txtCustomer.Text = UserSettings.Current.DefaultCustomer;
            }
            cmbSpecification.Init();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            this.btnOk.Enabled = !IsForView && Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Edit);
        }

        protected override void ItemShowing()
        {
            ProductInventoryItem item = UpdatingItem as ProductInventoryItem;
            dtStorageDateTime.Value = item.AddDate;
            txtWareHouse.Text = item.WareHouse.Name;
            txtWareHouse.Tag = item.WareHouse;
            txtCategory.Text = item.Product.Category.Name;
            txtCategory.Tag = item.Product.Category;
            cmbSpecification.Specification = item.Product.Specification;
            txtOriginalWeight.DecimalValue = item.OriginalWeight.Value;
            if (item.OriginalLength.HasValue) txtOriginalLength.DecimalValue = item.OriginalLength.Value;
            txtLength.DecimalValue = item.Length.Value;
            if (item.Length.HasValue) txtLength.DecimalValue = item.Length.Value;
            txtCustomer.Text = item.Customer;
            if (!string.IsNullOrEmpty(item.Supplier))
            {
                CompanyInfo s = new CompanyBLL(AppSettings.Current.ConnStr).GetByID(item.Supplier).QueryObject;
                txtSupplier.Text = s != null ? s.Name : null;
                txtSupplier.Tag = s;
            }
            cmbBrand.Text = item.Manufacture;
            txtSerialNumber.Text = item.SerialNumber;
            if (item.PurchasePrice.HasValue) txtPurchasePrice.DecimalValue = item.PurchasePrice.Value;
            rdWithTax.Checked = item.WithTax.HasValue && item.WithTax.Value;
            rdWithoutTax.Checked = item.WithTax.HasValue && !item.WithTax.Value;
            if (item.TransCost.HasValue) txtTransCost.DecimalValue = item.TransCost.Value;
            chkTransCostPrepay.Checked = item.TransCostPrepay.HasValue && item.TransCostPrepay.Value;
            if (item.OtherCost.HasValue) txtOtherCost.DecimalValue = item.OtherCost.Value;
            chkOtherCostPrepay.Checked = item.OtherCostPrepay.HasValue && item.OtherCostPrepay.Value;
            txtPosition.Text = item.Position;
            txtMemo.Text = item.Memo;
            btnOk.Enabled = btnOk.Enabled && item.CanEdit;
        }

        protected override object GetItemFromInput()
        {
            ProductInventoryItem item = UpdatingItem as ProductInventoryItem;
            if (UpdatingItem == null)
            {
                item = new ProductInventoryItem();
                item.ID = Guid.NewGuid();
            }
            Product p = new ProductBLL(AppSettings.Current.ConnStr).Create((txtCategory.Tag as ProductCategory).ID, StringHelper.ToDBC(cmbSpecification.Specification).Trim(), "原材料", 7.85m);
            if (p == null) throw new Exception("创建相关产品信息失败");
            item.Product = p;
            item.ProductID = p.ID;
            item.Model = p.Model;
            item.AddDate = dtStorageDateTime.Value;
            item.WareHouse = txtWareHouse.Tag as WareHouse;
            item.WareHouseID = item.WareHouse.ID;
            item.OriginalThick = SpecificationHelper.GetWrittenThick(p.Specification);
            if (txtOriginalLength.DecimalValue > 0) item.OriginalLength = txtOriginalLength.DecimalValue;
            item.OriginalWeight = txtOriginalWeight.DecimalValue;
            if (txtLength.DecimalValue > 0) item.Length = txtLength.DecimalValue;
            item.Weight = txtWeight.DecimalValue;
            item.Unit = "卷";
            item.Count = 1;
            item.State = ProductInventoryState.Inventory;
            item.Customer = txtCustomer.Text;
            if (txtSupplier.Tag != null) item.Supplier = (txtSupplier.Tag as CompanyInfo).ID;
            item.Manufacture = cmbBrand.Text;
            item.SerialNumber = txtSerialNumber.Text;
            item.PurchasePrice = txtPurchasePrice.DecimalValue > 0 ? (decimal?)txtPurchasePrice.DecimalValue : null;
            if (rdWithTax.Checked) item.WithTax = true;
            if (rdWithoutTax.Checked) item.WithTax = false;
            item.TransCost = txtTransCost.DecimalValue > 0 ? (decimal?)txtTransCost.DecimalValue : null;
            item.TransCostPrepay = chkTransCostPrepay.Checked;
            item.OtherCost = txtOtherCost.DecimalValue > 0 ? (decimal?)txtOtherCost.DecimalValue : null;
            item.OtherCostPrepay = chkOtherCostPrepay.Checked;
            item.Position = txtPosition.Text;
            item.Memo = txtMemo.Text;
            item.Operator = Operator.Current.Name;
            return item;
        }

        protected override CommandResult AddItem(object item)
        {
            return (new SteelRollBLL(AppSettings.Current.ConnStr)).Add(item as ProductInventoryItem);
        }

        protected override CommandResult UpdateItem(object item)
        {
            return (new SteelRollBLL(AppSettings.Current.ConnStr)).Update(item as ProductInventoryItem);
        }
        #endregion

        #region 事件处理程序
        private void lnkCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmProductCategoryMaster frm = new FrmProductCategoryMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var c = frm.SelectedItem as ProductCategory;
                txtCategory.Text = c != null ? c.Name : string.Empty;
                txtCategory.Tag = c;
            }
        }

        private void lnkSupplier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Purchase.FrmSupplierMaster frm = new Purchase.FrmSupplierMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CompanyInfo s=frm.SelectedItem as CompanyInfo;
                txtSupplier.Text = s.Name;
                txtSupplier.Tag = s;
            }
        }

        private void txtSupplier_DoubleClick(object sender, EventArgs e)
        {
            txtSupplier.Text = string.Empty;
            txtSupplier.Tag = null;
        }

        private void lnkWareHouse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmWareHouseMaster frm = new FrmWareHouseMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtWareHouse.Text = (frm.SelectedItem as WareHouse).Name;
                txtWareHouse.Tag = frm.SelectedItem;
            }
        }

        private void lnkBrand_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRelatedCompanyMaster frm = new FrmRelatedCompanyMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                cmbBrand.Text = (frm.SelectedItem as CompanyInfo).Name;
            }
        }

        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sale.FrmCustomerMaster frm = new Sale.FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCustomer.Text = (frm.SelectedItem as CompanyInfo).Name;
            }
        }

        private void txtOriginalWeight_TextChanged(object sender, EventArgs e)
        {
            txtWeight.DecimalValue = txtOriginalWeight.DecimalValue;
        }

        private void txtOriginalLength_TextChanged(object sender, EventArgs e)
        {
            txtLength.DecimalValue = txtOriginalLength.DecimalValue;
        }
        #endregion
    }
}
