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
using LJH.Inventory.UI.Forms.Purchase;
using LJH.Inventory.UI.Forms.General;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class Frm管理费用退款 : FrmSheetDetailBase
    {
        public Frm管理费用退款()
        {
            InitializeComponent();
        }

        #region 公共属性
        public Account Account { get; set; }
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
            if (string.IsNullOrEmpty(txtCategory.Text))
            {
                MessageBox.Show("没有指定费用类别");
                return false;
            }
            if (dtPaidDate.IsNull)
            {
                MessageBox.Show("没有填写到款日期");
                dtPaidDate.Focus();
                return false;
            }
            if (txtAccount.Tag == null)
            {
                MessageBox.Show("没有指定退款账号");
                return false;
            }
            if (txtAccount.Tag != null && (txtAccount.Tag as Account).Class == AccountType.无效)
            {
                MessageBox.Show("账号是无效账号,请先将账号设置成有效的账号!");
                return false;
            }
            if (string.IsNullOrEmpty(txt申请人.Text))
            {
                MessageBox.Show("没有指定申请人");
                return false;
            }
            return true;
        }

        protected override void InitControls()
        {
            dtSheetDate.Value = DateTime.Today;
            txtAccount.Text = Account != null ? Account.Name : null;
            txtAccount.Tag = Account;
            if (IsForView) toolStrip1.Enabled = false;
            this.dtPaidDate.IsNull = true;
        }

        protected override void ItemShowing()
        {
            CustomerPayment item = UpdatingItem as CustomerPayment;
            if (item != null)
            {
                txtSheetNo.Text = item.ID;
                dtSheetDate.Value = item.SheetDate;
                txtAmount.DecimalValue = item.Amount;
                txtCategory.Text = item.GetProperty("费用类别");
                if (!string.IsNullOrEmpty(item.CustomerID))
                {
                    var c = new CompanyBLL(AppSettings.Current.ConnStr).GetByID(item.CustomerID).QueryObject;
                    txtSupplier.Text = c != null ? c.Name : null;
                    txtSupplier.Tag = c;
                }
                else
                {
                    txtSupplier.Text = null;
                    txtSupplier.Tag = null;
                }
                if (!string.IsNullOrEmpty(item.AccountID))
                {
                    Account ac = null;
                    ac = new AccountBLL(AppSettings.Current.ConnStr).GetByID(item.AccountID).QueryObject;
                    txtAccount.Text = ac != null ? ac.Name : null;
                    txtAccount.Tag = ac;
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
                txt申请人.Text = item.GetProperty("申请人");
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
                if (txtSheetNo.Text == _AutoCreate) txtSheetNo.Text = string.Empty;
            }
            else
            {
                info = UpdatingItem as CustomerPayment;
            }
            info.ClassID = CustomerPaymentType.管理费用退款;
            info.Amount = txtAmount.DecimalValue;
            info.SheetDate = dtSheetDate.Value;
            info.SetProperty("费用类别", txtCategory.Text);
            if (txtAccount.Tag != null) info.AccountID = (txtAccount.Tag as Account).ID;
            else info.AccountID = string.Empty;// 账号不能为NULL，所以这里设置成空字符吧
            if (txtSupplier.Tag != null) info.CustomerID = (txtSupplier.Tag as CompanyInfo).ID;
            info.SetProperty("申请人", txt申请人.Text);
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
            btnSave.Enabled = IsAdding && btnSave.Enabled && Operator.Current.Permit(Permission.ExpenditureRecord, PermissionActions.Edit);
            btnApprove.Enabled = btnApprove.Enabled && Operator.Current.Permit(Permission.ExpenditureRecord, PermissionActions.Approve);
            btnUndoApprove.Enabled = btnUndoApprove.Enabled && Operator.Current.Permit(Permission.ExpenditureRecord, PermissionActions.UndoApprove);
            btnNullify.Enabled = btnNullify.Enabled && Operator.Current.Permit(Permission.ExpenditureRecord, PermissionActions.Nullify);
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
            PerformOperation<CustomerPayment>(processor, IsAdding ? SheetOperation.Create : SheetOperation.Modify);
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
        private void lnkCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frm管理费用类别 frm = new Frm管理费用类别();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var Category = frm.SelectedItem as ExpenditureType;
                txtCategory.Text = Category != null ? Category.Name : string.Empty;
            }
        }

        private void txtCategory_DoubleClick(object sender, EventArgs e)
        {
            txtCategory.Text = string.Empty;
        }

        private void lnkSupplier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSupplierMaster frm = new FrmSupplierMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var c = frm.SelectedItem as CompanyInfo;
                txtSupplier.Text = c != null ? c.Name : string.Empty;
                txtSupplier.Tag = c;
            }
        }

        private void txtSupplier_DoubleClick(object sender, EventArgs e)
        {
            txtSupplier.Text = string.Empty;
            txtSupplier.Tag = null;
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

        private void txtAccount_DoubleClick(object sender, EventArgs e)
        {
            txtAccount.Tag = null;
            txtAccount.Text = null;
        }
        #endregion
    }
}
