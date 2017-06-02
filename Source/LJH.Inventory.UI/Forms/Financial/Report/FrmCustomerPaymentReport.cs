using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.GeneralLibrary;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.Inventory.UI.Forms;
using LJH.Inventory.UI.Forms.General;
using LJH.Inventory.UI.Forms.Sale;
using LJH.Inventory.UI.Forms.Financial.View;

namespace LJH.Inventory.UI.Forms.Financial.Report
{
    public partial class FrmCustomerPaymentReport : FrmReportBase
    {
        public FrmCustomerPaymentReport()
        {
            InitializeComponent();
        }

        private List<CompanyInfo> _AllCustomers = null;
        private List<Account> _AllAccounts = null;
        private List<AccountRecord> _AccountRecords = null;

        private decimal GetRemain(CustomerPayment cp)
        {
            decimal ret = 0;
            if (_AccountRecords == null || _AccountRecords.Count == 0) return 0;
            ret = _AccountRecords.Sum(it => (it.SheetID == cp.ID && it.ClassID == cp.ClassID) ? it.Remain : 0);
            return ret;
        }

        #region 重写基类方法
        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CustomerPayment cp = item as CustomerPayment;
            row.Tag = cp;
            row.Cells["colSheetID"].Value = cp.ID;
            row.Cells["colClass"].Value = cp.ClassID.ToString();
            row.Cells["colSheetDate"].Value = cp.SheetDate;
            if (cp.PaymentMode != PaymentMode.None) row.Cells["colPaymentMode"].Value = LJH.Inventory.BusinessModel.Resource.PaymentModeDescription.GetDescription(cp.PaymentMode);
            Account ac = null;
            if (_AllAccounts != null && _AllAccounts.Count > 0) ac = _AllAccounts.SingleOrDefault(it => it.ID == cp.AccountID);
            row.Cells["colAccount"].Value = ac != null ? ac.Name : null;
            row.Cells["colPayer"].Value = cp.Payer;
            row.Cells["colAmount"].Value = cp.Amount;
            if (cp.State != SheetState.Canceled)
            {
                var remain = GetRemain(cp);
                row.Cells["colRemain"].Value = remain != 0 ? (decimal?)remain : null;
                row.Cells["colAssigned"].Value = cp.Amount - remain != 0 ? (decimal?)(cp.Amount - remain) : null;
            }
            row.Cells["colStackSheetID"].Value = cp.StackSheetID;
            if (_AllCustomers != null)
            {
                var c = _AllCustomers.SingleOrDefault(it => it.ID == cp.CustomerID);
                row.Cells["colCustomer"].Value = c != null ? c.Name : cp.CustomerID;
            }
            row.Cells["colMemo"].Value = cp.Memo;
            if (cp.ClassID == CustomerPaymentType.客户收款 || cp.ClassID == CustomerPaymentType.其它收款) row.DefaultCellStyle.ForeColor = Color.Blue;
            else if (cp.ClassID == CustomerPaymentType.供应商付款 || cp.ClassID == CustomerPaymentType.公司管理费用) row.DefaultCellStyle.ForeColor = Color.Red;
            if (cp.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
        }

