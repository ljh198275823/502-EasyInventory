﻿using System;
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
    public partial class DepartmentTree : MyTree
    {
        public DepartmentTree()
        {
            InitializeComponent();
        }

        public DepartmentTree(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region 私有变量
        private List<TreeNode> _AllDeptNodes = new List<TreeNode>();
        private List<TreeNode> _AllStaffNodes = new List<TreeNode>();
        private Hashtable _AllStaff = new Hashtable();
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置是否在树中显示公司信息，否则只显示公司类别
        /// </summary>
        public bool LoadStaff { get; set; }
        #endregion

        #region 私有方法
        private void AddDeptNodes(List<Department> items, TreeNode parent)
        {
            List<Department> pcs = null;
            if (parent.Tag == null)
            {
                pcs = items.Where(it => string.IsNullOrEmpty(it.Parent)).ToList();
            }
            else
            {
                pcs = items.Where(it => it.Parent == (parent.Tag as Department).ID).ToList();
            }
            if (pcs != null && pcs.Count > 0)
            {
                foreach (Department pc in pcs)
                {
                    TreeNode node = AddDepartmentNode(pc, parent);
                    AddDeptNodes(items, node);
                }
            }
            parent.ImageIndex = 0;
            parent.SelectedImageIndex = 0;
        }

        private void AddStaffNodes(List<Staff> staffs, TreeNode parent)
        {
            Department ct = parent.Tag as Department;
            List<Staff> items = null;
            if (ct == null)
            {
                items = staffs.Where(it => string.IsNullOrEmpty(it.DepartmentID)).ToList();
            }
            else
            {
                items = staffs.Where(it => it.DepartmentID == ct.ID).ToList();
            }
            foreach (Staff c in items)
            {
                AddStaffNode(c, parent);
            }
        }

        private void RenderDeptNode(Department pc, TreeNode node)
        {
            node.Tag = pc;
            node.SelectedImageIndex = 0;
            node.ImageIndex = 0;
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 初始化
        /// </summary
        public void Init()
        {
            _AllDeptNodes.Clear();
            _AllStaffNodes.Clear();
            _AllStaff.Clear();
            this.ImageList = imageList1;
            this.Nodes.Clear();
            this.Nodes.Add(LoadStaff ? "所有用户" : "所有部门");

            List<Department> items = (new DepartmentBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            if (items != null && items.Count > 0)
            {
                AddDeptNodes(items, this.Nodes[0]);
            }

            if (LoadStaff)
            {
                List<Staff> staffs = (new StaffBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
                if (staffs != null && staffs.Count > 0)
                {
                    _AllStaff = new Hashtable();
                    staffs.ForEach(it => _AllStaff.Add(it.ID, it));
                }
                AddStaffNodes(staffs, this.Nodes[0]);
                foreach (TreeNode cnode in _AllDeptNodes)
                {
                    AddStaffNodes(staffs, cnode);
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
        public TreeNode AddDepartmentNode(Department pc, TreeNode parent)
        {
            TreeNode node = parent.Nodes.Add(string.Format("{0}", pc.Name));
            RenderDeptNode(pc, node);
            _AllDeptNodes.Add(node);
            return node;
        }
        /// <summary>
        /// 增加客户
        /// </summary>
        /// <param name="c"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public TreeNode AddStaffNode(Staff c, TreeNode parent)
        {
            TreeNode node = parent.Nodes.Add(string.Format("[{0}]{1}", c.ID, c.Name));
            node.Tag = c;
            node.SelectedImageIndex = 1;
            node.ImageIndex = 1;
            _AllStaffNodes.Add(node);
            return node;
        }
        /// <summary>
        /// 获取所有某个节点下的所有公司信息，包括此节点下所有后代公司节点的公司信息
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public List<Staff> GetStaffofNode(TreeNode node)
        {
            List<Staff> items = new List<Staff>();
            if (node.Tag is Operator)
            {
                items.Add(node.Tag as Staff);
            }
            else if (node.Nodes.Count > 0)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    items.AddRange(GetStaffofNode(child));
                }
            }
            return items;
        }
        /// <summary>
        /// 获取所有某个节点下的所有产品类别信息，包括此节点下所有后代产品类别节点的产品类别信息
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public List<Department> GetDepartmentofNode(TreeNode node)
        {
            List<Department> items = new List<Department>();
            if (node.Tag is Department)
            {
                items.Add(node.Tag as Department);
            }
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    items.AddRange(GetDepartmentofNode(child));
                }
            }
            return items;
        }
        /// <summary>
        /// 通过id获取客户树中的客户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Staff GetStaff(string id)
        {
            if (_AllStaff != null && _AllStaff.Count > 0)
            {
                return _AllStaff[id] as Staff;
            }
            return null;
        }
        /// <summary>
        /// 通过部门ID获取部门信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department GetDepartment(string id)
        {
            if (_AllDeptNodes != null && _AllDeptNodes.Count > 0)
            {
                foreach (TreeNode node in _AllDeptNodes)
                {
                    Department dept = node.Tag as Department;
                    if (dept != null && dept.ID == id) return dept;
                }
            }
            return null;
        }
        /// <summary>
        /// 选择指定部门ID的节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="parent"></param>
        public void SelectDeptNode(string deptID)
        {
            foreach (TreeNode node in _AllDeptNodes)
            {
                Department pdept = node.Tag as Department;
                if (pdept.ID == deptID)
                {
                    this.SelectedNode = node;
                    break;
                }
            }
        }
        #endregion
    }
}
