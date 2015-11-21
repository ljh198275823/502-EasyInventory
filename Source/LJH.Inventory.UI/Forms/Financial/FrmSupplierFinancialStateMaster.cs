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
using LJH.Inventory.UI.Forms.Financial;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmSupplierFinancialStateMaster : FrmMasterBase
    {
        public FrmSupplierFinancialStateMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<CompanyInfo> _Customers = null;
        private List<CustomerPayment> _CustomerPayments = null;
        private List<CustomerReceivable> _CustomerReceivables = null;
        #endregion

        #region 私有方法
        private void FreshData()
        {
            List<object> items = FilterData();
            ShowItemsOnGrid(items);
        }

        private List<object> FilterData()
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
            cpsc.PaymentTypes.Add(CustomerPaymentType.Supplier);
            cpsc.States = new List<SheetState>();
            cpsc.States.Add(SheetState.Approved);
            cpsc.HasRemain = true;
            _CustomerPayments = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetItems(cpsc).QueryObjects;

            CustomerReceivableSearchCondition crsc = new CustomerReceivableSearchCondition();
            crsc.Settled = false;
            crsc.ReceivableTypes = new List<CustomerReceivableType>();
            crsc.ReceivableTypes.Add(CustomerReceivableType.SupplierReceivable);
            crsc.ReceivableTypes.Add(CustomerReceivableType.SupplierReceivable);
            _CustomerReceivables = (new CustomerReceivableBLL(AppSettings.Current.ConnStr)).GetItems(crsc).QueryObjects;

            CompanyBLL bll = new CompanyBLL(AppSettings.Current.ConnStr);
            if (SearchCondition == null)
            {
                CustomerSearchCondition con = new CustomerSearchCondition();
                con.ClassID = CompanyClass.Supplier;
                _Customers = bll.GetItems(con).QueryObjects;
            }
            else
            {
                _Customers = bll.GetItems(SearchCondition).QueryObjects;
            }
            List<object> records = FilterData();
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
            if (_CustomerPayments != null && _CustomerPayments.Count > 0)
            {
                row.Cells["colPrepay"].Value = _CustomerPayments.Sum(it => it.CustomerID == c.ID ? it.Remain : 0).Trim();
            }
            else
            {
                row.Cells["colPrepay"].Value = 0;
            }
            if (_CustomerReceivables != null && _CustomerReceivables.Count > 0)
            {
                row.Cells["colReceivable"].Value = _CustomerReceivables.Sum(it => it.CustomerID == c.ID ? it.Remain : 0).Trim();
            }
            else
            {
                row.Cells["colReceivable"].Value = 0;
            }
        }
        #endregion

        #region 事件处理程序
        private void categoryTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FreshData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colReceivable")
                {
                    CompanyInfo c = dataGridView1.Rows[e.RowIndex].Tag as CompanyInfo;
                    View.FrmCustomerReceivableView frm = new View.FrmCustomerReceivableView();
                    CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
                    con.CustomerID = c.ID;
                    con.ReceivableTypes = new List<CustomerReceivableType>();
                    con.ReceivableTypes.Add(CustomerReceivableType.SupplierReceivable);
                    con.ReceivableTypes.Add(CustomerReceivableType.SupplierReceivable);
                    con.Settled = false;
                    frm.SearchCondition = con;
                    frm.Text = string.Format("{0} 应付款明细", c.Name);
                    frm.ShowDialog();
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colPrepay")
                {
                    CompanyInfo c = dataGridView1.Rows[e.RowIndex].Tag as CompanyInfo;
                    View.FrmCustomerPaymentView frm = new View.FrmCustomerPaymentView();
                    CustomerPaymentSearchCondition con = new CustomerPaymentSearchCondition();
                    con.CustomerID = c.ID;
                    con.PaymentTypes = new List<CustomerPaymentType>();
                    con.PaymentTypes.Add(CustomerPaymentType.Supplier);
                    con.States = new List<SheetState>();
                    con.States.Add(SheetState.Approved);
                    con.HasRemain = true;
                    frm.SearchCondition = con;
                    frm.Text = string.Format("{0} 付款流水明细", c.Name);
                    frm.ShowDialog();
                }
            }
        }

        private void mnu_Payment_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                CompanyInfo c = dataGridView1.SelectedRows[0].Tag as CompanyInfo;
                FrmCustomerPaymentDetail frm = new FrmCustomerPaymentDetail();
                frm.Customer = c;
                frm.IsAdding = true;
                frm.ItemAdded += delegate(object obj, ItemAddedEventArgs args)
                {
                    CompanyInfo c1 = (new CompanyBLL(AppSettings.Current.ConnStr)).GetByID(c.ID).QueryObject;
                    if (c1 != null)
                    {
                        ShowItemInGridViewRow(dataGridView1.SelectedRows[0], c1);
                    }
                };
                frm.ShowDialog();
            }
        }
        #endregion
    }
}
