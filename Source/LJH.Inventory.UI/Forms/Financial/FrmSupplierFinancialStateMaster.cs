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
                if (this.categoryTree.SelectedNode != null && this.categoryTree.SelectedNode.Tag != null)
                {
                    var categories = categoryTree.GetCategoryofNode(this.categoryTree.SelectedNode);
                    if (categories != null) items = items.Where(it => categories.Exists(c => c.ID == it.Customer.CategoryID)).ToList();
                }
                if (!string.IsNullOrEmpty(txtKeyword.Text.Trim())) items = items.Where(it => it.Customer.Name.Contains(txtKeyword.Text.Trim())).ToList();
                if (chkOnlyHasRecievables.Checked) items = items.Where(it => it.Recievables > 0).ToList();
                return (from p in items
                        orderby p.Customer.Name ascending
                        select (object)p).ToList();
            }
            return null;
        }
        #endregion

        #region 重写基类方法
        public override void ReFreshData()
        {
            categoryTree.Init();
            base.ReFreshData();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            cMnu_Payment.Enabled = Operator.Current.Permit(Permission.SupplierPayment , PermissionActions.Edit);
            mnu_AddRecievable.Enabled = Operator.Current.Permit(Permission.SupplierReceivable, PermissionActions.Edit);
            mnu_AddTax.Enabled = Operator.Current.Permit(Permission.SupplierTax, PermissionActions.Edit);
            mnu_AddTaxBill.Enabled = Operator.Current.Permit(Permission.SupplierTaxBill, PermissionActions.Edit);
        }

        protected override List<object> GetDataSource()
        {
            _CustomerStates = new CompanyBLL(AppSettings.Current.ConnStr).GetAllSupplierStates().QueryObjects;
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
            row.Cells["colPrepay"].Value = cs.Prepay;
            row.Cells["colReceivable"].Value = cs.Recievables;
            row.Cells["colTax"].Value = cs.Tax;
            row.Cells["colTaxBill"].Value = cs.TaxBill;
        }
        #endregion

        #region 事件处理程序
        private void categoryTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FreshData();
        }

        private void FreshData_Clicked(object sender, EventArgs e)
        {
            FreshData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                CompanyInfo c = (dataGridView1.Rows[e.RowIndex].Tag as CustomerFinancialState).Customer;
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colReceivable")
                {
                    View.FrmCustomerReceivableView frm = new View.FrmCustomerReceivableView();
                    frm.Customer = c;
                    frm.ReceivableType = CustomerReceivableType.SupplierReceivable;
                    frm.Text = string.Format("{0} 应付款明细", c.Name);
                    frm.ShowDialog();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "colPrepay")
                {
                    View.FrmCustomerPaymentView frm = new View.FrmCustomerPaymentView();
                    frm.Customer = c;
                    frm.PaymentType = CustomerPaymentType.Supplier;
                    frm.Text = string.Format("{0} 付款流水明细", c.Name);
                    frm.ShowDialog();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "colTax")
                {
                    View.FrmCustomerTaxView frm = new View.FrmCustomerTaxView();
                    frm.Customer = c;
                    frm.ReceivableType = CustomerReceivableType.SupplierTax;
                    frm.Text = string.Format("{0} 应开增值税明细", c.Name);
                    frm.ShowDialog();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "colTaxBill")
                {
                    View.FrmCustomerTaxBillView frm = new View.FrmCustomerTaxBillView();
                    frm.Customer = c;
                    frm.PaymentType = CustomerPaymentType.SupplierTax;
                    frm.Text = string.Format("{0} 已开增值税发票明细", c.Name);
                    frm.ShowDialog();
                }
                //刷新数据
                var cs = new CompanyBLL(AppSettings.Current.ConnStr).GetSupplierState(c.ID).QueryObject;
                if (cs != null) ShowItemInGridViewRow(dataGridView1.Rows[e.RowIndex], cs);
            }
        }

        private void mnu_Payment_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                CompanyInfo customer = (dataGridView1.SelectedRows[0].Tag as CustomerFinancialState).Customer;
                FrmCustomerPaymentDetail frm = new FrmCustomerPaymentDetail();
                frm.Customer = customer;
                frm.PaymentType = CustomerPaymentType.Supplier;
                frm.IsAdding = true;
                frm.ShowDialog();
                var cs = new CompanyBLL(AppSettings.Current.ConnStr).GetSupplierState(customer.ID).QueryObject;
                ShowItemInGridViewRow(dataGridView1.SelectedRows[0], cs);
            }
        }

        private void mnu_AddRecievable_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                CompanyInfo customer = (dataGridView1.SelectedRows[0].Tag as CustomerFinancialState).Customer;
                FrmCustomerReceivableAdd frm = new FrmCustomerReceivableAdd();
                frm.Customer = customer;
                frm.ReceivableType = CustomerReceivableType.SupplierReceivable;
                frm.ShowDialog();
                var cs = new CompanyBLL(AppSettings.Current.ConnStr).GetSupplierState(customer.ID).QueryObject;
                ShowItemInGridViewRow(dataGridView1.SelectedRows[0], cs);
            }
        }

        private void mnu_AddTax_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                CompanyInfo customer = (dataGridView1.SelectedRows[0].Tag as CustomerFinancialState).Customer;
                FrmCustomerReceivableAdd frm = new FrmCustomerReceivableAdd();
                frm.Customer = customer;
                frm.ReceivableType = CustomerReceivableType.SupplierTax;
                frm.ShowDialog();
                var cs = new CompanyBLL(AppSettings.Current.ConnStr).GetSupplierState(customer.ID).QueryObject;
                ShowItemInGridViewRow(dataGridView1.SelectedRows[0], cs);
            }
        }

        private void mnu_AddTaxBill_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                CompanyInfo customer = (dataGridView1.SelectedRows[0].Tag as CustomerFinancialState).Customer;
                FrmCustomerTaxBillDetail frm = new FrmCustomerTaxBillDetail();
                frm.Customer = customer;
                frm.TaxType = CustomerPaymentType.SupplierTax;
                frm.IsAdding = true;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                var cs = new CompanyBLL(AppSettings.Current.ConnStr).GetSupplierState(customer.ID).QueryObject;
                ShowItemInGridViewRow(dataGridView1.SelectedRows[0], cs);
            }
        }
        #endregion
    }
}
