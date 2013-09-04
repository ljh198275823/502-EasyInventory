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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmOrderMaster :FrmMasterBase 
    {
        public FrmOrderMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法和处理事件
        protected override void Init()
        {
            base.Init();
            btnAll.BackColor = SystemColors.ControlDark;
            OperatorInfo opt = OperatorInfo.CurrentOperator;
            dataGridView1.Columns["colAmount"].Visible = OperatorInfo.CurrentOperator.Permit(Permission.ReadPrice);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmOrderDetail();
        }

        protected override List<object> GetDataSource()
        {
            List<Order> items = (new OrderBLL(AppSettings.CurrentSetting.ConnectString)).GetItems(SearchCondition).QueryObjects;
            List<Order> temp = new List<Order>();
            List<object> records = null;
            temp.AddRange(items);

            records = (from o in temp
                       where o.State == SheetState.Canceled
                       select (object)o).ToList();
            btnCanceled.Tag = records;
            btnCanceled.Text = string.Format("作废 ({0})", records == null ? 0 : records.Count);
            temp.RemoveAll(o => o.State == SheetState.Canceled);

            records = (from o in temp
                       where o.State == SheetState.Closed
                       select (object)o).ToList();
            btnClosed.Tag = records;
            btnClosed.Text = string.Format("关闭 ({0})", records == null ? 0 : records.Count);
            temp.RemoveAll(o => o.State == SheetState.Closed);

            records = (from o in temp
                       where o.IsCompleteAll
                       select (object)o).ToList();
            btnCompleteAll.Tag = records;
            btnCompleteAll.Text = string.Format("全部交货 ({0})", records == null ? 0 : records.Count);
            temp.RemoveAll(o => o.IsCompleteAll);

            records = (from o in temp
                       where o.IsOverDate
                       select (object)o).ToList();
            btnOverDate.Tag = records;
            btnOverDate.Text = string.Format("逾期未交 ({0})", records == null ? 0 : records.Count);
            temp.RemoveAll(o => o.IsOverDate);

            records = (from o in temp
                       where o.IsEmergency
                       select (object)o).ToList();
            btnEmergency.Tag = records;
            btnEmergency.Text = string.Format("即将交货 ({0})", records == null ? 0 : records.Count);
            temp.RemoveAll(o => o.IsEmergency);

            records = (from o in temp
                       where !o.IsEmergency
                       select (object)o).ToList();
            btnNonEmergency.Tag = records;
            btnNonEmergency.Text = string.Format("非紧急 ({0})", records == null ? 0 : records.Count);
            temp.RemoveAll(o => o.IsEmergency);

            records = (from o in items
                       select (object)o).ToList();
            btnAll.Tag = records;
            btnAll.Text = string.Format("全部 ({0})", records == null ? 0 : records.Count);
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
            row.Cells["colMemo"].Value = order.Memo;
            if (order.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
        }
        #endregion

        
    }
}
