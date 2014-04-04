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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmExpenditureRecordDetail : FrmDetailBase
    {
        public FrmExpenditureRecordDetail()
        {
            InitializeComponent();
        }

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
        }

        protected override void ItemShowing()
        {
            ExpenditureRecord item = UpdatingItem as ExpenditureRecord;
            if (item != null)
            {
                txtSheetNo.Text = item.ID;
                dtPaidDate.Value = item.ExpenditureDate;
                rdTransfer.Checked = (item.PaymentMode == PaymentMode.Transfer);
                rdCash.Checked = item.PaymentMode == PaymentMode.Cash;
                rdCheck.Checked = item.PaymentMode == PaymentMode.Check;
                txtAmount.DecimalValue = item.Amount;
                txtCategory.Text = item.Category;
                txtCheckNum.Text = item.CheckNum;
                txtRequest.Text = item.Request;
                txtPayee.Text = item.Payee;
                txtOrderID.Text = item.OrderID;
                txtMemo.Text = item.Memo;
                List<DocumentOperation> items = (new DocumentOperationBLL(AppSettings.CurrentSetting.ConnStr)).GetHisOperations(item.ID, item.DocumentType).QueryObjects;
                ShowOperations(items, dataGridView1);
                List<AttachmentHeader> headers = (new AttachmentBLL(AppSettings.CurrentSetting.ConnStr)).GetHeaders(item.ID, item.DocumentType).QueryObjects;
                ShowAttachmentHeaders(headers, this.gridAttachment);
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
            info.ExpenditureDate = dtPaidDate.Value;
            if (rdTransfer.Checked) info.PaymentMode = PaymentMode.Transfer;
            if (rdCheck.Checked) info.PaymentMode = PaymentMode.Check;
            if (rdCash.Checked) info.PaymentMode = PaymentMode.Cash;
            info.Amount = txtAmount.DecimalValue;
            info.Category = txtCategory.Text;
            info.CheckNum = txtCheckNum.Text;
            info.Request = txtRequest.Text;
            info.Payee = txtPayee.Text;
            info.OrderID = txtOrderID.Text;
            info.Memo = txtMemo.Text;
            return info;
        }

        protected override CommandResult AddItem(object item)
        {
            ExpenditureRecordBLL bll = new ExpenditureRecordBLL(AppSettings.CurrentSetting.ConnStr);
            return bll.Add(item as ExpenditureRecord, Operator.Current.Name);
        }

        protected override CommandResult UpdateItem(object item)
        {
            throw new Exception("资金支出不支持修改");
        }

        protected override void ShowButtonState()
        {
            btnOk.Enabled = IsAdding;
        }
        #endregion

        #region 与附件操作相关的方法和事件处理程序
        private void mnu_AttachmentAdd_Click(object sender, EventArgs e)
        {
            ExpenditureRecord item = UpdatingItem as ExpenditureRecord;
            if (item != null)
            {
                OpenFileDialog dig = new OpenFileDialog();
                if (dig.ShowDialog() == DialogResult.OK)
                {
                    AttachmentHeader header = new AttachmentHeader();
                    header.ID = Guid.NewGuid();
                    header.DocumentID = item.ID;
                    header.DocumentType = item.DocumentType;
                    header.Owner = Operator.Current.Name;
                    header.FileName = System.IO.Path.GetFileName(dig.FileName);
                    header.UploadDateTime = DateTime.Now;
                    CommandResult ret = (new AttachmentBLL(AppSettings.CurrentSetting.ConnStr)).Upload(header, dig.FileName);
                    if (ret.Result == ResultCode.Successful)
                    {
                        int row = gridAttachment.Rows.Add();
                        ShowAttachmentHeaderOnRow(header, gridAttachment.Rows[row]);
                    }
                    else
                    {
                        MessageBox.Show(ret.Message);
                    }
                }
            }
        }

        private void mnu_AttachmentOpen_Click(object sender, EventArgs e)
        {
            if (this.gridAttachment.SelectedRows.Count == 1)
            {
                AttachmentHeader header = this.gridAttachment.SelectedRows[0].Tag as AttachmentHeader;
                string dir = LJH.GeneralLibrary.TempFolderManager.GetCurrentFolder();
                string path = System.IO.Path.Combine(dir, header.FileName);
                CommandResult ret = (new AttachmentBLL(AppSettings.CurrentSetting.ConnStr)).Download(header, path);
                if (ret.Result == ResultCode.Successful)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(path);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show(ret.Message);
                }
            }
        }

        private void mnu_AttachmentSaveAs_Click(object sender, EventArgs e)
        {
            if (this.gridAttachment.SelectedRows.Count == 1)
            {
                AttachmentHeader header = this.gridAttachment.SelectedRows[0].Tag as AttachmentHeader;
                SaveFileDialog dig = new SaveFileDialog();
                dig.FileName = header.FileName;
                dig.Filter = "所有文件(*.*)|*.*";
                if (dig.ShowDialog() == DialogResult.OK)
                {
                    CommandResult ret = (new AttachmentBLL(AppSettings.CurrentSetting.ConnStr)).Download(header, dig.FileName);
                    if (ret.Result == ResultCode.Successful)
                    {
                    }
                    else
                    {
                        MessageBox.Show(ret.Message);
                    }
                }
            }
        }

        private void mnu_AttachmentDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要删除所选项?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<DataGridViewRow> deletingRows = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in this.gridAttachment.SelectedRows)
                {
                    AttachmentHeader header = row.Tag as AttachmentHeader;
                    CommandResult ret = (new AttachmentBLL(AppSettings.CurrentSetting.ConnStr)).Delete(header);
                    if (ret.Result == ResultCode.Successful)
                    {
                        deletingRows.Add(row);
                    }
                    else
                    {
                        MessageBox.Show(ret.Message);
                    }
                }
                if (deletingRows != null && deletingRows.Count > 0)
                {
                    foreach (DataGridViewRow row in deletingRows)
                    {
                        this.gridAttachment.Rows.Remove(row);
                    }
                }
            }
        }

        #endregion

        private void btnNullify_Click(object sender, EventArgs e)
        {
            if (UpdatingItem != null)
            {
                if (MessageBox.Show("是否要取消此项?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ExpenditureRecord item = UpdatingItem as ExpenditureRecord;
                    CommandResult ret = (new ExpenditureRecordBLL(AppSettings.CurrentSetting.ConnStr)).Cancel(item, Operator.Current.Name);
                    if (ret.Result == ResultCode.Successful)
                    {
                        ExpenditureRecord item1 = (new ExpenditureRecordBLL(AppSettings.CurrentSetting.ConnStr)).GetByID(item.ID).QueryObject;
                        this.UpdatingItem = item1;
                        ItemShowing();
                        ShowButtonState();
                        this.OnItemUpdated(new ItemUpdatedEventArgs(item1));
                    }
                    else
                    {
                        MessageBox.Show(ret.Message);
                    }
                }
            }
        }

        private void lnkCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmExpenditureTypeMaster frm = new FrmExpenditureTypeMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ExpenditureType item = frm.SelectedItem as ExpenditureType;
                txtCategory.Text = item.Name;
            }
        }

        private void lnkRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmOperatorMaster frm = new FrmOperatorMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Operator item = frm.SelectedItem as Operator;
                txtRequest.Text = item.Name;
            }
        }
    }
}
