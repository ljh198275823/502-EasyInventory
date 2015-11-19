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
        private List<CustomerState> _CustomerStates = null;
        #endregion

        #region 私有方法
        private void FreshData()
        {
            List<object> items = FilterData();
            ShowItemsOnGrid(items);
        }

        private List<object> FilterData()
        {
            List<CustomerState> items = _CustomerStates;
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
            CustomerPaymentSearchCondition cpsc = new CustomerPaymentSearchCondition();
            cpsc.PaymentTypes = new List<CustomerPaymentType>();
            cpsc.PaymentTypes.Add(CustomerPaymentType.Customer);
            cpsc.States = new List<SheetState>();
            cpsc.States.Add(SheetState.Add);
            cpsc.States.Add(SheetState.Approved);
            cpsc.HasRemain = true;
            var customerPayments = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetItems(cpsc).QueryObjects;

            CustomerReceivableSearchCondition crsc = new CustomerReceivableSearchCondition();
            crsc.Settled = false;
            crsc.ReceivableTypes = new List<CustomerReceivableType>();
            crsc.ReceivableTypes.Add(CustomerReceivableType.CustomerOtherReceivable);
            crsc.ReceivableTypes.Add(CustomerReceivableType.CustomerReceivable);
            var customerReceivables = (new CustomerReceivableBLL(AppSettings.Current.ConnStr)).GetItems(crsc).QueryObjects;

            CompanyBLL bll = new CompanyBLL(AppSettings.Current.ConnStr);
            List<CompanyInfo> customers = null;
            if (SearchCondition == null)
            {
                CustomerSearchCondition con = new CustomerSearchCondition();
                con.ClassID = CompanyClass.Customer;
                customers = bll.GetItems(con).QueryObjects;
            }
            else
            {
                customers = bll.GetItems(SearchCondition).QueryObjects;
            }

            if (customers != null && customers.Count > 0)
            {
                _CustomerStates = new List<CustomerState>();
                foreach (var c in customers)
                {
                    CustomerState cs = new CustomerState()
                    {
                        Customer = c,
                        Recievables = customerReceivables != null ? customerReceivables.Sum(it => it.CustomerID == c.ID ? it.Remain : 0) : 0,
                        Prepay = customerPayments != null ? customerPayments.Sum(it => it.CustomerID == c.ID ? it.Remain : 0) : 0,
                    };
                    _CustomerStates.Add(cs);
                }
            }

            List<object> records = FilterData();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CustomerState cs = item as CustomerState;
            CompanyInfo c = cs.Customer;
            row.Tag = c;
            row.Cells["colImage"].Value = Properties.Resources.customer;
            row.Cells["colID"].Value = c.ID;
            row.Cells["colName"].Value = c.Name;
            row.Cells["colCategory"].Value = c.CategoryID;
            row.Cells["colCreditLine"].Value = c.CreditLine;
            row.Cells["colPrepay"].Value = cs.Prepay;
            row.Cells["colReceivable"].Value = cs.Recievables;
            row.Cells["colFileID"].Value = cs.Recievables > 0 ? (c.FileID.HasValue ? c.FileID.ToString() : null) : null;
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
                    CompanyInfo c = (dataGridView1.Rows[e.RowIndex].Tag as CustomerState).Customer;
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
                    CompanyInfo c = (dataGridView1.Rows[e.RowIndex].Tag as CustomerState).Customer;
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
                    ReFreshData(); //刷新数据
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        var cs = row.Tag as CustomerState;
                        row.Selected = cs.Customer.ID == c.ID;
                    }
                }
            }
        }

        private void mnu_Payment_Click(object sender, EventArgs e)
        {
            FrmCustomerPaymentDetail frm = new FrmCustomerPaymentDetail();
            CompanyInfo customer = dataGridView1.SelectedRows.Count == 1 ? (dataGridView1.SelectedRows[0].Tag as CustomerState).Customer : null;
            frm.Customer = customer;
            frm.PaymentType = CustomerPaymentType.Customer;
            frm.IsAdding = true;
            frm.ShowDialog();
            ReFreshData();
            if (customer != null)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var cs = row.Tag as CustomerState;
                    row.Selected = cs.Customer.ID == customer.ID;
                }
            }
        }

        private void mnu_SetFileID_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                CustomerState customerState = dataGridView1.SelectedRows[0].Tag as CustomerState;
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
                var cs = dataGridView1.SelectedRows[0].Tag as CustomerState;
                FrmCreditLine frm = new FrmCreditLine();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.Customer = cs.Customer;
                if (frm.ShowDialog() == DialogResult.OK) ShowItemInGridViewRow(dataGridView1.SelectedRows[0], cs);
            }
        }
        #endregion

        internal class CustomerState
        {
            public CompanyInfo Customer { get; set; }

            public decimal Recievables { get; set; }

            public decimal Prepay { get; set; }
        }
    }
}
