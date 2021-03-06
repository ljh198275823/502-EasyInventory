﻿using System;
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
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmProductInventoryMaster : FrmMasterBase
    {
        public FrmProductInventoryMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<ProductInventory> _ProductInventorys = null;
        #endregion

        #region 私有方法
        private void FreshData()
        {
            List<object> items = FilterData();
            ShowItemsOnGrid(items);
        }

        private List<object> FilterData()
        {
            List<ProductInventory> items = _ProductInventorys;
            List<ProductCategory> cs = null;
            if (this.categoryTree.SelectedNode != null)
            {
                cs = this.categoryTree.GetCategoryofNode(this.categoryTree.SelectedNode);
                if (cs != null && cs.Count > 0) items = _ProductInventorys.Where(it => cs.Exists(c => c.ID == it.Product.CategoryID)).ToList();
            }
            string warehouse = wareHouseComboBox1.SelectedWareHouseID;
            if (items != null && items.Count > 0 && !string.IsNullOrEmpty(warehouse))
            {
                items = items.Where(it => it.WareHouseID == warehouse).ToList();
            }
            if (chkOnlyHasInventory.Checked)
            {
                items = items.Where(item => item.Valid + item.Reserved > 0).ToList();
            }
            return (from p in items
                    orderby p.Product.Name ascending
                    select (object)p).ToList();
        }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
            this.wareHouseComboBox1.Init();
            this.wareHouseComboBox1.SelectedIndexChanged -= wareHouseComboBox1_SelectedIndexChanged;
            this.wareHouseComboBox1.SelectedIndexChanged += wareHouseComboBox1_SelectedIndexChanged;
        }

        protected override void ReFreshData()
        {
            this.categoryTree.Init();
            base.ReFreshData();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.ProductInventory, PermissionActions.Edit);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmProductInventoryDetail frm = new FrmProductInventoryDetail();
            frm.WareHouse = categoryTree.SelectedNode != null ? (categoryTree.SelectedNode.Tag as WareHouse) : null;
            return frm;
        }

        protected override bool DeletingItem(object item)
        {
            return false;
        }

        protected override List<object> GetDataSource()
        {
            ProductInventoryBLL bll = new ProductInventoryBLL(AppSettings.Current.ConnStr);
            List<ProductInventory> items = null;
            if (SearchCondition == null)
            {
                items = bll.GetItems(null).QueryObjects;
            }
            else
            {
                items = bll.GetItems(SearchCondition).QueryObjects;
            }
            _ProductInventorys = bll.GetItems(SearchCondition).QueryObjects;
            List<object> records = FilterData();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            ProductInventory pi = item as ProductInventory;
            row.Cells["colImage"].Value = Properties.Resources.inventory;
            row.Cells["colProductID"].Value = pi.ProductID;
            row.Cells["colProduct"].Value = pi.Product.Name;
            row.Cells["colCategory"].Value = pi.Product.Category == null ? pi.Product.CategoryID : pi.Product.Category.Name;
            row.Cells["colSpecification"].Value = pi.Product.Specification;
            row.Cells["colModel"].Value = pi.Product.Model;
            row.Cells["colWareHouse"].Value = pi.WareHouse.Name;
            row.Cells["colUnit"].Value = pi.Unit;
            row.Cells["colReserved"].Value = pi.Reserved.Trim();
            row.Cells["colValid"].Value = pi.Valid.Trim();
            row.Cells["colAmount"].Value = pi.Count.Trim();
            if (_ProductInventorys == null || !_ProductInventorys.Exists(it => it.ID == pi.ID))
            {
                if (_ProductInventorys == null) _ProductInventorys = new List<ProductInventory>();
                _ProductInventorys.Add(pi);
            }
        }

        protected override void ShowItemsOnGrid(List<object> items)
        {
            base.ShowItemsOnGrid(items);
            Filter(txtKeyword.Text.Trim());
        }
        #endregion

        #region 事件处理函数
        private void categoryTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FreshData();
        }

        private void wareHouseComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FreshData();
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            FreshData();
        }

        private void chkOnlyHasInventory_CheckedChanged(object sender, EventArgs e)
        {
            FreshData();
        }

        private void mnu_StackRecords_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                ProductInventory pi = dataGridView1.SelectedRows[0].Tag as ProductInventory;
                View.FrmProductStackRecordsView frm = new View.FrmProductStackRecordsView();
                frm.ProductInventory = pi;
                frm.ShowDialog();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colValid")
                {
                    ProductInventory item = dataGridView1.Rows[e.RowIndex].Tag as ProductInventory;
                    ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                    con.Products = new List<string>();
                    con.Products.Add(item.ProductID);
                    con.WareHouseID = item.WareHouseID;
                    con.UnReserved = true;
                    con.UnShipped = true;
                    View.FrmProductInventoryItemView frm = new View.FrmProductInventoryItemView();
                    frm.SearchCondition = con;
                    frm.ShowDialog();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "colReserved")
                {
                    ProductInventory item = dataGridView1.Rows[e.RowIndex].Tag as ProductInventory;
                    ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                    con.Products = new List<string>();
                    con.Products.Add(item.ProductID);
                    con.WareHouseID = item.WareHouseID;
                    con.UnReserved = false;
                    con.UnShipped = true;
                    View.FrmProductInventoryItemView frm = new View.FrmProductInventoryItemView();
                    frm.SearchCondition = con;
                    frm.ShowDialog();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "colAmount")
                {
                    ProductInventory item = dataGridView1.Rows[e.RowIndex].Tag as ProductInventory;
                    ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                    con.Products = new List<string>();
                    con.Products.Add(item.ProductID);
                    con.WareHouseID = item.WareHouseID;
                    con.UnShipped = true;
                    View.FrmProductInventoryItemView frm = new View.FrmProductInventoryItemView();
                    frm.SearchCondition = con;
                    frm.ShowDialog();
                }
            }
        }

        private void mnu_Check_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                ProductInventory pi = dataGridView1.SelectedRows[0].Tag as ProductInventory;
                FrmInvnetoryCheck frm = new FrmInvnetoryCheck();
                frm.ProductInventory = pi;
                DialogResult ret= frm.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    ProductInventorySearchCondition con = new ProductInventorySearchCondition();
                    con.ProductID = pi.ProductID;
                    con.WareHouseID = pi.WareHouseID;
                    List<ProductInventory> items = (new ProductInventoryBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
                    ProductInventory pii = items[0];
                    ShowItemInGridViewRow(dataGridView1.SelectedRows[0], pii);
                }
            }
        }
        #endregion
    }
}