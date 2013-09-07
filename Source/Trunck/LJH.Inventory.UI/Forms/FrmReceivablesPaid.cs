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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmReceivablesPaid : Form
    {
        public FrmReceivablesPaid()
        {
            InitializeComponent();
        }

        #region 公共方法
        /// <summary>
        /// 
        /// </summary>
        public Customer Customer { get; set; }

        public string ReceivableID { get; set; }

        public decimal MaxAmount { get; set; }
        #endregion

        private void FrmReceivablesPaid_Load(object sender, EventArgs e)
        {
            if (Customer != null) txtCustomer.Text = Customer.Name;
            txtReceivable.Text = ReceivableID;
            txtAmount.MaxValue = MaxAmount;
            txtAmount.DecimalValue = MaxAmount;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //CustomerPayment info =  new CustomerPayment();
            //info.Customer = Customer;
            //info.CustomerID = Customer.ID;
            //info.SheetNo = txtReceivable.Text;
            //info.PaidDate = dtPaidDate.Value;
            //if (rdTransfer.Checked) info.PaymentMode = PaymentMode.Transfer;
            //if (rdCheck.Checked) info.PaymentMode = PaymentMode.Check;
            //if (rdCash.Checked) info.PaymentMode = PaymentMode.Cash;
            //info.Amount = txtAmount.DecimalValue;
            //info.CheckNum = txtCheckNum.Text;
            //info.IsPrepay =false;
            //info.CreateDate = DateTime.Now;
            //info.CreateOperator = OperatorInfo.CurrentOperator.OperatorName;
            //info.Memo = txtMemo.Text;
            //CommandResult ret = (new CustomerPaymentBLL(AppSettings.CurrentSetting.ConnectString)).AddAndAssign(info);
            //if (ret.Result == ResultCode.Successful)
            //{
            //    this.DialogResult = DialogResult.OK;
            //}
            //else
            //{
            //    MessageBox.Show(ret.Message);
            //}
        }
    }
}
