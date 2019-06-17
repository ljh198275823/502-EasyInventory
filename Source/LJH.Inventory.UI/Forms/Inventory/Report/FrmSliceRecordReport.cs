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

namespace LJH.Inventory.UI.Forms.Inventory.Report
{
    public partial class FrmSliceRecordReport : FrmReportBase
    {
        public FrmSliceRecordReport()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
            this.ucDateTimeInterval1.Init();
            this.ucDateTimeInterval1.SelectThisMonth();
            this.categoryComboBox1.Init();
            this.comSpecification1.Init();
            mnu_Undo.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Slice);
        }

        protected override List<object> GetDataSource()
        {
            SliceRecordSearchCondition con = new SliceRecordSearchCondition();
            con.SliceDate = new DateTimeRange(this.ucDateTimeInterval1.StartDateTime, this.ucDateTimeInterval1.EndDateTime);
            con.Category = this.categoryComboBox1.SelectedCategoryID;
            con.Specification = this.comSpecification1.Text;
            List<SteelRollSliceRecord> records = (new SteelRollSliceRecordBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            if (records != null && records.Count > 0)
            {
                return (from it in records
                        orderby it.SliceDate ascending
                        select (object)it).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            SteelRollSliceRecord record = item as SteelRollSliceRecord;
            row.Tag = record;
            row.Cells["colSlicedDateTime"].Value = record.SliceDate.ToString("yyyy年MM月dd日");
            row.Cells["colCategoryID"].Value = record.Category;
            row.Cells["colSpecification"].Value = record.Specification;
            row.Cells["colBeforeWeight"].Value = record.BeforeWeight;
            row.Cells["colWeight"].Value = record.Weight;
            row.Cells["colAfterWeight"].Value = record.AfterWeight;
            row.Cells["colSlicer"].Value = string.IsNullOrEmpty(record.Slicer) ? record.Operator : record.Slicer;
            row.Cells["colCustomer"].Value = record.Customer;
            row.Cells["colSourceRoll"].Value = "查看原料卷";
            row.Cells["colMemo"].Value = record.Memo;
        }
        #endregion

        #region 事件处理程序
        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colSourceRoll")
            {
                var pi = dataGridView1.Rows[e.RowIndex].Tag as SteelRollSliceRecord;
                if (pi != null)
                {
                    var steelRoll = new SteelRollBLL(AppSettings.Current.ConnStr).GetByID(pi.SliceSource).QueryObject;
                    if (steelRoll != null)
                    {
                        FrmSteelRollDetail frm = new FrmSteelRollDetail();
                        frm.IsForView = true;
                        frm.UpdatingItem = steelRoll;
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void mnu_Undo_Click(object sender, EventArgs e)
        {
            if (this.GridView.SelectedRows.Count > 0 &&
                MessageBox.Show("是否撤销这些加工记录？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                List<SteelRollSliceRecord> records = new List<SteelRollSliceRecord>();
                List<DataGridViewRow> delingRows = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in this.GridView.SelectedRows)
                {
                    var record = row.Tag as SteelRollSliceRecord;
                    var ret= new SteelRollBLL(AppSettings.Current.ConnStr).UndoSlice(record);
                    if (ret.Result == GeneralLibrary.Core.DAL.ResultCode.Successful) delingRows.Add(row);
                }
                if (delingRows.Count > 0)
                {
                    foreach (DataGridViewRow row in delingRows)
                    {
                        GridView.Rows.Remove(row);
                    }
                }
            }
        }
        #endregion
    }
}
