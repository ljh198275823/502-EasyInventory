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
using LJH.Inventory.UI.View;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmOrderMaster : FrmMasterBase
    {
        public FrmOrderMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法和处理事件
        protected override void Init()
        {
            base.Init();
            this.customerTree1.LoadCustomer = true;
            this.customerTree1.Init();
            Operator opt = Operator.Current;
            dataGridView1.Columns["colAmount"].Visible = Operator.Current.Permit(Permission.ReadPrice);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmOrderDetail();
        }

        protected override List<object> GetDataSource()
        {
            List<Order> items = (new OrderBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            List<Order> temp = new List<Order>();
            List<object> records = null;
            temp.AddRange(items);

            records = (from o in temp
                       where o.State == SheetState.Canceled
                       select (object)o).ToList();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            Order order = item as Order;
            row.Cells["colID"].Value = order.ID;
            row.Cells["colOrderDate"].Value = order.OrderDate;
            row.Cells["colCustomer"].Value = order.Customer.Name;
            row.Cells["colFinalCustomer"].Value = order.FinalCustomer != null ? order.FinalCustomer.Name : string.Empty;
            row.Cells["colSales"].Value = order.SalesPerson;
            row.Cells["colDeliveryDate"].Value = order.DemandDate;
            row.Cells["colWithTax"].Value = order.WithTax;
            row.Cells["colAmount"].Value = order.CalAmount().Trim();
            row.Cells["colReceivable"].Value = order.Receivable.Trim();
            row.Cells["colHasPaid"].Value = order.HasPaid.Trim();
            row.Cells["colNotPaid"].Value = (order.CalAmount() - order.HasPaid).Trim();
            row.Cells["colMemo"].Value = order.Memo;
            if (order.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
        }
        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "colReceivable")
            {
                Order order = dataGridView1.Rows[e.RowIndex].Tag as Order;
                DeliveryRecordSearchCondition con = new DeliveryRecordSearchCondition();
                con.OrderID = order.ID;
                FrmDeliveryRecordView frm = new FrmDeliveryRecordView();
                frm.SearchCondition = con;
                frm.ShowDialog();
            }
        }
    }
}
