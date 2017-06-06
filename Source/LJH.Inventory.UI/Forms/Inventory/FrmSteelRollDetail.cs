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
            if (string.IsNullOrEmpty(txtCustomer.Text))
            {
                MessageBox.Show("没有指定客户");
                return false;
            }
            if (txtSupplier.Tag == null)
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
            if (string.IsNullOrEmpty(txtMaterial.Text) && UserSettings.Current.NeedMaterial)
            {
                MessageBox.Show("请输入产品材质");
                txtMaterial.Focus();
                return false;
            }
            if (txtPurchasePrice.DecimalValue > 0 && !rdWithoutTax__入库单价.Checked && !rdWithTax_入库单价.Checked)
            {
                MessageBox.Show("没有指定入库价格是否含税");
                return false;
            }
            if (txtTransCost.DecimalValue > 0 && !rdWithTax_运费.Checked && !rdWithoutTax__运费.Checked)
            {
                MessageBox.Show("没有指定运费是否含税");
                return false;
            }
            if (txtOtherCost.DecimalValue > 0 && !rdWithTax_其它费用.Checked && !rdWithoutTax__其它费用.Checked)
            {
                MessageBox.Show("没有指定其它费用是否含税");
                return false;
            }
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
                    var w = ws.FirstOrDefault(it => it.Name == UserSettings.Current.DefaultWarehouse);
                    if (w != null)
                    {
                        txtWareHouse.Text = w.Name;
                        txtWareHouse.Tag = w;
                    }
                }
                if (UserSettings.Current != null && !string.IsNullOrEmpty(UserSettings.Current.DefaultProductCategory))
                {
                    List<ProductCategory> cs = new ProductCategoryBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
                    var c = cs.FirstOrDefault(it => it.Name == UserSettings.Current.DefaultProductCategory);
                    if (c != null)
                    {
                        txtCategory.Text = c.Name;
                        txtCategory.Tag = c;
                    }
                }
                if (UserSettings.Current != null) txtCustomer.Text = UserSettings.Current.DefaultCustomer;
            }
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
            var ws = new WareHouseBLL(AppSettings.Current.ConnStr).GetByID(item.WareHouseID).QueryObject;
            txtWareHouse.Text = ws != null ? ws.Name : null;
            txtWareHouse.Tag = ws;
            txtCategory.Text = item.Product.Category.Name;
            txtCategory.Tag = item.Product.Category;
            cmbSpecification.Specification = item.Product.Specification;
            txtOriginalWeight.DecimalValue = item.OriginalWeight.Value;
            if (item.OriginalLength.HasValue) txtOriginalLength.DecimalValue = item.OriginalLength.Value;
            if (item.Weight.HasValue) txtWeight.DecimalValue = item.Weight.Value;
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

            pnlCost.Visible = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.ShowPrice);
            if (!pnlCost.Visible) this.Height -= pnlCost.Height;
            var ci = item.GetCost(CostItem.入库单价);
            txtPurchasePrice.DecimalValue = ci != null ? ci.Price : 0;
            rdWithTax_入库单价.Checked = ci != null && ci.WithTax;
            rdWithoutTax__入库单价.Checked = !rdWithTax_入库单价.Checked;
            ci = item.GetCost(CostItem.运费);
            txtTransCost.DecimalValue = ci != null ? ci.Price : 0;
            rdWithTax_运费.Checked = ci != null && ci.WithTax;
            rdWithoutTax__运费.Checked = !rdWithTax_运费.Checked;
            chkTransCostPrepay.Checked = ci != null && ci.Prepay;
            ci = item.GetCost(CostItem.其它费用);
            txtOtherCost.DecimalValue = ci != null ? ci.Price : 0;
            rdWithTax_其它费用.Checked = ci != null && ci.WithTax;
            rdWithoutTax__其它费用.Checked = !rdWithTax_其它费用.Checked;
            chkOtherCostPrepay.Checked = ci != null && ci.Prepay;

            txtPosition.Text = item.Position;
            txtMaterial.Text = item.Material;
            txtCarPlate.Text = item.Carplate;
            txtPurchaseID.Text = item.PurchaseID;
            txtMemo.Text = item.Memo;
            btnOk1.Enabled = btnOk1.Enabled && item.CanEdit && item.GetCost(CostItem.结算单价) == null;
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
            item.WareHouseID = (txtWareHouse.Tag as WareHouse).ID;
            item.OriginalWeight = txtOriginalWeight.DecimalValue;
            if (txtOriginalLength.DecimalValue > 0)
            {
                item.OriginalLength = txtOriginalLength.DecimalValue;
                item.OriginalThick = ProductInventoryItem.CalThick(SpecificationHelper.GetWrittenWidth(p.Specification).Value, item.OriginalWeight.Value, item.OriginalLength.Value, p.Density.Value); //指定长度时计算入库厚度
            }
            else
            {
                item.OriginalThick = SpecificationHelper.GetWrittenThick(p.Specification);
            }
            item.OriginalCount = 1;
            item.Weight = txtWeight.DecimalValue;
            if (txtLength.DecimalValue > 0) item.Length = txtLength.DecimalValue;
            item.Unit = "卷";
            item.Count = 1;
            item.State = ProductInventoryState.Inventory;
            item.Customer = txtCustomer.Text;
            if (txtSupplier.Tag != null) item.Supplier = (txtSupplier.Tag as CompanyInfo).ID;
            item.Manufacture = cmbBrand.Text;
            item.SerialNumber = txtSerialNumber.Text;
            item.SetCost(new CostItem() { Name = CostItem.入库单价, Price = txtPurchasePrice.DecimalValue, WithTax = rdWithTax_入库单价.Checked });
            item.SetCost(new CostItem() { Name = CostItem.运费, Price = txtTransCost.DecimalValue, WithTax = rdWithTax_运费.Checked, Prepay = chkTransCostPrepay.Checked });
            item.SetCost(new CostItem() { Name = CostItem.其它费用, Price = txtOtherCost.DecimalValue, WithTax = rdWithTax_其它费用.Checked, Prepay = chkOtherCostPrepay.Checked });
            item.Position = txtPosition.Text;
            item.Carplate = txtCarPlate.Text;
            item.Material = txtMaterial.Text;
            item.Memo = txtMemo.Text;
            item.PurchaseID = txtPurchaseID.Text;
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
                CompanyInfo s = frm.SelectedItem as CompanyInfo;
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

        private void btnOk1_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;
            object item = GetItemFromInput();
            CommandResult ret = null;
            if (IsAdding)
            {
                ret = AddItem(item);
                if (ret.Result == ResultCode.Successful)
                {
                    OnItemAdded(new ItemAddedEventArgs(item));
                    txtOriginalWeight.DecimalValue = 0;
                    txtWeight.DecimalValue = 0;
                    if (txtOriginalLength.DecimalValue > 0) txtOriginalLength.DecimalValue = 0;
                    if (txtLength.DecimalValue > 0) txtLength.DecimalValue = 0;
                    cmbSpecification.Specification = null;
                    IsAdding = true;
                    cmbSpecification.Focus();
                }
                else
                {
                    MessageBox.Show(ret.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ret = UpdateItem(item);
                if (ret.Result == ResultCode.Successful)
                {
                    OnItemUpdated(new ItemUpdatedEventArgs(item));
                    this.Close();
                }
                else
                {
                    MessageBox.Show(ret.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
