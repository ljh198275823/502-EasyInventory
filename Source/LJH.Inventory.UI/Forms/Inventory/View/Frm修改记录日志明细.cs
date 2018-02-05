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

namespace LJH.Inventory.UI.Forms.Inventory.View
{
    public partial class Frm修改记录日志明细 : LJH.GeneralLibrary.Core.UI.FrmMasterBase
    {
        public Frm修改记录日志明细()
        {
            InitializeComponent();
        }


        #region 重写基类方法
        protected override List<object> GetDataSource()
        {
            List<DocumentOperation> items = null;
            if (SearchCondition != null) items = (new DocumentOperationBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            if (items == null || items.Count == 0) return null;
            return (from item in items
                    orderby item.OperatDate descending
                    select (object)item).ToList();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            var log = item as DocumentOperation;
            row.Cells["colOperateDate"].Value = log.OperatDate;
            row.Cells["colOperation"].Value = log.Operation;
            row.Cells["colOperator"].Value = log.Operator;
            row.Cells["colMemo"].Value = log.Memo;
        }
        #endregion
    }
}
