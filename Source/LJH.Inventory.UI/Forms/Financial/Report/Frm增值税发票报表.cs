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
    public partial class Frm增值税发票报表 : FrmReportBase
    {
        public Frm增值税发票报表()
        {
            InitializeComponent();
        }

        private List<CompanyInfo> _AllCustomers = null;
        private List<AccountRecord> _AccountRecords = null;
        private List<DocumentOperation> _CancelOptions = null;// 

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
            if (cp.ClassID == CustomerPaymentType.客户增值税发票) row.Cells["colClass"].Value = "销售";
            else if (cp.ClassID == CustomerPaymentType.供应商增值税发票) row.Cells["colClass"].Value = "采购";
            row.Cells["colSheetDate"].Value = cp.SheetDate;
            row.Cells["colAmount"].Value = cp.Amount;
            if (cp.State != SheetState.作废)
            {
                var remain = GetRemain(cp);
                row.Cells["colRemain"].Value = remain != 0 ? (decimal?)remain : null;
                row.Cells["colAssigned"].Value = cp.Amount - remain != 0 ? (decimal?)(cp.Amount - remain) : null;
            }
            if (_AllCustomers != null)
            {
                var c = _AllCustomers.SingleOrDefault(it => it.ID == cp.CustomerID);
                row.Cells["colCustomer"].Value = c != null ? c.Name : cp.CustomerID;
            }
            row.Cells["col购货单位"].Value = cp.Payer;
            row.Cells["col出票单位"].Value = cp.AccountID;
            row.Cells["colMemo"].Value = cp.Memo;
            if (cp.ClassID == CustomerPaymentType.客户增值税发票) row.DefaultCellStyle.ForeColor = Color.Blue;
            else if (cp.ClassID == CustomerPaymentType.供应商增值税发票) row.DefaultCellStyle.ForeColor = Color.Red;
            if (cp.State == SheetState.作废)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                var ducopt = (_CancelOptions != null && _CancelOptions.Count > 0) ? _CancelOptions.SingleOrDefault(it => it.DocumentID == cp.ID) : null;
                row.Cells["col作废原因"].Value = ducopt != null ? ducopt.Memo : null;
            }
        }

        protected override List<object> GetDataSource()
        {
            _AllCustomers = new CompanyBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            if (!chk支.Checked && !chk收.Checked) return null;

            var acon = new AccountRecordSearchCondition();
            acon.CreateDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            if (txtCustomer.Tag != null) acon.CustomerID = (txtCustomer.Tag as CompanyInfo).ID;
            if (txtSupplier.Tag != null) acon.CustomerID = (txtSupplier.Tag as CompanyInfo).ID;
            acon.PaymentTypes = new List<CustomerPaymentType>();
            if (chk收.Checked) acon.PaymentTypes.Add(CustomerPaymentType.客户增值税发票);
            if (chk支.Checked) acon.PaymentTypes.Add(CustomerPaymentType.供应商增值税发票);
            _AccountRecords = new AccountRecordBLL(AppSettings.Current.ConnStr).GetItems(acon).QueryObjects;

            var dcon = new DocumentSearchCondition();
            dcon.Operation = "作废";
            dcon.CreateDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, DateTime.MaxValue);
            _CancelOptions = new DocumentOperationBLL(AppSettings.Current.ConnStr).GetItems(dcon).QueryObjects;

            var con = new CustomerPaymentSearchCondition();
            con.SheetDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            if (txtCustomer.Tag != null) con.CustomerID = (txtCustomer.Tag as CompanyInfo).ID;
            if (txtSupplier.Tag != null) con.CustomerID = (txtSupplier.Tag as CompanyInfo).ID;
            con.PaymentTypes = new List<CustomerPaymentType>();
            if (chk收.Checked) con.PaymentTypes.Add(CustomerPaymentType.客户增值税发票);
            if (chk支.Checked) con.PaymentTypes.Add(CustomerPaymentType.供应商增值税发票);
            var items = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            if (!string.IsNullOrEmpty(txtBillID.Text.Trim()) && items != null && items.Count > 0)
            {
                items = items.Where(it => it.ID.Contains(txtBillID.Text.Trim())).ToList();
            }
            return (from item in items orderby item.SheetDate ascending, item.ID ascending select (object)item).ToList();
        }

        protected override void Init()
        {
            ucDateTimeInterval1.ShowTime = false;
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
            btnSaveAs.Enabled = Operator.Current.Permit(Permission.TaxBillReport, PermissionActions.导出);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Tag == null) return;
                CustomerPayment sheet = dataGridView1.Rows[e.RowIndex].Tag as CustomerPayment;
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "colAssigned")
                {
                    var ar = new AccountRecordBLL(AppSettings.Current.ConnStr).GetRecord(sheet.ID, sheet.ClassID).QueryObject;
                    if (ar != null)
                    {
                        FrmReceivablePaymentAssigns frm = new FrmReceivablePaymentAssigns();
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowAssigns(ar);
                        frm.ShowDialog();
                    }
                }
                else if (this.dataGridView1.Columns[e.ColumnIndex].Name == "colSheetID")
                {
                    FrmCustomerTaxBillDetail frm = new FrmCustomerTaxBillDetail();
                    frm.TaxType = sheet.ClassID;
                    frm.IsAdding = false;
                    frm.UpdatingItem = sheet;
                    frm.ShowDialog();
                }
            }
        }
        #endregion
    }
}
