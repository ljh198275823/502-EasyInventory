using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmSteelRollSliceSelection : Form
    {
        public FrmSteelRollSliceSelection()
        {
            InitializeComponent();
        }
        private FrmProductInventoryMaster _FrmSteelRollSlice = null;

        public Dictionary<ProductInventoryItem, decimal> SelectedItems { get; set; }

        #region 事件处理程序
        private void FrmSteelRollSliceSelection_Load(object sender, EventArgs e)
        {
            _FrmSteelRollSlice = new FrmProductInventoryMaster();
            _FrmSteelRollSlice.ForSelect = true;
            _FrmSteelRollSlice.MultiSelect = true;
            _FrmSteelRollSlice.ItemSelected += new EventHandler<GeneralLibrary.Core.UI.ItemSelectedEventArgs>(FrmSteelRollSlice_ItemSelected);
            var con = new ProductInventoryItemSearchCondition();
            con.HasRemain = true;
            con.States = new List<ProductInventoryState>() { ProductInventoryState.Inventory, ProductInventoryState.Reserved };
            _FrmSteelRollSlice.SearchCondition = con;
            this.ucFormViewMain.AddAForm(_FrmSteelRollSlice, false);
        }

        private void FrmSteelRollSlice_ItemSelected(object sender, GeneralLibrary.Core.UI.ItemSelectedEventArgs e)
        {
            bool exists = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (object.ReferenceEquals(row.Tag, e.SelectedItem)) exists = true;
                break;
            }
            if (!exists)
            {
                ProductInventoryItem pi = e.SelectedItem as ProductInventoryItem;
                if (pi.Count == 1) //如果数量为1，直接就选中
                {
                    var r = dataGridView1.Rows.Add();
                    ShowItemInGridViewRow(dataGridView1.Rows[r], e.SelectedItem, 1);
                    dataGridView1.Rows[r].Selected = false;
                }
                else
                {
                    FrmCountInput frm = new FrmCountInput();
                    frm.MaxCount = pi.Count;
                    frm.Count = pi.Count;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        var r = dataGridView1.Rows.Add();
                        ShowItemInGridViewRow(dataGridView1.Rows[r], e.SelectedItem, frm.Count);
                        dataGridView1.Rows[r].Selected = false;
                    }
                }
            }
        }

        private void ShowItemInGridViewRow(DataGridViewRow row, object item, decimal deliveryCount)
        {
            ProductInventoryItem pi = item as ProductInventoryItem;
            row.Tag = pi;
            row.Cells["colCategory"].Value = pi.Product.Category == null ? pi.Product.CategoryID : pi.Product.Category.Name;
            row.Cells["colSpecification"].Value = pi.Product.Specification;
            row.Cells["colModel"].Value = pi.Product.Model;
            row.Cells["colWareHouse"].Value = pi.WareHouse.Name;
            row.Cells["colWeight"].Value = pi.Weight;
            row.Cells["colLength"].Value = pi.Product.Length;
            row.Cells["colDeliveryCount"].Value = deliveryCount;
            row.Cells["colOriginalThick"].Value = pi.OriginalThick;
            row.Cells["colRealThick"].Value = pi.RealThick;
            row.Cells["colSourceRoll"].Value = pi.SourceRoll.HasValue ? "查看来源卷" : null;
            row.Cells["colSourceRollWeight"].Value = pi.SourceRollWeight;
            row.Cells["colCustomer"].Value = pi.Customer;
            row.Cells["colAction"].Value = "取消";
        }

        private void dataGridview1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colDeliveryCount")
            {
                int count = 0;
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null && int.TryParse(StringHelper.ToDBC(cell.Value.ToString()).Trim(), out count))
                {
                    if (count > 0 && count <= (dataGridView1.Rows[e.RowIndex].Tag as ProductInventoryItem).Count)
                    {
                        cell.Value = count;
                    }
                    else
                    {
                        MessageBox.Show("出货数量超出库存数量");
                        cell.Value = null;
                    }
                }
                else
                {
                    cell.Value = null;
                }
            }
        }

        private void dataGridview1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colSourceRoll")
            {
                var pi = dataGridView1.Rows[e.RowIndex].Tag as ProductInventoryItem;
                if (pi != null && pi.SourceRoll != null)
                {
                    var steelRoll = new SteelRollBLL(AppSettings.Current.ConnStr).GetByID(pi.SourceRoll.Value).QueryObject;
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
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "colAction")
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.SelectedItems = new Dictionary<ProductInventoryItem, decimal>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["colDeliveryCount"].Value != null)
                {
                    int count = 0;
                    if (int.TryParse(row.Cells["colDeliveryCount"].Value.ToString(), out count))
                    {
                        this.SelectedItems.Add(row.Tag as ProductInventoryItem, count);
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}
