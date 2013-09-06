using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmCustomerPaymentDetail : FrmDetailBase
    {
        public FrmCustomerPaymentDetail()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (txtCustomer.Tag  == null)
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

        protected override void ItemShowing()
        {
            CustomerPayment cp = UpdatingItem as CustomerPayment;
            if (cp != null)
            {
                txtCustomer.Text = cp.Customer != null ? cp.Customer.Name : cp.CustomerID;
                txtSheetNo.Text = cp.SheetNo;
                dtPaidDate.Value = cp.PaidDate;
                rdTransfer.Checked = (cp.PaymentMode == PaymentMode.Transfer);
                rdCash.Checked = cp.PaymentMode == PaymentMode.Cash;
                rdCheck.Checked = cp.PaymentMode == PaymentMode.Check;
                txtAmount.DecimalValue = cp.Amount;
                txtCheckNum.Text = cp.CheckNum;
                txtMemo.Text = cp.Memo;
                ShowButtonState();
            }
        }

        protected override object GetItemFromInput()
        {
            CustomerPayment info = null;
            if (UpdatingItem == null)
            {
                info = new CustomerPayment();
            }
            else
            {
                info = UpdatingItem as CustomerPayment;
            }
            info.Customer = txtCustomer.Tag as Customer;
            info.CustomerID = info.Customer.ID;
            info.SheetNo = txtSheetNo.Text;
            info.PaidDate = dtPaidDate.Value;
            if (rdTransfer.Checked) info.PaymentMode = PaymentMode.Transfer;
            if (rdCheck.Checked) info.PaymentMode = PaymentMode.Check;
            if (rdCash.Checked) info.PaymentMode = PaymentMode.Cash;
            info.Amount = txtAmount.DecimalValue;
            info.CheckNum = txtCheckNum.Text;
            info.CreateDate = DateTime.Now;
            info.CreateOperator = OperatorInfo.CurrentOperator.OperatorName;
            info.Memo = txtMemo.Text;
            return info;
        }

        protected override CommandResult AddItem(object item)
        {
            CustomerPaymentBLL bll = new CustomerPaymentBLL(AppSettings.CurrentSetting.ConnectString);
            return bll.Add(item as CustomerPayment, false);
        }

        protected override CommandResult UpdateItem(object item)
        {
            throw new Exception("客户付款不支持修改");
        }

        protected override void ShowButtonState()
        {
            btnOk.Enabled = IsAdding;
            //btnNullify .Enabled =false ;
            //if (UpdatingItem != null)
            //{
            //    CustomerPayment cp = UpdatingItem as CustomerPayment;
            //    btnNullify.Enabled = cp.CancelDate == null;
            //}
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置付款的用户
        /// </summary>
        public Customer Customer
        {
            get
            {
                return txtCustomer.Tag as Customer;
            }
            set
            {
                InitControls();
                if (value != null)
                {
                    txtCustomer.Text = value.Name;
                    txtCustomer.Tag = value;
                }
                else
                {
                    txtCustomer.Text = string.Empty;
                }
            }
        }
        #endregion

        private void FrmCustomerPaymentDetail_Load(object sender, EventArgs e)
        {
        }

        private void btnNullify_Click(object sender, EventArgs e)
        {
            if (UpdatingItem != null)
            {
                if (MessageBox.Show("是否要取消此项?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CustomerPayment item = UpdatingItem as CustomerPayment;
                    CommandResult ret = (new CustomerPaymentBLL(AppSettings.CurrentSetting.ConnectString)).Cancel(item, OperatorInfo.CurrentOperator.OperatorName);
                    if (ret.Result == ResultCode.Successful)
                    {
                        CustomerPayment item1 = (new CustomerPaymentBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(item.ID).QueryObject;
                        this.UpdatingItem = item1;
                        ItemShowing();
                        ShowButtonState();
                        this.OnItemUpdated(new ItemUpdatedEventArgs(item1));
                    }
                    else
                    {
                        MessageBox.Show(ret.Message);
                    }
                }
            }
        }

        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomerMaster frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Customer item = frm.SelectedItem as Customer;
                txtCustomer.Text = item.Name;
                txtCustomer.Tag = item;
            }
        }
    }
}
