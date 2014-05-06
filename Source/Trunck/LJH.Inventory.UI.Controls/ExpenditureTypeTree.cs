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
    public partial class ExpenditureTypeTree :MyTree 
    {
        public ExpenditureTypeTree()
        {
            InitializeComponent();
        }

        public ExpenditureTypeTree(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region 私有变量
        private List<TreeNode> _AllTypeNodes = new List<TreeNode>();
        #endregion

        #region 私有方法
        private void AddDesendNodes(List<ExpenditureType> items, TreeNode parent)
        {
            List<ExpenditureType> pcs = null;
            if (parent.Tag == null)
            {
                pcs = items.Where(it => string.IsNullOrEmpty(it.Parent)).ToList();
            }
            else
            {
                pcs = items.Where(it => it.Parent == (parent.Tag as ExpenditureType).ID).ToList();
            }
            if (pcs != null && pcs.Count > 0)
            {
                foreach (ExpenditureType pc in pcs)
                {
                    TreeNode node = AddExpenditureTypeNode(pc, parent);
                    _AllTypeNodes.Add(node);
                    AddDesendNodes(items, node);
                }
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
            this.ImageList = imageList1;
            this.Nodes.Clear();
            TreeNode root = this.Nodes.Add("所有支出类别");
            root.ImageIndex = 0;
            root.SelectedImageIndex = 0;

            List<ExpenditureType> items = (new ExpenditureTypeBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            if (items != null && items.Count > 0)
            {
                AddDesendNodes(items, root);
            }
            this.ExpandAll();
        }
        /// <summary>
        /// 增加支出类别节点
        /// </summary>
        /// <param name="pc"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public TreeNode AddExpenditureTypeNode(ExpenditureType pc, TreeNode parent)
        {
            TreeNode node = parent.Nodes.Add(string.Format("{0}", pc.Name));
            node.Tag = pc;
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            return node;
        }

        /// <summary>
        /// 获取所有某个节点下的所有支出类别，包括此节点下所有后代节点的支出类别
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public List<ExpenditureType> GetCategoryofNode(TreeNode node)
        {
            List<ExpenditureType> items = new List<ExpenditureType>();
            if (node.Tag is ExpenditureType)
            {
                items.Add(node.Tag as ExpenditureType);
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
        /// 通过id获取费用类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ExpenditureType GetExpenditureType(string id)
        {
            foreach (TreeNode node in _AllTypeNodes)
            {
                ExpenditureType ct = node.Tag as ExpenditureType;
                if (ct.ID == id) return ct;
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
            foreach (TreeNode node in _AllTypeNodes)
            {
                ExpenditureType pdept = node.Tag as ExpenditureType;
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
