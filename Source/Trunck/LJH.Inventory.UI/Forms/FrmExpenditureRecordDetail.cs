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
                dtPaidDate.Value = cp.ExpenditureDate;
                rdTransfer.Checked = (cp.PaymentMode == PaymentMode.Transfer);
                rdCash.Checked = cp.PaymentMode == PaymentMode.Cash;
                rdCheck.Checked = cp.PaymentMode == PaymentMode.Check;
                txtAmount.DecimalValue = cp.Amount;
                txtCategory.Text = cp.Category;
                txtMemo.Text = cp.Memo;
                ShowButtonState();
            }
        }

        protected override object GetItemFromInput()
        {
            ExpenditureRecord info = null;
            if (UpdatingItem == null)
            {
                info = new ExpenditureRecord();
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
            info.Memo = txtMemo.Text;
            info.CreateDate = DateTime.Now;
            info.CreateOperator = OperatorInfo.CurrentOperator.OperatorName;
            return info;
        }

        protected override CommandResult AddItem(object item)
        {
            ExpenditureRecordBLL bll = new ExpenditureRecordBLL(AppSettings.CurrentSetting.ConnectString);
            return bll.Add(item as ExpenditureRecord);
        }

        protected override CommandResult UpdateItem(object item)
        {
            throw new Exception("资金支出不支持修改");
        }

        protected override void ShowButtonState()
        {
            btnOk.Enabled = IsAdding;
            //btnNullify.Enabled = false;
            //if (UpdatingItem != null)
            //{
            //    ExpenditureRecord cp = UpdatingItem as ExpenditureRecord;
            //    btnNullify.Enabled = cp.CancelDate == null;
            //}
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
    }
}
