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
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.UI.Forms.Report;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmCustomerDaiFuMaster : FrmMasterBase
    {
        public FrmCustomerDaiFuMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法和处理事件
        protected override void Init()
        {
            base.Init();
            this.txtCustomer.Init();
            this.ucDateTimeInterval1.ShowTime = false;
            this.ucDateTimeInterval1.Init();
            this.ucDateTimeInterval1.SelectThisMonth();
            OperatorInfo opt = OperatorInfo.CurrentOperator;
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmCustomerDaiFuDetail();
        }

        protected override List<object> GetDataSource()
        {
            CustomerDaiFuSearchCondition con = new CustomerDaiFuSearchCondition();
            con.CreateDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            con.ContainCanceled = true;
            if (txtCustomer.SelectedCustomer != null)
            {
                con.CustomerID = txtCustomer.SelectedCustomer.ID;
            }
            else
            {
                con.CustomerName = txtCustomer.Text;
            }
            if (chkOnlyUnsettled.Checked) con.IsSettled = false;

            List<CustomerDaiFu> items = (new CustomerDaiFuBLL(AppSettings.CurrentSetting.ConnectString)).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                if (!chkTransfer.Checked) items = items.Where(cp => cp.PaymentMode != PaymentMode.Transfer).ToList();
                if (!chkCheck.Checked) items = items.Where(cp => cp.PaymentMode != PaymentMode.Check).ToList();
                if (!chkCash.Checked) items = items.Where(cp => cp.PaymentMode != PaymentMode.Cash).ToList();
                lblTotalDaiFu.Text = items.Sum(cp => cp.CancelDate == null ? cp.Amount : 0).Trim().ToString();
                lblTotalPaid.Text = items.Sum(cp => cp.CancelDate == null ? cp.Paid : 0).Trim().ToString();
                return (from cp in items
                        orderby cp.DaiFuDate descending
                        select (object)cp).ToList();
            }
            else
            {
                lblTotalDaiFu.Text = "0";
                lblTotalPaid.Text = "0";
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CustomerDaiFu info = item as CustomerDaiFu;
            row.Cells["colID"].Value = info.ID;
            row.Cells["colPaidDate"].Value = info.DaiFuDate.ToString("yyyy-MM-dd");
            row.Cells["colCustomer"].Value = info.Customer != null ? info.Customer.Name : info.CustomerID;
            row.Cells["colPaymentMode"].Value = PaymentModeDescription.GetDescription(info.PaymentMode);
            row.Cells["colAmount"].Value = info.Amount;
            row.Cells["colPaid"].Value = info.Paid;
            row.Cells["colMemo"].Value = info.Memo;
            row.Cells["colCancelDate"].Value = info.CancelDate;
            row.Cells["colCancelOperator"].Value = info.CancelOperator;
            if (info.CancelDate != null)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
            else if (info.Receivables == 0)
            {
                row.DefaultCellStyle.ForeColor = Color.Blue;
            }
        }

        protected override bool DeletingItem(object item)
        {
            //return (new CustomerDaiFuBLL(AppSettings.CurrentSetting.ConnectString)).Delete(item as CustomerDaiFu).Result == ResultCode.Successful;
            return false;
        }
        #endregion

        #region 事件处理程序
        private void mnu_Cancel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DialogResult dr = MessageBox.Show("取消预付款时，对于此预付款项客户已经支付的金额，你是否想把它用于抵销其它应收项？", "询问", MessageBoxButtons.YesNoCancel);
                if (dr != DialogResult.Cancel)
                {
                    CustomerDaiFu item = dataGridView1.SelectedRows[0].Tag as CustomerDaiFu;
                    CommandResult ret = (new CustomerDaiFuBLL(AppSettings.CurrentSetting.ConnectString)).Cancel(item, OperatorInfo.CurrentOperator.OperatorName, dr == DialogResult.Yes);
                    if (ret.Result == ResultCode.Successful)
                    {
                        ShowItemInGridViewRow(dataGridView1.SelectedRows[0], item);
                    }
                    else
                    {
                        MessageBox.Show(ret.Message);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colPaid")
                {
                    CustomerDaiFu daifu = dataGridView1.Rows[e.RowIndex].Tag as CustomerDaiFu;
                    if (daifu != null)
                    {
                        FrmReceivablePaymentAssigns frm = new FrmReceivablePaymentAssigns();
                        frm.ReceivableID = daifu.ID;
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void mnu_Pay_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                CustomerDaiFu daifu = dataGridView1.SelectedRows[0].Tag as CustomerDaiFu;
                if (daifu.Payable)
                {
                    FrmReceivablesPaid frm = new FrmReceivablesPaid();
                    Customer c = (new CustomerBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(daifu.CustomerID).QueryObject;
                    if (c != null)
                    {
                        frm.Customer = c;
                        frm.ReceivableID = daifu.ID;
                        frm.MaxAmount = daifu.Receivables;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            CustomerDaiFu sheet1 = (new CustomerDaiFuBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(daifu.ID).QueryObject;
                            ShowItemInGridViewRow(dataGridView1.SelectedRows[0], sheet1);
                        }
                    }
                }
            }
        }
        #endregion
    }
}
