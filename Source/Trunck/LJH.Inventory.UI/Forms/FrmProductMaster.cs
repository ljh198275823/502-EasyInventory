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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmProductMaster : FrmMasterBase
    {
        public FrmProductMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        List<Product> _Products = null;
        #endregion

        #region 私有方法
        private void InitCategoryTree()
        {
            this.categoryTree.Nodes.Clear();
            this.categoryTree.Nodes.Add("所有产品类别");

            List<ProductCategory> items = (new ProductCategoryBLL(AppSettings.CurrentSetting.ConnectString)).GetAll().QueryObjects;
            if (items != null && items.Count > 0)
            {
                AddDesendNodes(items, this.categoryTree.Nodes[0]);
            }
        }

        private void AddDesendNodes(List<ProductCategory> items, TreeNode parent)
        {
            List<ProductCategory> pcs = null;
            if (parent.Tag == null)
            {
                pcs = items.Where(it => string.IsNullOrEmpty(it.Parent)).ToList();
            }
            else
            {
                pcs = items.Where(it => it.Parent == (parent.Tag as ProductCategory).ID).ToList();
            }
            if (pcs != null && pcs.Count > 0)
            {
                foreach (ProductCategory pc in pcs)
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
            List<Product> items = _Products;
            ProductCategory pc = null;
            if (this.categoryTree.SelectedNode != null) pc = this.categoryTree.SelectedNode.Tag as ProductCategory;
            if (pc != null) items = _Products.Where(it => it.CategoryID == pc.ID).ToList();

            return (from p in items
                    orderby p.Name ascending
                    select (object)p).ToList();
        }

        private TreeNode AddNode(ProductCategory pc, TreeNode parent)
        {
            TreeNode node = parent.Nodes.Add(string.Format("[{0}] {1}", pc.ID, pc.Name));
            node.Tag = pc;
            return node;
        }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            InitCategoryTree();
            this.mnu_AddCategory.Enabled = OperatorInfo.CurrentOperator.Permit(Permission.EditProductCategory);
            this.mnu_DeleteCategory.Enabled = OperatorInfo.CurrentOperator.Permit(Permission.EditProductCategory);
            this.mnu_CategoryProperty.Enabled = OperatorInfo.CurrentOperator.Permit(Permission.EditProductCategory) || OperatorInfo.CurrentOperator.Permit(Permission.ReadProductCategory);
            base.Init();
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmProductDetail frm = new FrmProductDetail();
            if (categoryTree.SelectedNode != null) frm.Category = categoryTree.SelectedNode.Tag as ProductCategory;
            return frm;
        }

        protected override List<object> GetDataSource()
        {
            _Products = (new ProductBLL(AppSettings.CurrentSetting.ConnectString)).GetItems(null).QueryObjects;
            List<object> records = GetSelectedNodeItems();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            Product p = item as Product;
            row.Tag = p;
            row.Cells["colImage"].Value = Properties.Resources.product;
            row.Cells["colNumber"].Value = p.ID;
            row.Cells["colName"].Value = p.Name;
            row.Cells["colForeignName"].Value = p.ForeignName;
            row.Cells["colCategoryID"].Value = p.Category != null ? p.Category.Name : p.CategoryID;
            row.Cells["colSpecification"].Value = p.Specification;
            row.Cells["colModel"].Value = p.Model;
            row.Cells["colHSCode"].Value = p.HSCode;
            row.Cells["colMemo"].Value = p.Memo;
            if (_Products == null || !_Products.Exists(it => it.ID == p.ID))
            {
                if (_Products == null) _Products = new List<Product>();
                _Products.Add(p);
            }
        }

        protected override bool DeletingItem(object item)
        {
            Product p = item as Product;
            CommandResult ret = (new ProductBLL(AppSettings.CurrentSetting.ConnectString)).Delete(p);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            else
            {
                _Products.Remove(p);
            }
            return ret.Result == ResultCode.Successful;
        }
        #endregion

        #region 事件处理程序
        private void categoryTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectNode(e.Node);
        }

        private void mnu_FreshTree_Click(object sender, EventArgs e)
        {
            InitCategoryTree();
            SelectNode(categoryTree.Nodes[0]);
        }
        #endregion

        private void mnu_AddCategory_Click(object sender, EventArgs e)
        {
            ProductCategory pc = categoryTree.SelectedNode.Tag as ProductCategory;
            FrmProductCategoryDetail frm = new FrmProductCategoryDetail();
            frm.IsAdding = true;
            frm.ParentCategory = pc;
            frm.ItemAdded += delegate(object obj, ItemAddedEventArgs args)
            {
                ProductCategory item = args.AddedItem as ProductCategory;
                AddNode(item, categoryTree.SelectedNode);
            };
            frm.ShowDialog();
        }

        private void mnu_DeleteCategory_Click(object sender, EventArgs e)
        {
            ProductCategory pc = categoryTree.SelectedNode.Tag as ProductCategory;
            if (pc != null && MessageBox.Show("是否删除此类别及其子项?", "询问", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                CommandResult ret = (new ProductCategoryBLL(AppSettings.CurrentSetting.ConnectString)).Delete(pc);
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
            ProductCategory pc = categoryTree.SelectedNode.Tag as ProductCategory;
            FrmProductCategoryDetail frm = new FrmProductCategoryDetail();
            frm.IsAdding = false;
            frm.UpdatingItem = pc;
            frm.ItemUpdated += delegate(object obj, ItemUpdatedEventArgs args)
            {
                categoryTree.SelectedNode.Text = string.Format("[{0}] {1}", pc.ID, pc.Name);
            };
            frm.ShowDialog();
        }
    }
}
