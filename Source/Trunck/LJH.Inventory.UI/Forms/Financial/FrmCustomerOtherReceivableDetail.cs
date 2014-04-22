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

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmCustomerOtherReceivableDetail : FrmSheetDetailBase
    {
        public FrmCustomerOtherReceivableDetail()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (txtCustomer.Tag == null)
            {
                MessageBox.Show("客户不能为空");
                txtCustomer.Focus();
                return false;
            }
            if (txtAmount.DecimalValue <= 0)
            {
                MessageBox.Show("金额不正确");
                txtAmount.Focus();
                return false;
            }
            return true;
        }

        protected override void ItemShowing()
        {
            CustomerOtherReceivable item = UpdatingItem as CustomerOtherReceivable;
            if (item != null)
            {
                this.txtID.Text = item.ID;
                this.txtID.Enabled = false;
                dtCreateDate.Value = item.LastActiveDate;
                txtAmount.DecimalValue = item.Amount;
                txtCustomer.Text = item.Customer != null ? item.Customer.Name : string.Empty;
                txtCustomer.Tag = item.Customer;
                txtMemo.Text = item.Memo;
                ShowOperations(item.ID, item.DocumentType, dataGridView1);
                ShowAttachmentHeaders(item.ID, item.DocumentType, this.gridAttachment);
                ShowButtonState();
            }
        }

        protected override object GetItemFromInput()
        {
            CustomerOtherReceivable info = null;
            if (UpdatingItem == null)
            {
                info = new CustomerOtherReceivable();
            }
            else
            {
                info = UpdatingItem as CustomerOtherReceivable;
            }
            if (txtID.Text == _AutoCreate) info.ID = string.Empty;
            info.LastActiveDate = dtCreateDate.Value;
            info.Amount = txtAmount.DecimalValue;
            info.Customer = txtCustomer.Tag as CompanyInfo;
            info.CustomerID = info.Customer.ID;
            info.Memo = txtMemo.Text;
            return info;
        }

        protected override CommandResult AddItem(object item)
        {
            CustomerOtherReceivableBLL bll = new CustomerOtherReceivableBLL(AppSettings.Current.ConnStr);
            return bll.ProcessSheet(item as CustomerOtherReceivable, SheetOperation.Create, Operator.Current.Name);
        }

        protected override CommandResult UpdateItem(object item)
        {
            CustomerOtherReceivableBLL bll = new CustomerOtherReceivableBLL(AppSettings.Current.ConnStr);
            return bll.ProcessSheet(item as CustomerOtherReceivable, SheetOperation.Modify, Operator.Current.Name);
        }

        protected override void ShowButtonState()
        {
            if (UpdatingItem == null)
            {
                this.btnSave.Enabled = true;
                this.btnApprove.Enabled = false;
                this.btnUndoApprove.Enabled = false;
                this.btnNullify.Enabled = false;
            }
            else
            {
                ISheet<string> sheet = UpdatingItem as ISheet<string>;
                this.btnSave.Enabled = sheet.CanEdit;
                this.btnApprove.Enabled = sheet.CanApprove;
                this.btnUndoApprove.Enabled = sheet.State == SheetState.Approved;
                this.btnNullify.Enabled = sheet.CanCancel;
            }
        }
        #endregion

        #region 与附件操作相关的方法和事件处理程序
        private void mnu_AttachmentAdd_Click(object sender, EventArgs e)
        {
            CustomerOtherReceivable item = UpdatingItem as CustomerOtherReceivable;
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
        #endregion

        #region 工具栏事件处理
        private void btnSave_Click(object sender, EventArgs e)
        {
            CustomerOtherReceivableBLL processor = new CustomerOtherReceivableBLL(AppSettings.Current.ConnStr);
            PerformCreateOrModify<CustomerOtherReceivable>(processor, IsAdding ? SheetOperation.Create : SheetOperation.Modify);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            CustomerOtherReceivableBLL processor = new CustomerOtherReceivableBLL(AppSettings.Current.ConnStr);
            PerformOperation<CustomerOtherReceivable>(processor, SheetOperation.Approve);
        }

        private void btnUndoApprove_Click(object sender, EventArgs e)
        {
            CustomerOtherReceivableBLL processor = new CustomerOtherReceivableBLL(AppSettings.Current.ConnStr);
            PerformOperation<CustomerOtherReceivable>(processor, SheetOperation.UndoApprove);
        }

        private void btnNullify_Click(object sender, EventArgs e)
        {
            CustomerOtherReceivableBLL processor = new CustomerOtherReceivableBLL(AppSettings.Current.ConnStr);
            PerformOperation<CustomerOtherReceivable>(processor, SheetOperation.Nullify);
        }
        #endregion

        #region 事件处理程序
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
        #endregion
    }
}
