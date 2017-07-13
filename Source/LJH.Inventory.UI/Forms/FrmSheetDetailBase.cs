using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmSheetDetailBase : FrmDetailBase
    {
        public FrmSheetDetailBase()
            : base()
        {
            InitializeComponent();
        }

        #region 保护属性
        protected readonly string _AutoCreate = "自动创建";
        #endregion

        #region 私有方法
        //将文件大小转换成易于读取的字符串
        private string FileSizeFormat(long filesize)
        {
            Decimal OneKiloByte = 1024M;
            Decimal OneMegaByte = OneKiloByte * 1024M;
            Decimal OneGigaByte = OneMegaByte * 1024M;
            string suffix;
            decimal temp = 0;
            if (filesize > OneGigaByte)
            {
                temp = (decimal)filesize / OneGigaByte;
                suffix = "GB";
            }
            else if (filesize > OneMegaByte)
            {
                temp = (decimal)filesize / OneMegaByte;
                suffix = "MB";
            }
            else if (filesize > OneKiloByte)
            {
                temp = (decimal)filesize / OneKiloByte;
                suffix = "kB";
            }
            else
            {
                temp = (decimal)filesize;
                suffix = " B";
            }
            temp = Math.Round(temp, 2).Trim();
            return String.Format("{0:F}{1}", temp, suffix);
        }
        #endregion

        #region 重写基类方法
        protected override void InitControls()
        {
            base.InitControls();
            ShowButtonState();
        }

        protected virtual void ShowButtonState()
        {
        }
        #endregion

        #region 与操作记录有关的方法
        protected virtual void ShowOperations(string docID, string docType, DataGridView dataGridView1)
        {
            List<DocumentOperation> items = (new DocumentOperationBLL(AppSettings.Current.ConnStr)).GetHisOperations(docID, docType).QueryObjects;
            dataGridView1.Rows.Clear();
            if (items != null && items.Count > 0)
            {
                foreach (DocumentOperation item in items)
                {
                    int row = dataGridView1.Rows.Add();
                    if (dataGridView1.Columns.Contains("colOperateDate")) dataGridView1.Rows[row].Cells["colOperateDate"].Value = item.OperatDate;
                    if (dataGridView1.Columns.Contains("colOperation")) dataGridView1.Rows[row].Cells["colOperation"].Value = item.Operation;
                    if (dataGridView1.Columns.Contains("colOperator")) dataGridView1.Rows[row].Cells["colOperator"].Value = item.Operator;
                    if (dataGridView1.Columns.Contains("colMemo")) dataGridView1.Rows[row].Cells["colMemo"].Value = item.Memo;
                }
            }
        }
        #endregion

        #region 与附件操作相关的方法和事件处理程序
        protected virtual void ShowAttachmentHeaderOnRow(AttachmentHeader header, DataGridViewRow row)
        {
            row.Tag = header;
            row.Cells["colUploadDateTime"].Value = header.UploadDateTime;
            row.Cells["colOwner"].Value = header.Owner;
            row.Cells["colFileName"].Value = header.FileName;
            row.Cells["colSize"].Value = header.FileSize;
        }

        protected virtual void ShowAttachmentHeaders(string docID, string docType, DataGridView gridAttachment)
        {
            List<AttachmentHeader> items = (new AttachmentBLL(AppSettings.Current.ConnStr)).GetHeaders(docID, docType).QueryObjects;
            gridAttachment.Rows.Clear();
            if (items != null && items.Count > 0)
            {
                foreach (AttachmentHeader header in items)
                {
                    int row = gridAttachment.Rows.Add();
                    ShowAttachmentHeaderOnRow(header, gridAttachment.Rows[row]);
                }
            }
        }

        protected virtual void PerformAddAttach(string docID, string docType, DataGridView gridAttachment)
        {
            OpenFileDialog dig = new OpenFileDialog();
            if (dig.ShowDialog() == DialogResult.OK)
            {
                AttachmentHeader header = new AttachmentHeader();
                header.ID = Guid.NewGuid();
                header.DocumentID = docID;
                header.DocumentType = docType;
                header.Owner = Operator.Current.Name;
                header.FileName = System.IO.Path.GetFileName(dig.FileName);
                header.UploadDateTime = DateTime.Now;
                FileInfo fi = new FileInfo(dig.FileName);
                header.FileSize = FileSizeFormat(fi.Length);
                CommandResult ret = (new AttachmentBLL(AppSettings.Current.ConnStr)).Upload(header, dig.FileName);
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

        protected virtual void PerformDelAttach(DataGridView gridAttachment)
        {
            if (MessageBox.Show("确实要删除所选项?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<DataGridViewRow> deletingRows = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in gridAttachment.SelectedRows)
                {
                    AttachmentHeader header = row.Tag as AttachmentHeader;
                    CommandResult ret = (new AttachmentBLL(AppSettings.Current.ConnStr)).Delete(header);
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
                        gridAttachment.Rows.Remove(row);
                    }
                }
            }
        }

        protected virtual void PerformAttachSaveAs(DataGridView gridAttachment)
        {
            if (gridAttachment.SelectedRows.Count >= 1)
            {
                AttachmentHeader header = gridAttachment.SelectedRows[0].Tag as AttachmentHeader;
                SaveFileDialog dig = new SaveFileDialog();
                dig.FileName = header.FileName;
                dig.Filter = "所有文件(*.*)|*.*";
                if (dig.ShowDialog() == DialogResult.OK)
                {
                    CommandResult ret = (new AttachmentBLL(AppSettings.Current.ConnStr)).Download(header, dig.FileName);
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

        protected virtual void PerformAttachOpen(DataGridView gridAttachment)
        {
            if (gridAttachment.SelectedRows.Count >= 1)
            {
                AttachmentHeader header = gridAttachment.SelectedRows[0].Tag as AttachmentHeader;
                string dir = LJH.GeneralLibrary.TempFolderManager.GetCurrentFolder();
                string path = System.IO.Path.Combine(dir, header.FileName);
                CommandResult ret = (new AttachmentBLL(AppSettings.Current.ConnStr)).Download(header, path);
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
        #endregion

        #region 与工具栏有关的方法
        protected void ShowButtonState(ToolStrip toolBar)
        {
            if (UpdatingItem == null)
            {
                if (toolBar.Items["btnSave"] != null) toolBar.Items["btnSave"].Enabled = true;
                if (toolBar.Items["btnApprove"] != null) toolBar.Items["btnApprove"].Enabled = false;
                if (toolBar.Items["btnUndoApprove"] != null) toolBar.Items["btnUndoApprove"].Enabled = false;
                if (toolBar.Items["btnInventory"] != null) toolBar.Items["btnInventory"].Enabled = false;
                if (toolBar.Items["btnShip"] != null) toolBar.Items["btnShip"].Enabled = false;
                if (toolBar.Items["btnNullify"] != null) toolBar.Items["btnNullify"].Enabled = false;
            }
            else
            {
                ISheet<string> sheet = UpdatingItem as ISheet<string>;
                if (sheet != null)
                {
                    if (toolBar.Items["btnSave"] != null) toolBar.Items["btnSave"].Enabled = sheet.CanDo(SheetOperation.Modify);
                    if (toolBar.Items["btnApprove"] != null) toolBar.Items["btnApprove"].Enabled = sheet.CanDo(SheetOperation.Approve);
                    if (toolBar.Items["btnUndoApprove"] != null) toolBar.Items["btnUndoApprove"].Enabled = sheet.CanDo(SheetOperation.UndoApprove);
                    if (toolBar.Items["btnInventory"] != null) toolBar.Items["btnInventory"].Enabled = sheet.CanDo(SheetOperation.StackIn);
                    if (toolBar.Items["btnShip"] != null) toolBar.Items["btnShip"].Enabled = sheet.CanDo(SheetOperation.StackOut);
                    if (toolBar.Items["btnNullify"] != null) toolBar.Items["btnNullify"].Enabled = sheet.CanDo(SheetOperation.Nullify);
                }
            }
        }

        private void PerformSave<T>(SheetProcessorBase<T> processor, SheetOperation operation) where T : class,ISheet<string>
        {
            if (CheckInput())
            {
                T sheet = GetItemFromInput() as T;
                CommandResult ret = processor.ProcessSheet(sheet, operation, Operator.Current.Name, Operator.Current.ID);
                if (ret.Result == ResultCode.Successful)
                {
                    UpdatingItem = sheet;
                    IsAdding = false;
                    ShowButtonState();
                    if (operation == SheetOperation.Create) this.OnItemAdded(new ItemAddedEventArgs(sheet));
                    if (operation != SheetOperation.Create) this.OnItemUpdated(new ItemUpdatedEventArgs(sheet));
                    MessageBox.Show(string.Format("{0} 成功", SheetOperationDescription.GetDescription(operation)), "确定");
                    ItemShowing();
                }
                else
                {
                    MessageBox.Show(ret.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected virtual void PerformOperation<T>(SheetProcessorBase<T> processor, SheetOperation operation, string memo = null) where T : class,ISheet<string>
        {
            if (operation == SheetOperation.Create || operation == SheetOperation.Modify)
            {
                PerformSave<T>(processor, operation);
            }
            else
            {
                if (UpdatingItem != null)
                {
                    T sheet = sheet = UpdatingItem as T;
                    if (operation == SheetOperation.Nullify || operation == SheetOperation.UndoApprove)
                    {
                        FrmMemo frm = new FrmMemo();
                        if (frm.ShowDialog() != DialogResult.OK) return;
                        memo = frm.Memo;
                    }
                    else
                    {
                        if (MessageBox.Show(string.Format("是否要进行 {0}?", SheetOperationDescription.GetDescription(operation)),
                                   "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                        {
                            return;
                        }
                    }
                    CommandResult ret = processor.ProcessSheet(sheet, operation, Operator.Current.Name, Operator.Current.ID, memo);
                    if (ret.Result == ResultCode.Successful)
                    {
                        ShowButtonState();
                        if (operation != SheetOperation.Create) this.OnItemUpdated(new ItemUpdatedEventArgs(sheet));
                        MessageBox.Show(string.Format("{0} 成功", SheetOperationDescription.GetDescription(operation)), "确定");
                        ItemShowing();
                    }
                    else
                    {
                        MessageBox.Show(ret.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion
    }
}
