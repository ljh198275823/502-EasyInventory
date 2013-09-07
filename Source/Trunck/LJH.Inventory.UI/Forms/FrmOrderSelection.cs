using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory.BusinessModel.Resource;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmOrderSelection : FrmMasterBase
    {
        public FrmOrderSelection()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return null;
        }

        protected override List<object> GetDataSource()
        {
            List<Order> items = (new OrderBLL(AppSettings.CurrentSetting.ConnectString)).GetItems(SearchCondition).QueryObjects;
            return (from item in items
                    orderby item.ID ascending
                    select (object)item).ToList();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            row.Tag = item;
            Order order = item as Order;
            row.Cells["colOrderID"].Value = order.ID;
            row.Cells["colAmount"].Value = order.CalAmount().Trim();
            row.Cells["colReceivable"].Value = order.Receivable.Trim();
            row.Cells["colHasPaid"].Value = order.HasPaid.Trim();
            row.Cells["colNotPaid"].Value = (order.CalAmount() - order.HasPaid).Trim();
            row.Cells["colMemo"].Value = order.Memo;
        }
        #endregion
    }
}
