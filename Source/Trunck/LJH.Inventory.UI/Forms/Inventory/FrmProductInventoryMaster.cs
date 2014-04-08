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

namespace LJH.Inventory.UI.Forms
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
        private void SelectNode(TreeNode node)
        {
            List<object> items = GetSelectedNodeItems();
            ShowItemsOnGrid(items);
        }

        private List<object> GetSelectedNodeItems()
        {
            List<ProductInventory> items = _ProductInventorys;
            ProductCategory pc = null;
            if (this.categoryTree.SelectedNode != null) pc = this.categoryTree.SelectedNode.Tag as ProductCategory;
            if (pc != null) items = _ProductInventorys.Where(it => it.Product.CategoryID == pc.ID).ToList();

            return (from p in items
                    orderby p.Product.Name ascending
                    select (object)p).ToList();
        }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
            this.categoryTree.Init();
            Operator cur = Operator.Current;
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
            List<ProductInventory> items = bll.GetItems(null).QueryObjects;
            _ProductInventorys = bll.GetItems(SearchCondition).QueryObjects;
            List<object> records = GetSelectedNodeItems();
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
            row.Cells["colSum"].Value = pi.Count.Trim();
            if (_ProductInventorys == null || !_ProductInventorys.Exists(it => it.ID == pi.ID))
            {
                if (_ProductInventorys == null) _ProductInventorys = new List<ProductInventory>();
                _ProductInventorys.Add(pi);
            }
        }
        #endregion

        #region 事件处理函数
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colProductID")
                {
                    ProductInventory pi = dataGridView1.Rows[e.RowIndex].Tag as ProductInventory;
                    Product p = (new ProductBLL(AppSettings.Current.ConnStr)).GetByID(pi.ProductID).QueryObject;
                    if (p != null)
                    {
                        FrmProductDetail frm = new FrmProductDetail();
                        frm.UpdatingItem = p;
                        frm.IsAdding = false;
                        frm.IsForView = true;
                        frm.ShowDialog();
                    }
                }
            }
        }
        #endregion

        private void categoryTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectNode(e.Node);
        }
    }
}