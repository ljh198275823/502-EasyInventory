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
    public partial class Frm收付款流水明细 : FrmSheetDetailBase
    {
        public Frm收付款流水明细()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置收款或付款的客户
        /// </summary>
        public CompanyInfo Customer { get; set; }
        /// <summary>
        /// 获取或设置收款或付款类型
        /// </summary>
        public CustomerPaymentType PaymentType { get; set; }

        public string StackSheetID { get; set; }

        public decimal Amount { get; set; }
        #endregion

        #region 私有方法
        private void ShowAssigns()
        {
            ItemsGrid.Rows.Clear();
            if (UpdatingItem == null) return;
            List<AccountRecordAssign> assigns = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetAssigns(UpdatingItem as CustomerPayment).QueryObjects;
            if (assigns != null && assigns.Count > 0)
            {
                CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
                con.ReceivableIDS = assigns.Select(it => it.ReceivableID).ToList();
                List<CustomerReceivable> crs = (new CustomerReceivableBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
                if (crs != null && crs.Count > 0)
                {
                    foreach (AccountRecordAssign assign in assigns)
                    {
                        CustomerReceivable cr = crs.FirstOrDefault(it => it.ID == assign.ReceivableID);
                        int row = ItemsGrid.Rows.Add();
                        ItemsGrid.Rows[row].Tag = assign;
                        ItemsGrid.Rows[row].Cells["colSheetID"].Value = cr.SheetID;
                        if (cr.ClassID == CustomerReceivableType.SupplierReceivable)
                        {
                            var gg = cr.GetProperty("规格");
                            if (!string.IsNullOrEmpty(gg)) ItemsGrid.Rows[row].Cells["colSheetID"].Value = gg;
                        }
                        ItemsGrid.Rows[row].Cells["colClassID"].Value = CustomerReceivableTypeDescription.GetDescription(cr.ClassID);
                        ItemsGrid.Rows[row].Cells["colAssign"].Value = assign.Amount.Trim();
                    }
                }
                int rowTotal = ItemsGrid.Rows.Add();
                ItemsGrid.Rows[rowTotal].Cells["colSheetID"].Value = "合计";
                ItemsGrid.Rows[rowTotal].Cells["colAssign"].Value = assigns.Sum(item => item.Amount).Trim();
            }
        }
        #endregion

        #region 重写基类方法
        protected override void InitControls()
        {
            base.InitControls();
            txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
            this.Text = (PaymentType == CustomerPaymentType.客户收款) ? "客户付款流水" : "供应商付款流水";
            this.lnkCustomer.Text = (PaymentType == CustomerPaymentType.客户收款) ? "客户" : "供应商";
            lnkAccout.Text = (PaymentType == CustomerPaymentType.客户收款) ? "到款账号" : "付款账号";
            this.dtPaidDate.IsNull = true;
            if (Amount != 0)
            {
                txtAmount.DecimalValue = Amount;
                txtAmount.ForeColor = System.Drawing.Color.Red;
                txtAmount.Focus();
            }
            if (IsForView)
            {
                toolStrip1.Enabled = false;
                ItemsGrid.ReadOnly = true;
                ItemsGrid.ContextMenu = null;
                ItemsGrid.ContextMenuStrip = null;
            }
        }

        protected override bool CheckInput()
        {
            if (Customer == null && PaymentType != CustomerPaymentType.客户收款)
            {
                MessageBox.Show(PaymentType == CustomerPaymentType.客户收款 ? "客户不能为空" : "供应商不能为空");
                txtCustomer.Focus();
                return false;
            }
            if (txtAccount.Tag == null && PaymentType != CustomerPaymentType.客户收款)
            {
                MessageBox.Show("没有指定账号");
                return false;
            }
            if (PaymentType == CustomerPaymentType.客户收款 && Customer == null && txtAccount.Tag == null)
            {
                MessageBox.Show("客户和账号至少要指定一个");
                return false;
            }
            if (txtAmount.DecimalValue <= 0)
            {
                MessageBox.Show("金额不正确,不能小于零");
                txtAmount.Focus();
                return false;
            }
            if (dtPaidDate.IsNull && txtAccount.Tag != null)
            {
                MessageBox.Show("没有填写到款日期");
                dtPaidDate.Focus();
                return false;
            }
            if (PaymentType == CustomerPaymentType.供应商付款 && (txtAccount.Tag as Account).Class != AccountType.财务核算)
            {
                decimal amount = new AccountBLL(AppSettings.Current.ConnStr).GetRemain((txtAccount.Tag as Account).ID);
                if (amount < txtAmount.DecimalValue)
                {
                    MessageBox.Show("此账号余额不足");
                    return false;
                }
            }
            if (string.IsNullOrEmpty(txtPayer.Text))
            {
                MessageBox.Show("对方账号不能为空");
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
                dtSheetDate.Enabled = false;
                rd公账.Checked = item.PaymentMode == PaymentMode.公账;
                rd私账.Checked = item.PaymentMode == PaymentMode.私账;
                rd公账.Enabled = false;
                rd私账.Enabled = false;
                txtAmount.DecimalValue = item.Amount;
                txtAmount.Enabled = false;
                txtPayer.Text = item.Payer;
                txtPayer.Enabled = false;
                if (!string.IsNullOrEmpty(item.CustomerID)) Customer = (new CompanyBLL(AppSettings.Current.ConnStr)).GetByID(item.CustomerID).QueryObject;
                txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
                lnkCustomer.Enabled = Customer == null;
                txtCustomer.Enabled = Customer == null;
                Account ac = null;
                if (!string.IsNullOrEmpty(item.AccountID)) ac = (new AccountBLL(AppSettings.Current.ConnStr)).GetByID(item.AccountID).QueryObject;
                txtAccount.Text = ac != null ? ac.Name : string.Empty;
                txtAccount.Tag = ac;
                lnkAccout.Enabled = ac == null;
                txtAccount.Enabled = ac == null;
                dtPaidDate.Enabled = ac == null;
                txtMemo.Text = item.Memo;
                var temp = item.GetProperty("到款日期");
                DateTime pd = item.SheetDate;
                if (!string.IsNullOrEmpty(temp) && DateTime.TryParse(temp, out pd)) dtPaidDate.Value = pd;
                ShowAssigns();
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
                info.ClassID = PaymentType;
                info.ID = txtID.Text == _AutoCreate ? string.Empty : txtID.Text.Trim();
            }
            else
            {
                info = UpdatingItem as CustomerPayment;
            }
            info.SheetDate = dtSheetDate.Value;
            if (rd公账.Checked) info.PaymentMode = PaymentMode.公账;
            if (rd私账.Checked) info.PaymentMode = PaymentMode.私账;
            info.Amount = txtAmount.DecimalValue;
            var ac = txtAccount.Tag as Account;
            info.AccountID = ac != null ? ac.ID : string.Empty;
            info.Payer = txtPayer.Text;
            info.CustomerID = Customer != null ? Customer.ID : CompanyInfo.财务上不存在的客户;
            if (!string.IsNullOrEmpty(StackSheetID)) info.StackSheetID = StackSheetID;
            if (!dtPaidDate.IsNull) info.SetProperty("到款日期", dtPaidDate.Value.ToString("yyyy-MM-dd"));
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

            if (PaymentType == CustomerPaymentType.客户收款)
            {
                btnSave.Enabled = btnSave.Enabled && Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.Edit) && (cp == null || string.IsNullOrEmpty(cp.AccountID) || Customer ==null);
                AccountRecord ac = null;
                if (cp != null) ac = new AccountRecordBLL(AppSettings.Current.ConnStr).GetRecord(cp.ID, cp.ClassID).QueryObject;
                btnAssign.Enabled = cp != null && (cp.State == SheetState.新增 || cp.State == SheetState.已审批) && !string.IsNullOrEmpty(cp.AccountID) && ac != null && ac.Remain > 0;
                btnApprove.Enabled = btnApprove.Enabled && Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.Approve);
                btnUndoApprove.Enabled = btnUndoApprove.Enabled && Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.UndoApprove);
                btnNullify.Enabled = btnNullify.Enabled && Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.Nullify);
            }
            else if (PaymentType == CustomerPaymentType.供应商付款)
            {
                btnSave.Enabled = IsAdding && btnSave.Enabled && Operator.Current.Permit(Permission.SupplierPayment, PermissionActions.Edit);
                AccountRecord ac = null;
                if (cp != null) ac = new AccountRecordBLL(AppSettings.Current.ConnStr).GetRecord(cp.ID, cp.ClassID).QueryObject;
                btnAssign.Enabled = cp != null && (cp.State == SheetState.新增 || cp.State == SheetState.已审批) && ac != null && ac.Remain > 0;
                btnApprove.Enabled = btnApprove.Enabled && Operator.Current.Permit(Permission.SupplierPayment, PermissionActions.Approve);
                btnUndoApprove.Enabled = btnUndoApprove.Enabled && Operator.Current.Permit(Permission.SupplierPayment, PermissionActions.UndoApprove);
                btnNullify.Enabled = btnNullify.Enabled && Operator.Current.Permit(Permission.SupplierPayment, PermissionActions.Nullify);
            }
            else
            {
                btnSave.Enabled = false;
                btnAssign.Enabled = false;
                btnApprove.Enabled = false;
                btnUndoApprove.Enabled = false;
                btnNullify.Enabled = false;
            }
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            if (PaymentType == CustomerPaymentType.客户收款)
            {
                mnu_AttachmentAdd.Enabled = mnu_AttachmentAdd.Enabled && Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.EditAttachment);
                mnu_AttachmentDelete.Enabled = mnu_AttachmentDelete.Enabled && Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.EditAttachment);
                mnu_AttachmentOpen.Enabled = mnu_AttachmentOpen.Enabled && Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.ShowAttachment);
                mnu_AttachmentSaveAs.Enabled = mnu_AttachmentSaveAs.Enabled && Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.ShowAttachment);
            }
            else if (PaymentType == CustomerPaymentType.供应商付款)
            {
                mnu_AttachmentAdd.Enabled = mnu_AttachmentAdd.Enabled && Operator.Current.Permit(Permission.SupplierPayment, PermissionActions.EditAttachment);
                mnu_AttachmentDelete.Enabled = mnu_AttachmentDelete.Enabled && Operator.Current.Permit(Permission.SupplierPayment, PermissionActions.EditAttachment);
                mnu_AttachmentOpen.Enabled = mnu_AttachmentOpen.Enabled && Operator.Current.Permit(Permission.SupplierPayment, PermissionActions.ShowAttachment);
                mnu_AttachmentSaveAs.Enabled = mnu_AttachmentSaveAs.Enabled && Operator.Current.Permit(Permission.SupplierPayment, PermissionActions.ShowAttachment);
            }
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
            var cp = UpdatingItem as CustomerPayment;
            if (so == SheetOperation.Create && !string.IsNullOrEmpty(StackSheetID) && !string.IsNullOrEmpty(cp.AccountID)) //如果已经是确定收款是用于哪个出入库单了, 新建时直接核销
            {
                new CustomerPaymentBLL(AppSettings.Current.ConnStr).核销(UpdatingItem as CustomerPayment);
                this.Close();
            }
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

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (UpdatingItem != null)
            {
                var cp = UpdatingItem as CustomerPayment;
                var ar = new AccountRecordBLL(AppSettings.Current.ConnStr).GetRecord(cp.ID, cp.ClassID).QueryObject;
                if (ar != null)
                {
                    if (ar.ClassID == CustomerPaymentType.供应商付款)
                    {
                        FrmSupplierPaymentAssign frm = new FrmSupplierPaymentAssign();
                        frm.AccountRecord = ar;
                        this.Close();
                        frm.ShowDialog();
                    }
                    else
                    {
                        FrmPaymentAssign frm = new FrmPaymentAssign();
                        frm.AccountRecord = ar;
                        this.Close();
                        frm.ShowDialog();
                    }
                }
            }
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
            if (PaymentType == CustomerPaymentType.客户收款)
            {
                frm = new FrmCustomerMaster();
            }
            else
            {
                frm = new FrmSupplierMaster();
            }
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Customer = frm.SelectedItem as CompanyInfo;
                txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
            }
        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            txtCustomer.Text = string.Empty;
            Customer = null;
        }

        private void mnu_UndoAssign_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> delRows = new List<DataGridViewRow>();
            if (ItemsGrid.SelectedRows != null && ItemsGrid.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否要取消此核销项?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in ItemsGrid.SelectedRows)
                    {
                        AccountRecordAssign assign = row.Tag as AccountRecordAssign;
                        CommandResult ret = (new AccountRecordAssignBLL(AppSettings.Current.ConnStr)).UndoAssign(assign);
                        if (ret.Result == ResultCode.Successful) delRows.Add(row);
                    }
                }
            }
            delRows.ForEach(it => ItemsGrid.Rows.Remove(it));
            UpdatingItem = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetByID((UpdatingItem as CustomerPayment).ID).QueryObject;
            OnItemUpdated(new ItemUpdatedEventArgs(UpdatingItem));
            ShowButtonState();
        }

        private void lnkAccout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAccountMaster frm = new FrmAccountMaster();
            frm.SearchCondition = new LJH.Inventory.BusinessModel.SearchCondition.AccountSearchCondition()
            {
                IsPublic = rd公账.Checked,
                AccountTypes = new List<AccountType>() { AccountType.现金账号, AccountType.银行账号, AccountType.财务核算 }
            };
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var ac = frm.SelectedItem as Account;
                txtAccount.Text = ac.Name;
                txtAccount.Tag = ac;
                dtPaidDate.Enabled = true;
            }
        }

        private void txtAccount_DoubleClick(object sender, EventArgs e)
        {
            txtAccount.Text = string.Empty;
            txtAccount.Tag = null;
            dtPaidDate.Enabled = false;
        }
        #endregion
    }
}
