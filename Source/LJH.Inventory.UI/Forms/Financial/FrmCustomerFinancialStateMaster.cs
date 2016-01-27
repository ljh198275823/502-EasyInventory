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
        protected override void Init()
        {
            base.Init();
            if (ForSelect)
            {
                this.Text = "客户选择";
                this.GridView.ContextMenuStrip = null;
                this.GridView.Columns["colTax"].Visible = false;
                this.GridView.Columns["colTaxBill"].Visible = false;
            }
        }

        protected override void ReFreshData()
        {
            categoryTree.Init();
            base.ReFreshData();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            mnu_AddPayment.Enabled = Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.Edit);
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
            row.Cells["colFileID"].Value = cs.Recievables > 0 ? (cs.Customer.FileID.HasValue ? cs.Customer.FileID.ToString() : null) : null;
            row.Cells["colPrepay"].Value = cs.Prepay;
            row.Cells["colReceivable"].Value = cs.Recievables;
            row.Cells["colTax"].Value = cs.Tax;
            row.Cells["colTaxBill"].Value = cs.TaxBill;
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
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                CompanyInfo c = (dataGridView1.Rows[e.RowIndex].Tag as CustomerFinancialState).Customer;
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colReceivable")
                {
                    View.FrmCustomerReceivableView frm = new View.FrmCustomerReceivableView();
                    frm.Customer = c;
                    frm.ReceivableType = CustomerReceivableType.CustomerReceivable;
                    frm.Text = string.Format("{0} 应收款明细", c.Name);
                    frm.ShowDialog();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "colPrepay")
                {
                    View.FrmCustomerPaymentView frm = new View.FrmCustomerPaymentView();
                    frm.Customer = c;
                    frm.PaymentType = CustomerPaymentType.Customer;
                    frm.Text = string.Format("{0} 付款流水明细", c.Name);
                    frm.ShowDialog();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "colTax")
                {
                    View.FrmCustomerTaxView frm = new View.FrmCustomerTaxView();
                    frm.Customer = c;
                    frm.Text = string.Format("{0} 应开增值税明细", c.Name);
                    frm.ShowDialog();

                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "colTaxBill")
                {
                    View.FrmCustomerTaxBillView frm = new View.FrmCustomerTaxBillView();
                    frm.Customer = c;
                    frm.PaymentType = CustomerPaymentType.CustomerTax;
                    frm.Text = string.Format("{0} 已开增值税发票明细", c.Name);
                    frm.ShowDialog();
                }
                //刷新数据
                var cs = new CompanyBLL(AppSettings.Current.ConnStr).GetCustomerState(c.ID).QueryObject;
                if (cs != null) ShowItemInGridViewRow(dataGridView1.Rows[e.RowIndex], cs);
            }
        }

        private void mnu_AddRecievable_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                CompanyInfo customer = (dataGridView1.SelectedRows[0].Tag as CustomerFinancialState).Customer;
                FrmCustomerReceivableAdd frm = new FrmCustomerReceivableAdd();
                frm.Customer = customer;
                frm.ReceivableType = CustomerReceivableType.CustomerReceivable;
                frm.ShowDialog();
                var cs = new CompanyBLL(AppSettings.Current.ConnStr).GetCustomerState(customer.ID).QueryObject;
                ShowItemInGridViewRow(dataGridView1.SelectedRows[0], cs);
            }
        }

        private void mnu_AddPayment_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                CompanyInfo customer = (dataGridView1.SelectedRows[0].Tag as CustomerFinancialState).Customer;
                FrmCustomerPaymentDetail frm = new FrmCustomerPaymentDetail();
                frm.Customer = customer;
                frm.PaymentType = CustomerPaymentType.Customer;
                frm.IsAdding = true;
                frm.ShowDialog();
                var cs = new CompanyBLL(AppSettings.Current.ConnStr).GetCustomerState(customer.ID).QueryObject;
                ShowItemInGridViewRow(dataGridView1.SelectedRows[0], cs);
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

        private void mnu_AddTax_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                CompanyInfo customer = (dataGridView1.SelectedRows[0].Tag as CustomerFinancialState).Customer;
                FrmCustomerReceivableAdd frm = new FrmCustomerReceivableAdd();
                frm.Customer = customer;
                frm.ReceivableType = CustomerReceivableType.CustomerTax;
                frm.ShowDialog();
                var cs = new CompanyBLL(AppSettings.Current.ConnStr).GetCustomerState(customer.ID).QueryObject;
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
                frm.IsAdding = true;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                var cs = new CompanyBLL(AppSettings.Current.ConnStr).GetCustomerState(customer.ID).QueryObject;
                ShowItemInGridViewRow(dataGridView1.SelectedRows[0], cs);
            }
        }
        #endregion
    }
}
