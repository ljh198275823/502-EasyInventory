using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.UI;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.UI.Forms.Inventory.View
{
    public partial class FrmSteelRollCheckRecordView : FrmMasterBase
    {
        public FrmSteelRollCheckRecordView()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override List<object> GetDataSource()
        {
            List<InventoryCheckRecord> records = null;
            if (SearchCondition == null)
            {
                records = (new InventoryCheckRecordBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                records = (new InventoryCheckRecordBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            return (from item in records
                    orderby item.CheckDateTime descending
                    select (object)item).ToList();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            InventoryCheckRecord record = item as InventoryCheckRecord;
            row.Tag = record;
            row.Cells["colCheckDate"].Value = record.CheckDateTime.ToString("yyyy年MM月dd日");
            row.Cells["colBeforeWeight"].Value = record.BeforeWeight;
            row.Cells["colBeforeLength"].Value = record.BeforeLength;
            row.Cells["colWeight"].Value = record.Weight;
            row.Cells["colLength"].Value = record.Length;
            row.Cells["colChecker"].Value = record.Checker;
            row.Cells["colMemo"].Value = record.Memo;
        }
        #endregion
    }
}
