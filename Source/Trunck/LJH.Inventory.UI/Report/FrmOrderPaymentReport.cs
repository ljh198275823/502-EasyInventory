using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.UI.View;
using LJH.Inventory.BLL;
using LJH.Inventory.UI.Forms;

namespace LJH.Inventory.UI.Report
{
    public partial class FrmOrderPaymentReport : FrmReportBase
    {
        public FrmOrderPaymentReport()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override void OnItemSearching(EventArgs e)
        {
            OrderSearchCondition con = new OrderSearchCondition();
            if (txtCustomer.Tag != null) con.CustomerID = (txtCustomer.Tag as Customer).ID;
            if (txtFinalCustomer.Tag != null) con.FinalCustomerID = (txtFinalCustomer.Tag as Customer).ID;
            if (txtSalesPerson.Tag != null) con.Sales = (txtSalesPerson.Tag as Operator).Name;
            con.States = new List<SheetState>();
            con.States.Add(SheetState.Add);
            con.States.Add(SheetState.Approved);
            con.States.Add(SheetState.Closed);
            List<Order> items = (new OrderBLL(AppSettings.CurrentSetting.ConnStr)).GetItems(con).QueryObjects;
            foreach (Order item in items)
            {
                int row = gridView.Rows.Add();
                ShowItemOnRow(gridView.Rows[row], item);
            }
        }

        private void ShowItemOnRow(DataGridViewRow row, Order item)
        {
            row.Cells["colOrderDate"].Value = item.OrderDate .ToLongDateString ();
            row.Cells["colOrderID"].Value = item.ID;
            row.Cells["colCustomer"].Value =item.Customer !=null ?item.Customer.Name:string.Empty ;
            row.Cells["colFinalCustomer"].Value = item.FinalCustomer != null ? item.FinalCustomer.Name : string.Empty;
            row.Cells["colCurrencyType"].Value = item.CurrencyType;
            row.Cells["colAmount"].Value = item.CalAmount().Trim();
            row.Cells["colShipped"].Value = item.Receivable.Trim();
            row.Cells["colHasPaid"].Value = item.HasPaid.Trim();
            row.Cells["colNotPaid"].Value = item.NotPaid.Trim();
            row.Cells["colSalesPerson"].Value = item.SalesPerson;
        }
        #endregion

        #region 事件处理程序
        private void FrmOrderPaymentReport_Load(object sender, EventArgs e)
        {
            this.ucDateTimeInterval1.ShowTime = false;
            this.ucDateTimeInterval1.Init();
            this.ucDateTimeInterval1.SelectThisMonth();
        }

        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomerMaster frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Customer item = frm.SelectedItem as Customer;
                txtCustomer.Text = item.Name;
                txtCustomer.Tag = item;
            }
        }

        private void lnkEndCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomerMaster frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Customer item = frm.SelectedItem as Customer;
                txtFinalCustomer.Text = item.Name;
                txtFinalCustomer.Tag = item;
            }
        }

        private void lnkSalesPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmOperatorMaster frm = new FrmOperatorMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Operator item = frm.SelectedItem as Operator;
                txtSalesPerson.Text = item.Name;
                txtSalesPerson.Tag = item;
            }
        }
        #endregion
    }
}
