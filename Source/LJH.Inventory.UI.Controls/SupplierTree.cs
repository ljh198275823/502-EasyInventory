using System;
using System.Collections;
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
    public partial class SupplierTree : MyTree
    {
        #region 构造函数
        public SupplierTree()
        {
            InitializeComponent();
        }

        public SupplierTree(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region 私有变量
        private List<TreeNode> _AllTypeNodes = new List<TreeNode>();
        private List<TreeNode> _AllCustomerNodes = new List<TreeNode>();
        private Hashtable _Companys = null;
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置是否在树中显示公司信息，否则只显示公司类别
        /// </summary>
        public bool LoadSupplier { get; set; }
        #endregion

        #region 私有方法
        private void AddDesendNodes(List<SupplierType> items, TreeNode parent)
        {
            List<SupplierType> pcs = null;
            if (parent.Tag == null)
            {
                pcs = items.Where(it => string.IsNullOrEmpty(it.Parent)).ToList();
            }
            else
            {
                pcs = items.Where(it => it.Parent == (parent.Tag as SupplierType).ID).ToList();
            }
            if (pcs != null && pcs.Count > 0)
            {
                foreach (SupplierType pc in pcs)
                {
                    TreeNode node = AddSupplierTypeNode(pc, parent);
                    AddDesendNodes(items, node);
                }
            }
            parent.ImageIndex = 0;
            parent.SelectedImageIndex = 0;
        }

        private void AddCustomerNodes(List<CompanyInfo> customers, TreeNode parent)
        {
            SupplierType ct = parent.Tag as SupplierType;
            List<CompanyInfo> items = null;
            if (ct == null)
            {
                items = customers.Where(it => string.IsNullOrEmpty(it.CategoryID)).ToList();
            }
            else
            {
                items = customers.Where(it => it.CategoryID == ct.ID).ToList();
            }
            foreach (CompanyInfo c in items)
            {
                AddCustomerNode(c, parent);
            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            _AllTypeNodes.Clear();
            _AllCustomerNodes.Clear();
            if (_Companys != null) _Companys.Clear();
            this.ImageList = imageList1;
            this.Nodes.Clear();
            this.Nodes.Add(LoadSupplier ? "所有供应商" : "所有供应商类别");

            List<SupplierType> items = (new SupplierTypeBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            if (items != null && items.Count > 0)
            {
                AddDesendNodes(items, this.Nodes[0]);
            }

            if (LoadSupplier)
            {
                List<CompanyInfo> customers = (new CompanyBLL(AppSettings.Current.ConnStr)).GetAllSuppliers().QueryObjects;
                if (customers != null && customers.Count > 0)
                {
                    _Companys = new Hashtable();
                    customers.ForEach(it => _Companys.Add(it.ID, it));
                }
                AddCustomerNodes(customers, this.Nodes[0]);
                foreach (TreeNode cnode in _AllTypeNodes)
                {
                    AddCustomerNodes(customers, cnode);
                }
            }
            this.ExpandAll();
        }
        /// <summary>
        /// 增加客户类别
        /// </summary>
        /// <param name="pc"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public TreeNode AddSupplierTypeNode(SupplierType pc, TreeNode parent)
        {
            TreeNode node = parent.Nodes.Add(string.Format("{0}", pc.Name));
            node.Tag = pc;
            node.SelectedImageIndex = 0;
            node.ImageIndex = 0;
            _AllTypeNodes.Add(node);
            return node;
        }
        /// <summary>
        /// 增加客户
        /// </summary>
        /// <param name="c"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public TreeNode AddCustomerNode(CompanyInfo c, TreeNode parent)
        {
            TreeNode node = parent.Nodes.Add(string.Format("[{0}]{1}", c.ID, c.Name));
            node.Tag = c;
            node.SelectedImageIndex = 1;
            node.ImageIndex = 1;
            _AllCustomerNodes.Add(node);
            return node;
        }
        /// <summary>
        /// 获取所有某个节点下的所有公司信息，包括此节点下所有后代公司节点的公司信息
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public List<CompanyInfo> GetCompanyofNode(TreeNode node)
        {
            List<CompanyInfo> items = new List<CompanyInfo>();
            if (node.Tag is CompanyInfo)
            {
                items.Add(node.Tag as CompanyInfo);
            }
            else if (node.Nodes.Count > 0)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    items.AddRange(GetCompanyofNode(child));
                }
            }
            return items;
        }
        /// <summary>
        /// 获取所有某个节点下的所有产品类别信息，包括此节点下所有后代产品类别节点的产品类别信息
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public List<SupplierType> GetCategoryofNode(TreeNode node)
        {
            List<SupplierType> items = new List<SupplierType>();
            if (node.Tag is SupplierType)
            {
                items.Add(node.Tag as SupplierType);
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
        /// 通过id获取客户树中的客户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CompanyInfo GetSupplier(string id)
        {
            if (_Companys != null && _Companys.Count > 0)
            {
                return _Companys[id] as CompanyInfo;
            }
            return null;
        }
        /// <summary>
        /// 通过id获取供应商类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SupplierType GetSupplierType(string id)
        {
            foreach (TreeNode node in _AllTypeNodes)
            {
                SupplierType ct = node.Tag as SupplierType;
                if (ct.ID == id) return ct;
            }
            return null;
        }
        /// <summary>
        /// 选择指定类别ID的节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="parent"></param>
        public void SelectSupplierTypeNode(string typeID)
        {
            foreach (TreeNode node in _AllTypeNodes)
            {
                SupplierType pdept = node.Tag as SupplierType;
                if (pdept.ID == typeID)
                {
                    this.SelectedNode = node;
                    break;
                }
            }
        }
        #endregion
    }
}
