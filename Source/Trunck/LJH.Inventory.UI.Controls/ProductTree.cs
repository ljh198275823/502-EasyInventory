using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.UI.Controls
{
    public partial class ProductTree : MyTree
    {
        public ProductTree()
        {
            InitializeComponent();
        }

        public ProductTree(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region 私有变量
        private List<TreeNode> _AllCategoryNodes = new List<TreeNode>();
        private List<TreeNode> _AllProductNodes = new List<TreeNode>();
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置是否加载产品信息
        /// </summary>
        public bool LoadProduct { get; set; }
        #endregion

        #region 私有方法
        private void AddCategoryNodes(List<ProductCategory> items, TreeNode parent)
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
                    TreeNode node = AddCategoryNode(pc, parent);
                    AddCategoryNodes(items, node);
                }
            }
        }

        private void AddProductNodes(List<Product> products, TreeNode parent)
        {
            ProductCategory ct = parent.Tag as ProductCategory;
            List<Product> items = null;
            if (ct == null)
            {
                items = products.Where(it => string.IsNullOrEmpty(it.CategoryID)).ToList();
            }
            else
            {
                items = products.Where(it => it.CategoryID == ct.ID).ToList();
            }
            foreach (Product p in items)
            {
                AddProductNode(p, parent);
            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            this.Nodes.Clear();
            this.Nodes.Add(LoadProduct ? "所有产品" : "所有产品类别");

            List<ProductCategory> items = (new ProductCategoryBLL(AppSettings.Current.ConnStr)).GetAll().QueryObjects;
            if (items != null && items.Count > 0)
            {
                AddCategoryNodes(items, this.Nodes[0]);
            }
            if (LoadProduct)
            {
                List<Product> products = (new ProductBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
                AddProductNodes(products, this.Nodes[0]);
                foreach (TreeNode cnode in _AllCategoryNodes)
                {
                    AddProductNodes(products, cnode);
                }
            }
            this.ExpandAll();
        }
        /// <summary>
        /// 在树中添加类别节点
        /// </summary>
        /// <param name="pc"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public TreeNode AddCategoryNode(ProductCategory pc, TreeNode parent)
        {
            TreeNode node = parent.Nodes.Add(string.Format("[{0}] {1}", pc.ID, pc.Name));
            node.Tag = pc;
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            this._AllCategoryNodes.Add(node);
            return node;
        }
        /// <summary>
        /// 增加产品信息节点
        /// </summary>
        /// <param name="p"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public TreeNode AddProductNode(Product p, TreeNode parent)
        {
            TreeNode node = parent.Nodes.Add(string.Format("[{0}] {1}", p.ID, p.Name));
            node.Tag = p;
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;
            this._AllProductNodes.Add(node);
            return node;
        }
        #endregion
    }
}
