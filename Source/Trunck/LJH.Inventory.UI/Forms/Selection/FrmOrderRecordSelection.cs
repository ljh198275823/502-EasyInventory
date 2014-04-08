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
using LJH.Inventory.UI.Report;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmOrderRecordSelection : FrmMasterBase
    {
        public FrmOrderRecordSelection()
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
            List<OrderRecord> items = (new OrderBLL(AppSettings.Current.ConnStr)).GetRecords(SearchCondition).QueryObjects;
            return (from item in items
                    orderby item.OrderID ascending
                    select (object)item).ToList();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            OrderRecord c = item as OrderRecord;
            row.Tag = c;
            row.Cells["colOrderID"].Value = c.OrderID;
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
