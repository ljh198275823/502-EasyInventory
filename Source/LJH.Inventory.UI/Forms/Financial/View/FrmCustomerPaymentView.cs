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
    public partial class FrmCustomerPaymentView : FrmMasterBase 
    {
        public FrmCustomerPaymentView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取或设置收款或付款类型
        /// </summary>
        public CustomerPaymentType PaymentType { get; set; }

        #region 重写基类方法
        protected override List<object> GetDataSource()
        {
            List<CustomerPayment> items = null;
            if (SearchCondition == null)
            {
                items = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                items = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            List<object> records = (from item in items orderby item.SheetDate ascending, item.ID ascending select (object)item).ToList();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CustomerPayment cp = item as CustomerPayment;
            row.Tag = cp;
            row.Cells["colID"].Value = cp.ID;
            row.Cells["colSheetDate"].Value = cp.SheetDate;
            row.Cells["colPaymentMode"].Value = LJH.Inventory.BusinessModel.Resource.PaymentModeDescription.GetDescription(cp.PaymentMode);
            row.Cells["colAmount"].Value = cp.Amount;
            if (cp.Remain != 0) row.Cells["colRemain"].Value = cp.Remain;
            else row.Cells["colRemain"].Value = null;
            if (cp.Assigned != 0) row.Cells["colAssigned"].Value = cp.Assigned;
            else row.Cells["colAssigned"].Value = null;
            row.Cells["colMemo"].Value = cp.Memo;
        }

        protected override void ShowItemsOnGrid(List<object> items)
        {
            base.ShowItemsOnGrid(items);
            int rowTotal = dataGridView1.Rows.Add();
            dataGridView1.Rows[rowTotal].Cells["colSheetDate"].Value = "合计";
            dataGridView1.Rows[rowTotal].Cells["colAmount"].Value = items.Sum(item => (item as CustomerPayment).Amount).Trim();
            dataGridView1.Rows[rowTotal].Cells["colAssigned"].Value = items.Sum(item => (item as CustomerPayment).Assigned).Trim();
            dataGridView1.Rows[rowTotal].Cells["colRemain"].Value = items.Sum(item => (item as CustomerPayment).Remain).Trim();
        }
        #endregion

        #region 事件处理程序
        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (SearchCondition != null)
            {
                CustomerPaymentSearchCondition cpsc = SearchCondition as CustomerPaymentSearchCondition;
                if (cpsc != null)
                {
                    if (!chkShowAll.Checked) cpsc.HasRemain = true;
                    else cpsc.HasRemain = null;
                }
                ReFreshData();
            }
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
                    frm.PaymentType = CustomerPaymentType.Customer;
                    frm.ShowDialog();
                    cp = new CustomerPaymentBLL(AppSettings.Current.ConnStr).GetByID(cp.ID).QueryObject;
                    ShowItemInGridViewRow(dataGridView1.SelectedRows[0], cp);
                }
            }
        }
        #endregion
    }
}
