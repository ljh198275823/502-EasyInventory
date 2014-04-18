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
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmSheetDetailBase : LJH.GeneralLibrary.UI.FrmDetailBase
    {
        public FrmSheetDetailBase()
            : base()
        {
            InitializeComponent();
        }

        #region 保护属性
        protected readonly string _AutoCreate = "自动创建";
        #endregion

        #region 保护方法
        protected void ShowOperations(List<DocumentOperation> items, DataGridView dataGridView1)
        {
            dataGridView1.Rows.Clear();
            if (items != null && items.Count > 0)
            {
                foreach (DocumentOperation item in items)
                {
                    int row = dataGridView1.Rows.Add();
                    dataGridView1.Rows[row].Cells["colOperateDate"].Value = item.OperatDate;
                    dataGridView1.Rows[row].Cells["colOperation"].Value = item.Operation;
                    dataGridView1.Rows[row].Cells["colOperator"].Value = item.Operator;
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
        }

        protected virtual void ShowAttachmentHeaders(List<AttachmentHeader> items, DataGridView gridAttachment)
        {
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
    }
}
