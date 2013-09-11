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
    public partial class FrmCustomerOtherReceivableMaster : FrmMasterBase
    {
        public FrmCustomerOtherReceivableMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法和处理事件
        protected override void Init()
        {
            base.Init();
            this.btnAll.BackColor = SystemColors.ControlDark;
            OperatorInfo opt = OperatorInfo.CurrentOperator;
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmCustomerOtherReceivableDetail();
        }

        protected override List<object> GetDataSource()
        {
            List<CustomerOtherReceivable> items = (new CustomerOtherReceivableBLL(AppSettings.CurrentSetting.ConnectString)).GetItems(SearchCondition).QueryObjects;
            List<object> records = null;

            records = (from o in items
                       where o.State == SheetState.Add
                       orderby o.CreateDate descending
                       select (object)o).ToList();
            btnAdd.Tag = records;
            btnAdd.Text = string.Format("新建 ({0})", records == null ? 0 : records.Count);

            records = (from o in items
                       where o.State == SheetState.Approved
                       orderby o.CreateDate descending
                       select (object)o).ToList();
            btnApprove.Tag = records;
            btnApprove.Text = string.Format("审核 ({0})", records == null ? 0 : records.Count);

            records = (from o in items
                       where o.State == SheetState.Canceled
                       orderby o.CreateDate descending
                       select (object)o).ToList();
            btnCanceled.Tag = records;
            btnCanceled.Text = string.Format("作废 ({0})", records == null ? 0 : records.Count);

            records = (from o in items
                       orderby o.CreateDate descending
                       select (object)o).ToList();
            btnAll.Tag = records;
            btnAll.Text = string.Format("全部 ({0})", records == null ? 0 : records.Count);
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CustomerOtherReceivable info = item as CustomerOtherReceivable;
            row.Cells["colID"].Value = info.ID;
            row.Cells["colCreateDate"].Value = info.CreateDate.ToString("yyyy-MM-dd");
            row.Cells["colCustomer"].Value = info.Customer != null ? info.Customer.Name : info.CustomerID;
            row.Cells["colCurrencyType"].Value = info.CurrencyType;
            row.Cells["colAmount"].Value = info.Amount.Trim();
            row.Cells["colPaid"].Value = info.Paid.Trim();
            row.Cells["colNotPaid"].Value = info.NotPaid.Trim();
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

        #region 事件处理程序
        private void mnu_Cancel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("是否要取消此项?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CustomerOtherReceivable item = dataGridView1.SelectedRows[0].Tag as CustomerOtherReceivable;
                    CommandResult ret = (new CustomerOtherReceivableBLL(AppSettings.CurrentSetting.ConnectString)).Cancel(item, OperatorInfo.CurrentOperator.OperatorName);
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
                    CustomerOtherReceivable daifu = dataGridView1.Rows[e.RowIndex].Tag as CustomerOtherReceivable;
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
                CustomerOtherReceivable daifu = dataGridView1.SelectedRows[0].Tag as CustomerOtherReceivable;
                if (daifu.Payable)
                {
                    FrmReceivablesPaid frm = new FrmReceivablesPaid();
                    Customer c = (new CustomerBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(daifu.CustomerID).QueryObject;
                    if (c != null)
                    {
                        frm.Customer = c;
                        frm.ReceivableID = daifu.ID;
                        frm.MaxAmount = daifu.NotPaid;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            CustomerOtherReceivable sheet1 = (new CustomerOtherReceivableBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(daifu.ID).QueryObject;
                            ShowItemInGridViewRow(dataGridView1.SelectedRows[0], sheet1);
                        }
                    }
                }
            }
        }
        #endregion
    }
}
