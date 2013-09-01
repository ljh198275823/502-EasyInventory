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
            if (items != null && items.Count > 0)
            {
                return (from cp in items
                        orderby cp.PaidDate descending
                        select (object)cp).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CustomerPayment info = item as CustomerPayment;
            row.Cells["colID"].Value = info.ID;
            row.Cells["colPaidDate"].Value = info.PaidDate.ToString("yyyy-MM-dd");
            row.Cells["colCustomer"].Value = info.Customer != null ? info.Customer.Name : info.CustomerID;
            row.Cells["colPaymentMode"].Value = PaymentModeDescription.GetDescription(info.PaymentMode);
            row.Cells["colAmount"].Value = info.Amount;
            row.Cells["colIsPrepay"].Value = info.IsPrepay;
            row.Cells["colCheckNum"].Value = info.CheckNum;
            row.Cells["colDeliverySheetNo"].Value = info.SheetNo;
            row.Cells["colMemo"].Value = info.Memo;
            row.Cells["colCancelDate"].Value = info.CancelDate;
            row.Cells["colCancelOperator"].Value = info.CancelOperator;
            if (info.CancelDate != null)
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
