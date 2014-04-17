using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary.UI;

namespace LJH.Inventory.UI.View
{
    public partial class FrmInventoryRecordView : FrmMasterBase
    {
        public FrmInventoryRecordView()
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
            List<InventoryRecord> records = (new InventorySheetBLL(AppSettings.Current.ConnStr)).GetInventoryRecords(SearchCondition).QueryObjects;
            return (from item in records
                    orderby item.ProductID ascending
                    select (object)item).ToList();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            InventoryRecord c = item as InventoryRecord;
            row.Tag = c;
            row.Cells["colInventorySheet"].Value = c.SheetNo;
            row.Cells["colProductID"].Value = c.ProductID;
            row.Cells["colProductName"].Value = c.Product.Name;
            row.Cells["colSpecification"].Value = c.Product.Specification;
            row.Cells["colInventoryDate"].Value = c.InventoryDate.ToString("yyyy-MM-dd");
            row.Cells["colCount"].Value = c.Count.Trim();
            row.Cells["colPrice"].Value = c.Price.Trim();
            row.Cells["colAmount"].Value = c.Amount.Trim();
            row.Cells["colPurchaseID"].Value = c.PurchaseID;
            row.Cells["colSupplier"].Value = c.Supplier != null ? c.Supplier.Name : string.Empty;
            row.Cells["colWareHouse"].Value = c.WareHouse != null ? c.WareHouse.Name : string.Empty;
        }
        #endregion
    }
}
