using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;
using LJH.Inventory.UI.Forms.General;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmExpenditureRecordDetail : FrmSheetDetailBase
    {
        public FrmExpenditureRecordDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置费用类别
        /// </summary>
        public ExpenditureType Category { get; set; }
        /// <summary>
        /// 获取或设置费用申请人
        /// </summary>
        public Staff Requster { get; set; }
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
            return true;
        }

        protected override void InitControls()
        {
            dtPaidDate.Value = DateTime.Today;
            this.txtCategory.Text = Category != null ? Category.Name : string.Empty;
            this.txtRequest.Text = Requster != null ? Requster.Name : string.Empty;
        }

        protected override void ItemShowing()
        {
            ExpenditureRecord item = UpdatingItem as ExpenditureRecord;
            if (item != null)
            {
                txtSheetNo.Text = item.ID;
                rdTransfer.Checked = (item.PaymentMode == PaymentMode.Transfer);
                rdCash.Checked = item.PaymentMode == PaymentMode.Cash;
                rdCheck.Checked = item.PaymentMode == PaymentMode.Check;
                txtAmount.DecimalValue = item.Amount;
                if (!string.IsNullOrEmpty(item.Category))
                {
                    Category = (new ExpenditureTypeBLL(AppSettings.Current.ConnStr)).GetByID(item.Category).QueryObject;
                }
                txtCategory.Text = Category != null ? Category.Name : string.Empty;
                txtCheckNum.Text = item.CheckNum;
                txtRequest.Text = item.Request;
                txtMemo.Text = item.Memo;
                ShowOperations(item.ID, item.DocumentType, dataGridView1);
                ShowAttachmentHeaders(item.ID, item.DocumentType, this.gridAttachment);
            }
        }

        protected override object GetItemFromInput()
        {
            ExpenditureRecord info = null;
            if (UpdatingItem == null)
            {
                info = new ExpenditureRecord();
                if (txtSheetNo.Text == _AutoCreate) txtSheetNo.Text = string.Empty;
            }
            else
            {
                info = UpdatingItem as ExpenditureRecord;
            }
            if (rdTransfer.Checked) info.PaymentMode = PaymentMode.Transfer;
            if (rdCheck.Checked) info.PaymentMode = PaymentMode.Check;
            if (rdCash.Checked) info.PaymentMode = PaymentMode.Cash;
            info.Amount = txtAmount.DecimalValue;
            info.Category = Category != null ? Category.ID : null;
            info.CheckNum = txtCheckNum.Text;
            info.Request = Requster != null ? Requster.Name : string.Empty;
            info.Memo = txtMemo.Text;
            return info;
        }

        protected override CommandResult AddItem(object item)
        {
            ExpenditureRecordBLL bll = new ExpenditureRecordBLL(AppSettings.Current.ConnStr);
            return bll.ProcessSheet(item as ExpenditureRecord, SheetOperation.Create, Operator.Current.Name, Operator.Current.ID);
        }

        protected override CommandResult UpdateItem(object item)
        {
            ExpenditureRecordBLL bll = new ExpenditureRecordBLL(AppSettings.Current.ConnStr);
            return bll.ProcessSheet(item as ExpenditureRecord, SheetOperation.Modify, Operator.Current.Name, Operator.Current.ID);
        }

        protected override void ShowButtonState()
        {
            ShowButtonState(this.toolStrip1);
            btnSave.Enabled = btnSave.Enabled && Operator.Current.Permit(Permission.ExpenditureRecord, PermissionActions.Edit);
            btnApprove.Enabled = btnApprove.Enabled && Operator.Current.Permit(Permission.ExpenditureRecord, PermissionActions.Approve);
            btnUndoApprove.Enabled = btnUndoApprove.Enabled && Operator.Current.Permit(Permission.ExpenditureRecord, PermissionActions.UndoApprove);
            btnNullify.Enabled = btnNullify.Enabled && Operator.Current.Permit(Permission.ExpenditureRecord, PermissionActions.Nullify);
        }
        #endregion

        #region 与附件操作相关的方法和事件处理程序
        private void mnu_AttachmentAdd_Click(object sender, EventArgs e)
        {
            ExpenditureRecord item = UpdatingItem as ExpenditureRecord;
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
            ExpenditureRecordBLL processor = new ExpenditureRecordBLL(AppSettings.Current.ConnStr);
            PerformOperation<ExpenditureRecord>(processor, IsAdding ? SheetOperation.Create : SheetOperation.Modify);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            ExpenditureRecordBLL processor = new ExpenditureRecordBLL(AppSettings.Current.ConnStr);
            PerformOperation<ExpenditureRecord>(processor, SheetOperation.Approve);
        }

        private void btnUndoApprove_Click(object sender, EventArgs e)
        {
            ExpenditureRecordBLL processor = new ExpenditureRecordBLL(AppSettings.Current.ConnStr);
            PerformOperation<ExpenditureRecord>(processor, SheetOperation.UndoApprove);
        }

        private void btnNullify_Click(object sender, EventArgs e)
        {
            ExpenditureRecordBLL processor = new ExpenditureRecordBLL(AppSettings.Current.ConnStr);
            PerformOperation<ExpenditureRecord>(processor, SheetOperation.Nullify);
        }
        #endregion

        #region 事件处理程序
        private void lnkCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmExpenditureTypeMaster frm = new FrmExpenditureTypeMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Category = frm.SelectedItem as ExpenditureType;
                txtCategory.Text = Category != null ? Category.Name : string.Empty;
            }
        }

        private void txtCategory_DoubleClick(object sender, EventArgs e)
        {
            Category = null;
            txtCategory.Text = Category != null ? Category.Name : string.Empty;
        }

        private void lnkRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmStaffMaster frm = new FrmStaffMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Requster = frm.SelectedItem as Staff;
                txtRequest.Text = Requster != null ? Requster.Name : string.Empty;
            }
        }

        private void txtRequest_DoubleClick(object sender, EventArgs e)
        {
            Requster = null;
            txtRequest.Text = Requster != null ? Requster.Name : string.Empty;
        }
        #endregion
    }
}
