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
            var con = new CustomerPaymentSearchCondition();
            con.CustomerID = Customer != null ? Customer.ID : null;
            con.PaymentTypes = new List<CustomerPaymentType>();
            con.PaymentTypes.Add(PaymentType);
            if (!chkShowAll.Checked)
            {
                con.States = new List<SheetState>();
                con.States.Add(SheetState.Add);
                con.States.Add(SheetState.Approved);
                con.HasRemain = true;
            }
            var items = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            items = (from item in items orderby item.SheetDate ascending, item.ID ascending select item).ToList();
            ShowItemsOnGrid(items);
        }

        private void ShowItemInGridViewRow(DataGridViewRow row, CustomerPayment cp)
        {
            row.Tag = cp;
            row.Cells["colID"].Value = cp.ID;
            row.Cells["colSheetDate"].Value = cp.SheetDate;
            row.Cells["colAmount"].Value = cp.Amount;
            if (cp.Remain != 0) row.Cells["colRemain"].Value = cp.Remain;
            else row.Cells["colRemain"].Value = null;
            if (cp.Assigned != 0) row.Cells["colAssigned"].Value = cp.Assigned;
            else row.Cells["colAssigned"].Value = null;
            row.Cells["colMemo"].Value = cp.Memo;
            if (cp.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
        }

        private void ShowItemsOnGrid(List<CustomerPayment> items)
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
                dataGridView1.Rows[rowTotal].Cells["colAmount"].Value = items.Sum(item => (item as CustomerPayment).Amount).Trim();
                dataGridView1.Rows[rowTotal].Cells["colAssigned"].Value = items.Sum(item => (item as CustomerPayment).Assigned).Trim();
                dataGridView1.Rows[rowTotal].Cells["colRemain"].Value = items.Sum(item => (item as CustomerPayment).Remain).Trim();
            }
            lblMSG.Text = string.Format("共 {0} 项", items != null ? items.Count : 0);
        }
        #endregion

        #region 事件处理程序
        private void FrmCustomerPaymentView_Load(object sender, EventArgs e)
        {
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
            frm.IsAdding = true;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            FreshData();
        }

        private void mnu_Assign_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                CustomerPayment cp = dataGridView1.SelectedRows[0].Tag as CustomerPayment;
                if (cp.State != SheetState.Canceled && cp.Remain > 0)
                {
                    string paymentID = cp.ID;
                    FrmPaymentAssign frm = new FrmPaymentAssign();
                    frm.CustomerPaymentID = paymentID;
                    frm.ShowDialog();
                    FreshData();
                }
            }
        }

        private void cMnu_Export_Click(object sender, EventArgs e)
        {
            NPOIExcelHelper.Export(dataGridView1);
        }
        #endregion
    }
}
