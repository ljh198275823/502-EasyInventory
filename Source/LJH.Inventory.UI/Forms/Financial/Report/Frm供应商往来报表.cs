using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.Inventory.UI.Forms.Sale;
using LJH.Inventory.UI.Forms.Inventory;

namespace LJH.Inventory.UI.Forms.Financial.Report
{
    public partial class Frm供应商往来报表 : FrmReportBase
    {
        public Frm供应商往来报表()
        {
            InitializeComponent();
        }

        private decimal _balance = 0;
        private List<Account> _AllAccounts = null;

        public CompanyInfo Customer { get; set; }

        #region 重写基类方法
        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            供应商往来项 cp = item as 供应商往来项;
            row.Tag = cp;
            row.Cells["colSheetDate"].Value = cp.Name;
            row.Cells["colSheetID"].Value = string.IsNullOrEmpty(cp.规格) ? cp.单据编号 : cp.规格;
            row.Cells["col重量"].Value = cp.重量;
            row.Cells["col吨价"].Value = !string.IsNullOrEmpty(cp.吨价) ? (decimal?)(decimal.Parse(cp.吨价)) : null;
            if (cp.出货 != 0 && !string.IsNullOrEmpty(cp.单据编号)) row.Cells["col出货"].Value = cp.出货;
            if (cp.收入 != 0 && !string.IsNullOrEmpty(cp.单据编号)) row.Cells["col收入"].Value = cp.收入;
            _balance += cp.出货 - cp.收入;
            row.Cells["col余额"].Value = _balance;
            Account ac = null;
            if (!string.IsNullOrEmpty(cp.付款账号) && _AllAccounts != null && _AllAccounts.Count > 0) ac = _AllAccounts.SingleOrDefault(it => it.ID == cp.付款账号);
            row.Cells["col付款账号"].Value = ac != null ? ac.Name : cp.付款账号;
            if (!string.IsNullOrEmpty(cp.对方账号) && _AllAccounts != null && _AllAccounts.Count > 0) ac = _AllAccounts.SingleOrDefault(it => it.ID == cp.对方账号);
            row.Cells["col对方账号"].Value = ac != null ? ac.Name : cp.对方账号;
            row.Cells["colMemo"].Value = cp.Memo;
        }

