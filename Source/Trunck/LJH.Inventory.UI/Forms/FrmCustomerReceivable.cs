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
    public partial class FrmCustomerReceivable : FrmMasterBase
    {
        public FrmCustomerReceivable()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<CompanyInfo> _Customers = null;
        private List<CustomerState> _CustomerStates = null;
        #endregion

        #region 私有方法
        private void SelectNode(TreeNode node)
        {
            List<object> items = GetSelectedNodeItems();
            ShowItemsOnGrid(items);
        }

        private List<object> GetSelectedNodeItems()
        {
            List<CompanyInfo> items = _Customers;
            CustomerType pc = null;
            if (this.categoryTree.SelectedNode != null) pc = this.categoryTree.SelectedNode.Tag as CustomerType;
            if (pc != null) items = _Customers.Where(it => it.CategoryID == pc.ID).ToList();

            return (from p in items
                    orderby p.Name ascending
                    select (object)p).ToList();
        }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
            categoryTree.Init();
            Operator opt = Operator.Current;
            menu.Items["btn_Add"].Enabled = opt.Permit(Permission.EditCustomer);
            menu.Items["btn_Delete"].Enabled = opt.Permit(Permission.EditCustomer);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return null;
        }

        protected override bool DeletingItem(object item)
        {
            return false;
        }

        protected override List<object> GetDataSource()
        {
            CompanyBLL bll = new CompanyBLL(AppSettings.Current.ConnStr);
            if (SearchCondition == null)
            {
                CustomerSearchCondition con = new CustomerSearchCondition();
                con.ClassID = CustomerClass.Customer;
                SearchCondition = con;
            }
            _Customers = bll.GetItems(SearchCondition).QueryObjects;
            _CustomerStates = bll.GetCustomerStates().QueryObjects;
            List<object> records = GetSelectedNodeItems();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CompanyInfo c = item as CompanyInfo;
            row.Tag = c;
            row.Cells["colImage"].Value = Properties.Resources.customer;
            row.Cells["colID"].Value = c.ID;
            row.Cells["colName"].Value = c.Name;
            row.Cells["colCategory"].Value = c.CategoryID;
            CustomerState cs = null;
            if (_CustomerStates != null && _CustomerStates.Count > 0) cs = _CustomerStates.SingleOrDefault(it => it.CustomerID == c.ID);
            row.Cells["colPrepay"].Value = cs != null ? cs.Prepay.Trim() : 0;
            row.Cells["colReceivable"].Value = cs != null ? cs.Receivable.Trim() : 0;
        }
        #endregion

        #region 事件处理程序
        private void categoryTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectNode(e.Node);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colPrepay")
                {
                    CompanyInfo c = dataGridView1.Rows[e.RowIndex].Tag as CompanyInfo;
                    FrmCustomerPaymentRemains frm = new FrmCustomerPaymentRemains();
                    frm.Customer = c;
                    frm.ShowDialog();
                }
            }
        }
        #endregion
    }
}
