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
    public partial class FrmCustomerDaiFuDetail : FrmDetailBase
    {
        public FrmCustomerDaiFuDetail()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (txtCustomer.SelectedCustomer == null)
            {
                MessageBox.Show("客户不能为空");
                txtCustomer.Focus();
                return false;
            }
            if (txtAmount.DecimalValue <= 0)
            {
                MessageBox.Show("付款金额不正确");
                txtAmount.Focus();
                return false;
            }
            return true;
        }

        protected override void InitControls()
        {
            txtCustomer.Init();
        }

        protected override void ItemShowing()
        {
            CustomerDaiFu cp = UpdatingItem as CustomerDaiFu;
            if (cp != null)
            {
                txtCustomer.Text = cp.Customer != null ? cp.Customer.Name : cp.CustomerID;
                dtPaidDate.Value = cp.DaiFuDate;
                rdTransfer.Checked = (cp.PaymentMode == PaymentMode.Transfer);
                rdCash.Checked = cp.PaymentMode == PaymentMode.Cash;
                rdCheck.Checked = cp.PaymentMode == PaymentMode.Check;
                txtAmount.DecimalValue = cp.Amount;
                txtMemo.Text = cp.Memo;
            }
        }

        protected override object GetItemFromInput()
        {
            CustomerDaiFu info = null;
            if (UpdatingItem == null)
            {
                info = new CustomerDaiFu();
            }
            else
            {
                info = UpdatingItem as CustomerDaiFu;
            }
            info.Customer = txtCustomer.SelectedCustomer;
            info.CustomerID = txtCustomer.SelectedCustomer.ID;
            info.DaiFuDate = dtPaidDate.Value;
            if (rdTransfer.Checked) info.PaymentMode = PaymentMode.Transfer;
            if (rdCheck.Checked) info.PaymentMode = PaymentMode.Check;
            if (rdCash.Checked) info.PaymentMode = PaymentMode.Cash;
            info.Amount = txtAmount.DecimalValue;
            info.CreateDate = DateTime.Now;
            info.CreateOperator = OperatorInfo.CurrentOperator.OperatorName;
            info.Memo = txtMemo.Text;
            return info;
        }

        protected override CommandResult AddItem(object item)
        {
            CustomerDaiFuBLL bll = new CustomerDaiFuBLL(AppSettings.CurrentSetting.ConnectString);
            return bll.Add(item as CustomerDaiFu);
        }

        protected override CommandResult UpdateItem(object item)
        {
            throw new Exception("客户代付款不支持修改,如果确实要修改,请先取消此记录,再增加一条新记录");
        }
        #endregion

    }
}
