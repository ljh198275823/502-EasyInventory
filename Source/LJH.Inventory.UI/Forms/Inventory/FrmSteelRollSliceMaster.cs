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
using LJH.Inventory.UI.Report;
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
                if (!string.IsNullOrEmpty(wareHouseComboBox1.Text)) items = items.Where(it => it.WareHouse.ID == wareHouseComboBox1.SelectedWareHouseID).ToList();
                if (!string.IsNullOrEmpty(categoryComboBox1.Text)) items = items.Where(it => it.Product.CategoryID == categoryComboBox1.SelectedCategoryID).ToList();
                if (!string.IsNullOrEmpty(cmbSpecification.Text)) items = items.Where(it => it.Product.Specification == cmbSpecification.Text).ToList();
                items = items.Where(it => (chk开平.Checked && it.Product.Model == "开平") ||
                                          (chk开卷.Checked && it.Product.Model == "开卷") ||
                                          (chk开吨.Checked && it.Product.Model == "开吨")).ToList();
                return (from p in items
                        orderby p.Product.Specification ascending
                        select (object)p).ToList();
            }
            return null;
        }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
            this.wareHouseComboBox1.Init();
            this.wareHouseComboBox1.SelectedIndexChanged -= FreshDate_Clicked;
            this.wareHouseComboBox1.SelectedIndexChanged += FreshDate_Clicked;
            this.cmbSpecification.Init();
            this.categoryComboBox1.Init();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.ProductInventory, PermissionActions.Edit);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmSteelRollSliceDetail frm = new FrmSteelRollSliceDetail();
            return frm;
        }

        protected override bool DeletingItem(object item)
        {
            return false;
        }

        protected override List<object> GetDataSource()
        {
            SteelRollSliceBLL bll = new SteelRollSliceBLL(AppSettings.Current.ConnStr);
            if (SearchCondition == null)
            {
                ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                con.ExcludeModel = "原材料"; //排除原材料库存项
                con.States = (int)ProductInventoryState.UnShipped;
                _ProductInventorys = bll.GetItems(con).QueryObjects;
            }
            else
            {
                _ProductInventorys = bll.GetItems(SearchCondition).QueryObjects;
            }
            List<object> records = FilterData();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            SteelRollSlice pi = item as SteelRollSlice;
            row.Cells["colImage"].Value = Properties.Resources.inventory;
            row.Cells["colCategory"].Value = pi.Product.Category == null ? pi.Product.CategoryID : pi.Product.Category.Name;
            row.Cells["colSpecification"].Value = pi.Product.Specification;
            row.Cells["colModel"].Value = pi.Product.Model;
            row.Cells["colWareHouse"].Value = pi.WareHouse.Name;
            row.Cells["colWeight"].Value = pi.Product.Weight;
            row.Cells["colLength"].Value = pi.Product.Length;
            row.Cells["colReserved"].Value = pi.Reserved.Trim();
            row.Cells["colValid"].Value = pi.Valid.Trim();
            row.Cells["colTotal"].Value = pi.Count.Trim();
            if (_ProductInventorys == null || !_ProductInventorys.Exists(it => it.ID == pi.ID))
            {
                if (_ProductInventorys == null) _ProductInventorys = new List<SteelRollSlice>();
                _ProductInventorys.Add(pi);
            }
        }
        #endregion

        #region 事件处理函数
        private void FreshDate_Clicked(object sender, EventArgs e)
        {
            FreshData();
        }

        private void mnu_StackRecords_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                SteelRollSlice srs = dataGridView1.SelectedRows[0].Tag as SteelRollSlice;
                View.FrmProductStackRecordsView frm = new View.FrmProductStackRecordsView();
                ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                con.ExcludeModel = "原材料";
                con.ProductID = srs.Product.ID;
                con.WareHouseID = srs.WareHouse.ID;
                con.States = (int)ProductInventoryState.UnShipped | (int)ProductInventoryState.Shipped;
                frm.SearchCondition = con;
                frm.ShowDialog();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colValid")
                {
                    SteelRollSlice item = dataGridView1.Rows[e.RowIndex].Tag as SteelRollSlice;
                    ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                    con.Products = new List<string>();
                    con.Products.Add(item.Product.ID);
                    con.WareHouseID = item.WareHouse.ID;
                    con.States = (int)ProductInventoryState.Inventory;
                    View.FrmSteelRollSliceView frm = new View.FrmSteelRollSliceView();
                    frm.SearchCondition = con;
                    frm.ShowDialog();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "colReserved")
                {
                    SteelRollSlice item = dataGridView1.Rows[e.RowIndex].Tag as SteelRollSlice;
                    ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                    con.Products = new List<string>();
                    con.Products.Add(item.Product.ID);
                    con.WareHouseID = item.WareHouse.ID;
                    con.States = (int)ProductInventoryState.Reserved;
                    View.FrmSteelRollSliceView frm = new View.FrmSteelRollSliceView();
                    frm.SearchCondition = con;
                    frm.ShowDialog();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "colTotal")
                {
                    SteelRollSlice item = dataGridView1.Rows[e.RowIndex].Tag as SteelRollSlice;
                    ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                    con.Products = new List<string>();
                    con.Products.Add(item.Product.ID);
                    con.WareHouseID = item.WareHouse.ID;
                    con.States = (int)ProductInventoryState.UnShipped;
                    View.FrmSteelRollSliceView frm = new View.FrmSteelRollSliceView();
                    frm.SearchCondition = con;
                    frm.ShowDialog();
                }
            }
        }

        private void mnu_Check_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                SteelRollSlice pi = dataGridView1.SelectedRows[0].Tag as SteelRollSlice;
                FrmInvnetoryCheck frm = new FrmInvnetoryCheck();
                frm.ProductInventory = pi;
                DialogResult ret= frm.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                    con.ProductID = pi.Product.ID;
                    con.WareHouseID = pi.WareHouse.ID;
                    List<SteelRollSlice> items = (new SteelRollSliceBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
                    SteelRollSlice pii = items[0];
                    ShowItemInGridViewRow(dataGridView1.SelectedRows[0], pii);
                }
            }
        }
        #endregion
    }
}