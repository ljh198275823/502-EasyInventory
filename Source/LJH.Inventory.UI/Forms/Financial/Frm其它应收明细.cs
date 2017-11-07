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
    public partial class Frm其它应收明细 : FrmSheetDetailBase
    {
        public Frm其它应收明细()
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
        public CustomerReceivableType ReceivableType { get; set; }

        public string StackinSheetID { get; set; }

        public decimal Amount { get; set; }
        #endregion

        #region 重写基类方法
        protected override void InitControls()
        {
            base.InitControls();
            txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
            if (ReceivableType == CustomerReceivableType.CustomerReceivable)
            {
                this.Text = "客户应收款";
                this.lnkCustomer.Text = "客户";
            }
            else if (ReceivableType == CustomerReceivableType.CustomerTax )
            {
                this.Text = "客户应开发票";
                this.lnkCustomer.Text = "客户";
            }
            else if (ReceivableType == CustomerReceivableType.SupplierReceivable)
            {
                this.Text = "供应商应付款";
                this.lnkCustomer.Text = "供应商";
            }
            else if (ReceivableType == CustomerReceivableType.SupplierTax)
            {
                this.Text ="供应商应开发票";
                this.lnkCustomer.Text = "供应商";
            }
            if (Amount != 0)
            {
                txtAmount.DecimalValue = Amount;
                txtAmount.ForeColor = System.Drawing.Color.Red;
                txtAmount.Focus();
            }
            if (IsForView)
            {
                toolStrip1.Enabled = false;
            }
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            if (ReceivableType == CustomerReceivableType.CustomerReceivable)
            {
                mnu_AttachmentAdd.Enabled = mnu_AttachmentAdd.Enabled && Operator.Current.Permit(Permission.CustomerReceivable, PermissionActions.EditAttachment);
                mnu_AttachmentDelete.Enabled = mnu_AttachmentDelete.Enabled && Operator.Current.Permit(Permission.CustomerReceivable, PermissionActions.EditAttachment);
                mnu_AttachmentOpen.Enabled = mnu_AttachmentOpen.Enabled && Operator.Current.Permit(Permission.CustomerReceivable, PermissionActions.ShowAttachment);
                mnu_AttachmentSaveAs.Enabled = mnu_AttachmentSaveAs.Enabled && Operator.Current.Permit(Permission.CustomerReceivable, PermissionActions.ShowAttachment);
            }
            else if (ReceivableType == CustomerReceivableType.CustomerTax)
            {
                mnu_AttachmentAdd.Enabled = mnu_AttachmentAdd.Enabled && Operator.Current.Permit(Permission.CustomerTax, PermissionActions.EditAttachment);
                mnu_AttachmentDelete.Enabled = mnu_AttachmentDelete.Enabled && Operator.Current.Permit(Permission.CustomerTax, PermissionActions.EditAttachment);
                mnu_AttachmentOpen.Enabled = mnu_AttachmentOpen.Enabled && Operator.Current.Permit(Permission.CustomerTax, PermissionActions.ShowAttachment);
                mnu_AttachmentSaveAs.Enabled = mnu_AttachmentSaveAs.Enabled && Operator.Current.Permit(Permission.CustomerTax, PermissionActions.ShowAttachment);
            }
            else if (ReceivableType == CustomerReceivableType.SupplierReceivable)
            {
                mnu_AttachmentAdd.Enabled = mnu_AttachmentAdd.Enabled && Operator.Current.Permit(Permission.SupplierReceivable, PermissionActions.EditAttachment);
                mnu_AttachmentDelete.Enabled = mnu_AttachmentDelete.Enabled && Operator.Current.Permit(Permission.SupplierReceivable, PermissionActions.EditAttachment);
                mnu_AttachmentOpen.Enabled = mnu_AttachmentOpen.Enabled && Operator.Current.Permit(Permission.SupplierReceivable, PermissionActions.ShowAttachment);
                mnu_AttachmentSaveAs.Enabled = mnu_AttachmentSaveAs.Enabled && Operator.Current.Permit(Permission.SupplierReceivable, PermissionActions.ShowAttachment);
            }
            else if (ReceivableType == CustomerReceivableType.SupplierTax)
            {
                mnu_AttachmentAdd.Enabled = mnu_AttachmentAdd.Enabled && Operator.Current.Permit(Permission.SupplierTax, PermissionActions.EditAttachment);
                mnu_AttachmentDelete.Enabled = mnu_AttachmentDelete.Enabled && Operator.Current.Permit(Permission.SupplierTax, PermissionActions.EditAttachment);
                mnu_AttachmentOpen.Enabled = mnu_AttachmentOpen.Enabled && Operator.Current.Permit(Permission.SupplierTax, PermissionActions.ShowAttachment);
                mnu_AttachmentSaveAs.Enabled = mnu_AttachmentSaveAs.Enabled && Operator.Current.Permit(Permission.SupplierTax, PermissionActions.ShowAttachment);
            }
        }

        protected override bool CheckInput()
        {
            if (Customer == null)
            {
                MessageBox.Show(ReceivableType == CustomerReceivableType.CustomerReceivable ? "客户不能为空" : "供应商不能为空");
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
            OtherReceivableSheet item = UpdatingItem as OtherReceivableSheet;
            if (item != null)
            {
                this.txtID.Text = item.ID;
                this.txtID.Enabled = false;
                lnkCustomer.Enabled = false;
                dtSheetDate.Value = item.SheetDate;
                txtAmount.DecimalValue = item.Amount;
                Customer = (new CompanyBLL(AppSettings.Current.ConnStr)).GetByID(item.CustomerID).QueryObject;
                txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
                txtMemo.Text = item.Memo;
                ShowOperations(item.ID, item.DocumentType, dataGridView1);
                ShowAttachmentHeaders(item.ID, item.DocumentType, this.gridAttachment);
                ShowButtonState();
            }
        }

        protected override object GetItemFromInput()
        {
            OtherReceivableSheet info = null;
            if (UpdatingItem == null)
            {
                info = new OtherReceivableSheet();
                info.ClassID = ReceivableType;
                info.ID = txtID.Text == _AutoCreate ? string.Empty : txtID.Text.Trim();
            }
            else
            {
                info = UpdatingItem as OtherReceivableSheet;
            }
            info.SheetDate = dtSheetDate.Value;
            info.Amount = txtAmount.DecimalValue;
            info.CustomerID = Customer != null ? Customer.ID : null;
            if (!string.IsNullOrEmpty(StackinSheetID)) info.StackinSheetID = StackinSheetID;
            info.Memo = txtMemo.Text;
            return info;
        }

        protected override CommandResult AddItem(object item)
        {
            OtherReceivableSheetBLL bll = new OtherReceivableSheetBLL(AppSettings.Current.ConnStr);
            return bll.ProcessSheet(item as OtherReceivableSheet, SheetOperation.Create, Operator.Current.Name, Operator.Current.ID);
        }

        protected override CommandResult UpdateItem(object item)
        {
            OtherReceivableSheetBLL bll = new OtherReceivableSheetBLL(AppSettings.Current.ConnStr);
            return bll.ProcessSheet(item as OtherReceivableSheet, SheetOperation.Modify, Operator.Current.Name, Operator.Current.ID);
        }

        protected override void ShowButtonState()
        {
            base.ShowButtonState(this.toolStrip1);
            OtherReceivableSheet cp = UpdatingItem != null ? UpdatingItem as OtherReceivableSheet : null;

            if (ReceivableType == CustomerReceivableType.CustomerReceivable)
            {
                btnSave.Enabled = btnSave.Enabled && Operator.Current.Permit(Permission.CustomerReceivable, PermissionActions.Edit);
                btnApprove.Enabled = btnApprove.Enabled && Operator.Current.Permit(Permission.CustomerReceivable, PermissionActions.Approve);
                btnUndoApprove.Enabled = btnUndoApprove.Enabled && Operator.Current.Permit(Permission.CustomerReceivable, PermissionActions.UndoApprove);
                btnNullify.Enabled = btnNullify.Enabled && Operator.Current.Permit(Permission.CustomerReceivable, PermissionActions.Nullify);
            }
            else if (ReceivableType == CustomerReceivableType.CustomerTax)
            {
                btnSave.Enabled = btnSave.Enabled && Operator.Current.Permit(Permission.CustomerTax, PermissionActions.Edit);
                btnApprove.Enabled = btnApprove.Enabled && Operator.Current.Permit(Permission.CustomerTax, PermissionActions.Approve);
                btnUndoApprove.Enabled = btnUndoApprove.Enabled && Operator.Current.Permit(Permission.CustomerTax, PermissionActions.UndoApprove);
                btnNullify.Enabled = btnNullify.Enabled && Operator.Current.Permit(Permission.CustomerTax, PermissionActions.Nullify);
            }
            else if (ReceivableType == CustomerReceivableType.SupplierReceivable)
            {
                btnSave.Enabled = btnSave.Enabled && Operator.Current.Permit(Permission.SupplierReceivable, PermissionActions.Edit);
                btnApprove.Enabled = btnApprove.Enabled && Operator.Current.Permit(Permission.SupplierReceivable, PermissionActions.Approve);
                btnUndoApprove.Enabled = btnUndoApprove.Enabled && Operator.Current.Permit(Permission.SupplierReceivable, PermissionActions.UndoApprove);
                btnNullify.Enabled = btnNullify.Enabled && Operator.Current.Permit(Permission.SupplierReceivable, PermissionActions.Nullify);
            }
            else if (ReceivableType == CustomerReceivableType.SupplierTax)
            {
                btnSave.Enabled = btnSave.Enabled && Operator.Current.Permit(Permission.SupplierTax, PermissionActions.Edit);
                btnApprove.Enabled = btnApprove.Enabled && Operator.Current.Permit(Permission.SupplierTax, PermissionActions.Approve);
                btnUndoApprove.Enabled = btnUndoApprove.Enabled && Operator.Current.Permit(Permission.SupplierTax, PermissionActions.UndoApprove);
                btnNullify.Enabled = btnNullify.Enabled && Operator.Current.Permit(Permission.SupplierTax, PermissionActions.Nullify);
            }
            else
            {
                btnSave.Enabled = false;
                btnApprove.Enabled = false;
                btnUndoApprove.Enabled = false;
                btnNullify.Enabled = false;
            }
        }
        #endregion

        #region 与附件操作相关的方法和事件处理程序
        private void mnu_AttachmentAdd_Click(object sender, EventArgs e)
        {
            OtherReceivableSheet item = UpdatingItem as OtherReceivableSheet;
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
            OtherReceivableSheetBLL processor = new OtherReceivableSheetBLL(AppSettings.Current.ConnStr);
            SheetOperation so = IsAdding ? SheetOperation.Create : SheetOperation.Modify;
            PerformOperation<OtherReceivableSheet>(processor, so);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            OtherReceivableSheetBLL processor = new OtherReceivableSheetBLL(AppSettings.Current.ConnStr);
            PerformOperation<OtherReceivableSheet>(processor, SheetOperation.Approve);
        }

        private void btnUndoApprove_Click(object sender, EventArgs e)
        {
            OtherReceivableSheetBLL processor = new OtherReceivableSheetBLL(AppSettings.Current.ConnStr);
            PerformOperation<OtherReceivableSheet>(processor, SheetOperation.UndoApprove);
        }

        private void btnNullify_Click(object sender, EventArgs e)
        {
            OtherReceivableSheetBLL processor = new OtherReceivableSheetBLL(AppSettings.Current.ConnStr);
            PerformOperation<OtherReceivableSheet>(processor, SheetOperation.Nullify);
        }
        #endregion

        #region 事件处理程序
        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMasterBase frm = null;
            if (ReceivableType  == CustomerReceivableType.CustomerReceivable )
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
        #endregion
    }
}
