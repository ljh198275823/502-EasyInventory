using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmCustomerFinancialStateMaster : FrmMasterBase
    {
        public FrmCustomerFinancialStateMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<CustomerFinancialState> _CustomerStates = null;
        #endregion

        #region 私有方法
        private void FreshData()
        {
            List<object> items = FilterData();
            ShowItemsOnGrid(items);
        }

        private List<object> FilterData()
        {
            List<CustomerFinancialState> items = _CustomerStates;
            if (items != null && items.Count > 0)
            {
                if (this.categoryTree.SelectedNode != null)
                {
                    var categories = categoryTree.GetCategoryofNode(this.categoryTree.SelectedNode);
                    if (categories != null) items = items.Where(it => categories.Exists(c => c.ID == it.Customer.CategoryID)).ToList();
                }
                if (chkOnlyHasRecievables.Checked) items = items.Where(it => it.Recievables > 0).ToList();
                return (from p in items
                        orderby p.Customer.Name ascending
                        select (object)p).ToList();
            }
            return null;
        }
        #endregion

        #region 重写基类方法
        protected override void ReFreshData()
        {
            categoryTree.Init();
            base.ReFreshData();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            cMnu_Payment.Enabled = Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.Edit);
        }

        protected override List<object> GetDataSource()
        {
            _CustomerStates = new CompanyBLL(AppSettings.Current.ConnStr).GetAllCustomerStates().QueryObjects;
            List<object> records = FilterData();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CustomerFinancialState cs = item as CustomerFinancialState;
            row.Tag = cs;
            row.Cells["colImage"].Value = Properties.Resources.customer;
            row.Cells["colID"].Value = cs.Customer.ID;
            row.Cells["colName"].Value = cs.Customer.Name;
            row.Cells["colCategory"].Value = cs.Customer.CategoryID;
            row.Cells["colCreditLine"].Value = cs.Customer.CreditLine;
            row.Cells["colPrepay"].Value = cs.Prepay;
            row.Cells["colReceivable"].Value = cs.Recievables;
            row.Cells["colFileID"].Value = cs.Recievables > 0 ? (cs.Customer.FileID.HasValue ? cs.Customer.FileID.ToString() : null) : null;
        }

        protected override void ShowItemsOnGrid(List<object> items)
        {
            base.ShowItemsOnGrid(items);
            Filter(txtKeyword.Text.Trim());
        }
        #endregion

        #region 事件处理程序
        private void FreshData_Clicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            FreshData();
        }

        private void FreshData_Clicked(object sender, EventArgs e)
        {
            FreshData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colReceivable")
                {
                    CompanyInfo c = (dataGridView1.Rows[e.RowIndex].Tag as CustomerFinancialState).Customer;
                    View.FrmCustomerReceivableView frm = new View.FrmCustomerReceivableView();
                    CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
                    con.CustomerID = c.ID;
                    con.ReceivableTypes = new List<CustomerReceivableType>();
                    con.ReceivableTypes.Add(CustomerReceivableType.CustomerOtherReceivable);
                    con.ReceivableTypes.Add(CustomerReceivableType.CustomerReceivable);
                    con.Settled = false;
                    frm.SearchCondition = con;
                    frm.Text = string.Format("{0} 应收款明细", c.Name);
                    frm.ShowDialog();
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colPrepay")
                {
                    CompanyInfo c = (dataGridView1.Rows[e.RowIndex].Tag as CustomerFinancialState).Customer;
                    View.FrmCustomerPaymentView frm = new View.FrmCustomerPaymentView();
                    CustomerPaymentSearchCondition con = new CustomerPaymentSearchCondition();
                    con.CustomerID = c.ID;
                    con.PaymentTypes = new List<CustomerPaymentType>();
                    con.PaymentTypes.Add(CustomerPaymentType.Customer);
                    con.States = new List<SheetState>();
                    con.States.Add(SheetState.Add);
                    con.States.Add(SheetState.Approved);
                    con.HasRemain = true;
                    frm.SearchCondition = con;
                    frm.PaymentType = CustomerPaymentType.Customer;
                    frm.Text = string.Format("{0} 付款流水明细", c.Name);
                    frm.ShowDialog();
                    //刷新数据
                    var cs = new CompanyBLL(AppSettings.Current.ConnStr).GetCustomerState(c.ID).QueryObject;
                    if (cs != null) ShowItemInGridViewRow(dataGridView1.Rows[e.RowIndex], cs);
                }
            }
        }

        private void mnu_Payment_Click(object sender, EventArgs e)
        {
            FrmCustomerPaymentDetail frm = new FrmCustomerPaymentDetail();
            CompanyInfo customer = dataGridView1.SelectedRows.Count == 1 ? (dataGridView1.SelectedRows[0].Tag as CustomerFinancialState).Customer : null;
            frm.Customer = customer;
            frm.PaymentType = CustomerPaymentType.Customer;
            frm.IsAdding = true;
            frm.ShowDialog();
            ReFreshData();
            if (customer != null)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var cs = row.Tag as CustomerFinancialState;
                    row.Selected = cs.Customer.ID == customer.ID;
                }
            }
        }

        private void mnu_SetFileID_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                CustomerFinancialState customerState = dataGridView1.SelectedRows[0].Tag as CustomerFinancialState;
                if (customerState.Recievables > 0)
                {
                    CompanyInfo customer = customerState.Customer;
                    List<int> exludes = new List<int>();
                    foreach (var cs in _CustomerStates)
                    {
                        CompanyInfo c = cs.Customer;
                        if (c.ID != customer.ID && c.City == customer.City && c.FileID.HasValue && cs.Recievables > 0)
                        {
                            exludes.Add(c.FileID.Value);
                        }
                    }
                    FrmSetFileID frm = new FrmSetFileID();
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ExcludeFileIDs = exludes;
                    frm.Customer = customer;
                    if (frm.ShowDialog() == DialogResult.OK) ShowItemInGridViewRow(dataGridView1.SelectedRows[0], customerState);
                }
            }
        }

        private void mnu_UpdateCreditLine_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var cs = dataGridView1.SelectedRows[0].Tag as CustomerFinancialState;
                FrmCreditLine frm = new FrmCreditLine();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.Customer = cs.Customer;
                if (frm.ShowDialog() == DialogResult.OK) ShowItemInGridViewRow(dataGridView1.SelectedRows[0], cs);
            }
        }
        #endregion

       
    }
}
