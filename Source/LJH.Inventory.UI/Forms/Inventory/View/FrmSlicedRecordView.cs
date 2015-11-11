using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.UI.Forms.Inventory.View
{
    public partial class FrmSlicedRecordView : Form
    {
        public FrmSlicedRecordView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取或设置在窗口上要显示的小件加工记录
        /// </summary>
        public List<SteelRollSliceRecord> ShowingItems { get; set; }

        private void FrmSlicedRecords_Load(object sender, EventArgs e)
        {
            GridView.Rows.Clear();
            if (ShowingItems != null && ShowingItems.Count > 0)
            {
                foreach (SteelRollSliceRecord item in ShowingItems)
                {
                    int row = GridView.Rows.Add();
                    ShowItemOnRow(GridView.Rows[row], item);
                }
            }
            this.toolStripStatusLabel1.Text = string.Format("总共 {0} 项", GridView.Rows.Count);
        }

        private void ShowItemOnRow(DataGridViewRow row, SteelRollSliceRecord item)
        {
            row.Cells["colSlicedDateTime"].Value = item.SliceDate.ToString("yyyy年MM月dd日");
            row.Cells["colCategoryID"].Value = item.Category;
            row.Cells["colSpecification"].Value = item.Specification;
            row.Cells["colSlicedTo"].Value = item.SliceType;
            row.Cells["colLength"].Value = item.Length;
            row.Cells["colWeight"].Value = item.Weight;
            row.Cells["colAmount"].Value = item.Count;
            row.Cells["colBeforeWeight"].Value = item.BeforeWeight;
            row.Cells["colBeforeLength"].Value = item.BeforeLength;
            row.Cells["colAfterWeight"].Value = item.AfterWeight;
            row.Cells["colAfterLength"].Value = item.AfterLength;
            row.Cells["colTotalLength"].Value = item.BeforeLength - item.AfterLength;
            row.Cells["colTotalWeight"].Value = item.BeforeWeight - item.AfterWeight;
            row.Cells["colSlicer"].Value = item.Slicer;
        }
    }
}
