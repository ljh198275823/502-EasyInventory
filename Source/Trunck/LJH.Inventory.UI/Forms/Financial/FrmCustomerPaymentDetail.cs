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
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmCustomerPaymentDetail : FrmSheetDetailBase 
    {
        public FrmCustomerPaymentDetail()
        {
            InitializeComponent();
        }

        #region 私有方法
        private void ShowAssigns(List<CustomerPaymentAssign> assigns)
        {
            ItemsGrid.Rows.Clear();
            if (assigns != null && assigns.Count > 0)
            {
                foreach (CustomerPaymentAssign assign in assigns)
                {
                    int row = ItemsGrid.Rows.Add();
                    ItemsGrid.Rows[row].Tag = assign;
                    ItemsGrid.Rows[row].Cells["colOrderID"].Value = assign.ReceivableID;
                    ItemsGrid.Rows[row].Cells["colAssign"].Value = assign.Amount.Trim();
                }
                int rowTotal = ItemsGrid.Rows.Add();
                ItemsGrid.Rows[rowTotal].Cells["colOrderID"].Value = "合计";
                ItemsGrid.Rows[rowTotal].Cells["colAssign"].Value = assigns.Sum(item => item.Amount).Trim();
            }
        }

        private List<CustomerPaymentAssign> GetAssignsFromGrid()
        {
            List<CustomerPaymentAssign> items = new List<CustomerPaymentAssign>();
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                if (row.Tag != null) items.Add(row.Tag as CustomerPaymentAssign);
            }
            return items;
        }
        #endregion

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (txtCustomer.Tag == null)
            {
                MessageBox.Show("客户不能为空");
                txtCustomer.Focus();
                return false;
            }
            List<CustomerPaymentAssign> items = GetAssignsFromGrid();
            if (items.Sum(item => item.Amount) > txtAmount.DecimalValue)
            {
                MessageBox.Show("付款流水分配的金额大于付款流水金额");
                txtAmount.Focus();
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
            CustomerPayment item = UpdatingItem as CustomerPayment;
            if (item != null)
            {
                this.txtID.Text = item.ID;
                this.txtID.Enabled = false;
                dtPaidDate.Value = item.LastActiveDate;
                txtCurrencyType.Text = item.CurrencyType;
                rdTransfer.Checked = (item.PaymentMode == PaymentMode.Transfer);
                rdCash.Checked = item.PaymentMode == PaymentMode.Cash;
                rdCheck.Checked = item.PaymentMode == PaymentMode.Check;
                txtAmount.DecimalValue = item.Amount;
                txtCheckNum.Text = item.CheckNum;
                if (!string.IsNullOrEmpty(item.CustomerID))
                {
                    CompanyInfo c = (new CompanyBLL(AppSettings.Current.ConnStr)).GetByID(item.CustomerID).QueryObject;
                    txtCustomer.Text = c != null ? c.Name : string.Empty;
                    txtCustomer.Tag = c;
                }
                txtMemo.Text = item.Memo;
                ShowAssigns(item.Assigns);
                List<DocumentOperation> items = (new DocumentOperationBLL(AppSettings.Current.ConnStr)).GetHisOperations(item.ID, item.DocumentType).QueryObjects;
                ShowOperations(items, dataGridView1);
                List<AttachmentHeader> headers = (new AttachmentBLL(AppSettings.Current.ConnStr)).GetHeaders(item.ID, item.DocumentType).QueryObjects;
                ShowAttachmentHeaders(headers, this.gridAttachment);
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
            if (txtID.Text == _AutoCreate) info.ID = string.Empty;
            info.LastActiveDate = dtPaidDate.Value;
            if (rdTransfer.Checked) info.PaymentMode = PaymentMode.Transfer;
            if (rdCheck.Checked) info.PaymentMode = PaymentMode.Check;
            if (rdCash.Checked) info.PaymentMode = PaymentMode.Cash;
            info.CurrencyType = txtCurrencyType.Text;
            info.Amount = txtAmount.DecimalValue;
            info.CheckNum = txtCheckNum.Text;
            CompanyInfo c = txtCustomer.Tag as CompanyInfo;
            info.CustomerID = c != null ? c.ID : null;
            info.Memo = txtMemo.Text;
            info.Assigns = GetAssignsFromGrid();
            info.Assigns.ForEach(item => item.PaymentID = info.ID);
            return info;
        }

        protected override CommandResult AddItem(object item)
        {
            CustomerPaymentBLL bll = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            return bll.ProcessSheet (item as CustomerPayment,SheetOperation .Create , Operator.Current.Name);
        }

        protected override CommandResult UpdateItem(object item)
        {
            CustomerPaymentBLL bll = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            return bll.ProcessSheet(item as CustomerPayment, SheetOperation.Modify , Operator.Current.Name);
        }

        protected override void ShowButtonState()
        {
        }
        #endregion

        #region 与附件操作相关的方法和事件处理程序
        private void mnu_AttachmentAdd_Click(object sender, EventArgs e)
        {
            CustomerPayment item = UpdatingItem as CustomerPayment;
            if (item != null) PerformAddAttach(item.ID, item.DocumentType, gridAttachment);
        }

        private void mnu_AttachmentDelete_Click(object sender, EventArgs e)
        {
            PerformDelAttach(gridAttachment);
        }

        private void mnu_AttachmentSaveAs_Click(object sender, EventArgs e)
        {
            PerformAttachSaveAs(gridAttachment);
        }

        private void mnu_AttachmentOpen_Click(object sender, EventArgs e)
        {
            PerformAttachOpen(gridAttachment);
        }

        private void gridAttachment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PerformAttachOpen(gridAttachment);
        }
        #endregion

        #region 公共方法
        public void AddOrderToAssign(Order order)
        {
            List<CustomerPaymentAssign> items = GetAssignsFromGrid();
            CustomerPaymentAssign assign = items.SingleOrDefault(item => item.ReceivableID == order.ID);
            if (assign == null && items.Sum(item => item.Amount) < txtAmount.DecimalValue)
            {
                assign = new CustomerPaymentAssign();
                assign.ID = Guid.NewGuid();
                assign.PaymentID = UpdatingItem != null ? (UpdatingItem as CustomerPayment).ID : string.Empty;
                assign.ReceivableID = order.ID;
                decimal amount = txtAmount.DecimalValue - items.Sum(item => item.Amount);
                //assign.Amount = amount >= order.NotPaid ? order.NotPaid : amount;
                items.Add(assign);
                ShowAssigns(items);
            }
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置付款的用户
        /// </summary>
        public CompanyInfo Customer
        {
            get
            {
                return txtCustomer.Tag as CompanyInfo;
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

        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomerMaster frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CompanyInfo item = frm.SelectedItem as CompanyInfo;
                txtCustomer.Text = item.Name;
                txtCustomer.Tag = item;
            }
        }

        private void lnkCurrencyType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCurrencyTypeMaster frm = new FrmCurrencyTypeMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CurrencyType item = frm.SelectedItem as CurrencyType;
                txtCurrencyType.Text = item.ID;
            }
        }

        private void mnu_Delete_Click(object sender, EventArgs e)
        {
            if (ItemsGrid.SelectedRows.Count > 0)
            {
                List<CustomerPaymentAssign> items = GetAssignsFromGrid();
                foreach (DataGridViewRow row in ItemsGrid.SelectedRows)
                {
                    if (row.Tag != null) items.Remove(row.Tag as CustomerPaymentAssign);
                }
                ShowAssigns(items);
            }
        }

        private void mnu_SelectOrder_Click(object sender, EventArgs e)
        {
            if (txtCustomer.Tag != null)
            {
                OrderSearchCondition con = new OrderSearchCondition();
                con.CustomerID = (txtCustomer.Tag as CompanyInfo).ID;
                con.HasNotPaid = true;
                FrmOrderSelection frm = new FrmOrderSelection();
                frm.SearchCondition = con;
                frm.ForSelect = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Order order = frm.SelectedItem as Order;
                    AddOrderToAssign(order);
                }
            }
        }

        private void ItemsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && ItemsGrid.Columns[e.ColumnIndex].Name == "colAssign")
            {
                CustomerPaymentAssign assign = ItemsGrid.Rows[e.RowIndex].Tag as CustomerPaymentAssign;
                if (assign != null)
                {
                    decimal amount = 0;
                    decimal.TryParse(ItemsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out amount);
                    assign.Amount = amount;
                    ItemsGrid.Rows[ItemsGrid.Rows.Count - 1].Cells["colAssign"].Value = GetAssignsFromGrid().Sum(item => item.Amount).Trim();
                }
            }
        }
    }
}
