﻿using System;
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
    public partial class Frm退款 : FrmSheetDetailBase
    {
        public Frm退款()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置收款或付款的客户
        /// </summary>
        public CompanyInfo Customer { get; set; }
        #endregion

        #region 重写基类方法
        protected override void InitControls()
        {
            base.InitControls();
            if (IsForView) toolStrip1.Enabled = false;
            txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
            dtPaidDate.IsNull = true;
        }

        protected override bool CheckInput()
        {
            if (Customer == null)
            {
                MessageBox.Show("客户不能为空");
                txtCustomer.Focus();
                return false;
            }
            if (txtAccount.Tag == null && !IsAdding)
            {
                MessageBox.Show("没有指定账号");
            }
            if (txtAccount.Tag != null)
            {
                decimal amount = new AccountBLL(AppSettings.Current.ConnStr).GetRemain((txtAccount.Tag as Account).ID);
                if (amount < txtAmount.DecimalValue)
                {
                    MessageBox.Show("此账号余额不足");
                    return false;
                }
            }
            if (txtAmount.DecimalValue <= 0)
            {
                MessageBox.Show("金额不正确,不能小于零");
                txtAmount.Focus();
                return false;
            }
            if (dtPaidDate.IsNull)
            {
                MessageBox.Show("没有填写到款日期");
                dtPaidDate.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPayer.Text))
            {
                MessageBox.Show("对方账号不能为空");
                return false;
            }
            if (txt手续费类别.Tag != null && txt手续费.DecimalValue <= 0)
            {
                MessageBox.Show("请输入手续费");
                return false;
            }
            if (!rd计为管理费用.Checked && !rd增加客户应收.Checked)
            {
                MessageBox.Show("请指定退款是退回到应收款还是计为管理费用");
                return false;
            }
            if (rd计为管理费用.Checked && txt管理费用类别.Tag == null)
            {
                MessageBox.Show("计为管理费用时要指定管理费用类别");
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
                Customer = (new CompanyBLL(AppSettings.Current.ConnStr)).GetByID(item.CustomerID).QueryObject;
                txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
                chk公账.Checked = item.PaymentMode == PaymentMode.公账;
                Account ac = null;
                if (!string.IsNullOrEmpty(item.AccountID)) ac = (new AccountBLL(AppSettings.Current.ConnStr)).GetByID(item.AccountID).QueryObject;
                txtAccount.Text = ac != null ? ac.Name : string.Empty;
                txtAccount.Tag = ac;
                txtPayer.Text = item.Payer;
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
                if (!string.IsNullOrEmpty(item.GetProperty(SheetNote.手续费类别.ToString())))
                {
                    txt手续费类别.Text = item.GetProperty(SheetNote.手续费类别.ToString());
                    txt手续费.DecimalValue = decimal.Parse(item.GetProperty(SheetNote.手续费金额.ToString ()));
                }
                var 费用类别 = item.GetProperty(SheetNote.费用类别.ToString ());
                if (string.IsNullOrEmpty(费用类别))
                {
                    rd增加客户应收.Checked = true;
                    chk公账.Checked = item.PaymentMode == PaymentMode.公账;
                }
                else
                {
                    rd计为管理费用.Checked = true;
                    var category = new ExpenditureTypeBLL(AppSettings.Current.ConnStr).GetByID(费用类别).QueryObject;
                    txt管理费用类别.Tag = category;
                    txt管理费用类别.Text = category != null ? category.Name : null;
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
                info.ClassID = CustomerPaymentType.客户退款;
                info.ID = txtID.Text == _AutoCreate ? string.Empty : txtID.Text.Trim();
            }
            else
            {
                info = UpdatingItem as CustomerPayment;
            }
            info.PaymentMode = chk公账.Checked ? PaymentMode.公账 : PaymentMode.私账;
            info.SheetDate = dtSheetDate.Value;
            info.Amount = txtAmount.DecimalValue;
            info.CustomerID = Customer.ID;
            var ac = txtAccount.Tag as Account;
            info.AccountID = ac != null ? ac.ID : null;
            info.Payer = txtPayer.Text;
            info.SetProperty("到款日期", dtPaidDate.Value.ToString("yyyy-MM-dd"));
            if (txt手续费类别.Tag != null)
            {
                info.SetProperty(SheetNote.手续费类别.ToString(), (txt手续费类别.Tag as ExpenditureType).ID);
                info.SetProperty(SheetNote.手续费金额.ToString(), txt手续费.Text);
            }
            if (rd计为管理费用.Checked) info.SetProperty(SheetNote.费用类别.ToString(), (txt管理费用类别.Tag as ExpenditureType).ID);
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
            CustomerPayment cp = UpdatingItem != null ? UpdatingItem as CustomerPayment : null;
            btnSave.Enabled = IsAdding && btnSave.Enabled && Operator.Current.Permit(Permission.退款, PermissionActions.Edit);
            btnApprove.Enabled = btnApprove.Enabled && Operator.Current.Permit(Permission.退款, PermissionActions.Approve);
            btnUndoApprove.Enabled = btnUndoApprove.Enabled && Operator.Current.Permit(Permission.退款, PermissionActions.UndoApprove);
            btnNullify.Enabled = btnNullify.Enabled && Operator.Current.Permit(Permission.退款, PermissionActions.Nullify);
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            mnu_AttachmentAdd.Enabled = mnu_AttachmentAdd.Enabled && Operator.Current.Permit(Permission.退款, PermissionActions.EditAttachment);
            mnu_AttachmentDelete.Enabled = mnu_AttachmentDelete.Enabled && Operator.Current.Permit(Permission.退款, PermissionActions.EditAttachment);
            mnu_AttachmentOpen.Enabled = mnu_AttachmentOpen.Enabled && Operator.Current.Permit(Permission.退款, PermissionActions.ShowAttachment);
            mnu_AttachmentSaveAs.Enabled = mnu_AttachmentSaveAs.Enabled && Operator.Current.Permit(Permission.退款, PermissionActions.ShowAttachment);
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
            SheetOperation so = IsAdding ? SheetOperation.新建 : SheetOperation.修改;
            PerformOperation<CustomerPayment>(processor, so);
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
        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMasterBase frm = null;
            frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Customer = frm.SelectedItem as CompanyInfo;
                txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
            }
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

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            lbl大写.Text = RMBHelper.NumGetStr((double)txtAmount.DecimalValue);
        }
    }
}
