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
            List<PurchaseOrder> items = bll.GetItems(SearchCondition).QueryObjects;
            List<object> ret = null;
            foreach (PurchaseOrder item in items)
            {
                foreach (PurchaseItem pii in item.Items)
                {
                    if (pii.OnWay > 0)
                    {
                        if (ret == null) ret = new List<object>();
                        ret.Add(pii);
                    }
                }
            }
            return ret;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            PurchaseItem c = item as PurchaseItem;
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

