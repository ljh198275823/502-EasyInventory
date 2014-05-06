using System;
using System.Collections.Generic;
using System.Collections ;
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
        private Hashtable _AllProducts = null;
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
            _AllCategoryNodes.Clear();
            _AllProductNodes.Clear();
            if (_AllProducts != null) _AllProducts.Clear();
            this.Nodes.Clear();
            this.Nodes.Add(LoadProduct ? "所有产品" : "所有产品类别");

            List<ProductCategory> items = (new ProductCategoryBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            if (items != null && items.Count > 0)
            {
                AddCategoryNodes(items, this.Nodes[0]);
            }
            if (LoadProduct)
            {
                List<Product> products = (new ProductBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
                if (products != null && products.Count > 0)
                {
                    if (_AllProducts == null) _AllProducts = new Hashtable();
                    products.ForEach(it => _AllProducts.Add(it.ID, it));
                }
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
        /// <summary>
        /// 获取所有某个节点下的所有产品信息，包括此节点下所有后代产品节点的产品信息
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public List<Product> GetProductsofNode(TreeNode node)
        {
            List<Product> items = new List<Product>();
            if (node.Tag is Product)
            {
                items.Add(node.Tag as Product);
            }
            else if (node.Nodes.Count > 0)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    items.AddRange(GetProductsofNode(child));
                }
            }
            return items;
        }
        /// <summary>
        /// 获取所有某个节点下的所有产品类别信息，包括此节点下所有后代产品类别节点的产品类别信息
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public List<ProductCategory> GetCategoryofNode(TreeNode node)
        {
            List<ProductCategory> items = new List<ProductCategory>();
            if (node.Tag is ProductCategory)
            {
                items.Add(node.Tag as ProductCategory);
            }
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    items.AddRange(GetCategoryofNode(child));
                }
            }
            return items;
        }
        /// <summary>
        /// 通过id获取树中的产品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProduct(string id)
        {
            if (_AllProducts != null && _AllProducts.Count > 0)
            {
                return _AllProducts[id] as Product;
            }
            return null;
        }
        /// <summary>
        /// 通过部门ID获取产品类别信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductCategory GetCategory(string id)
        {
            if (_AllCategoryNodes != null && _AllCategoryNodes.Count > 0)
            {
                foreach (TreeNode node in _AllCategoryNodes)
                {
                    ProductCategory dept = node.Tag as ProductCategory;
                    if (dept != null && dept.ID == id) return dept;
                }
            }
            return null;
        }
        /// <summary>
        /// 选择指定类别ID的节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="parent"></param>
        public void SelectCategoryNode(string categoryID)
        {
            foreach (TreeNode node in _AllCategoryNodes)
            {
                ProductCategory pdept = node.Tag as ProductCategory;
                if (pdept.ID == categoryID)
                {
                    this.SelectedNode = node;
                    break;
                }
            }
        }
        #endregion
    }
}
