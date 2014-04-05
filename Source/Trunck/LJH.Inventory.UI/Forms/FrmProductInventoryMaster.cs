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
        private void InitCategoryTree()
        {
            this.categoryTree.Nodes.Clear();
            this.categoryTree.Nodes.Add("所有仓库");

            List<WareHouse> items = (new WareHouseBLL(AppSettings.Current.ConnStr)).GetAll().QueryObjects;
            if (items != null && items.Count > 0)
            {
                AddDesendNodes(items, this.categoryTree.Nodes[0]);
            }
        }

        private void AddDesendNodes(List<WareHouse> items, TreeNode parent)
        {
            List<WareHouse> pcs = null;
            if (parent.Tag == null)
            {
                pcs = items.Where(it => string.IsNullOrEmpty(it.Parent)).ToList();
            }
            else
            {
                pcs = items.Where(it => it.Parent == (parent.Tag as WareHouse).ID).ToList();
            }
            if (pcs != null && pcs.Count > 0)
            {
                foreach (WareHouse pc in pcs)
                {
                    TreeNode node = AddNode(pc, parent);
                    AddDesendNodes(items, node);
                }
            }
            parent.ImageIndex = 0;
            parent.SelectedImageIndex = 0;
            parent.ExpandAll();
        }

        private void SelectNode(TreeNode node)
        {
            if (!object.ReferenceEquals(categoryTree.SelectedNode, node))
            {
                if (categoryTree.SelectedNode != null)
                {
                    categoryTree.SelectedNode.BackColor = Color.White;
                    categoryTree.SelectedNode.ForeColor = Color.Black;
                }
                categoryTree.SelectedNode = node;
                categoryTree.SelectedNode.BackColor = Color.Blue;  //Color.FromArgb(128, 128, 255);
                categoryTree.SelectedNode.ForeColor = Color.White;

                List<object> items = GetSelectedNodeItems();
                ShowItemsOnGrid(items);
            }
        }

        private List<object> GetSelectedNodeItems()
        {
            List<ProductInventory> items = _ProductInventorys;
            WareHouse pc = null;
            if (this.categoryTree.SelectedNode != null) pc = this.categoryTree.SelectedNode.Tag as WareHouse;
            if (pc != null) items = _ProductInventorys.Where(it => it.WareHouseID == pc.ID).ToList();

            return (from p in items
                    orderby p.Product.Name ascending
                    select (object)p).ToList();
        }

        private TreeNode AddNode(WareHouse pc, TreeNode parent)
        {
            TreeNode node = parent.Nodes.Add(string.Format("{0}", pc.Name));
            node.Tag = pc;
            return node;
        }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
            InitCategoryTree();
            Operator cur = Operator.Current;
            this.mnu_AddCategory.Enabled = cur.Permit(Permission.EditWareHouse);
            this.mnu_DeleteCategory.Enabled = cur.Permit(Permission.EditWareHouse);
            this.mnu_CategoryProperty.Enabled = cur.Permit(Permission.EditWareHouse) || cur.Permit(Permission.ReadWareHouse);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmProductInventoryDetail  frm= new FrmProductInventoryDetail();
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

        #region 类别树右键菜单
        private void categoryTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectNode(e.Node);
        }

        private void mnu_FreshTree_Click(object sender, EventArgs e)
        {
            InitCategoryTree();
            SelectNode(categoryTree.Nodes[0]);
        }

        private void mnu_AddCategory_Click(object sender, EventArgs e)
        {
            WareHouse pc = categoryTree.SelectedNode.Tag as WareHouse;
            FrmWareHouseDetail frm = new FrmWareHouseDetail();
            frm.IsAdding = true;
            frm.ParentWareHouse = pc;
            frm.ItemAdded += delegate(object obj, ItemAddedEventArgs args)
            {
                WareHouse item = args.AddedItem as WareHouse;
                AddNode(item, categoryTree.SelectedNode);
            };
            frm.ShowDialog();
        }

        private void mnu_DeleteCategory_Click(object sender, EventArgs e)
        {
            WareHouse pc = categoryTree.SelectedNode.Tag as WareHouse;
            if (pc != null && MessageBox.Show("是否删除此仓库?", "询问", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                CommandResult ret = (new WareHouseBLL(AppSettings.Current.ConnStr)).Delete(pc);
                if (ret.Result == ResultCode.Successful)
                {
                    categoryTree.SelectedNode.Parent.Nodes.Remove(categoryTree.SelectedNode);
                }
                else
                {
                    MessageBox.Show(ret.Message);
                }
            }
        }

        private void mnu_CategoryProperty_Click(object sender, EventArgs e)
        {
            WareHouse pc = categoryTree.SelectedNode.Tag as WareHouse;
            FrmWareHouseDetail frm = new FrmWareHouseDetail();
            frm.IsAdding = false;
            frm.UpdatingItem = pc;
            frm.ItemUpdated += delegate(object obj, ItemUpdatedEventArgs args)
            {
                categoryTree.SelectedNode.Text = string.Format("{0}", pc.Name);
            };
            frm.ShowDialog();
        }
        #endregion
    }
}