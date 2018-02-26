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
            if (txt运费.DecimalValue > 0 && !rdWithoutTax_运费.Checked && !rdWithTax_运费.Checked)
            {
                MessageBox.Show("没有指定运费是否含税");
                return false;
            }
            if (txt运费.DecimalValue > 0 && txtSupplier运费.Tag == null)
            {
                MessageBox.Show("没有指定运费供应商");
                return false;
            }
            return true;
        }

        protected override void InitControls()
        {
            base.InitControls();
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
            }
            cmbSpecification.Init();
            txtCarPlate.Init();
            txtMaterial.Init();
            pnlCost.Visible = Operator.Current.Permit(Permission.其它成本, PermissionActions.Read);
            if (!pnlCost.Visible) this.Height -= pnlCost.Height;
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            btn设置结算单价.Enabled = !IsAdding && Operator.Current.Permit(Permission.结算单价, PermissionActions.Edit);
            btn设置其它成本.Enabled = !IsAdding && Operator.Current.Permit(Permission.其它成本, PermissionActions.Edit);
            btn查看成本明细.Enabled = !IsAdding;
            txtPurchasePrice.Enabled = Operator.Current.Permit(Permission.其它成本, PermissionActions.Edit);
            txt运费.Enabled = Operator.Current.Permit(Permission.其它成本, PermissionActions.Edit);
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
            CompanyInfo s = null;
            if (!string.IsNullOrEmpty(item.Supplier)) s = new CompanyBLL(AppSettings.Current.ConnStr).GetByID(item.Supplier).QueryObject;
            txtSupplier.Text = s != null ? s.Name : null;
            txtSupplier.Tag = s;
            cmbBrand.Text = item.Manufacture;
            txtSerialNumber.Text = item.SerialNumber;

            var ci = item.GetCost(CostItem.入库单价);
            txtPurchasePrice.DecimalValue = ci != null ? ci.Price : 0;
            rdWithTax_入库单价.Checked = ci != null && ci.WithTax;
            rdWithoutTax__入库单价.Checked = !rdWithTax_入库单价.Checked;
            ci = item.GetCost(CostItem.运费);
            if (ci != null)
            {
                txt运费.DecimalValue = ci != null ? ci.Price : 0;
                rdWithTax_运费.Checked = ci != null && ci.WithTax;
                rdWithoutTax_运费.Checked = ci != null && !ci.WithTax;
                if (!string.IsNullOrEmpty(ci.SupllierID))
                {
                    var sp = new CompanyBLL(AppSettings.Current.ConnStr).GetByID(ci.SupllierID).QueryObject;
                    txtSupplier运费.Text = sp != null ? sp.Name : null;
                    txtSupplier运费.Tag = sp;
                }
            }

            txtPosition.Text = item.Position;
            txtMaterial.Text = item.Material;
            txtCarPlate.Text = item.Carplate;
            txtPurchaseID.Text = item.PurchaseID;
            txtMemo.Text = item.Memo;
            if (item.SourceRoll.HasValue) btnOk1.Enabled = false;
            btnOk1.Enabled = btnOk1.Enabled && item.State == ProductInventoryState.Inventory && item.Status == "整卷";
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
            var pi = item as ProductInventoryItem;
            var ret = (new SteelRollBLL(AppSettings.Current.ConnStr)).Add(pi);
            if (ret.Result == ResultCode.Successful)
            {
                if (txt运费.DecimalValue > 0)
                {
                    var ci = new CostItem() { Name = CostItem.运费, Price = txt运费.DecimalValue, WithTax = rdWithTax_运费.Checked, SupllierID = (txtSupplier运费.Tag as CompanyInfo).ID };
                    new ProductInventoryItemBLL(AppSettings.Current.ConnStr).设置成本(pi, ci, Operator.Current.Name, Operator.Current.ID, null, null, pi.Carplate);
                }
            }
            return ret;
        }

        protected override CommandResult UpdateItem(object item)
        {
            var pi = item as ProductInventoryItem;
            var ret = (new SteelRollBLL(AppSettings.Current.ConnStr)).Update(pi);
            if (ret.Result == ResultCode.Successful)
            {
                if (txt运费.DecimalValue > 0)
                {
                    var ci = new CostItem() { Name = CostItem.运费, Price = txt运费.DecimalValue, WithTax = rdWithTax_运费.Checked, SupllierID = (txtSupplier运费.Tag as CompanyInfo).ID };
                    new ProductInventoryItemBLL(AppSettings.Current.ConnStr).设置成本(pi, ci, Operator.Current.Name, Operator.Current.ID, null, null, pi.Carplate);
                }
            }
            return ret;
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

        private void btn查看来源卷_Click(object sender, EventArgs e)
        {
            var pi = UpdatingItem as ProductInventoryItem;
            if (pi != null && pi.SourceRoll != null)
            {
                var steelRoll = new SteelRollBLL(AppSettings.Current.ConnStr).GetByID(pi.SourceRoll.Value).QueryObject;
                if (steelRoll != null)
                {
                    FrmSteelRollDetail frm = new FrmSteelRollDetail();
                    frm.IsForView = true;
                    frm.UpdatingItem = steelRoll;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }
            }
        }

        private void lnkSupplier_运费_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Purchase.FrmSupplierMaster frm = new Purchase.FrmSupplierMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CompanyInfo s = frm.SelectedItem as CompanyInfo;
                txtSupplier运费.Text = s.Name;
                txtSupplier运费.Tag = s;
            }
        }

        private void btn设置入库单价_Click(object sender, EventArgs e)
        {
            Frm设置结算单价 frm = new Frm设置结算单价();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var pi = UpdatingItem as ProductInventoryItem;
                var ci = new CostItem() { Name = CostItem.结算单价, Price = frm.单价, WithTax = frm.WithTax, SupllierID = string.IsNullOrEmpty(frm.SupplierID) ? pi.Supplier : frm.SupplierID, Memo = frm.Memo };
                var ret = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).设置成本(pi, ci, Operator.Current.Name, Operator.Current.ID, frm.Memo);
                if (ret.Result == ResultCode.Successful)
                {
                    this.OnItemUpdated(new ItemUpdatedEventArgs(UpdatingItem));
                }
                else
                {
                    MessageBox.Show(ret.Message);
                }
            }
        }

        private void btn设置其它成本_Click(object sender, EventArgs e)
        {
            Frm设置其它成本 frm = new Frm设置其它成本();
            frm.chk总金额.Enabled = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var ci = frm.Cost;
                decimal? 总额 = null;
                if (frm.chk总金额.Checked) 总额 = ci.Price;
                var pi = UpdatingItem as ProductInventoryItem;
                var ret = new SteelRollBLL(AppSettings.Current.ConnStr).设置成本(pi, ci, Operator.Current.Name, Operator.Current.ID, frm.Memo, 总额, frm.CarPlate);
                if (ret.Result == ResultCode.Successful)
                {
                    this.OnItemUpdated(new ItemUpdatedEventArgs(UpdatingItem));
                }
                else
                {
                    MessageBox.Show(ret.Message);
                }
            }
        }

        private void btn查看成本明细_Click(object sender, EventArgs e)
        {
            var frm = new Frm成本明细();
            frm.ProductInventoryItem = UpdatingItem as ProductInventoryItem;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}
