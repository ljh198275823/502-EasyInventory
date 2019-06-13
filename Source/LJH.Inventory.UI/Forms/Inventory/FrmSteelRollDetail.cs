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
            if (UpdatingItem  != null)
            {
                ProductInventoryItem item = UpdatingItem as ProductInventoryItem;
                var sr = new SteelRollBLL(AppSettings.Current.ConnStr).GetByID(item.ID).QueryObject;
                if (sr.Count == 0 || !sr.CanEdit)
                {
                    MessageBox.Show("其它操作员已经修改了此卷的状态，请刷新后再修改");
                    return false;
                }
            }
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
            //if (this.txtLength.DecimalValue <= 0)
            //{
            //    MessageBox.Show("原材料的剩余长度不正确");
            //    return false;
            //}
            //if (txtOriginalLength.DecimalValue < txtLength.DecimalValue)
            //{
            //    MessageBox.Show("剩余长度大于入库长度");
            //    return false;
            //}
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
            txtCarPlate.Init();
            txtMaterial.Init();
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
            txtWeight.DecimalValue = item.Weight.Value;
            txtCustomer.Text = item.Customer;
            txtSupplier.Text = item.Supplier;
            cmbBrand.Text = item.Manufacture;
            txtSerialNumber.Text = item.SerialNumber;
            txtCarPlate.Text = item.Carplate;
            txtMaterial.Text = item.Material;
            if (item.PurchasePrice.HasValue) txtPurchasePrice.DecimalValue = item.PurchasePrice.Value;
            if (item.TransCost.HasValue) txtTransCost.DecimalValue = item.TransCost.Value;
            if (item.OtherCost.HasValue) txtOtherCost.DecimalValue = item.OtherCost.Value;
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
            item.OriginalWeight = txtOriginalWeight.DecimalValue;
            //item.OriginalLength = item.CalLength(p.Specification, item.OriginalWeight.Value, p.Density.Value); // txtOriginalLength.DecimalValue;
            item.Weight = txtWeight.DecimalValue;
            //item.Length = item.CalLength(p.Specification, item.Weight.Value, p.Density.Value);  //txtLength.DecimalValue;
            item.Unit = "卷";
            item.Count = 1;
            item.State = ProductInventoryState.Inventory;
            item.Customer = txtCustomer.Text;
            item.Supplier = txtSupplier.Text;
            item.Manufacture = cmbBrand.Text;
            item.SerialNumber = txtSerialNumber.Text;
            item.Carplate = txtCarPlate.Text;
            item.Material = txtMaterial.Text;
            item.PurchasePrice = txtPurchasePrice.DecimalValue > 0 ? (decimal?)txtPurchasePrice.DecimalValue : null;
            item.TransCost = txtTransCost.DecimalValue > 0 ? (decimal?)txtTransCost.DecimalValue : null;
            item.OtherCost = txtOtherCost.DecimalValue > 0 ? (decimal?)txtOtherCost.DecimalValue : null;
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
