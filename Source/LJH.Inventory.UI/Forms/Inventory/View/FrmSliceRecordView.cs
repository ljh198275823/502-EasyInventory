using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Inventory.View
{
    public partial class FrmSliceRecordView : FrmMasterBase
    {
        public FrmSliceRecordView()
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
                    orderby item.SliceDate descending
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
            row.Cells["colCustomer"].Value = record.Customer;
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            mnu_Undo.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Slice);
        }
        #endregion

        private void 撤回加工ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (this.GridView.SelectedRows.Count > 0 &&
                MessageBox.Show("是否撤销这些加工记录？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                List<SteelRollSliceRecord> records = new List<SteelRollSliceRecord>();
                foreach (DataGridViewRow row in this.GridView.SelectedRows)
                {
                    records.Add(row.Tag as SteelRollSliceRecord);
                }
                records = (from it in records
                           orderby it.SliceDate descending
                           select it).ToList();
                foreach (var record in records)
                {
                    new SteelRollBLL(AppSettings.Current.ConnStr).UndoSlice(record);
                }
                this.ReFreshData();
            }
        }
    }
}
