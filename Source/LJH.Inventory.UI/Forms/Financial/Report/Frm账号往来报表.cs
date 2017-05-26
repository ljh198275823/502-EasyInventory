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
    public partial class Frm账号往来报表 : FrmReportBase
    {
        public Frm账号往来报表()
        {
            InitializeComponent();
        }

        private decimal _balance = 0;
        private List<Account> _AllAccounts = new AccountBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;

        public Account Account { get; set; }

        #region 重写基类方法
        protected override void Init()
        {
            ucDateTimeInterval1.ShowTime = false;
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
            txtAccount.Tag = Account;
            txtAccount.Text = Account != null ? Account.Name : null;
            base.Init();
            if (Account != null) btnSearch.PerformClick();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            账户往来项 cp = item as 账户往来项;
            row.Tag = cp;
            row.Cells["colSheetDate"].Value = cp.DT;
            row.Cells["colSheetID"].Value = cp.单据编号;
            if (cp.收入 != 0 && !string.IsNullOrEmpty(cp.单据编号)) row.Cells["col收入"].Value = cp.收入;
            if (cp.支出 != 0 && !string.IsNullOrEmpty(cp.单据编号)) row.Cells["col支出"].Value = cp.支出;
            _balance += cp.收入 - cp.支出;
            row.Cells["col余额"].Value = _balance;
            row.Cells["col付款单位"].Value = cp.付款单位;
            row.Cells["colMemo"].Value = cp.Memo;
        }

        protected override List<object> GetDataSource()
        {
            _balance = 0;
            if (txtAccount.Tag == null)
            {
                MessageBox.Show("没有指定账号");
                return null;
            }
            var con = new CustomerPaymentSearchCondition();
            con.PaymentTypes = new List<CustomerPaymentType>() { CustomerPaymentType.Customer, CustomerPaymentType.Supplier };
            con.States = new List<SheetState>() { SheetState.Add, SheetState.Approved };
            con.AccountID = (txtAccount.Tag as Account).ID;
            var ps = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;

            List<账户往来项> ret = new List<账户往来项>();
            var first = new 账户往来项();
            first.DT = "上期结余";
            first.收入 = ps.Sum(it => it.ClassID == CustomerPaymentType.Customer && it.SheetDate < ucDateTimeInterval1.StartDateTime.Date ? it.Amount : 0);
            first.支出 = ps.Sum(it => it.ClassID == CustomerPaymentType.Supplier && it.SheetDate < ucDateTimeInterval1.StartDateTime.Date ? it.Amount : 0);
            //ret.Add(first);
            ret.AddRange(from it in ps
                         where it.SheetDate >= ucDateTimeInterval1.StartDateTime && it.SheetDate <= ucDateTimeInterval1.EndDateTime
                         select new 账户往来项()
                         {
                             DT = it.SheetDate.ToString("yyyy-MM-dd"),
                             单据编号 = it.ID,
                             收入 = it.ClassID == CustomerPaymentType.Customer ? it.Amount : 0,
                             支出 = it.ClassID == CustomerPaymentType.Supplier ? it.Amount : 0,
                             付款单位 = it.Payer,
                             Memo = it.Memo
                         });
            ret = (from it in ret
                   orderby it.DT ascending
                   select it).ToList();
            if (ret.Count > 0) ret.Insert(0, first);
            return ret.Select(it => (object)it).ToList();
        }
        #endregion

        #region 事件处理程序
        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAccountMaster frm = new FrmAccountMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Account ac = frm.SelectedItem as Account;
                txtAccount.Text = ac != null ? ac.Name : string.Empty;
                txtAccount.Tag = ac;
            }
        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            txtAccount.Text = string.Empty;
            txtAccount.Tag = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Tag == null) return;
                账户往来项 cp = dataGridView1.Rows[e.RowIndex].Tag as 账户往来项;
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "colSheetID")
                {
                    if (!Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.Read)) return;
                    var sheet = new CustomerPaymentBLL(AppSettings.Current.ConnStr).GetByID(cp.单据编号).QueryObject;
                    if (sheet != null)
                    {
                        FrmCustomerPaymentDetail frm = new FrmCustomerPaymentDetail();
                        frm.IsAdding = false;
                        frm.UpdatingItem = sheet;
                        frm.PaymentType = CustomerPaymentType.Customer;
                        frm.ShowDialog();
                    }
                }
            }
        }
        #endregion
    }

    internal class 账户往来项
    {
        public string DT { get; set; }

        public string 单据编号 { get; set; }

        public decimal 收入 { get; set; }

        public decimal 支出 { get; set; }

        //public string 到款账号 { get; set; }

        public string 付款单位 { get; set; }

        public string Memo { get; set; }
    }
}
