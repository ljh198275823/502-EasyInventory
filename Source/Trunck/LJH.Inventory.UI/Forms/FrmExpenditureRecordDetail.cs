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
    public partial class FrmExpenditureRecordDetail : FrmDetailBase
    {
        public FrmExpenditureRecordDetail()
        {
            InitializeComponent();
            Init();
        }

        #region 私有方法
        private void Init()
        {
        }
        #endregion

        #region 重写基类方法
        protected override bool CheckInput()
        {
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
            dtPaidDate.Value = DateTime.Today;
        }

        protected override void ItemShowing()
        {
            ExpenditureRecord cp = UpdatingItem as ExpenditureRecord;
            if (cp != null)
            {
                txtSheetNo.Text = cp.ID;
                dtPaidDate.Value = cp.ExpenditureDate;
                rdTransfer.Checked = (cp.PaymentMode == PaymentMode.Transfer);
                rdCash.Checked = cp.PaymentMode == PaymentMode.Cash;
                rdCheck.Checked = cp.PaymentMode == PaymentMode.Check;
                txtAmount.DecimalValue = cp.Amount;
                txtCategory.Text = cp.Category;
                txtCheckNum.Text = cp.CheckNum;
                txtRequest.Text = cp.Request;
                txtPayee.Text = cp.Payee;
                txtOrderID.Text = cp.OrderID;
                txtMemo.Text = cp.Memo;
            }
        }

        protected override object GetItemFromInput()
        {
            ExpenditureRecord info = null;
            if (UpdatingItem == null)
            {
                info = new ExpenditureRecord();
                if (txtSheetNo.Text == _AutoCreate) txtSheetNo.Text = string.Empty;
            }
            else
            {
                info = UpdatingItem as ExpenditureRecord;
            }
            info.ExpenditureDate = dtPaidDate.Value;
            if (rdTransfer.Checked) info.PaymentMode = PaymentMode.Transfer;
            if (rdCheck.Checked) info.PaymentMode = PaymentMode.Check;
            if (rdCash.Checked) info.PaymentMode = PaymentMode.Cash;
            info.Amount = txtAmount.DecimalValue;
            info.Category = txtCategory.Text;
            info.CheckNum = txtCheckNum.Text;
            info.Request = txtRequest.Text;
            info.Payee = txtPayee.Text;
            info.OrderID = txtOrderID.Text;
            info.Memo = txtMemo.Text;
            return info;
        }

        protected override CommandResult AddItem(object item)
        {
            ExpenditureRecordBLL bll = new ExpenditureRecordBLL(AppSettings.CurrentSetting.ConnectString);
            return bll.Add(item as ExpenditureRecord, OperatorInfo.CurrentOperator.OperatorName);
        }

        protected override CommandResult UpdateItem(object item)
        {
            throw new Exception("资金支出不支持修改");
        }

        protected override void ShowButtonState()
        {
            btnOk.Enabled = IsAdding;
        }
        #endregion

        private void btnNullify_Click(object sender, EventArgs e)
        {
            if (UpdatingItem != null)
            {
                if (MessageBox.Show("是否要取消此项?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ExpenditureRecord item = UpdatingItem as ExpenditureRecord;
                    CommandResult ret = (new ExpenditureRecordBLL(AppSettings.CurrentSetting.ConnectString)).Cancel(item, OperatorInfo.CurrentOperator.OperatorName);
                    if (ret.Result == ResultCode.Successful)
                    {
                        ExpenditureRecord item1 = (new ExpenditureRecordBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(item.ID).QueryObject;
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

        private void lnkCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmExpenditureTypeMaster frm = new FrmExpenditureTypeMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ExpenditureType item = frm.SelectedItem as ExpenditureType;
                txtCategory.Text = item.Name;
            }
        }

        private void lnkRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmOperatorMaster frm = new FrmOperatorMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                OperatorInfo item = frm.SelectedItem as OperatorInfo;
                txtRequest.Text = item.OperatorName;
            }
        }
    }
}
