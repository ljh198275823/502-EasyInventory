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
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Purchase.View
{
    public partial class FrmPurchaseRecordView : FrmMasterBase
    {
        public FrmPurchaseRecordView()
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
            List<PurchaseItemRecord> items = null;
            if (SearchCondition == null)
            {
                items = new PurchaseOrderBLL(AppSettings.Current.ConnStr).GetRecords(null).QueryObjects;
            }
            else
            {
                items = new PurchaseOrderBLL(AppSettings.Current.ConnStr).GetRecords(SearchCondition).QueryObjects;
            }
            return (from item in items
                    orderby item.SheetNo ascending
                    select (object)item).ToList();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            PurchaseItemRecord c = item as PurchaseItemRecord;
            row.Tag = c;
            row.Cells["colSheetNo"].Value = c.SheetNo;
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

