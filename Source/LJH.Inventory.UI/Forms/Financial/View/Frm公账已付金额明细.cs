using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary;

namespace LJH.Inventory.UI.Forms.Financial.View
{
    public partial class Frm公账已付金额明细 : Form
    {
        public Frm公账已付金额明细()
        {
            InitializeComponent();
        }

        private List<Account> _AllAccounts = new AccountBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;

        #region 公共属性
        public CompanyInfo Customer { get; set; }
        #endregion

        #region 重写基类方法
        private void FreshData()
        {
            var con = new AccountRecordSearchCondition();
            con.CustomerID = Customer != null ? Customer.ID : null;
            con.PaymentTypes = new List<CustomerPaymentType>() { CustomerPaymentType.公账 };
            if (!chkSheetDate.Checked) con.HasRemain = true;
            else con.CreateDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            var items = (new AccountRecordBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            items = (from item in items orderby item.CreateDate ascending, item.ID ascending select item).ToList();
            ShowItemsOnGrid(items);
        }

        private void ShowItemInGridViewRow(DataGridViewRow row, AccountRecord cp)
        {
            row.Tag = cp;
            row.Cells["colSheetID"].Value = cp.SheetID;
            row.Cells["colSheetDate"].Value = cp.CreateDate;
            Account ac = null;
            if (!string.IsNullOrEmpty(cp.AccountID) && _AllAccounts != null && _AllAccounts.Count > 0) ac = _AllAccounts.SingleOrDefault(it => it.ID == cp.AccountID);
            row.Cells["colAccount"].Value = ac != null ? ac.Name : null;
            if (!string.IsNullOrEmpty(cp.OtherAccount) && _AllAccounts != null && _AllAccounts.Count > 0) ac = _AllAccounts.SingleOrDefault(it => it.ID == cp.OtherAccount);
            row.Cells["colPayer"].Value = ac != null ? ac.Name : cp.OtherAccount;
            row.Cells["colAmount"].Value = cp.Amount;
            row.Cells["colRemain"].Value = cp.Remain != 0 ? (decimal?)cp.Remain : null;
            row.Cells["colAssigned"].Value = cp.Assigned != 0 ? (decimal?)cp.Assigned : null;
            row.Cells["colStackSheetID"].Value = cp.StackSheetID;
            row.Cells["colMemo"].Value = cp.Memo;
        }

        private void ShowItemsOnGrid(List<AccountRecord> items)
        {
            dataGridView1.Rows.Clear();
            if (items != null && items.Count > 0)
            {
                foreach (var cr in items)
                {
                    int row = dataGridView1.Rows.Add();
                    ShowItemInGridViewRow(dataGridView1.Rows[row], cr);
                }
                int rowTotal = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowTotal].Cells["colSheetDate"].Value = "合计";
                dataGridView1.Rows[rowTotal].Cells["colAmount"].Value = items.Sum(item => (item as AccountRecord).Amount).Trim();
                dataGridView1.Rows[rowTotal].Cells["colAssigned"].Value = items.Sum(item => (item as AccountRecord).Assigned).Trim();
                dataGridView1.Rows[rowTotal].Cells["colRemain"].Value = items.Sum(item => (item as AccountRecord).Remain).Trim();
            }
            lblMSG.Text = string.Format("共 {0} 项", items != null ? items.Count : 0);
        }

        private void ShowOperatorRights()
        {
        }
        #endregion

        #region 事件处理程序
        private void FrmCustomerPaymentView_Load(object sender, EventArgs e)
        {
            ShowOperatorRights();
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
            FreshData();
        }

        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            FreshData();
        }

        private void mnu_Add_Click(object sender, EventArgs e)
        {
            Frm转公账 frm = new Frm转公账();
            frm.Customer = Customer;
            frm.IsAdding = true;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            FreshData();
        }

        private void mnu_Assign_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                AccountRecord ar = dataGridView1.SelectedRows[0].Tag as AccountRecord;
                Frm核销公账 frm = new Frm核销公账();
                frm.AccountRecord = ar;
                frm.ShowDialog();
                FreshData();
            }
        }

        private void cMnu_Export_Click(object sender, EventArgs e)
        {
            NPOIExcelHelper.Export(dataGridView1);
        }

        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Tag == null) return;
                AccountRecord ar = dataGridView1.Rows[e.RowIndex].Tag as AccountRecord;
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "colSheetID")
                {
                    var sheet = new CustomerPaymentBLL(AppSettings.Current.ConnStr).GetByID(ar.SheetID).QueryObject;
                    if (sheet != null)
                    {
                        if (sheet.ClassID == CustomerPaymentType.转公账)
                        {
                            Frm转公账 frm = new Frm转公账();
                            frm.IsAdding = false;
                            frm.UpdatingItem = sheet;
                            frm.ShowDialog();
                            FreshData();
                        }
                        else
                        {
                            FrmCustomerPaymentDetail frm = new FrmCustomerPaymentDetail();
                            frm.IsAdding = false;
                            frm.UpdatingItem = sheet;
                            frm.PaymentType = sheet.ClassID;
                            frm.ShowDialog();
                            FreshData();
                        }
                    }
                }
                else if (this.dataGridView1.Columns[e.ColumnIndex].Name == "colAssigned")
                {
                    FrmReceivablePaymentAssigns frm = new FrmReceivablePaymentAssigns();
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowAssigns(ar);
                    frm.ShowDialog();
                    FreshData();
                }
                else if (this.dataGridView1.Columns[e.ColumnIndex].Name == "colStackSheetID")
                {
                    if (!string.IsNullOrEmpty(ar.StackSheetID))
                    {
                        var sheet = new StackOutSheetBLL(AppSettings.Current.ConnStr).GetByID(ar.StackSheetID).QueryObject;
                        if (sheet != null)
                        {
                            Inventory.FrmStackOutSheetDetail frm = new Inventory.FrmStackOutSheetDetail();
                            frm.IsAdding = false;
                            frm.IsForView = true;
                            frm.UpdatingItem = sheet;
                            frm.ShowDialog();
                        }
                    }
                }
            }
        }

        private void chkSheetDate_CheckedChanged(object sender, EventArgs e)
        {
            FreshData();
        }

        private void btnLast3Month_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            ucDateTimeInterval1.StartDateTime = today.AddMonths(-3);
            ucDateTimeInterval1.EndDateTime = today.AddDays(1).AddSeconds(-1);
        }

        private void ucDateTimeInterval1_ValueChanged(object sender, EventArgs e)
        {
            if (chkSheetDate.Checked) FreshData();
        }
        #endregion
    }
}
