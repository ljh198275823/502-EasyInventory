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
    public partial class Frm内部转账记录报表 : FrmReportBase
    {
        public Frm内部转账记录报表()
        {
            InitializeComponent();
        }

        private List<CompanyInfo> _AllCustomers = null;
        private List<Account> _AllAccounts = null;
        private List<DocumentOperation> _CancelOptions = null;// 

        #region 重写基类方法
        protected override void Init()
        {
            ucDateTimeInterval1.ShowTime = false;
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
            btnSaveAs.Enabled = Operator.Current.Permit(Permission.内部转账记录报表, PermissionActions.导出);
            base.Init();
        }

        protected override List<object> GetDataSource()
        {
            _AllCustomers = new CompanyBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            _AllAccounts = new AccountBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;

            var dcon = new DocumentSearchCondition();
            dcon.Operation = "作废";
            dcon.CreateDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, DateTime.MaxValue);
            _CancelOptions = new DocumentOperationBLL(AppSettings.Current.ConnStr).GetItems(dcon).QueryObjects;

            var con = new CustomerPaymentSearchCondition();
            con.SheetDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            if (txtCustomer.Tag != null) con.CustomerID = (txtCustomer.Tag as CompanyInfo).ID;
            if (txtSupplier.Tag != null) con.CustomerID = (txtSupplier.Tag as CompanyInfo).ID;
            if (txt转入账号.Tag != null) con.AccountID = (txt转入账号.Tag as Account).ID;
            con.PaymentTypes = new List<CustomerPaymentType>() { CustomerPaymentType.转公账, CustomerPaymentType.转账 };
            var items = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0 && txt转出账号.Tag != null) items = items.Where(it => it.Payer == (txt转出账号.Tag as Account).ID).ToList();
            if (items != null && items.Count > 0) return (from item in items orderby item.SheetDate ascending, item.ID ascending select (object)item).ToList();
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CustomerPayment cp = item as CustomerPayment;
            row.Tag = cp;
            row.Cells["colSheetID"].Value = cp.ID;
            row.Cells["colClass"].Value = cp.ClassID.ToString();
            row.Cells["colSheetDate"].Value = cp.SheetDate;
            if (cp.PaymentMode != PaymentMode.None)
            {
                row.Cells["colPaymentMode"].Value = LJH.Inventory.BusinessModel.Resource.PaymentModeDescription.GetDescription(cp.PaymentMode);
            }
            Account ac = null;
            if (_AllAccounts != null && _AllAccounts.Count > 0) ac = _AllAccounts.SingleOrDefault(it => it.ID == cp.AccountID);
            row.Cells["colAccount"].Value = ac != null ? ac.Name : null;
            if (_AllAccounts != null && _AllAccounts.Count > 0) ac = _AllAccounts.SingleOrDefault(it => it.ID == cp.Payer);
            row.Cells["colPayer"].Value = ac != null ? ac.Name : cp.Payer;
            row.Cells["colAmount"].Value = cp.Amount;
            if (_AllCustomers != null)
            {
                var c = _AllCustomers.SingleOrDefault(it => it.ID == cp.CustomerID);
                row.Cells["colCustomer"].Value = c != null ? c.Name : cp.CustomerID;
            }
            var temp = cp.GetProperty("到款日期");
            DateTime pd = cp.SheetDate;
            if (!string.IsNullOrEmpty(temp) && DateTime.TryParse(temp, out pd)) row.Cells["col到款日期"].Value = pd.ToString("yyyy年MM月dd日");
            row.Cells["colMemo"].Value = cp.Memo;
            if (cp.State == SheetState.作废)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                var ducopt = (_CancelOptions != null && _CancelOptions.Count > 0) ? _CancelOptions.SingleOrDefault(it => it.DocumentID == cp.ID) : null;
                row.Cells["col作废原因"].Value = ducopt != null ? ducopt.Memo : null;
            }
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
                txt转入账号.Text = ac.Name;
                txt转入账号.Tag = ac;
            }
        }

        private void txtAccount_DoubleClick(object sender, EventArgs e)
        {
            txt转入账号.Tag = null;
            txt转入账号.Text = null;
        }

        private void lnk转出账号_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAccountMaster frm = new FrmAccountMaster();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var ac = frm.SelectedItem as Account;
                txt转出账号.Text = ac.Name;
                txt转出账号.Tag = ac;
            }
        }

        private void txt转出账号_DoubleClick(object sender, EventArgs e)
        {
            txt转出账号.Tag = null;
            txt转出账号.Text = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Tag == null) return;
                CustomerPayment sheet = dataGridView1.Rows[e.RowIndex].Tag as CustomerPayment;
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "colSheetID")
                {
                    if (sheet.ClassID == CustomerPaymentType.转公账)
                    {
                        Frm转公账 frm = new Frm转公账();
                        frm.IsAdding = false;
                        frm.UpdatingItem = sheet;
                        frm.IsForView = true;
                        frm.ShowDialog();
                    }
                    else if (sheet.ClassID == CustomerPaymentType.转账)
                    {
                        Frm转账 frm = new Frm转账();
                        frm.IsAdding = false;
                        frm.UpdatingItem = sheet;
                        frm.IsForView = true;
                        frm.ShowDialog();
                    }
                }
            }
        }
        #endregion
    }
}
