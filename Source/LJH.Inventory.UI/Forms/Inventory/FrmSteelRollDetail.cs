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
            if (string.IsNullOrEmpty(cmbSpecification.Text))
            {
                MessageBox.Show("没有指定规格");
                return false;
            }
            if (SpecificationHelper.GetWrittenThick(cmbSpecification.Text) == null || SpecificationHelper.GetWrittenWidth(cmbSpecification.Text) == null)
            {
                MessageBox.Show("规格设置不正确,  规格格式为 \"厚度*宽度\" ");
                return false;
            }
            if (this.txtWeight.DecimalValue <= 0)
            {
                MessageBox.Show("原材料的剩余重量不正确");
                return false;
            }
            if (this.txtLength.DecimalValue <= 0)
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
            if (string.IsNullOrEmpty(txtCustomer.Text))
            {
                MessageBox.Show("没有指定客户");
                return false;
            }
            if (string.IsNullOrEmpty(txtSupplier.Text))
            {
                MessageBox.Show("没有指定供货商");
                return false;
            }
            if (string.IsNullOrEmpty(cmbBrand.Text))
            {
                MessageBox.Show("没有输入厂商");
                cmbBrand.Focus();
                return false;
            }
            return true;
        }

        protected override void InitControls()
        {
            this.dtStorageDateTime.Value = DateTime.Now;
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
            cmbSpecification.Text = item.Product.Specification;
            txtOriginalWeight.DecimalValue = item.OriginalWeight.Value;
            txtOriginalLength.DecimalValue = item.OriginalLength.Value;
            txtLength.DecimalValue = item.Length.Value;
            txtWeight.DecimalValue = item.Weight.Value;
            txtCustomer.Text = item.Customer;
            txtSupplier.Text = item.Supplier;
            cmbBrand.Text = item.Manufacture;
            txtSerialNumber.Text = item.SerialNumber;
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
            Product p = new ProductBLL(AppSettings.Current.ConnStr).Create((txtCategory.Tag as ProductCategory).ID, StringHelper.ToDBC(cmbSpecification.Text).Trim(), "原材料", 7.85m);
            if (p == null) throw new Exception("创建相关产品信息失败");
            item.Product = p;
            item.ProductID = p.ID;
            item.Model = p.Model;
            item.AddDate = dtStorageDateTime.Value;
            item.WareHouse = txtWareHouse.Tag as WareHouse;
            item.WareHouseID = item.WareHouse.ID;
            item.OriginalWeight = txtOriginalWeight.DecimalValue;
            item.OriginalLength = txtOriginalLength.DecimalValue;
            item.Weight = txtWeight.DecimalValue;
            item.Length = txtLength.DecimalValue;
            item.Unit = "卷";
            item.Count = 1;
            item.State = ProductInventoryState.Inventory;
            item.Customer = txtCustomer.Text;
            item.Supplier = txtSupplier.Text;
            item.Manufacture = cmbBrand.Text;
            item.SerialNumber = txtSerialNumber.Text;
            item.Memo = txtMemo.Text;
            item.Operator = Operator.Current.Name;
            item.OriginalThick = item.CalThick(p.Specification, item.OriginalWeight.Value, item.OriginalLength.Value, p.Density.Value);//计算实际厚度
            //item.RealThick = item.OriginalThick;
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
                txtSupplier.Text = (frm.SelectedItem as CompanyInfo).Name;
            }
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
            Purchase.FrmSupplierMaster frm = new Purchase.FrmSupplierMaster();
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
            if (IsAdding) txtWeight.DecimalValue = txtOriginalWeight.DecimalValue;
        }

        private void txtOriginalLength_TextChanged(object sender, EventArgs e)
        {
            if (IsAdding) txtLength.DecimalValue = txtOriginalLength.DecimalValue;
        }
        #endregion
    }
}
