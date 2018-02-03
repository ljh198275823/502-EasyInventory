using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;
using LJH.Inventory.UI.Forms.Sale;
using LJH.Inventory.UI.Forms.Purchase;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class Frm其它收款 : FrmSheetDetailBase
    {
        public Frm其它收款()
        {
            InitializeComponent();
        }

        #region 公共属性
        public Account Account { get; set; }
        #endregion

        #region 重写基类方法
        protected override void InitControls()
        {
            base.InitControls();
            if (IsForView) toolStrip1.Enabled = false;
            txtAccount.Text = Account != null ? Account.Name : null;
            txtAccount.Tag = Account;
            dtPaidDate.IsNull = true;
        }

        protected override bool CheckInput()
        {
            if (txtAccount.Tag == null && !IsAdding)
            {
                MessageBox.Show("没有指定账号");
            }
            if (txtAmount.DecimalValue <= 0)
            {
                MessageBox.Show("金额不正确,不能小于零");
                txtAmount.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPayer.Text))
            {
                MessageBox.Show("对方账号不能为空");
                return false;
            }
            if (dtPaidDate.IsNull)
            {
                MessageBox.Show("没有填写到款日期");
                dtPaidDate.Focus();
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
                dtSheetDate.Value = item.SheetDate;
                txtAmount.DecimalValue = item.Amount;
                txtPayer.Text = item.Payer;
                Account ac = null;
                if (!string.IsNullOrEmpty(item.AccountID)) ac = (new AccountBLL(AppSettings.Current.ConnStr)).GetByID(item.AccountID).QueryObject;
                txtAccount.Text = ac != null ? ac.Name : string.Empty;
                txtAccount.Tag = ac;
                if (!string.IsNullOrEmpty(item.CustomerID))
                {
                    var c = new CompanyBLL(AppSettings.Current.ConnStr).GetByID(item.CustomerID).QueryObject;
                    txtCustomer.Tag = c;
                    txtCustomer.Text = c != null ? c.Name : string.Empty;
                }
                var temp = item.GetProperty("到款日期");
                DateTime pd = item.SheetDate;
                if (!string.IsNullOrEmpty(temp) && DateTime.TryParse(temp, out pd))
                {
                    dtPaidDate.Value = pd;
                }
                else
                {
                    dtPaidDate.IsNull = true;
                }
                txtMemo.Text = item.Memo;
                ShowOperations(item.ID, item.DocumentType, dataGridView1);
                ShowAttachmentHeaders(item.ID, item.DocumentType, this.gridAttachment);
                ShowButtonState();
            }
        }

        protected override object GetItemFromInput()
        {
            CustomerPayment info = null;
            if (UpdatingItem == null)
            {
                info = new CustomerPayment();
                info.ClassID = CustomerPaymentType.其它收款;
                info.ID = txtID.Text == _AutoCreate ? string.Empty : txtID.Text.Trim();
            }
            else
            {
                info = UpdatingItem as CustomerPayment;
            }
            info.SheetDate = dtSheetDate.Value;
            info.Amount = txtAmount.DecimalValue;
            var ac = txtAccount.Tag as Account;
            info.AccountID = ac != null ? ac.ID : null;
            var c = txtCustomer.Tag as CompanyInfo;
            info.CustomerID = c != null ? c.ID : null;
            info.Payer = txtPayer.Text;
            info.SetProperty("到款日期", dtPaidDate.Value.ToString("yyyy-MM-dd"));
            info.Memo = txtMemo.Text;
            return info;
        }

        protected override CommandResult AddItem(object item)
        {
            CustomerPaymentBLL bll = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            return bll.ProcessSheet(item as CustomerPayment, SheetOperation.Create, Operator.Current.Name, Operator.Current.ID);
        }

        protected override CommandResult UpdateItem(object item)
        {
            CustomerPaymentBLL bll = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            return bll.ProcessSheet(item as CustomerPayment, SheetOperation.Modify, Operator.Current.Name, Operator.Current.ID);
        }

        protected override void ShowButtonState()
        {
            base.ShowButtonState(this.toolStrip1);
            CustomerPayment cp = UpdatingItem != null ? UpdatingItem as CustomerPayment : null;
            btnSave.Enabled = IsAdding && btnSave.Enabled && Operator.Current.Permit(Permission.其它收款, PermissionActions.Edit);
            btnApprove.Enabled = btnApprove.Enabled && Operator.Current.Permit(Permission.其它收款, PermissionActions.Approve);
            btnUndoApprove.Enabled = btnUndoApprove.Enabled && Operator.Current.Permit(Permission.其它收款, PermissionActions.UndoApprove);
            btnNullify.Enabled = btnNullify.Enabled && Operator.Current.Permit(Permission.其它收款, PermissionActions.Nullify);
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            mnu_AttachmentAdd.Enabled = mnu_AttachmentAdd.Enabled && Operator.Current.Permit(Permission.其它收款, PermissionActions.EditAttachment);
            mnu_AttachmentDelete.Enabled = mnu_AttachmentDelete.Enabled && Operator.Current.Permit(Permission.其它收款, PermissionActions.EditAttachment);
            mnu_AttachmentOpen.Enabled = mnu_AttachmentOpen.Enabled && Operator.Current.Permit(Permission.其它收款, PermissionActions.ShowAttachment);
            mnu_AttachmentSaveAs.Enabled = mnu_AttachmentSaveAs.Enabled && Operator.Current.Permit(Permission.其它收款, PermissionActions.ShowAttachment);
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

        #region 工具栏事件处理
        private void btnSave_Click(object sender, EventArgs e)
        {
            CustomerPaymentBLL processor = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            SheetOperation so = IsAdding ? SheetOperation.Create : SheetOperation.Modify;
            PerformOperation<CustomerPayment>(processor, so);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            CustomerPaymentBLL processor = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            PerformOperation<CustomerPayment>(processor, SheetOperation.Approve);
        }

        private void btnUndoApprove_Click(object sender, EventArgs e)
        {
            CustomerPaymentBLL processor = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            PerformOperation<CustomerPayment>(processor, SheetOperation.UndoApprove);
        }

        private void btnNullify_Click(object sender, EventArgs e)
        {
            CustomerPaymentBLL processor = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            PerformOperation<CustomerPayment>(processor, SheetOperation.Nullify);
        }
        #endregion

        #region 事件处理程序
        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMasterBase frm = null;
            frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var c = frm.SelectedItem as CompanyInfo;
                txtCustomer.Tag = c;
                txtCustomer.Text = c != null ? c.Name : string.Empty;
            }
        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            txtCustomer.Tag = null;
            txtCustomer.Text = string.Empty;
        }

        private void lnkAccout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAccountMaster frm = new FrmAccountMaster();
            frm.SearchCondition = new LJH.Inventory.BusinessModel.SearchCondition.AccountSearchCondition() { AccountTypes = new List<AccountType>() { AccountType.现金账号, AccountType.银行账号 } };
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var ac = frm.SelectedItem as Account;
                txtAccount.Text = ac.Name;
                txtAccount.Tag = ac;
            }
        }
        #endregion
    }
}
