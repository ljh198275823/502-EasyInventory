using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.Inventory.UI.Forms.Sale;

namespace LJH.Inventory.UI.Forms.Financial.Report
{
    public partial class Frm客户往来报表 : FrmReportBase
    {
        public Frm客户往来报表()
        {
            InitializeComponent();
        }

        private decimal _balance = 0;
        private List<Account> _AllAccounts =null;

        public CompanyInfo Customer { get; set; }

        #region 重写基类方法
        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            客户往来项 cp = item as 客户往来项;
            row.Tag = cp;
            row.Cells["colSheetDate"].Value = cp.DT;
            row.Cells["colSheetID"].Value = cp.单据编号;
            if (cp.出货 != 0 && !string.IsNullOrEmpty (cp.单据编号)) row.Cells["col出货"].Value = cp.出货;
            if (cp.收入 != 0 && !string.IsNullOrEmpty(cp.单据编号)) row.Cells["col收入"].Value = cp.收入;
            _balance += cp.出货 - cp.收入;
            row.Cells["col余额"].Value = _balance;
            Account ac = null;
            if (!string.IsNullOrEmpty(cp.到款账号) && _AllAccounts != null && _AllAccounts.Count > 0) ac = _AllAccounts.SingleOrDefault(it => it.ID == cp.到款账号);
            row.Cells["col到款账号"].Value = ac != null ? ac.Name : null;
            row.Cells["col付款单位"].Value = cp.付款单位;
            row.Cells["colMemo"].Value = cp.Memo;
        }

        protected override List<object> GetDataSource()
        {
            _AllAccounts = new AccountBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            _balance = 0;
            if (txtCustomer.Tag == null)
            {
                MessageBox.Show("没有指定客户");
                return null;
            }
            var con = new AccountRecordSearchCondition();
            con.CustomerID = (txtCustomer.Tag as CompanyInfo).ID;
            con.PaymentTypes = new List<CustomerPaymentType>() { CustomerPaymentType.客户收款 };
            var ps = (new AccountRecordBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;

            var rcon = new CustomerReceivableSearchCondition();
            rcon.CustomerID = con.CustomerID = (txtCustomer.Tag as CompanyInfo).ID;
            rcon.ReceivableTypes = new List<CustomerReceivableType>() { CustomerReceivableType.CustomerReceivable };
            var rs = new CustomerReceivableBLL(AppSettings.Current.ConnStr).GetItems(rcon).QueryObjects;

            List<客户往来项> ret = new List<客户往来项>();
            var first = new 客户往来项();
            first.DT = "上期结余";
            first.出货 = rs.Sum(it => it.CreateDate < ucDateTimeInterval1.StartDateTime.Date ? it.Amount : 0);
            first.收入 = ps.Sum(it => it.CreateDate < ucDateTimeInterval1.StartDateTime.Date ? it.Amount : 0);
            //ret.Add(first);
            ret.AddRange(from it in rs
                         where it.CreateDate >= ucDateTimeInterval1.StartDateTime && it.CreateDate <= ucDateTimeInterval1.EndDateTime
                         select new 客户往来项() { DT = it.CreateDate.ToString("yyyy-MM-dd"), 单据编号 = it.SheetID, 出货 = it.Amount, Memo = it.Memo });

            ret.AddRange(from it in ps
                         where it.CreateDate >= ucDateTimeInterval1.StartDateTime && it.CreateDate <= ucDateTimeInterval1.EndDateTime
                         select new 客户往来项() { DT = it.CreateDate.ToString("yyyy-MM-dd"), 单据编号 = it.SheetID, 收入 = it.Amount, 到款账号 = it.AccountID, 付款单位 = it.OtherAccount, Memo = it.Memo });
            ret = (from it in ret
                   orderby it.DT ascending
                   select it).ToList();
            ret.Insert(0, first);
            return ret.Select(it => (object)it).ToList();
        }

        protected override void Init()
        {
            ucDateTimeInterval1.ShowTime = false;
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
            txtCustomer.Tag = Customer;
            txtCustomer.Text = Customer != null ? Customer.Name : null;
            base.Init();
            if (Customer != null) btnSearch.PerformClick();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Tag == null) return;
                客户往来项 cp = dataGridView1.Rows[e.RowIndex].Tag as 客户往来项;
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "colSheetID")
                {
                    if (cp.出货 != 0)
                    {
                        if (!Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Read)) return;
                        var sheet = new StackOutSheetBLL(AppSettings.Current.ConnStr).GetByID(cp.单据编号).QueryObject;
                        if (sheet != null)
                        {
                            Inventory.FrmStackOutSheetDetail frm = new Inventory.FrmStackOutSheetDetail();
                            frm.IsAdding = false;
                            frm.IsForView = true;
                            frm.UpdatingItem = sheet;
                            frm.ShowDialog();
                        }
                        else
                        {
                            var osheet = new OtherReceivableSheetBLL(AppSettings.Current.ConnStr).GetByID(cp.单据编号).QueryObject;
                            if (osheet != null)
                            {
                                FrmOhterReceivableSheetDetail frm = new FrmOhterReceivableSheetDetail();
                                frm.ReceivableType = osheet.ClassID;
                                frm.UpdatingItem = osheet;
                                frm.ShowDialog();
                            }
                        }
                    }
                    else if (cp.收入 != 0)
                    {
                        if (!Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.Read)) return;
                        var sheet = new CustomerPaymentBLL(AppSettings.Current.ConnStr).GetByID(cp.单据编号).QueryObject;
                        if (sheet != null)
                        {
                            FrmCustomerPaymentDetail frm = new FrmCustomerPaymentDetail();
                            frm.IsAdding = false;
                            frm.UpdatingItem = sheet;
                            frm.PaymentType = CustomerPaymentType.客户收款;
                            frm.ShowDialog();
                        }
                    }
                }
            }
        }
        #endregion
    }

    internal class 客户往来项
    {
        public string DT { get; set; }

        public string 单据编号 { get; set; }

        public decimal 出货 { get; set; }

        public decimal 收入 { get; set; }

        public string 到款账号 { get; set; }

        public string 付款单位 { get; set; }

        public string Memo { get; set; }
    }
}
