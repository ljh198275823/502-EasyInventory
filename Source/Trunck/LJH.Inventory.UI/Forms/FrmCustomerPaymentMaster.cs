using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmCustomerPaymentMaster : FrmMasterBase
    {
        public FrmCustomerPaymentMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法和处理事件
        protected override void Init()
        {
            base.Init();
            btnAll.BackColor = SystemColors.ControlDark;
            OperatorInfo opt = OperatorInfo.CurrentOperator;
            menu.Items["btn_Add"].Enabled = opt.Permit(Permission.EditCustomerPayment);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmCustomerPaymentDetail();
        }

        protected override List<object> GetDataSource()
        {
            List<CustomerPayment> items = (new CustomerPaymentBLL(AppSettings.CurrentSetting.ConnectString)).GetItems(null).QueryObjects;
            List<object> records = null;

            records = (from o in items
                       where o.State == SheetState.Add
                       orderby o.PaidDate descending
                       select (object)o).ToList();
            btnAdd.Tag = records;
            btnAdd.Text = string.Format("新建 ({0})", records == null ? 0 : records.Count);

            records = (from o in items
                       where o.State == SheetState.Approved
                       orderby o.PaidDate descending
                       select (object)o).ToList();
            btnApprove.Tag = records;
            btnApprove.Text = string.Format("审核 ({0})", records == null ? 0 : records.Count);

            records = (from o in items
                       where o.State == SheetState.Canceled
                       orderby o.PaidDate descending
                       select (object)o).ToList();
            btnCanceled.Tag = records;
            btnCanceled.Text = string.Format("作废 ({0})", records == null ? 0 : records.Count);

            records = (from o in items
                       orderby o.PaidDate descending
                       select (object)o).ToList();
            btnAll.Tag = records;
            btnAll.Text = string.Format("全部 ({0})", records == null ? 0 : records.Count);
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CustomerPayment info = item as CustomerPayment;
            row.Cells["colID"].Value = info.ID;
            row.Cells["colPaidDate"].Value = info.PaidDate.ToString("yyyy-MM-dd");
            row.Cells["colCustomer"].Value = info.Customer != null ? info.Customer.Name : info.CustomerID;
            row.Cells["colCurrencyType"].Value = info.CurrencyType;
            row.Cells["colPaymentMode"].Value = PaymentModeDescription.GetDescription(info.PaymentMode);
            row.Cells["colAmount"].Value = info.Amount.Trim();
            row.Cells["colCheckNum"].Value = info.CheckNum;
            row.Cells["colMemo"].Value = info.Memo;
            if (info.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
        }

        protected override bool DeletingItem(object item)
        {
            return false;
        }
        #endregion
    }
}
