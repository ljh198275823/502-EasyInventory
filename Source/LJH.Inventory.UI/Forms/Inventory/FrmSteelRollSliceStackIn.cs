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
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;
using LJH.Inventory.UI.Forms.General;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmSteelRollSliceStackIn : Form
    {
        public FrmSteelRollSliceStackIn()
        {
            InitializeComponent();
        }

        #region 公共属性
        public Product Product { get; set; }

        public WareHouse WareHouse { get; set; }

        public ProductInventoryItem SteelRollSlice { get; set; }

        public bool IsForView { get; set; }
        #endregion

        #region 私有方法
        private void InitControls()
        {
            cmbSpecification.Init();
            dtStorageDateTime.Value = DateTime.Now;
            txtMaterial.Init();
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

            if (Product != null) ShowProduct(Product);
            if (WareHouse != null)
            {
                txtWareHouse.Text = WareHouse.Name;
                txtWareHouse.Tag = WareHouse;
            }

            btnOk.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Edit);
        }

        private void ShowProduct(Product product)
        {
            cmbSpecification.Specification = product.Specification;
            txtCategory.Text = product.Category.Name;
            txtCategory.Tag = product.Category;
            rd开平.Checked = product.Model == rd开平.Text;
            rd开卷.Checked = product.Model == rd开卷.Text;
            rd开吨.Checked = product.Model == rd开吨.Text;
            txtLength.DecimalValue = product.Length.HasValue ? product.Length.Value : 0;
            txtWeight.DecimalValue = product.Weight.HasValue ? product.Weight.Value : 0;
            decimal? thick = SpecificationHelper.GetWrittenThick(product.Specification);
        }

        private Product CreateProduct()
        {
            string sliceTo = null;
            if (rd开平.Checked) sliceTo = rd开平.Text;
            else if (rd开卷.Checked) sliceTo = rd开卷.Text;
            else if (rd开吨.Checked) sliceTo = rd开吨.Text;
            decimal? weight = null;
            if (rd单件重.Checked) weight = txtWeight.DecimalValue != 0 ? (decimal?)txtWeight.DecimalValue : null;
            return new ProductBLL(AppSettings.Current.ConnStr).Create(
                             (txtCategory.Tag as ProductCategory).ID,
                             StringHelper.ToDBC(cmbSpecification.Specification).Trim(),
                             sliceTo,
                             weight,
                             txtLength.DecimalValue != 0 ? (decimal?)txtLength.DecimalValue : null,
                             7.85m);

        }

        private bool CheckInput()
        {
            if (txtCategory.Tag == null)
            {
                MessageBox.Show("没有选择类别");
                return false;
            }
            if (string.IsNullOrEmpty(cmbSpecification.Specification))
            {
                MessageBox.Show("没有指定规格");
                return false;
            }
            if (!rd开平.Checked && !rd开卷.Checked && !rd开吨.Checked)
            {
                MessageBox.Show("没有指定加工类型");
                return false;
            }
            if (SpecificationHelper.GetWrittenThick(cmbSpecification.Specification) == null || SpecificationHelper.GetWrittenWidth(cmbSpecification.Specification) == null)
            {
                MessageBox.Show("规格设置不正确,  规格格式为 \"厚度*宽度\" ");
                return false;
            }
            if (txtWareHouse.Tag == null)
            {
                MessageBox.Show("没有选择仓库");
                txtWareHouse.Focus();
                return false;
            }
            if (txtWeight.DecimalValue <= 0)
            {
                MessageBox.Show("没有设置重量");
                return false;
            }
            if (txtWeight.DecimalValue > 0 && !rd总重.Checked && !rd单件重.Checked)
            {
                MessageBox.Show("重量没有指定是总重还是单件重量");
                return false;
            }
            if (txtCount.DecimalValue == 0)
            {
                MessageBox.Show("库存数量没有填写");
                txtCount.Focus();
                return false;
            }
            if (txtPurchasePrice.DecimalValue > 0 && !rdWithoutTax.Checked && !rdWithTax.Checked)
            {
                MessageBox.Show("没有指定价格是否含税");
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
            return true;
        }

        private void ShowItem(ProductInventoryItem item)
        {
            dtStorageDateTime.Value = item.AddDate;
            var ws = new WareHouseBLL(AppSettings.Current.ConnStr).GetByID(item.WareHouseID).QueryObject;
            txtWareHouse.Text = ws != null ? ws.Name : string.Empty;
            txtWareHouse.Tag = ws;
            txtCategory.Text = item.Product.Category.Name;
            txtCategory.Tag = item.Product.Category;
            cmbSpecification.Specification = item.Product.Specification;
            if (item.Product.Model == rd开平.Text) rd开平.Checked = true;
            if (item.Product.Model == rd开卷.Text) rd开卷.Checked = true;
            if (item.Product.Model == rd开吨.Text) rd开吨.Checked = true;
            if (item.Product.Weight.HasValue)
            {
                txtWeight.DecimalValue = item.Product.Weight.Value;
                rd单件重.Checked = true;
            }
            else
            {
                txtWeight.DecimalValue = item.OriginalWeight.Value;
                rd总重.Checked = true;
            }
            if (item.Product.Length.HasValue) txtLength.DecimalValue = item.Product.Length.Value;
            if (item.OriginalCount.HasValue) txtCount.DecimalValue = item.OriginalCount.Value;
            txtCustomer.Text = item.Customer;
            if (!string.IsNullOrEmpty(item.Supplier))
            {
                CompanyInfo s = new CompanyBLL(AppSettings.Current.ConnStr).GetByID(item.Supplier).QueryObject;
                txtSupplier.Text = s != null ? s.Name : null;
                txtSupplier.Tag = s;
            }
            cmbBrand.Text = item.Manufacture;

            txtPurchasePrice.Visible = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.ShowPrice);
            txtTransCost.Visible = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.ShowPrice);
            txtOtherCost.Visible = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.ShowPrice);
            chkOtherCostPrepay.Visible = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.ShowPrice);
            chkTransCostPrepay.Visible = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.ShowPrice);
            panel2.Visible = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.ShowPrice);
            var ci = item.GetCost(CostItem.采购价);
            txtPurchasePrice.DecimalValue = ci != null ? ci.Price : 0;
            rdWithTax.Checked = ci != null && ci.WithTax;
            rdWithoutTax.Checked = !rdWithTax.Checked;
            ci = item.GetCost(CostItem.运费);
            txtTransCost.DecimalValue = ci != null ? ci.Price : 0;
            chkTransCostPrepay.Checked = ci != null && ci.Prepay;
            ci = item.GetCost(CostItem.其它费用);
            txtOtherCost.DecimalValue = ci != null ? ci.Price : 0;
            chkOtherCostPrepay.Checked = ci != null && ci.Prepay;

            txtPosition.Text = item.Position;
            txtCarPlate.Text = item.Carplate;
            txtMaterial.Text = item.Material;
            txtOrderID.Text = item.OrderID;
            txtMemo.Text = item.Memo;
            btnOk.Enabled = !IsForView;
        }
        #endregion

        #region 事件处理程序
        private void FrmSteelRollSliceDetail_Load(object sender, EventArgs e)
        {
            InitControls();
            if (SteelRollSlice != null) ShowItem(SteelRollSlice);
        }

        private void rdSliceType_CheckedChanged(object sender, EventArgs e)
        {
            rd总重.Checked = rd开平.Checked;
        }

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

        private void lnkWarehouse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmWareHouseMaster frm = new FrmWareHouseMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                WareHouse w = frm.SelectedItem as WareHouse;
                txtWareHouse.Text = w != null ? w.Name : string.Empty;
                txtWareHouse.Tag = w;
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

        private void lnkBrand_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRelatedCompanyMaster frm = new FrmRelatedCompanyMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                cmbBrand.Text = (frm.SelectedItem as CompanyInfo).Name;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;
            var p = CreateProduct();
            if (p == null)
            {
                MessageBox.Show("创建产品信息失败");
                return;
            }
            ProductInventoryItem item = new ProductInventoryItem();
            item.ID = Guid.NewGuid();
            item.Product = p;
            item.ProductID = p.ID;
            item.Model = p.Model;
            item.AddDate = dtStorageDateTime.Value;
            item.WareHouseID = (txtWareHouse.Tag as WareHouse).ID;
            item.OriginalWeight = rd总重.Checked ? txtWeight.DecimalValue : txtWeight.DecimalValue * txtCount.DecimalValue; //区分总重和单重
            item.OriginalCount = txtCount.DecimalValue;
            item.Weight = item.OriginalWeight;
            item.Unit = "件";
            item.Count = txtCount.DecimalValue;
            item.State = ProductInventoryState.Inventory;
            item.Customer = txtCustomer.Text;
            if (txtSupplier.Tag != null) item.Supplier = (txtSupplier.Tag as CompanyInfo).ID;
            item.Manufacture = cmbBrand.Text;
            item.SetCost(new CostItem() { Name = CostItem.采购价, Price = txtPurchasePrice.DecimalValue, WithTax = rdWithTax.Checked });
            item.SetCost(new CostItem() { Name = CostItem.运费, Price = txtTransCost.DecimalValue, WithTax = false, Prepay = chkTransCostPrepay.Checked });
            item.SetCost(new CostItem() { Name = CostItem.其它费用, Price = txtOtherCost.DecimalValue, WithTax = false, Prepay = chkOtherCostPrepay.Checked });
            item.Position = txtPosition.Text;
            item.Material = txtMaterial.Text;
            item.OrderID = txtOrderID.Text;
            item.Carplate = txtCarPlate.Text;
            item.Memo = txtMemo.Text;
            item.Operator = Operator.Current.Name;
            var ret = new SteelRollSliceBLL(AppSettings.Current.ConnStr).Add(item);
            if (ret.Result == ResultCode.Successful)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(ret.Message);
            }
        }
        #endregion
    }
}
