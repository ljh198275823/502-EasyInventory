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

        #region 私有方法
        private void InitCmbBrand()
        {
            cmbBrand.Items.Clear();
            List<Product> _AllProducts = new ProductBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            if (_AllProducts != null && _AllProducts.Count > 0)
            {
                cmbBrand.Items.Add(string.Empty);
                var items = (from p in _AllProducts
                             where !string.IsNullOrEmpty(p.Brand)
                             orderby p.Brand ascending
                             select p.Brand).Distinct();
                foreach (var item in items)
                {
                    cmbBrand.Items.Add(item);
                }
            }
        }
        #endregion

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (txtCategory .Tag ==null )
            {
                MessageBox.Show("产品类别没有指定");
                return false;
            }
            if (string.IsNullOrEmpty(cmbSpecification.Text))
            {
                MessageBox.Show("没有指定规格");
                return false;
            }
            if (this.txtOriginalWeight.DecimalValue <= 0)
            {
                MessageBox.Show("原材料的入库重量不正确");
                return false;
            }
            if (this.txtOriginalLength.DecimalValue <= 0)
            {
                MessageBox.Show("原材料的入库长度不正确");
                return false;
            }
            //if (txtOriginalLength.DecimalValue < txtLength.DecimalValue)
            //{
            //    MessageBox.Show("剩余长度大于入库长度");
            //    return false;
            //}
            //if (txtOriginalWeight.DecimalValue < txtWeight.DecimalValue)
            //{
            //    MessageBox.Show("剩余重量大于入库重量");
            //    return false;
            //}
            if (string.IsNullOrEmpty (txtSupplier .Text ))
            {
                MessageBox.Show("没有指定供货商");
                return false;
            }
            if (string.IsNullOrEmpty(cmbBrand .Text ))
            {
                MessageBox.Show("没有输入厂商");
                cmbBrand.Focus();
                return false;
            }
            return true;
        }

        protected override void InitControls()
        {
            this.dtStorageDateTime.Value = DateTime.Today;
            InitCmbBrand();
            cmbSpecification.Init();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            this.btnOk.Enabled = Operator.Current.Permit(Permission.ProductInventory, PermissionActions.Edit);
        }

        protected override void ItemShowing()
        {
            ProductInventoryItem item = UpdatingItem as ProductInventoryItem;
            dtStorageDateTime.Value = item.AddDate;
            txtWareHouse.Text = item.WareHouse.Name;
            txtWareHouse.Tag = item.WareHouse;
            txtCategory.Text = item.Product.Category.Name;
            txtCategory.Tag = item.Product.Category;
            cmbSpecification.Text = item.Product.Specification;
            txtOriginalWeight.DecimalValue = item.OriginalWeight.Trim ();
            txtOriginalLength.DecimalValue = item.OriginalLength.Trim ();
            //txtLength.DecimalValue = item.Length.Trim();
            //txtWeight.DecimalValue = item.Weight.Trim();
            txtPrice.DecimalValue = item.Price.Trim();
            txtSupplier.Text = item.SupplierID;
            cmbBrand.Text = item.Manufacture;
            txtSerialNumber.Text = item.SerialNumber;
            txtMemo.Text = item.Memo;

            dtStorageDateTime.Enabled = item.CanEdit;
            lnkCategory.Enabled = item.CanEdit;
            cmbSpecification.Enabled = item.CanEdit;
            txtOriginalLength.Enabled = item.CanEdit;
            txtOriginalWeight.Enabled = item.CanEdit;
            //txtLength.Enabled = item.CanEdit;
            //txtWeight.Enabled = item.CanEdit;
            txtPrice.Enabled = item.CanEdit;
            lnkSupplier.Enabled = item.CanEdit;
            cmbBrand.Enabled = item.CanEdit;
            txtSerialNumber.Enabled = item.CanEdit;
        }

        protected override object GetItemFromInput()
        {
            ProductInventoryItem item = UpdatingItem as ProductInventoryItem;
            if (UpdatingItem == null)
            {
                item = new ProductInventoryItem();
                item.ID = Guid.NewGuid();
            }
            Product p = new ProductBLL(AppSettings.Current.ConnStr).Create((txtCategory.Tag as ProductCategory).ID, StringHelper.ToDBC(cmbSpecification.Text).Trim());
            if (p == null) throw new Exception("创建相关产品信息失败");
            item.Product = p;
            item.ProductID = p.ID;
            item.AddDate = dtStorageDateTime.Value;
            item.WareHouse = txtWareHouse.Tag as WareHouse;
            item.WareHouseID = item.WareHouse.ID;
            item.Model = "原材料";
            item.OriginalWeight = txtOriginalWeight.DecimalValue;
            item.OriginalLength = txtOriginalLength.DecimalValue;
            item.Weight = txtOriginalWeight.DecimalValue;
            item.Length = txtOriginalLength.DecimalValue;
            item.Price = txtPrice.DecimalValue;
            item.Unit = "卷";
            item.Count = 1;
            item.SupplierID = txtSupplier.Text;
            item.Manufacture = cmbBrand.Text;
            item.SerialNumber = txtSerialNumber.Text;
            item.Memo = txtMemo.Text;
            item.Operator = Operator.Current.Name;
            return item;
        }

        protected override CommandResult AddItem(object item)
        {
            return (new ProductInventoryItemBLL(AppSettings.Current.ConnStr)).Add(item as ProductInventoryItem);
        }

        protected override CommandResult UpdateItem(object item)
        {
            return (new ProductInventoryItemBLL(AppSettings.Current.ConnStr)).Update (item as ProductInventoryItem);
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

        private void txtCategory_DoubleClick(object sender, EventArgs e)
        {
            ProductInventoryItem item = UpdatingItem as ProductInventoryItem;
            if (item == null || item.CanEdit)
            {
                txtCategory.Text = string.Empty;
                txtCategory.Tag = null;
            }
        }

        private void lnkSupplier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Purchase.FrmSupplierMaster frm = new Purchase.FrmSupplierMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtSupplier.Text = (frm.SelectedItem as CompanyInfo).Name;
            }
        }

        private void txtSupplier_DoubleClick(object sender, EventArgs e)
        {
            ProductInventoryItem item = UpdatingItem as ProductInventoryItem;
            if (item == null || item.CanEdit)
            {
                txtSupplier.Text = string.Empty;
            }
        }
        #endregion

        private void txtOriginalWeight_TextChanged(object sender, EventArgs e)
        {
            //if (txtWeight.DecimalValue == 0) txtWeight.DecimalValue = txtOriginalWeight.DecimalValue;
        }

        private void txtOriginalLength_TextChanged(object sender, EventArgs e)
        {
            //if (txtLength.DecimalValue == 0) txtWeight.DecimalValue = txtOriginalLength.DecimalValue;
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

        private void txtWareHouse_DoubleClick(object sender, EventArgs e)
        {
            ProductInventoryItem item = UpdatingItem as ProductInventoryItem;
            if (item == null || item.CanEdit)
            {
                txtWareHouse.Text = string.Empty;
                txtWareHouse.Tag = null;
            }
        }
    }
}
