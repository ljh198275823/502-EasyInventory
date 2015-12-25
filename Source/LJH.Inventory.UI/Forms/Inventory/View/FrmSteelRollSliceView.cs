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
    public partial class FrmSteelRollSliceView : FrmMasterBase
    {
        public FrmSteelRollSliceView()
        {
            InitializeComponent();
        }

        public SteelRollSlice SteelRollSlice { get; set; }

        List<Product> _Products = null;

        #region 重写基类方法
        protected override List<object> GetDataSource()
        {
            _Products = new ProductBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            List<ProductInventoryItem> records = null;
            if (SearchCondition == null)
            {
                records = (new SteelRollSliceBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                records = (new SteelRollSliceBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            return (from item in records
                    orderby item.AddDate descending
                    select (object)item).ToList();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            mnu_Check.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Check);
            mnu_CreateInventory.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Edit);
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            ProductInventoryItem c = item as ProductInventoryItem;
            row.Tag = c;
            Product p = c.Product;
            row.Cells["colCategory"].Value = p != null ? p.Category.Name : string.Empty;
            row.Cells["colWareHouse"].Value = c.WareHouse.Name;
            row.Cells["colSpecification"].Value = p != null ? p.Specification : string.Empty;
            row.Cells["colWeight"].Value = c.Weight;
            row.Cells["colLength"].Value = c.Length;
            row.Cells["colOriginalThick"].Value = c.OriginalThick;
            row.Cells["colRealThick"].Value = c.RealThick;
            row.Cells["colInventoryDate"].Value = c.AddDate.ToString("yyyy-MM-dd");
            row.Cells["colCount"].Value = c.Count;
            row.Cells["colInventorySheet"].Value = c.InventorySheet;
            row.Cells["colDeliverySheet"].Value = c.DeliverySheet;
            row.Cells["colCustomer"].Value = c.Customer;
            row.Cells["colSourceRoll"].Value = c.SourceRoll.HasValue ? "查看来源卷" : null;
            row.Cells["colMemo"].Value = c.Memo;
        }
        #endregion

        #region 事件处理程序
        private void mnu_CreateInventory_Click(object sender, EventArgs e)
        {
            FrmSteelRollSliceStackIn frm = new FrmSteelRollSliceStackIn();
            if (SteelRollSlice != null)
            {
                frm.Product = SteelRollSlice.Product;
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ReFreshData();
            }
        }

        private void mnu_Check_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var pi = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                FrmSteelRollSliceCheck frm = new FrmSteelRollSliceCheck();
                frm.ProductInventory = pi;
                DialogResult ret = frm.ShowDialog();
                if (ret == DialogResult.OK) ReFreshData();
            }
        }

        private void 折包ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var pi = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                FrmSteelRollSliceDepart frm = new FrmSteelRollSliceDepart();
                frm.ProductInventory = pi;
                DialogResult ret = frm.ShowDialog();
                if (ret == DialogResult.OK) ReFreshData();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colMemo")
            {
                var pi = dataGridView1.Rows[e.RowIndex].Tag as ProductInventoryItem;
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string memo = cell.Value != null ? cell.Value.ToString() : null;
                var ret = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).UpdateMemo(pi, memo);
                if (ret.Result != ResultCode.Successful)
                {
                    MessageBox.Show(ret.Message);
                    cell.Value = pi.Memo;
                }
            }
        }
        #endregion

        
    }
}
