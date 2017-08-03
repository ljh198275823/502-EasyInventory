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
    public partial class Frm其它产品入库 : Form
    {
        public Frm其它产品入库()
        {
            InitializeComponent();
        }

        #region 公共属性
        public Product Product { get; set; }

        public WareHouse WareHouse { get; set; }

        public ProductInventoryItem SteelRollSlice { get; set; }

        public bool IsForView { get; set; }
        #endregion

        public event EventHandler<ItemAddedEventArgs> ItemAdded;
        public event EventHandler<ItemUpdatedEventArgs> ItemUpdated;

        #region 私有方法
        private void InitControls()
        {
            cmbSpecification.Init(new List<string> { ProductModel.其它产品 });
            dtStorageDateTime.Value = DateTime.Now;
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
            if (UserSettings.Current != null)
            {
                txtCustomer.Text = UserSettings.Current.DefaultCustomer;
                cmbBrand.Text = UserSettings.Current.默认厂家;
                if (!string.IsNullOrEmpty(UserSettings.Current.默认供应商))
                {
                    var sp = new CompanyBLL(AppSettings.Current.ConnStr).GetByID(UserSettings.Current.默认供应商).QueryObject;
                    txtSupplier.Text = sp != null ? sp.Name : null;
                    txtSupplier.Tag = sp;
                }
            }

            if (Product != null) ShowProduct(Product);
            if (WareHouse != null)
            {
                txtWareHouse.Text = WareHouse.Name;
                txtWareHouse.Tag = WareHouse;
            }
            btnOk.Enabled = Operator.Current.Permit(Permission.其它产品, PermissionActions.Edit);
            pnlCost.Visible = Operator.Current.Permit(Permission.其它产品, PermissionActions.设置入库单价);
            if (!pnlCost.Visible) this.Height -= pnlCost.Height;
        }

        private void ShowProduct(Product product)
        {
            cmbSpecification.Text = product.Specification;
            txtCategory.Text = product.Category.Name;
            txtCategory.Tag = product.Category;
            txtLength.DecimalValue = product.Length.HasValue ? product.Length.Value : 0;
        }

        private Product CreateProduct()
        {
            return new ProductBLL(AppSettings.Current.ConnStr).Create(
                             (txtCategory.Tag as ProductCategory).ID,
                             StringHelper.ToDBC(cmbSpecification.Text).Trim(),
                             ProductModel.其它产品,
                             null,
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
            if (string.IsNullOrEmpty(cmbSpecification.Text))
            {
                MessageBox.Show("没有指定规格");
                return false;
            }
            if (txtWareHouse.Tag == null)
            {
                MessageBox.Show("没有选择仓库");
                txtWareHouse.Focus();
                return false;
            }
            if (txtCount.DecimalValue == 0)
            {
                MessageBox.Show("库存数量没有填写");
                txtCount.Focus();
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

        private void ShowItem(ProductInventoryItem item)
        {
            dtStorageDateTime.Value = item.AddDate;
            var ws = new WareHouseBLL(AppSettings.Current.ConnStr).GetByID(item.WareHouseID).QueryObject;
            txtWareHouse.Text = ws != null ? ws.Name : string.Empty;
            txtWareHouse.Tag = ws;
            txtCategory.Text = item.Product.Category.Name;
            txtCategory.Tag = item.Product.Category;
            cmbSpecification.Text = item.Product.Specification;
            if (item.Weight.HasValue) txtWeight.DecimalValue = item.Weight.Value;
            if (item.Product.Length.HasValue) txtLength.DecimalValue = item.Product.Length.Value;
            txtCount.DecimalValue = item.OriginalCount.HasValue ? item.OriginalCount.Value : item.Count;
            txtCustomer.Text = item.Customer;
            CompanyInfo s = null;
            if (!string.IsNullOrEmpty(item.Supplier)) s = new CompanyBLL(AppSettings.Current.ConnStr).GetByID(item.Supplier).QueryObject;
            txtSupplier.Text = s != null ? s.Name : null;
            txtSupplier.Tag = s;
            cmbBrand.Text = item.Manufacture;

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
            txtCarPlate.Text = item.Carplate;
            txtPurchaseID.Text = item.PurchaseID;
            txtMemo.Text = item.Memo;
            if (!IsForView)
            {
                if (item.SourceID != null && item.SourceRoll != null) btnOk.Enabled = false;
                else btnOk.Enabled = item.Count == item.OriginalCount; //出过货或拆过包不能修改
            }
            else
            {
                btnOk.Enabled = false;
            }
        }
        #endregion

        #region 事件处理程序
        private void FrmSteelRollSliceDetail_Load(object sender, EventArgs e)
        {
            InitControls();
            if (SteelRollSlice != null) ShowItem(SteelRollSlice);
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

            bool isAdding = false;
            if (SteelRollSlice == null)
            {
                SteelRollSlice = new ProductInventoryItem();
                SteelRollSlice.ID = Guid.NewGuid();
                isAdding = true;
            }
            SteelRollSlice.Product = p;
            SteelRollSlice.ProductID = p.ID;
            SteelRollSlice.Model = p.Model;
            SteelRollSlice.AddDate = dtStorageDateTime.Value;
            SteelRollSlice.WareHouseID = (txtWareHouse.Tag as WareHouse).ID;
            SteelRollSlice.OriginalWeight = txtWeight.DecimalValue;
            SteelRollSlice.OriginalCount = txtCount.DecimalValue;
            SteelRollSlice.Weight = txtWeight.DecimalValue;
            SteelRollSlice.Count = txtCount.DecimalValue;
            SteelRollSlice.Unit = "件";
            SteelRollSlice.State = ProductInventoryState.Inventory;
            SteelRollSlice.Customer = txtCustomer.Text;
            if (txtSupplier.Tag != null) SteelRollSlice.Supplier = (txtSupplier.Tag as CompanyInfo).ID;
            SteelRollSlice.Manufacture = cmbBrand.Text;
            SteelRollSlice.SetCost(new CostItem() { Name = CostItem.入库单价, Price = txtPurchasePrice.DecimalValue, WithTax = rdWithTax_入库单价.Checked });
            SteelRollSlice.SetCost(new CostItem() { Name = CostItem.运费, Price = txtTransCost.DecimalValue, WithTax = rdWithTax_运费.Checked, Prepay = chkTransCostPrepay.Checked });
            SteelRollSlice.SetCost(new CostItem() { Name = CostItem.其它费用, Price = txtOtherCost.DecimalValue, WithTax = rdWithTax_其它费用.Checked, Prepay = chkOtherCostPrepay.Checked });
            SteelRollSlice.Position = txtPosition.Text;
            SteelRollSlice.PurchaseID = txtPurchaseID.Text;
            SteelRollSlice.Carplate = txtCarPlate.Text;
            SteelRollSlice.Memo = txtMemo.Text;
            SteelRollSlice.Operator = Operator.Current.Name;
            CommandResult ret = null;
            if (isAdding) ret = new OtherProductInventoryBLL(AppSettings.Current.ConnStr).Add(SteelRollSlice);
            else ret = new OtherProductInventoryBLL(AppSettings.Current.ConnStr).Update(SteelRollSlice);
            if (ret.Result == ResultCode.Successful)
            {
                if (isAdding) //新增
                {
                    cmbSpecification.Text = string.Empty;
                    txtWeight.DecimalValue = 0;
                    if (txtLength.DecimalValue > 0) txtLength.DecimalValue = 0;
                    txtCount.DecimalValue = 0;
                    cmbSpecification.Focus();
                    if (this.ItemAdded != null) this.ItemAdded(this, new ItemAddedEventArgs(SteelRollSlice));
                    SteelRollSlice = null; 
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show(ret.Message);
            }
        }
        #endregion
    }
}
