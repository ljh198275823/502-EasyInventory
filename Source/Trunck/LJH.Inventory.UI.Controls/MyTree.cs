using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace LJH.Inventory.UI.Controls
{
    public partial class MyTree : System.Windows.Forms.TreeView
    {
        #region 构造函数
        public MyTree()
        {
            InitializeComponent();
            this.AfterCheck += MyTree_AfterCheck;
        }

        public MyTree(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.AfterCheck += MyTree_AfterCheck;
        }
        #endregion

        #region 私有方法
        private void MyTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            this.AfterCheck -= MyTree_AfterCheck;
            CheckChildren(e.Node);
            CheckParent(e.Node);
            this.AfterCheck += MyTree_AfterCheck;
        }

        private void CheckChildren(TreeNode curNode)
        {
            foreach (TreeNode nod in curNode.Nodes)
            {
                nod.Checked = curNode.Checked;
                CheckChildren(nod);
            }
        }

        private void CheckParent(TreeNode curNode)
        {
            TreeNode parent = curNode.Parent;
            if (parent != null)
            {
                bool allChecked = true;
                foreach (TreeNode n in parent.Nodes)
                {
                    if (n.Checked == false)
                    {
                        allChecked = false;
                        break;
                    }
                }
                parent.Checked = allChecked;
                CheckParent(parent);
            }
        }
        #endregion

        #region 重写基类方法
        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            if (!object.ReferenceEquals(this.SelectedNode, e.Node))
            {
                if (this.SelectedNode != null)
                {
                    this.SelectedNode.BackColor = Color.White;
                    this.SelectedNode.ForeColor = Color.Black;
                }
                this.SelectedNode = e.Node;
                this.SelectedNode.BackColor = Color.Blue;  //Color.FromArgb(128, 128, 255);
                this.SelectedNode.ForeColor = Color.White;
            }
            base.OnNodeMouseClick(e);
        }
        #endregion
    }
}
