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
using LJH.Inventory.UI.Forms.Sale;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmCustomerOtherReceivableDetail : FrmSheetDetailBase
    {
        public FrmCustomerOtherReceivableDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        public CompanyInfo Customer { get; set; }
        #endregion

        #region 重写基类方法
        protected override void InitControls()
        {
            base.InitControls();
            txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
        }

        protected override bool CheckInput()
        {
            if (Customer == null)
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
                Customer = (new CompanyBLL(AppSettings.Current.ConnStr)).GetByID(item.CustomerID).QueryObject;
                txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
                txtMemo.Text = item.Memo;
                ShowOperations(item.ID, item.DocumentType, dataGridView1);
                ShowAttachmentHeaders(item.ID, item.DocumentType, this.gridAttachment);
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
            info.CustomerID = Customer != null ? Customer.ID : null;
            info.Memo = txtMemo.Text;
            return info;
        }

        protected override CommandResult AddItem(object item)
        {
            CustomerOtherReceivableBLL bll = new CustomerOtherReceivableBLL(AppSettings.Current.ConnStr);
            return bll.ProcessSheet(item as CustomerOtherReceivable, SheetOperation.Create, Operator.Current.Name, Operator.Current.ID);
        }

        protected override CommandResult UpdateItem(object item)
        {
            CustomerOtherReceivableBLL bll = new CustomerOtherReceivableBLL(AppSettings.Current.ConnStr);
            return bll.ProcessSheet(item as CustomerOtherReceivable, SheetOperation.Modify, Operator.Current.Name, Operator.Current.ID);
        }

        protected override void ShowButtonState()
        {
            ShowButtonState(this.toolStrip1);
            btnSave.Enabled = btnSave.Enabled && Operator.Current.Permit(Permission.CustomerOtherReceivable, PermissionActions.Edit);
            btnApprove.Enabled = btnApprove.Enabled && Operator.Current.Permit(Permission.CustomerOtherReceivable, PermissionActions.Approve);
            btnUndoApprove.Enabled = btnUndoApprove.Enabled && Operator.Current.Permit(Permission.CustomerOtherReceivable, PermissionActions.UndoApprove);
            btnNullify.Enabled = btnNullify.Enabled && Operator.Current.Permit(Permission.CustomerOtherReceivable, PermissionActions.Nullify);
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
            PerformOperation<CustomerOtherReceivable>(processor, IsAdding ? SheetOperation.Create : SheetOperation.Modify);
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
                Customer = frm.SelectedItem as CompanyInfo;
                txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
            }
        }
        #endregion
    }
}
