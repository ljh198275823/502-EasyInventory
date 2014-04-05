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
    public partial class FrmPurchaseRecordSelection : FrmMasterBase
    {
        public FrmPurchaseRecordSelection()
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
            List<PurchaseRecord> items = new PurchaseOrderBLL(AppSettings.Current.ConnStr).GetRecords(SearchCondition).QueryObjects;
            return (from item in items
                    orderby item.PurchaseID ascending
                    select (object)item).ToList();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            PurchaseRecord c = item as PurchaseRecord;
            row.Tag = c;
            row.Cells["colSheetNo"].Value = c.PurchaseID;
            row.Cells["colProductName"].Value = c.Product.Name;
            row.Cells["colDemandDate"].Value = c.DemandDate.ToLongDateString();
            row.Cells["colCount"].Value = c.Count.Trim();
            row.Cells["colReceived"].Value = c.Received.Trim();
            row.Cells["colOnPurchase"].Value = c.OnWay.Trim();
            row.Cells["colMemo"].Value = c.Memo;
        }
        #endregion
    }
}

