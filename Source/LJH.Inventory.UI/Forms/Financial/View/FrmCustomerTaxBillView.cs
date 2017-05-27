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
    public partial class FrmCustomerTaxBillView : Form
    {
        public FrmCustomerTaxBillView()
        {
            InitializeComponent();
        }

        #region 公共属性
        public CompanyInfo Customer { get; set; }

        /// <summary>
        /// 获取或设置收款或付款类型
        /// </summary>
        public CustomerPaymentType PaymentType { get; set; }
        #endregion

        #region 重写基类方法
        private void FreshData()
        {
            var con = new AccountRecordSearchCondition();
            con.CustomerID = Customer != null ? Customer.ID : null;
            con.PaymentTypes = new List<CustomerPaymentType>();
            con.PaymentTypes.Add(PaymentType);
            if (!chkShowAll.Checked) con.HasRemain = true;
            var items = (new AccountRecordBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            items = (from item in items orderby item.CreateDate ascending, item.ID ascending select item).ToList();
            ShowItemsOnGrid(items);
        }

        private void ShowItemInGridViewRow(DataGridViewRow row, AccountRecord cp)
        {
            row.Tag = cp;
            row.Cells["colSheetID"].Value = cp.SheetID;
            row.Cells["colSheetDate"].Value = cp.CreateDate;
            row.Cells["colAmount"].Value = cp.Amount;
            if (cp.Remain != 0) row.Cells["colRemain"].Value = cp.Remain;
            else row.Cells["colRemain"].Value = null;
            if (cp.Assigned != 0) row.Cells["colAssigned"].Value = cp.Assigned;
            else row.Cells["colAssigned"].Value = null;
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
            if (PaymentType == CustomerPaymentType.CustomerTax)
            {
                mnu_Add.Enabled = Operator.Current.Permit(Permission.CustomerTaxBill, PermissionActions.Edit);
            }
            else if (PaymentType == CustomerPaymentType.SupplierTax)
            {
                mnu_Add.Enabled = Operator.Current.Permit(Permission.SupplierTaxBill, PermissionActions.Edit);
            }
            else
            {
                mnu_Add.Enabled = false;
            }
        }
        #endregion

        #region 事件处理程序
        private void FrmCustomerPaymentView_Load(object sender, EventArgs e)
        {
            ShowOperatorRights();
            FreshData();
        }

        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            FreshData();
        }

        private void mnu_Add_Click(object sender, EventArgs e)
        {
            FrmCustomerTaxBillDetail frm = new FrmCustomerTaxBillDetail();
            frm.Customer = Customer;
            frm.TaxType = PaymentType;
            frm.IsAdding = true;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            FreshData();
        }

        private void mnu_Assign_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                AccountRecord cp = dataGridView1.SelectedRows[0].Tag as AccountRecord;
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
            NPOIExcelHelper.Export(dataGridView1);
        }

        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Tag == null) return;
                AccountRecord cp = dataGridView1.Rows[e.RowIndex].Tag as AccountRecord;
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colSheetID")
                {
                    var sheet = new CustomerPaymentBLL(AppSettings.Current.ConnStr).GetByID(cp.SheetID).QueryObject;
                    if (sheet != null)
                    {
                        FrmCustomerTaxBillDetail frm = new FrmCustomerTaxBillDetail();
                        frm.TaxType = this.PaymentType;
                        frm.IsAdding = false;
                        frm.UpdatingItem = sheet;
                        frm.ShowDialog();
                        FreshData();
                    }
                }
                else if (this.dataGridView1.Columns[e.ColumnIndex].Name == "colAssigned")
                {
                    FrmReceivablePaymentAssigns frm = new FrmReceivablePaymentAssigns();
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowAssigns(cp);
                    frm.ShowDialog();
                }
            }
        }
        #endregion
    }
}
