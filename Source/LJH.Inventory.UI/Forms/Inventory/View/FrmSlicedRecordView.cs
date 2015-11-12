using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Inventory.View
{
    public partial class FrmSlicedRecordView : FrmMasterBase 
    {
        public FrmSlicedRecordView()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override List<object> GetDataSource()
        {
            List<SteelRollSliceRecord> records = null;
            if (SearchCondition == null)
            {
                records = (new SteelRollSliceRecordBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                records = (new SteelRollSliceRecordBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            return (from item in records
                    orderby item.SliceDate ascending
                    select (object)item).ToList();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            SteelRollSliceRecord record = item as SteelRollSliceRecord;
            row.Tag = record;
            row.Cells["colSlicedDateTime"].Value = record.SliceDate.ToString("yyyy年MM月dd日");
            row.Cells["colCategoryID"].Value = record.Category;
            row.Cells["colSpecification"].Value = record.Specification;
            row.Cells["colSlicedTo"].Value = record.SliceType;
            row.Cells["colLength"].Value = record.Length;
            row.Cells["colWeight"].Value = record.Weight;
            row.Cells["colAmount"].Value = record.Count;
            row.Cells["colBeforeWeight"].Value = record.BeforeWeight;
            row.Cells["colBeforeLength"].Value = record.BeforeLength;
            row.Cells["colAfterWeight"].Value = record.AfterWeight;
            row.Cells["colAfterLength"].Value = record.AfterLength;
            row.Cells["colTotalLength"].Value = record.BeforeLength - record.AfterLength;
            row.Cells["colTotalWeight"].Value = record.BeforeWeight - record.AfterWeight;
            row.Cells["colSlicer"].Value = record.Slicer;
        }
        #endregion
    }
}
