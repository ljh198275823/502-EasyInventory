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
    public partial class FrmSupplierMaster : FrmMasterBase
    {
        public FrmSupplierMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<Customer> _Customers = null;
        #endregion

        #region 私有方法
        private void InitCategoryTree()
        {
            this.categoryTree.Nodes.Clear();
            this.categoryTree.Nodes.Add("所有供应商类别");

            List<SupplierType> items = (new SupplierTypeBLL(AppSettings.CurrentSetting.ConnStr)).GetAll().QueryObjects;
            if (items != null && items.Count > 0)
            {
                AddDesendNodes(items, this.categoryTree.Nodes[0]);
            }
        }

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
            List<Customer> items = _Customers;
            SupplierType pc = null;
            if (this.categoryTree.SelectedNode != null) pc = this.categoryTree.SelectedNode.Tag as SupplierType;
            if (pc != null) items = _Customers.Where(it => it.CategoryID == pc.ID).ToList();

            return (from p in items
                    orderby p.Name ascending
                    select (object)p).ToList();
        }

        private TreeNode AddNode(SupplierType pc, TreeNode parent)
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
            OperatorInfo opt = OperatorInfo.CurrentOperator;
            menu.Items["btn_Add"].Enabled = opt.Permit(Permission.EditSupplier);
            menu.Items["btn_Delete"].Enabled = opt.Permit(Permission.EditSupplier);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmSupplierDetail frm = new FrmSupplierDetail();
            frm.Category = categoryTree.SelectedNode != null ? (categoryTree.SelectedNode.Tag as SupplierType) : null;
            return frm;
        }

        protected override bool DeletingItem(object item)
        {
            Customer c = item as Customer;
            CustomerBLL bll = new CustomerBLL(AppSettings.CurrentSetting.ConnStr);
            CommandResult ret = bll.Delete(c);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            else
            {
                _Customers.Remove(c);
            }
            return ret.Result == ResultCode.Successful;
        }

        protected override List<object> GetDataSource()
        {
            CustomerBLL bll = new CustomerBLL(AppSettings.CurrentSetting.ConnStr);
            if (SearchCondition == null)
            {
                CustomerSearchCondition con = new CustomerSearchCondition();
                con.ClassID = CustomerClass.Supplier;
                SearchCondition = con;
            }
            _Customers = bll.GetItems(SearchCondition).QueryObjects;
            List<object> records = GetSelectedNodeItems();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            Customer c = item as Customer;
            row.Tag = c;
            row.Cells["colImage"].Value = Properties.Resources.customer;
            row.Cells["colID"].Value = c.ID;
            row.Cells["colNation"].Value = c.Nation;
            row.Cells["colName"].Value = c.Name;
            row.Cells["colWebsite"].Value = c.Website;
            row.Cells["colTelphone"].Value = c.TelPhone;
            row.Cells["colFax"].Value = c.Fax;
            row.Cells["colAddress"].Value = c.Address;
            row.Cells["colPostalCode"].Value = c.PostalCode;
            row.Cells["colMemo"].Value = c.Memo;
            if (_Customers == null || !_Customers.Exists(it => it.ID == c.ID))
            {
                if (_Customers == null) _Customers = new List<Customer>();
                _Customers.Add(c);
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
            SupplierType pc = categoryTree.SelectedNode.Tag as SupplierType;
            FrmSupplierTypeDetail frm = new FrmSupplierTypeDetail();
            frm.IsAdding = true;
            frm.ParentCategory = pc;
            frm.ItemAdded += delegate(object obj, ItemAddedEventArgs args)
            {
                SupplierType item = args.AddedItem as SupplierType;
                AddNode(item, categoryTree.SelectedNode);
            };
            frm.ShowDialog();
        }

        private void mnu_DeleteCategory_Click(object sender, EventArgs e)
        {
            SupplierType pc = categoryTree.SelectedNode.Tag as SupplierType;
            if (pc != null && MessageBox.Show("是否删除此类别及其子项?", "询问", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                CommandResult ret = (new SupplierTypeBLL(AppSettings.CurrentSetting.ConnStr)).Delete(pc);
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
            SupplierType pc = categoryTree.SelectedNode.Tag as SupplierType;
            FrmSupplierTypeDetail frm = new FrmSupplierTypeDetail();
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
