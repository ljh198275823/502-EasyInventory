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
    public partial class FrmCustomerMaster : FrmMasterBase
    {
        public FrmCustomerMaster()
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
            this.categoryTree.Nodes.Add("所有客户类别");

            List<CustomerType> items = (new CustomerTypeBLL(AppSettings.CurrentSetting.ConnectString)).GetAll().QueryObjects;
            if (items != null && items.Count > 0)
            {
                AddDesendNodes(items, this.categoryTree.Nodes[0]);
            }
        }

        private void AddDesendNodes(List<CustomerType> items, TreeNode parent)
        {
            List<CustomerType> pcs = null;
            if (parent.Tag == null)
            {
                pcs = items.Where(it => string.IsNullOrEmpty(it.Parent)).ToList();
            }
            else
            {
                pcs = items.Where(it => it.Parent == (parent.Tag as CustomerType).ID).ToList();
            }
            if (pcs != null && pcs.Count > 0)
            {
                foreach (CustomerType pc in pcs)
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
            CustomerType pc = null;
            if (this.categoryTree.SelectedNode != null) pc = this.categoryTree.SelectedNode.Tag as CustomerType;
            if (pc != null) items = _Customers.Where(it => it.CategoryID == pc.ID).ToList();

            return (from p in items
                    orderby p.Name ascending
                    select (object)p).ToList();
        }

        private TreeNode AddNode(CustomerType pc, TreeNode parent)
        {
            TreeNode node = parent.Nodes.Add(string.Format("{0}",pc.Name));
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
            menu.Items["btn_Add"].Enabled = opt.Permit(Permission.EditCustomer);
            menu.Items["btn_Delete"].Enabled = opt.Permit(Permission.EditCustomer);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmCustomerDetail frm = new FrmCustomerDetail();
            frm.Category = categoryTree.SelectedNode != null ? (categoryTree.SelectedNode.Tag as CustomerType) : null;
            return frm;
        }

        protected override bool DeletingItem(object item)
        {
            Customer c = item as Customer;
            CustomerBLL bll = new CustomerBLL(AppSettings.CurrentSetting.ConnectString);
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
            CustomerBLL bll = new CustomerBLL(AppSettings.CurrentSetting.ConnectString);
            if (SearchCondition == null)
            {
                CustomerSearchCondition con = new CustomerSearchCondition();
                con.ClassID = CustomerClass.Customer;
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
            row.Cells["colMedia"].Value = c.Media;
            row.Cells["colBusinessMan"].Value = c.BusinessMan;
            if (_Customers == null || !_Customers.Exists(it => it.ID == c.ID))
            {
                if (_Customers == null) _Customers = new List<Customer>();
                _Customers.Add(c);
            }
        }
        #endregion

        #region 事件处理程序
        private void mnu_Payment_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Customer c = dataGridView1.SelectedRows[0].Tag as Customer;
                FrmCustomerPaymentDetail frm = new FrmCustomerPaymentDetail();
                frm.Customer = c;
                frm.IsAdding = true;
                frm.ItemAdded += delegate(object obj, ItemAddedEventArgs args)
                {
                    Customer c1 = (new CustomerBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(c.ID).QueryObject;
                    if (c1 != null)
                    {
                        ShowItemInGridViewRow(dataGridView1.SelectedRows[0], c1);
                    }
                };
                frm.ShowDialog();
            }
        }

        private void mnu_ShowDeadlineDeliverySheets_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count == 1)
            //{
            //    Customer c = dataGridView1.SelectedRows[0].Tag as Customer;
            //    List<DeliverySheet> items = null;
            //    if (c.UnSettleSheets != null && c.UnSettleSheets.Count > 0)
            //    {
            //        items = c.UnSettleSheets.Where(item => item.IsOnDeadline).ToList();
            //    }
            //    FrmDeliverySheetView frm = new FrmDeliverySheetView();
            //    frm.ShowDeliverySheets(items);
            //    frm.ShowCustomer(c);
            //    frm.ShowDialog();
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colPrepay")
                {
                    Customer c = dataGridView1.Rows[e.RowIndex].Tag as Customer;
                    FrmCustomerPaymentRemains frm = new FrmCustomerPaymentRemains();
                    frm.Customer = c;
                    frm.ShowDialog();
                }
            }
        }

        private void mnu_Payment_Click_1(object sender, EventArgs e)
        {

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
            CustomerType pc = categoryTree.SelectedNode.Tag as CustomerType;
            FrmCustomerTypeDetail frm = new FrmCustomerTypeDetail();
            frm.IsAdding = true;
            frm.ParentCategory = pc;
            frm.ItemAdded += delegate(object obj, ItemAddedEventArgs args)
            {
                CustomerType item = args.AddedItem as CustomerType;
                AddNode(item, categoryTree.SelectedNode);
            };
            frm.ShowDialog();
        }

        private void mnu_DeleteCategory_Click(object sender, EventArgs e)
        {
            CustomerType pc = categoryTree.SelectedNode.Tag as CustomerType;
            if (pc != null && MessageBox.Show("是否删除此类别及其子项?", "询问", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                CommandResult ret = (new CustomerTypeBLL(AppSettings.CurrentSetting.ConnectString)).Delete(pc);
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
            CustomerType pc = categoryTree.SelectedNode.Tag as CustomerType;
            FrmCustomerTypeDetail frm = new FrmCustomerTypeDetail();
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
