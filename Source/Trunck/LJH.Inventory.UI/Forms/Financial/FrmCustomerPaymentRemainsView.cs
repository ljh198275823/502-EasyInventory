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

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmCustomerPaymentRemainsView : Form
    {
        public FrmCustomerPaymentRemainsView()
        {
            InitializeComponent();
        }

        #region 私有方法
        private void ShowCustomer(CompanyInfo c)
        {
            this.Text = string.Format("{0} 的付款单明细", c.Name);
            List<CustomerPayment> items = null;
            CustomerPaymentSearchCondition con = new CustomerPaymentSearchCondition();
            con.CustomerID = c.ID;
            if (!chkShowAll.Checked) con.HasRemain = true;
            items = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            GridView.Rows.Clear();
            if (items != null && items.Count > 0)
            {
                foreach (CustomerPayment item in items)
                {
                    int row = GridView.Rows.Add();
                    ShowItemInGridViewRow(GridView.Rows[row], item);
                }
                int rowTotal = GridView.Rows.Add();
                GridView.Rows[rowTotal].Cells["colPaidDate"].Value = "合计";
                GridView.Rows[rowTotal].Cells["colAmount"].Value = items.Sum(item => item.Amount);
                GridView.Rows[rowTotal].Cells["colRemain"].Value = items.Sum(item => (item.Amount - item.Assigned));
                this.toolStripStatusLabel1.Text = string.Format("总共 {0} 项", items.Count);
                GridView.Rows[0].Selected = false;
            }
        }

        private void ShowItemInGridViewRow(DataGridViewRow row, CustomerPayment item)
        {
            row.Tag = item;
            row.Cells["colID"].Value = item.ID;
            row.Cells["colPaidDate"].Value = item.LastActiveDate;
            row.Cells["colPaymentMode"].Value = LJH.Inventory.BusinessModel.Resource.PaymentModeDescription.GetDescription(item.PaymentMode);
            row.Cells["colAmount"].Value = item.Amount;
            row.Cells["colRemain"].Value = item.Amount - item.Assigned;
            row.Cells["colMemo"].Value = item.Memo;
        }
        #endregion

        #region 公共方法
        public CompanyInfo Customer { get; set; }
        #endregion

        #region 事件处理程序
        private void FrmCustomerPaymentRemains_Load(object sender, EventArgs e)
        {
            if (Customer != null)
            {
                ShowCustomer(Customer);
            }
        }

        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (Customer != null)
            {
                ShowCustomer(Customer);
            }
        }

        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (GridView.Columns[e.ColumnIndex].Name == "colID")
                {
                    CustomerPayment cp = GridView.Rows[e.RowIndex].Tag as CustomerPayment;
                    if (cp != null)
                    {
                        FrmCustomerPaymentDetail frm = new FrmCustomerPaymentDetail();
                        frm.IsAdding = false;
                        frm.IsForView = true;
                        frm.UpdatingItem = cp;
                        frm.ShowDialog();
                    }
                }
            }
        }
        #endregion
    }
}
