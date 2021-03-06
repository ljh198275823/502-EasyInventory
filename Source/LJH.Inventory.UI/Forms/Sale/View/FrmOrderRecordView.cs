﻿using System;
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
using LJH.Inventory.UI.Report;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Sale.View
{
    public partial class FrmOrderRecordView : FrmMasterBase
    {
        public FrmOrderRecordView()
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
            List<OrderItemRecord> items = null;
            if (SearchCondition == null)
            {
                items = (new OrderBLL(AppSettings.Current.ConnStr)).GetRecords(null).QueryObjects;
            }
            else
            {
                items = (new OrderBLL(AppSettings.Current.ConnStr)).GetRecords(SearchCondition).QueryObjects;
            }
            return (from item in items
                    orderby item.SheetNo ascending
                    select (object)item).ToList();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            OrderItemRecord c = item as OrderItemRecord;
            row.Tag = c;
            row.Cells["colOrderID"].Value = c.SheetNo;
            row.Cells["colProductName"].Value = c.Product.Name;
            row.Cells["colCount"].Value = c.Count.Trim();
            row.Cells["colDemandDate"].Value = c.DemandDate.ToLongDateString();
            row.Cells["colPrepared"].Value = (c.OnWay + c.Inventory).Trim();
            row.Cells["colNotPurchased"].Value = c.NotPurchased.Trim();
            row.Cells["colMemo"].Value = c.Memo;
        }
        #endregion
    }
}
