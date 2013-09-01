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
using LJH.Inventory.UI.Forms.Report;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmPurchaseItemSelection : FrmMasterBase
    {
        public FrmPurchaseItemSelection()
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
            PurchaseOrderBLL bll = new PurchaseOrderBLL(AppSettings.CurrentSetting.ConnectString);
            List<PurchaseRecord> items = bll.GetRecords(SearchCondition).QueryObjects;
            return (from item in items
                    where item.Missing > 0
                    orderby item.DemandDate ascending, item.SheetNo ascending
                    select (object)item
                    ).ToList();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            PurchaseRecord c = item as PurchaseRecord;
            row.Tag = c;
            row.Cells["colSheetNo"].Value = c.SheetNo;
            row.Cells["colProductName"].Value = c.Product.Name;
            row.Cells["colDemandDate"].Value = c.DemandDate.ToLongDateString();
            row.Cells["colCount"].Value = c.Count.Trim();
            row.Cells["colReceived"].Value = c.Received.Trim();
            row.Cells["colOnPurchase"].Value = c.Missing.Trim();
            row.Cells["colMemo"].Value = c.Memo;
        }
        #endregion
    }
}