        protected override List<object> GetDataSource()
        {
            _AllAccounts = new AccountBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            _balance = 0;
            if (txtCustomer.Tag == null)
            {
                MessageBox.Show("没有指定供应商");
                return null;
            }
            var con = new AccountRecordSearchCondition();
            con.CustomerID = (txtCustomer.Tag as CompanyInfo).ID;
            con.PaymentTypes = new List<CustomerPaymentType>() { CustomerPaymentType.供应商付款 };
            var ps = (new AccountRecordBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;

            var rcon = new CustomerReceivableSearchCondition();
            rcon.CustomerID = con.CustomerID = (txtCustomer.Tag as CompanyInfo).ID;
            rcon.ReceivableTypes = new List<CustomerReceivableType>() { CustomerReceivableType.SupplierReceivable };
            var rs = new CustomerReceivableBLL(AppSettings.Current.ConnStr).GetItems(rcon).QueryObjects;

            List<供应商往来项> ret = new List<供应商往来项>();
            var first = new 供应商往来项();
            first.Name = "上期结余";
            first.出货 = rs.Sum(it => it.CreateDate < ucDateTimeInterval1.StartDateTime.Date ? it.Amount : 0);
            first.收入 = ps.Sum(it => it.CreateDate < ucDateTimeInterval1.StartDateTime.Date ? it.Amount : 0);
            //ret.Add(first);
            ret.AddRange(from it in rs
                         where it.CreateDate >= ucDateTimeInterval1.StartDateTime && it.CreateDate <= ucDateTimeInterval1.EndDateTime
                         select new 供应商往来项() { Name = it.CreateDate.ToString("yyyy-MM-dd"), CreateDate = it.CreateDate, 单据编号 = it.SheetID, 规格 = it.GetProperty("规格"), 重量 =it.GetProperty ("重量"),吨价 =it.GetProperty ("入库单价"), 出货 = it.Amount, Memo = it.Memo });

            ret.AddRange(from it in ps
                         where it.CreateDate >= ucDateTimeInterval1.StartDateTime && it.CreateDate <= ucDateTimeInterval1.EndDateTime
                         select new 供应商往来项() { Name = it.CreateDate.ToString("yyyy-MM-dd"), CreateDate = it.CreateDate, 单据编号 = it.SheetID, 收入 = it.Amount, 付款账号 = it.AccountID, 对方账号 = it.OtherAccount, Memo = it.Memo });
            ret = (from it in ret
                   orderby it.CreateDate ascending
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
            btnSaveAs.Enabled = Operator.Current.Permit(Permission.供应商往来报表, PermissionActions.导出);
        }

        #endregion

        #region 事件处理程序
        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LJH.Inventory.UI.Forms.Purchase.FrmSupplierMaster frm = new Purchase.FrmSupplierMaster();
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
                供应商往来项 cp = dataGridView1.Rows[e.RowIndex].Tag as 供应商往来项;
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "colSheetID")
                {
                    if (cp.出货 != 0)
                    {
                        Guid gid;
                        if (Guid.TryParse(cp.单据编号, out gid))
                        {
                            var pi = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).GetByID(gid).QueryObject;
                            if (pi != null)
                            {
                                if (pi.Product.Model == ProductModel.原材料)
                                {
                                    FrmSteelRollDetail frm = new FrmSteelRollDetail();
                                    frm.UpdatingItem = pi;
                                    frm.IsForView = true;
                                    frm.ShowDialog();
                                }
                                else if (pi.Product.Model == ProductModel.其它产品)
                                {
                                    Frm其它产品入库 frm = new Frm其它产品入库();
                                    frm.SteelRollSlice = pi;
                                    frm.IsForView = true;
                                    frm.ShowDialog();
                                }
                                else
                                {
                                    FrmSteelRollSliceStackIn frm = new FrmSteelRollSliceStackIn();
                                    frm.SteelRollSlice = pi;
                                    frm.IsForView = true;
                                    frm.ShowDialog();
                                }
                            }
                        }
                        else
                        {
                            var osheet = new OtherReceivableSheetBLL(AppSettings.Current.ConnStr).GetByID(cp.单据编号).QueryObject;
                            if (osheet != null)
                            {
                                Frm其它应收明细 frm = new Frm其它应收明细();
                                frm.ReceivableType = osheet.ClassID;
                                frm.UpdatingItem = osheet;
                                frm.ShowDialog();
                            }
                            else
                            {
                                var tui = new CustomerPaymentBLL(AppSettings.Current.ConnStr).GetByID(cp.单据编号).QueryObject;
                                if (tui != null && tui.ClassID == CustomerPaymentType.供应商退款)
                                {
                                    Frm退款 frm = new Frm退款();
                                    frm.IsAdding = false;
                                    frm.UpdatingItem = tui;
                                    frm.ShowDialog();
                                }
                            }
                        }
                    }
                    else if (cp.收入 != 0)
                    {
                        if (!Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.Read)) return;
                        var sheet = new CustomerPaymentBLL(AppSettings.Current.ConnStr).GetByID(cp.单据编号).QueryObject;
                        if (sheet != null && sheet.ClassID == CustomerPaymentType.供应商付款)
                        {
                            Frm收付款流水明细 frm = new Frm收付款流水明细();
                            frm.IsAdding = false;
                            frm.UpdatingItem = sheet;
                            frm.PaymentType = sheet.ClassID;
                            frm.ShowDialog();
                        }
                    }
                }
            }
        }
        #endregion
    }

    internal class 供应商往来项
    {
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public string 单据编号 { get; set; }

        public string 规格 { get; set; }

        public string 重量 { get; set; }

        public string 吨价 { get; set; }

        public decimal 出货 { get; set; }

        public decimal 收入 { get; set; }

        public string 付款账号 { get; set; }

        public string 对方账号 { get; set; }

        public string Memo { get; set; }
    }
}
