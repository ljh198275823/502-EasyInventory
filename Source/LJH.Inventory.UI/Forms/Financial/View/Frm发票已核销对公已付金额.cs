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
using LJH.Inventory.UI.Forms;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Financial.View
{
    public partial class Frm发票已核销对公已付金额 : Form
    {
        public Frm发票已核销对公已付金额()
        {
            InitializeComponent();
        }

        #region 公共属性
        public CompanyInfo Customer { get; set; }
        #endregion

        #region 重写基类方法
        private void FreshData()
        {
            var con = new CustomerReceivableSearchCondition();
            con.CustomerID = Customer != null ? Customer.ID : null;
            con.ReceivableTypes = new List<CustomerReceivableType>() { CustomerReceivableType.公账应收款 };
            if (!chkSheetDate.Checked) con.Settled = false;
            else con.CreateDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            var items = (new CustomerReceivableBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            items = (from item in items orderby item.CreateDate ascending, item.ID ascending select item).ToList();
            ShowItemsOnGrid(items);
        }

        private void ShowItemInGridViewRow(DataGridViewRow row, CustomerReceivable cr)
        {
            row.Tag = cr;
            row.Cells["colSheetID"].Value = cr.SheetID;
            row.Cells["colSheetDate"].Value = cr.CreateDate;
            row.Cells["colAmount"].Value = cr.Amount;
            if (cr.Remain != 0) row.Cells["colRemain"].Value = cr.Remain;
            else row.Cells["colRemain"].Value = null;
            if (cr.Haspaid != 0) row.Cells["colAssigned"].Value = cr.Haspaid;
            else row.Cells["colAssigned"].Value = null;
            row.Cells["col购货单位"].Value = cr.GetProperty("购货单位");
            row.Cells["col出票单位"].Value = cr.GetProperty("出票单位");
            row.Cells["colMemo"].Value = cr.Memo;
        }

        private void ShowItemsOnGrid(List<CustomerReceivable> items)
        {
            GridView.Rows.Clear();
            if (items != null && items.Count > 0)
            {
                foreach (var cr in items)
                {
                    int row = GridView.Rows.Add();
                    ShowItemInGridViewRow(GridView.Rows[row], cr);
                }
                int rowTotal = GridView.Rows.Add();
                GridView.Rows[rowTotal].Cells["colSheetDate"].Value = "合计";
                GridView.Rows[rowTotal].Cells["colAmount"].Value = items.Sum(item => (item as CustomerReceivable).Amount).Trim();
                GridView.Rows[rowTotal].Cells["colAssigned"].Value = items.Sum(item => (item as CustomerReceivable).Haspaid).Trim();
                GridView.Rows[rowTotal].Cells["colRemain"].Value = items.Sum(item => (item as CustomerReceivable).Remain).Trim();
            }
            lblMSG.Text = string.Format("共 {0} 项", items != null ? items.Count : 0);
        }

        private void ShowOperatorRights()
        {
            mnu_Add.Enabled = false;
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

        private void mnu_Assign_Click(object sender, EventArgs e)
        {
            if (GridView.SelectedRows.Count == 1)
            {
                AccountRecord cp = GridView.SelectedRows[0].Tag as AccountRecord;
                if (cp.Remain > 0)
                {
                    FrmPaymentAssign frm = new FrmPaymentAssign();
                    frm.AccountRecord = cp;
                    frm.ShowDialog();
                    FreshData();
                }
            }
        }

        private void cMnu_Export_Click(object sender, EventArgs e)
        {
            NPOIExcelHelper.Export(GridView);
        }

        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (GridView.Rows[e.RowIndex].Tag == null) return;
                CustomerReceivable cp = GridView.Rows[e.RowIndex].Tag as CustomerReceivable;
                if (GridView.Columns[e.ColumnIndex].Name == "colSheetID")
                {
                    var sheet = new CustomerPaymentBLL(AppSettings.Current.ConnStr).GetByID(cp.SheetID).QueryObject;
                    if (sheet != null)
                    {
                        FrmCustomerTaxBillDetail frm = new FrmCustomerTaxBillDetail();
                        frm.TaxType = sheet.ClassID;
                        frm.IsAdding = false;
                        frm.UpdatingItem = sheet;
                        frm.IsForView = true;
                        frm.ShowDialog();
                    }
                }
                else if (this.GridView.Columns[e.ColumnIndex].Name == "colAssigned")
                {
                    FrmReceivablePaymentAssigns frm = new FrmReceivablePaymentAssigns();
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowAssigns(cp);
                    frm.ShowDialog();
                    FreshData();
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

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            FilterRow(txtKeyword.Text);
        }

        private void FilterRow(string key)
        {
            var items = new List<CustomerReceivable>();
            for (int i = 0; i < GridView.Rows.Count - 1; i++)
            {
                GridView.Rows[i].Visible = ContainText(GridView.Rows[i], key);
                if (GridView.Rows[i].Visible) items.Add(GridView.Rows[i].Tag as CustomerReceivable);
            }
            lblMSG.Text = string.Format("共 {0} 项", items.Count);
            if (GridView.Rows.Count > 0)
            {
                GridView.Rows[GridView.Rows.Count - 1].Cells["colAmount"].Value = items.Sum(item => (item as CustomerReceivable).Amount).Trim();
                GridView.Rows[GridView.Rows.Count - 1].Cells["colAssigned"].Value = items.Sum(item => (item as CustomerReceivable).Haspaid).Trim();
                GridView.Rows[GridView.Rows.Count - 1].Cells["colRemaind"].Value = items.Sum(item => (item as CustomerReceivable).Remain).Trim();
            }
        }

        private bool ContainText(DataGridViewRow row, string key)
        {
            if (string.IsNullOrEmpty(key)) return true;
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value != null && cell.Value.ToString().Contains(key)) return true;
            }
            return false;
        }
    }
}
