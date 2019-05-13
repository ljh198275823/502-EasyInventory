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
using LJH.Inventory.UI.Forms.Sale;
using LJH.Inventory.UI.Forms.Purchase;
using LJH.Inventory.UI.Forms.General;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class Frm管理费用明细 : FrmSheetDetailBase
    {
        public Frm管理费用明细()
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
            if (txtAccount.Tag != null && (txtAccount.Tag as Account).Class == AccountType.无效)
            {
                MessageBox.Show("账号是无效账号,请先将账号设置成有效的账号!");
                return false;
            }
            if (txtAccount.Tag != null)
            {
                decimal amount = new AccountBLL(AppSettings.Current.ConnStr).GetRemain((txtAccount.Tag as Account).ID);
                if (amount < txtAmount.DecimalValue)
                {
                    MessageBox.Show("此账号余额不足");
                    return false;
                }
                if (dtPaidDate.IsNull)
                {
                    MessageBox.Show("没有填写到款日期");
                    dtPaidDate.Focus();
                    return false;
                }
            }
            if (txtSupplier.Tag == null && txtAccount.Tag == null)
            {
                MessageBox.Show("没有指定付款客户");
                return false;
            }
            if (string.IsNullOrEmpty(txt申请人.Text))
            {
                MessageBox.Show("没有指定申请人");
                return false;
            }
            if (rd直接付款.Checked)
            {
                if (txtAccount.Tag == null)
                {
                    MessageBox.Show("没有指定付款客户");
                    return false;
                }
                if (dtPaidDate.IsNull)
                {
                    MessageBox.Show("没有指定付款日期");
                    return false;
                }
                if ((txtAccount.Tag as Account).Class == AccountType.无效)
                {
                    MessageBox.Show("账号是无效账号,请先将账号设置成有效的账号!");
                    return false;
                }
                if (txtAccount.Tag != null)
                {
                    var ac = txtAccount.Tag as Account;
                    if (ac.Amount < txtAmount.DecimalValue)
                    {
                        MessageBox.Show("此账号余额不足");
                        return false;
                    }
                    if (dtPaidDate.IsNull)
                    {
                        MessageBox.Show("没有填写到款日期");
                        dtPaidDate.Focus();
                        return false;
                    }
                }
            }
            if (rd增加供应商应付款.Checked)
            {
                if (txtSupplier.Tag == null)
                {
                    MessageBox.Show("没有指定供应商");
                    return false;
                }
            }
            if (rd用于冲抵客户应收款.Checked)
            {
                if (txtCustomer.Tag == null)
                {
                    MessageBox.Show("没有指定客户");
                    return false;
                }
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
            if (!string.IsNullOrEmpty(UserSettings.Current.默认公司费用客户))
            {
                var sp = new CompanyBLL(AppSettings.Current.ConnStr).GetByID(UserSettings.Current.默认公司费用客户).QueryObject;
                txtSupplier.Text = sp != null ? sp.Name : null;
                txtSupplier.Tag = sp;
            }
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
                if (!string.IsNullOrEmpty(item.AccountID))
                {
                    rd直接付款.Checked = true;
                    Account ac = null;
                    ac = new AccountBLL(AppSettings.Current.ConnStr).GetByID(item.AccountID).QueryObject;
                    txtAccount.Text = ac != null ? ac.Name : null;
                    txtAccount.Tag = ac;
                    var temp = item.GetProperty(SheetNote.到款日期.ToString());
                    DateTime pd = item.SheetDate;
                    if (!string.IsNullOrEmpty(temp) && DateTime.TryParse(temp, out pd))
                    {
                        dtPaidDate.Value = pd;
                    }
                    else
                    {
                        dtPaidDate.IsNull = true;
                    }
                }
                else if (!string.IsNullOrEmpty(item.CustomerID))
                {
                    var c = new CompanyBLL(AppSettings.Current.ConnStr).GetByID(item.CustomerID).QueryObject;
                    if (c.ClassID == CompanyClass.Customer)
                    {
                        rd用于冲抵客户应收款.Checked = true;
                        txtCustomer.Tag = c;
                        txtCustomer.Text = c.Name;
                    }
                    else if (c.ClassID == CompanyClass.Supplier)
                    {
                        rd增加供应商应付款.Checked = true;
                        txtSupplier.Text = c != null ? c.Name : null;
                        txtSupplier.Tag = c;
                    }
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
            info.ClassID = CustomerPaymentType.管理费用;
            info.Amount = txtAmount.DecimalValue;
            info.SheetDate = dtSheetDate.Value;
            info.SetProperty("费用类别", txtCategory.Text);
            if (rd直接付款.Checked)
            {
                info.AccountID = (txtAccount.Tag as Account).ID;
                if (!dtPaidDate.IsNull) info.SetProperty(SheetNote.到款日期.ToString(), dtPaidDate.Value.ToString("yyyy-MM-dd"));
                info.CustomerID = string.Empty;
            }
            else if (rd增加供应商应付款.Checked)
            {
                info.AccountID = string.Empty;
                info.CustomerID = (txtSupplier.Tag as CompanyInfo).ID;
            }
            else
            {
                info.AccountID = string.Empty;
                info.CustomerID = (txtCustomer.Tag as CompanyInfo).ID;
            }
            info.SetProperty("申请人", txt申请人.Text);
            info.Memo = txtMemo.Text;
            return info;
        }

        protected override CommandResult AddItem(object item)
        {
            CustomerPaymentBLL bll = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            return bll.ProcessSheet(item as CustomerPayment, SheetOperation.新建, Operator.Current.Name, Operator.Current.ID);
        }

        protected override CommandResult UpdateItem(object item)
        {
            CustomerPaymentBLL bll = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            return bll.ProcessSheet(item as CustomerPayment, SheetOperation.修改, Operator.Current.Name, Operator.Current.ID);
        }

        protected override void ShowButtonState()
        {
            base.ShowButtonState(this.toolStrip1);
            btnSave.Enabled = IsAdding && btnSave.Enabled && Operator.Current.Permit(Permission.ExpenditureRecord, PermissionActions.Edit);
            string sheetID = null; //关联的收付款单号，如果有关联单号，只能从关联单上操作
            if (UpdatingItem != null) sheetID = (UpdatingItem as CustomerPayment).GetProperty(SheetNote.关联收付款单号.ToString ());
            btnApprove.Enabled = btnApprove.Enabled && Operator.Current.Permit(Permission.ExpenditureRecord, PermissionActions.Approve) && string.IsNullOrEmpty(sheetID);
            btnUndoApprove.Enabled = btnUndoApprove.Enabled && Operator.Current.Permit(Permission.ExpenditureRecord, PermissionActions.UndoApprove) && string.IsNullOrEmpty(sheetID);
            btnNullify.Enabled = btnNullify.Enabled && Operator.Current.Permit(Permission.ExpenditureRecord, PermissionActions.Nullify) && string.IsNullOrEmpty(sheetID);
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
            PerformOperation<CustomerPayment>(processor, IsAdding ? SheetOperation.新建 : SheetOperation.修改);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            CustomerPaymentBLL processor = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            PerformOperation<CustomerPayment>(processor, SheetOperation.审核);
        }

        private void btnUndoApprove_Click(object sender, EventArgs e)
        {
            CustomerPaymentBLL processor = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            PerformOperation<CustomerPayment>(processor, SheetOperation.取消审核);
        }

        private void btnNullify_Click(object sender, EventArgs e)
        {
            CustomerPaymentBLL processor = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            PerformOperation<CustomerPayment>(processor, SheetOperation.作废);
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

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            lbl大写.Text = LJH.GeneralLibrary.RMBHelper.NumGetStr((double)txtAmount.DecimalValue);
        }

        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var c = frm.SelectedItem as CompanyInfo;
                txtCustomer.Tag = c;
                txtCustomer.Text = c.Name;
            }
        }

        private void rd增加供应商应付款_CheckedChanged(object sender, EventArgs e)
        {
            lnkSupplier.Enabled = rd增加供应商应付款.Checked;
            txtSupplier.Enabled = rd增加供应商应付款.Checked;
        }

        private void rd直接付款_CheckedChanged(object sender, EventArgs e)
        {
            lnkAccout.Enabled = rd直接付款.Checked;
            txtAccount.Enabled = rd直接付款.Checked;
            dtPaidDate.Enabled = rd直接付款.Checked;
        }

        private void rd用于冲抵客户应收款_CheckedChanged(object sender, EventArgs e)
        {
            lnkCustomer.Enabled = rd用于冲抵客户应收款.Checked;
            txtCustomer.Enabled = rd用于冲抵客户应收款.Checked;
        }
    }
}
