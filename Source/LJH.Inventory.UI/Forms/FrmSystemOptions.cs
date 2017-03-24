using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmSystemOptions : Form
    {
        public FrmSystemOptions()
        {
            InitializeComponent();
        }

        #region 私有方法
        private void ShowSetting(UserSettings us)
        {
            #region 基本
            txtBecomeTailAt.DecimalValue = UserSettings.Current.BecomeTailAt;
            txtBecomeRemainlessAt.DecimalValue = UserSettings.Current.BecomeRemainlessAt;
            chk启用拆卷和合并功能.Checked = UserSettings.Current.启用原料拆卷和合并功能;
            txtDefaultWareHouse.Text = UserSettings.Current.DefaultWarehouse;
            txtDefaultCustomer.Text = UserSettings.Current.DefaultCustomer;
            txtDefaultProductCategory.Text = UserSettings.Current.DefaultProductCategory;
            chkRealCount.Checked = UserSettings.Current.RealCountWhenCalRealThick;
            chkNeedMaterial.Checked = UserSettings.Current.NeedMaterial;
            #endregion

            #region 公司信息
            txtName.Text = us.CompanyName;
            txtForeignName.Text = us.ForeignName;
            txtTelphone.Text = us.TelPhone;
            txtFax.Text = us.Fax;
            txtPost.Text = us.PostalCode;
            txtWeb.Text = us.Website;
            txtAddress.Text = us.Address;
            #endregion

            #region 送货单
            if (us.ForbidWhenOverCreditLimit)
            {
                rdForbid.Checked = true;
            }
            else if (us.ReminderWhenOverCreditLimit)
            {
                rdReminder.Checked = true;
            }
            else
            {
                rdNone.Checked = true;
            }
            chkDoShipAfterPrint.Checked = us.DoShipAfterPrint;
            cmbStackoutSheetModel.Text = us.StackoutSheetModel;
            cmbStackoutSheetModel_WithTax.Text = us.StackoutSheetModel_WithTax;
            if (us.LoadSheetsBefore == 0)
            {
                rdOnlyThisMonth.Checked = true;
            }
            else
            {
                rdLoadSheetsBefore.Checked = true;
                txtLoadSheetsBefore.IntergerValue = us.LoadSheetsBefore;
            }
            #endregion

            #region 自动生成编号
            txtDeliverySheetPrefix.Text = us.DeliverySheetPrefix;
            txtDeliverySheetDate.Text = us.DeliverySheetDateFormat;
            txtDeliverySheetNum.IntergerValue = us.DeliverySheetSerialCount;
            txtInventorySheetPrefix.Text = us.InventorySheetPrefix;
            txtInventorySheetDate.Text = us.InventorySheetDateFormat;
            txtInventorySheetNum.IntergerValue = us.InventorySheetSerialCount;
            txtOrderPrefix.Text = us.OrderPrefix;
            txtOrderDate.Text = us.OrderDateFormat;
            txtOrderNum.IntergerValue = us.OrderSerialCount;
            txtPurchaseSheetPrefix.Text = us.PurchaseSheetPrefix;
            txtPurchaseSheetDate.Text = us.PurchaseSheetDateFormat;
            txtPurchaseSheetNum.IntergerValue = us.PurchaseSheetSerialCount;
            txtCustomerPaymentPrefix.Text = us.CustomerPaymentPrefix;
            txtCustomerPaymentDate.Text = us.CustomerPaymentDateFormat;
            txtCustomerPaymentNum.IntergerValue = us.CustomerPaymentSerialCount;
            txtExpenditureRecordPrefix.Text = us.ExpenditureRecordPrefix;
            txtExpenditureRecordDateFormat.Text = us.ExpenditureRecordDateFormat;
            txtExpenditureRecordSerialCount.IntergerValue = us.ExpenditureRecordSerialCount;
            txtCustomerPrefix.Text = us.CustomerPrefix;
            txtCustomerSerialCount.IntergerValue = us.CustomerSerialCount;
            txtSupplierPrefix.Text = us.SupplierPrefix;
            txtSupplierSerialCount.IntergerValue = us.SupplierSerialCount;
            txtWareHousePrefix.Text = us.WareHousePrefix;
            txtWareHouseSerialCount.IntergerValue = us.WareHouseSerialCount;
            txtCategoryPrefix.Text = us.CategoryPrefix;
            txtCategorySerialCount.IntergerValue = us.CategorySerialCount;
            txtProductSerialCount.IntergerValue = us.ProductSerialCount;
            #endregion
        }

        private UserSettings GetSettingFromInput()
        {
            UserSettings us = new UserSettings();

            #region 基本
            us.BecomeTailAt = txtBecomeTailAt.DecimalValue;
            us.BecomeRemainlessAt = txtBecomeRemainlessAt.DecimalValue;
            us.启用原料拆卷和合并功能 = chk启用拆卷和合并功能.Checked;
            us.DefaultCustomer = txtDefaultCustomer.Text;
            us.DefaultProductCategory = txtDefaultProductCategory.Text;
            us.DefaultWarehouse = txtDefaultWareHouse.Text;
            us.RealCountWhenCalRealThick = chkRealCount.Checked;
            us.NeedMaterial = chkNeedMaterial.Checked;
            #endregion

            #region 公司信息
            us.CompanyName = txtName.Text.Trim();
            us.ForeignName = txtForeignName.Text.Trim();
            us.TelPhone = txtTelphone.Text.Trim();
            us.Fax = txtFax.Text.Trim();
            us.PostalCode = txtPost.Text.Trim();
            us.Website = txtWeb.Text.Trim();
            us.Address = txtAddress.Text.Trim();
            #endregion

            #region 送货单选项
            us.ReminderWhenOverCreditLimit = rdReminder.Checked;
            us.ForbidWhenOverCreditLimit = rdForbid.Checked;
            us.DoShipAfterPrint = chkDoShipAfterPrint.Checked;
            us.StackoutSheetModel = cmbStackoutSheetModel.Text.Trim();
            us.StackoutSheetModel_WithTax = cmbStackoutSheetModel_WithTax.Text.Trim();
            if (rdOnlyThisMonth.Checked) us.LoadSheetsBefore = 0;
            else us.LoadSheetsBefore = txtLoadSheetsBefore.IntergerValue;
            #endregion

            #region 自动生成编号
            us.DeliverySheetPrefix = txtDeliverySheetPrefix.Text;
            us.DeliverySheetDateFormat = txtDeliverySheetDate.Text;
            us.DeliverySheetSerialCount = txtDeliverySheetNum.IntergerValue;
            us.InventorySheetPrefix = txtInventorySheetPrefix.Text;
            us.InventorySheetDateFormat = txtInventorySheetDate.Text;
            us.InventorySheetSerialCount = txtInventorySheetNum.IntergerValue;
            us.OrderPrefix = txtOrderPrefix.Text;
            us.OrderDateFormat = txtOrderDate.Text;
            us.OrderSerialCount = txtOrderNum.IntergerValue;
            us.PurchaseSheetPrefix = txtPurchaseSheetPrefix.Text;
            us.PurchaseSheetDateFormat = txtPurchaseSheetDate.Text;
            us.PurchaseSheetSerialCount = txtPurchaseSheetNum.IntergerValue;
            us.CustomerPaymentPrefix = txtCustomerPaymentPrefix.Text;
            us.CustomerPaymentDateFormat = txtCustomerPaymentDate.Text;
            us.CustomerPaymentSerialCount = txtCustomerPaymentNum.IntergerValue;
            us.ExpenditureRecordPrefix = txtExpenditureRecordPrefix.Text;
            us.ExpenditureRecordDateFormat = txtExpenditureRecordDateFormat.Text;
            us.ExpenditureRecordSerialCount = txtExpenditureRecordSerialCount.IntergerValue;
            us.CustomerPrefix = txtCustomerPrefix.Text;
            us.CustomerSerialCount = txtCustomerSerialCount.IntergerValue;
            us.SupplierPrefix = txtSupplierPrefix.Text;
            us.SupplierSerialCount = txtSupplierSerialCount.IntergerValue;
            us.WareHousePrefix = txtWareHousePrefix.Text;
            us.WareHouseSerialCount = txtWareHouseSerialCount.IntergerValue;
            us.CategoryPrefix = txtCategoryPrefix.Text;
            us.CategorySerialCount = txtCategorySerialCount.IntergerValue;
            us.ProductSerialCount = txtProductSerialCount.IntergerValue;
            #endregion
            return us;
        }
        #endregion

        #region 事件处理程序
        private void lnkCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            General.FrmProductCategoryMaster frm = new General.FrmProductCategoryMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var c = frm.SelectedItem as ProductCategory;
                txtDefaultProductCategory.Text = c != null ? c.Name : string.Empty;
                txtDefaultProductCategory.Tag = c;
            }
        }

        private void lnkWarehouse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Inventory.FrmWareHouseMaster frm = new Inventory.FrmWareHouseMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                WareHouse w = frm.SelectedItem as WareHouse;
                txtDefaultWareHouse.Text = w != null ? w.Name : string.Empty;
                txtDefaultWareHouse.Tag = w;
            }
        }

        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sale.FrmCustomerMaster frm = new Sale.FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtDefaultCustomer.Text = (frm.SelectedItem as CompanyInfo).Name;
            }
        }

        private void FrmSystemOptions_Load(object sender, EventArgs e)
        {
            InitCmbStackoutSheetModel(this.cmbStackoutSheetModel );
            InitCmbStackoutSheetModel(this.cmbStackoutSheetModel_WithTax);
            UserSettings.Current = SysParaSettingsBll.GetOrCreateSetting<UserSettings>(AppSettings.Current.ConnStr);
            ShowSetting(UserSettings.Current);
            btnOk.Enabled = Operator.Current.Permit(Permission.SystemOptions, PermissionActions.Edit);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            UserSettings.Current = GetSettingFromInput();
            SysParaSettingsBll.SaveSetting<UserSettings>(UserSettings.Current, AppSettings.Current.ConnStr);
            this.Close();
        }

        private void InitCmbStackoutSheetModel(ComboBox cmb)
        {
            cmb.Items.Clear();
            cmb.Items.Add(string.Empty);
            string dir = System.IO.Path.Combine(Application.StartupPath, "送货单模板");
            if (Directory.Exists(dir))
            {
                var files = Directory.GetFiles(dir);
                if (files != null && files.Length > 0)
                {
                    foreach (var f in files)
                    {
                        string model = Path.GetFileNameWithoutExtension(f);
                        if (model != "送货单模板")
                        {
                            cmb.Items.Add(Path.GetFileNameWithoutExtension(model));
                        }
                    }
                }
            }
        }
        #endregion
    }
}
