using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Inventory.View
{
    public partial class FrmProductInventoryRecordsView : Form
    {
        public FrmProductInventoryRecordsView()
        {
            InitializeComponent();
        }

        public ProductInventory ProductInventory { get; set; }

        #region 私有方法
        private void ShowItemInGridViewRow(DataGridViewRow row, ProductInventoryRecord item)
        {
            row.Tag = item;
            row.Cells["colDate"].Value = item.Date.ToString("yyyy-MM-dd");
            row.Cells["colProductID"].Value = item.ProductID;
            row.Cells["colProductName"].Value = item.ProductName;
            row.Cells["colIn"].Value = item.In != 0 ? item.In.Trim().ToString() : string.Empty;
            row.Cells["colOut"].Value = item.Out != 0 ? item.Out.Trim().ToString() : string.Empty;
            row.Cells["colSheetNo"].Value = item.SheetNo;
        }

        private void ShowItemsInGrid(List<ProductInventoryRecord> items)
        {
            this.gridView.Rows.Clear();
            foreach (ProductInventoryRecord item in items)
            {
                int row = this.gridView.Rows.Add();
                ShowItemInGridViewRow(gridView.Rows[row], item);
            }
            int total = this.gridView.Rows.Add();
            gridView.Rows[total].Cells["colDate"].Value = "合计";
            gridView.Rows[total].Cells["colIn"].Value = items.Sum(it => it.In).Trim();
            gridView.Rows[total].Cells["colOut"].Value = items.Sum(it => it.Out).Trim();
        }
        #endregion

        #region 事件处理程序
        private void FrmProductInventoryRecordsView_Load(object sender, EventArgs e)
        {
            DeliveryRecordSearchCondition con1 = new DeliveryRecordSearchCondition();
            con1.LastActiveDate = new DateTimeRange(DateTime.Today.AddMonths(-1), DateTime.Now);
            con1.States = new List<SheetState>();
            con1.States.Add(SheetState.Shipped);
            con1.ProductID = ProductInventory.ProductID;
            con1.WareHouseID = ProductInventory.WareHouseID;
            List<DeliveryRecord> item1 = new DeliverySheetBLL(AppSettings.Current.ConnStr).GetDeliveryRecords(con1).QueryObjects;

            InventoryRecordSearchCondition con2 = new InventoryRecordSearchCondition();
            con2.LastActiveDate = new DateTimeRange(DateTime.Today.AddMonths(-1), DateTime.Now);
            con2.States = new List<SheetState>();
            con2.States.Add(SheetState.Inventory);
            con2.ProductID = ProductInventory.ProductID;
            con2.WareHouseID = ProductInventory.WareHouseID;
            List<InventoryRecord> item2 = new InventorySheetBLL(AppSettings.Current.ConnStr).GetInventoryRecords(con2).QueryObjects;

            List<ProductInventoryRecord> items = new List<ProductInventoryRecord>();
            items.AddRange(item1.Select(item => new ProductInventoryRecord() { Date = item.LastActiveDate, ProductID = item.ProductID, ProductName = item.Product.Name, Out = item.Count, SheetNo = item.SheetNo }));
            items.AddRange(item2.Select(item => new ProductInventoryRecord() { Date = item.LastActiveDate, ProductID = item.ProductID, ProductName = item.Product.Name, In = item.Count, SheetNo = item.SheetNo }));
            items = (from item in items
                     orderby item.Date descending
                     select item).ToList();
            ShowItemsInGrid(items);
        }
        #endregion
    }

    internal class ProductInventoryRecord
    {
        public DateTime Date { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal In { get; set; }
        public decimal Out { get; set; }
        public string SheetNo { get; set; }
    }
}
