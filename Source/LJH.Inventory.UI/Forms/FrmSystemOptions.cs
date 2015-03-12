using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
            chkForbidWhenNoOrderID.Checked = us.ForbidWhenNoOrderID;
            txtDeadlineDays.IntergerValue = us.DeadlineDays;
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
            rdFIFO.Checked = us.InventoryOutType == InventoryOutType.FIFO;
            rdFILO.Checked = us.InventoryOutType == InventoryOutType.FILO;
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
            us.ForbidWhenNoOrderID = chkForbidWhenNoOrderID.Checked;
            us.ReminderWhenOverCreditLimit = rdReminder.Checked;
            us.ForbidWhenOverCreditLimit = rdForbid.Checked;
            us.DeadlineDays = txtDeadlineDays.IntergerValue;
            if (rdFIFO.Checked) us.InventoryOutType = InventoryOutType.FIFO;
            if (rdFILO.Checked) us.InventoryOutType = InventoryOutType.FILO;
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
        private void FrmSystemOptions_Load(object sender, EventArgs e)
        {
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
        #endregion
    }
}
