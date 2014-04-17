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
    public partial class FrmInventoryDetailBase : LJH.GeneralLibrary.UI.FrmDetailBase
    {
        public FrmInventoryDetailBase()
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
        protected void ShowAttachmentHeaderOnRow(AttachmentHeader header, DataGridViewRow row)
        {
            row.Tag = header;
            row.Cells["colUploadDateTime"].Value = header.UploadDateTime;
            row.Cells["colOwner"].Value = header.Owner;
            row.Cells["colFileName"].Value = header.FileName;
        }

        protected void ShowAttachmentHeaders(List<AttachmentHeader> items, DataGridView gridAttachment)
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
        #endregion
    }
}