        protected override List<object> GetDataSource()
        {
            _AllCustomers = new CompanyBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            _AllAccounts = new AccountBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            if (!chk供应商付款.Checked && !chk客户收款.Checked && !chk其它收款.Checked && !chk费用支出.Checked) return null;

            var acon = new AccountRecordSearchCondition();
            acon.CreateDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            if (txtCustomer.Tag != null) acon.CustomerID = (txtCustomer.Tag as CompanyInfo).ID;
            if (txtSupplier.Tag != null) acon.CustomerID = (txtSupplier.Tag as CompanyInfo).ID;
            if (txtAccount.Tag != null) acon.AccountID = (txtAccount.Tag as Account).ID;
            acon.PaymentTypes = new List<CustomerPaymentType>();
            if (chk客户收款.Checked) acon.PaymentTypes.Add(CustomerPaymentType.客户收款);
            if (chk供应商付款.Checked) acon.PaymentTypes.Add(CustomerPaymentType.供应商付款);
            if (chk其它收款.Checked) acon.PaymentTypes.Add(CustomerPaymentType.其它收款);
            if (chk费用支出.Checked) acon.PaymentTypes.Add(CustomerPaymentType.公司管理费用);
            if (chk退款.Checked)
            {
                acon.PaymentTypes.Add(CustomerPaymentType.客户退款);
                acon.PaymentTypes.Add(CustomerPaymentType.供应商退款);
            }
            _AccountRecords = new AccountRecordBLL(AppSettings.Current.ConnStr).GetItems(acon).QueryObjects;

            var con = new CustomerPaymentSearchCondition();
            con.SheetDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            if (txtCustomer.Tag != null) con.CustomerID = (txtCustomer.Tag as CompanyInfo).ID;
            if (txtSupplier.Tag != null) con.CustomerID = (txtSupplier.Tag as CompanyInfo).ID;
            if (txtAccount.Tag != null) con.AccountID = (txtAccount.Tag as Account).ID;
            con.PaymentTypes = new List<CustomerPaymentType>();
            if (chk客户收款.Checked) con.PaymentTypes.Add(CustomerPaymentType.客户收款);
            if (chk供应商付款.Checked) con.PaymentTypes.Add(CustomerPaymentType.供应商付款);
            if (chk其它收款.Checked) con.PaymentTypes.Add(CustomerPaymentType.其它收款);
            if (chk费用支出.Checked) con.PaymentTypes.Add(CustomerPaymentType.公司管理费用);
            if (chk退款.Checked)
            {
                con.PaymentTypes.Add(CustomerPaymentType.客户退款);
                con.PaymentTypes.Add(CustomerPaymentType.供应商退款);
            }
            var items = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            return (from item in items orderby item.SheetDate ascending, item.ID ascending select (object)item).ToList();
        }

        protected override void Init()
        {
            ucDateTimeInterval1.ShowTime = false;
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
            base.Init();
        }

        #endregion

        #region 事件处理程序
        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomerMaster frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CompanyInfo customer = frm.SelectedItem as CompanyInfo;
                txtCustomer.Text = customer != null ? customer.Name : string.Empty;
                txtCustomer.Tag = customer;
            }
        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            txtCustomer.Text = string.Empty;
            txtCustomer.Tag = null;
        }

        private void lnkSupplier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Purchase.FrmSupplierMaster frm = new Purchase.FrmSupplierMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CompanyInfo s = frm.SelectedItem as CompanyInfo;
                txtSupplier.Text = s.Name;
                txtSupplier.Tag = s;
            }
        }

        private void txtSupplier_DoubleClick(object sender, EventArgs e)
        {
            txtSupplier.Text = string.Empty;
            txtSupplier.Tag = null;
        }

        private void lnkAccout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAccountMaster frm = new FrmAccountMaster();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var ac = frm.SelectedItem as Account;
                txtAccount.Text = ac.Name;
                txtAccount.Tag = ac;
            }
        }

        private void txtAccount_DoubleClick(object sender, EventArgs e)
        {
            txtAccount.Tag = null;
            txtAccount.Text = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Tag == null) return;
                CustomerPayment cp = dataGridView1.Rows[e.RowIndex].Tag as CustomerPayment;
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "colAssigned")
                {
                    var ar = new AccountRecordBLL(AppSettings.Current.ConnStr).GetRecord(cp.ID, cp.ClassID).QueryObject;
                    if (ar != null)
                    {
                        FrmReceivablePaymentAssigns frm = new FrmReceivablePaymentAssigns();
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowAssigns(ar);
                        frm.ShowDialog();
                    }
                }
            }
        }
        #endregion
    }
}
