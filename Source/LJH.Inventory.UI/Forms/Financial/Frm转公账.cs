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
    public partial class Frm转公账 : FrmSheetDetailBase
    {
        public Frm转公账()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置收款或付款的客户
        /// </summary>
        public CompanyInfo Customer { get; set; }
        #endregion

        #region 私有方法
        #endregion

        #region 重写基类方法
        protected override void InitControls()
        {
            base.InitControls();
            txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
            if (IsForView)
            {
                toolStrip1.Enabled = false;
            }
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
            if (txtAmount.DecimalValue <= 0)
            {
                MessageBox.Show("金额不正确,不能小于零");
                txtAmount.Focus();
                return false;
            }
            if (txtPayer.Tag != null)
            {
                decimal amount = new AccountBLL(AppSettings.Current.ConnStr).GetRemain((txtPayer.Tag as Account).ID);
                if (amount < txtAmount.DecimalValue)
                {
                    MessageBox.Show("此账号余额不足");
                    return false;
                }
            }
            if (txtPayer.Tag == null)
            {
                MessageBox.Show("对方账号不能为空");
                return false;
            }
            if ((txtAccount.Tag as Account).ID == (txtPayer.Tag as Account).ID)
            {
                MessageBox.Show("输入账号和转出账号为同一个账号");
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
                Customer = (new CompanyBLL(AppSettings.Current.ConnStr)).GetByID(item.CustomerID).QueryObject;
                txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
                Account ac = null;
                if (!string.IsNullOrEmpty(item.AccountID)) ac = (new AccountBLL(AppSettings.Current.ConnStr)).GetByID(item.AccountID).QueryObject;
                txtAccount.Text = ac != null ? ac.Name : string.Empty;
                txtAccount.Tag = ac;
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
                info.ClassID = CustomerPaymentType.转公账;
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
            info.Payer = txtPayer.Text;
            info.CustomerID = Customer != null ? Customer.ID : null;
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
            btnSave.Enabled = IsAdding && btnSave.Enabled && Operator.Current.Permit(Permission.转账, PermissionActions.Edit);
            AccountRecord ac = null;
            if (cp != null) ac = new AccountRecordBLL(AppSettings.Current.ConnStr).GetRecord(cp.ID, CustomerPaymentType.转账入).QueryObject;
            btnApprove.Enabled = btnApprove.Enabled && Operator.Current.Permit(Permission.转账, PermissionActions.Approve);
            btnUndoApprove.Enabled = btnUndoApprove.Enabled && Operator.Current.Permit(Permission.转账, PermissionActions.UndoApprove);
            btnNullify.Enabled = btnNullify.Enabled && Operator.Current.Permit(Permission.转账, PermissionActions.Nullify);
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            mnu_AttachmentAdd.Enabled = mnu_AttachmentAdd.Enabled && Operator.Current.Permit(Permission.转账, PermissionActions.EditAttachment);
            mnu_AttachmentDelete.Enabled = mnu_AttachmentDelete.Enabled && Operator.Current.Permit(Permission.转账, PermissionActions.EditAttachment);
            mnu_AttachmentOpen.Enabled = mnu_AttachmentOpen.Enabled && Operator.Current.Permit(Permission.转账, PermissionActions.ShowAttachment);
            mnu_AttachmentSaveAs.Enabled = mnu_AttachmentSaveAs.Enabled && Operator.Current.Permit(Permission.转账, PermissionActions.ShowAttachment);
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
            List<AccountRecordAssign> assigns = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetAssigns((UpdatingItem as CustomerPayment).ID).QueryObjects;
            if (assigns != null && assigns.Count > 0)
            {
                string msg = "\"取消审核\"的操作会删除此单的所有核销项删除，是否继续?";
                if (MessageBox.Show(msg, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            }
            CustomerPaymentBLL processor = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            PerformOperation<CustomerPayment>(processor, SheetOperation.UndoApprove);

            UpdatingItem = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetByID((UpdatingItem as CustomerPayment).ID).QueryObject;
            ItemShowing();
            OnItemUpdated(new ItemUpdatedEventArgs(UpdatingItem));
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (UpdatingItem != null)
            {
                var cp = UpdatingItem as CustomerPayment;
                var ar = new AccountRecordBLL(AppSettings.Current.ConnStr).GetRecord(cp.ID, cp.ClassID).QueryObject;
                if (ar != null)
                {
                    FrmPaymentAssign frm = new FrmPaymentAssign();
                    frm.AccountRecord = ar;
                    this.Close();
                    frm.ShowDialog();
                }
            }
        }

        private void btnNullify_Click(object sender, EventArgs e)
        {
            List<AccountRecordAssign> assigns = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetAssigns((UpdatingItem as CustomerPayment).ID).QueryObjects;
            if (assigns != null && assigns.Count > 0)
            {
                string msg = "\"作废\"的操作会删除此单的所有核销项删除，是否继续?";
                if (MessageBox.Show(msg, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            }

            CustomerPaymentBLL processor = new CustomerPaymentBLL(AppSettings.Current.ConnStr);
            PerformOperation<CustomerPayment>(processor, SheetOperation.Nullify);

            UpdatingItem = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetByID((UpdatingItem as CustomerPayment).ID).QueryObject;
            ItemShowing();
            OnItemUpdated(new ItemUpdatedEventArgs(UpdatingItem));
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
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ForSelect = true;
            frm.Ispublic = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var ac = frm.SelectedItem as Account;
                txtAccount.Text = ac.Name;
                txtAccount.Tag = ac;
            }
        }

        private void lnk转出账号_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAccountMaster frm = new FrmAccountMaster();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var ac = frm.SelectedItem as Account;
                txtPayer.Text = ac != null ? ac.Name : null;
                txtPayer.Tag = ac;
            }
        }
        #endregion

        
    }
}
