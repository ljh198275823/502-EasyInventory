﻿using System;
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
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Sale.View
{
    public partial class FrmOrderView : FrmMasterBase
    {
        public FrmOrderView()
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
            List<Order> items = null;
            if (SearchCondition == null)
            {
                items = (new OrderBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                items = (new OrderBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
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
            //row.Cells["colReceivable"].Value = order.Receivable.Trim();
            //row.Cells["colHasPaid"].Value = order.HasPaid.Trim();
            //row.Cells["colNotPaid"].Value = (order.CalAmount() - order.HasPaid).Trim();
        }
        #endregion
    }
}
