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
    public partial class FrmSteelRollSliceMaster : FrmMasterBase
    {
        public FrmSteelRollSliceMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<SteelRollSlice> _ProductInventorys = null;
        #endregion

        #region 私有方法
        private void FreshData()
        {
            List<object> items = FilterData();
            ShowItemsOnGrid(items);
        }

        private List<object> FilterData()
        {
            List<SteelRollSlice> items = _ProductInventorys;
            if (items != null && items.Count > 0)
            {
                if (!string.IsNullOrEmpty(categoryComboBox1.Text)) items = items.Where(it => it.Product.CategoryID == categoryComboBox1.SelectedCategoryID).ToList();
                if (!string.IsNullOrEmpty(cmbSpecification.Text)) items = items.Where(it => it.Product.Specification.Contains(cmbSpecification.Text)).ToList();
                if (txtWeight.DecimalValue > 0) items = items.Where(it => it.Product.Weight == txtWeight.DecimalValue).ToList();
                if (txtLength.DecimalValue > 0) items = items.Where(it => it.Product.Length == txtLength.DecimalValue).ToList();
                items = items.Where(it => (chk开平.Checked && it.Product.Model == chk开平.Text) ||
                                          (chk开卷.Checked && it.Product.Model == chk开卷.Text) ||
                                          (chk开条.Checked && it.Product.Model == chk开条.Text) ||
                                          (chk开吨.Checked && it.Product.Model == chk开吨.Text)).ToList();
                return (from p in items
                        orderby p.Product.CategoryID ascending,
                                SpecificationHelper.GetWrittenWidth(p.Product.Specification) ascending,
                                SpecificationHelper.GetWrittenThick(p.Product.Specification) ascending
                        select (object)p).ToList();
            }
            return null;
        }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
            this.cmbSpecification.Init(new List<string> { ProductModel.原材料, ProductModel.开平, ProductModel.开卷, ProductModel.开吨, ProductModel.开条 });
            this.categoryComboBox1.Init();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            mnu_CreateInventory.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Inventory);
            mnu_Import.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Inventory);
            cMnu_Export.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.导出);
        }

        protected override List<object> GetDataSource()
        {
            SteelRollSliceBLL bll = new SteelRollSliceBLL(AppSettings.Current.ConnStr);
            if (SearchCondition == null)
            {
                ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                con.States = new List<ProductInventoryState>() { ProductInventoryState.Inventory, ProductInventoryState.WaitShipping, ProductInventoryState.Reserved };
                con.HasRemain = true;
                _ProductInventorys = bll.GetSteelRollSlices(con).QueryObjects;
            }
            else
            {
                _ProductInventorys = bll.GetSteelRollSlices(SearchCondition).QueryObjects;
            }
            List<object> records = FilterData();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            SteelRollSlice pi = item as SteelRollSlice;
            row.Tag = pi;
            row.Cells["colImage"].Value = Properties.Resources.inventory;
            row.Cells["colCategory"].Value = pi.Product.Category == null ? pi.Product.CategoryID : pi.Product.Category.Name;
            row.Cells["colSpecification"].Value = pi.Product.Specification;
            row.Cells["colModel"].Value = pi.Product.Model;
            row.Cells["colWeight"].Value = pi.Product.Weight;
            row.Cells["colLength"].Value = pi.Product.Length;
            row.Cells["colWaitShipping"].Value = pi.WaitShipping;
            row.Cells["colValid"].Value = pi.Valid;
            row.Cells["colTotal"].Value = pi.Total;
            if (!_ProductInventorys.Exists(it => it.Product.ID == pi.Product.ID))
            {
                _ProductInventorys.Add(pi);
            }
        }
        #endregion

        #region 事件处理函数
        private void FreshDate_Clicked(object sender, EventArgs e)
        {
            FreshData();
        }

        private void mnu_CreateInventory_Click(object sender, EventArgs e)
        {
            FrmSteelRollSliceStackIn frm = new FrmSteelRollSliceStackIn();
            if (dataGridView1.SelectedRows.Count == 1)
            {
                SteelRollSlice srs = dataGridView1.SelectedRows[0].Tag as SteelRollSlice;
                frm.Product = srs.Product;
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ReFreshData();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (!(dataGridView1.Columns[e.ColumnIndex] is DataGridViewLinkColumn)) return;
                SteelRollSlice item = dataGridView1.Rows[e.RowIndex].Tag as SteelRollSlice;
                ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                con.ProductID = item.Product.ID;
                con.HasRemain = true;
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colValid")
                {
                    con.States = new List<ProductInventoryState>() { ProductInventoryState.Inventory };
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "colWaitShipping")
                {
                    con.States = new List<ProductInventoryState>() { ProductInventoryState.WaitShipping };
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "colTotal")
                {
                    con.States = new List<ProductInventoryState>() { ProductInventoryState.Inventory, ProductInventoryState.WaitShipping, ProductInventoryState.Reserved };
                }
                View.FrmSteelRollSliceView frm = new View.FrmSteelRollSliceView();
                frm.SearchCondition = con;
                frm.SteelRollSlice = item;
                frm.ShowDialog();

                cMnu_Fresh.PerformClick();
            }
        }

        private void mnu_CheckView_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                SteelRollSlice pi = dataGridView1.SelectedRows[0].Tag as SteelRollSlice;
                InventoryCheckRecordSearchCondition con = new InventoryCheckRecordSearchCondition();
                con.ProductID = pi.Product.ID;
                View.FrmSteelRollSliceCheckRecordView frm = new View.FrmSteelRollSliceCheckRecordView();
                frm.SearchCondition = con;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private void mnu_Import_Click(object sender, EventArgs e)
        {
            FrmSteelRollSliceImport frm = new FrmSteelRollSliceImport();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            cMnu_Fresh.PerformClick();
        }
        #endregion
    }
}