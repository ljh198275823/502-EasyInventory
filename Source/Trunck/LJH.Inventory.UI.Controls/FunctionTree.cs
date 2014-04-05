using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;

namespace LJH.Inventory.UI.Controls
{
    public partial class FunctionTree : MyTree
    {
        private readonly string RootText = "所有权限";

        private List<TreeNode> _rightNodes = new List<TreeNode>();

        public FunctionTree()
        {
            InitializeComponent();
        }

        public FunctionTree(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        #region 公共方法和属性
        public void Init()
        {
            this.ImageList = images;
            this.CheckBoxes = true;
            this.Nodes.Clear();
            TreeNode root = new TreeNode(RootText, 0, 0);
            this.Nodes.Add(root);
            List<TreeNode> catalogs = new List<TreeNode>();
            Type operatorEnum = typeof(Permission);
            FieldInfo[] fields = operatorEnum.GetFields();
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum)
                {
                    object[] attrs = field.GetCustomAttributes(false);
                    foreach (object attr in attrs)
                    {
                        if (attr is OperatorRightAttribute)
                        {
                            OperatorRightAttribute right = attr as OperatorRightAttribute;
                            string catalog = right.Catalog;
                            TreeNode catalogNode = catalogs.Find(t => t.Text == catalog);
                            if (catalogNode == null)
                            {
                                catalogNode = new TreeNode(catalog, 0, 0);
                                root.Nodes.Add(catalogNode);
                                catalogs.Add(catalogNode);
                            }
                            TreeNode rightNode = new TreeNode(right.Description, 1, 1);
                            rightNode.Tag = field.GetValue(null);
                            catalogNode.Nodes.Add(rightNode);
                            _rightNodes.Add(rightNode);
                        }
                    }
                }
            }
            root.Expand();
        }

        [Browsable(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedRights
        {
            get
            {
                if (this.Nodes[0].Checked)
                {
                    return "all";
                }
                else
                {
                    List<Permission> rights = new List<Permission>();
                    foreach (TreeNode node in _rightNodes)
                    {
                        if (node.Checked)
                        {
                            rights.Add((Permission)node.Tag);
                        }
                    }
                    var list = from right in rights
                               select right.ToString("D");
                    return string.Join(",", list.ToArray());
                }

            }
            set
            {
                if (value.ToLower() == "all")
                {
                    this.Nodes[0].Checked = true;
                }
                else if (!string.IsNullOrEmpty(value))
                {
                    foreach (string str in value.Split(','))
                    {
                        int i;
                        if (int.TryParse(str, out i))
                        {
                            TreeNode node = _rightNodes.Find(n => (int)n.Tag == i);
                            if (node != null)
                            {
                                node.Checked = true;
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
