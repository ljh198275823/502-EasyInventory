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
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.UI;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.UI.Forms.Inventory.View
{
    public partial class FrmProductStackRecordsView : FrmMasterBase
    {
        public FrmProductStackRecordsView()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override List<object> GetDataSource()
        {
            List<Product> ps = new ProductBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            List<WareHouse> ws = new WareHouseBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            List<ProductInventoryItem> pis = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).GetItems(SearchCondition).QueryObjects;
            if (pis != null && pis.Count > 0)
            {
                List<ProductInventoryRecord> records = new List<ProductInventoryRecord>();
                var ins = pis.Where(it => !pis.Exists(temp => temp.ID == it.SourceID));
                foreach (var item in ins)
                {
                    Product p = ps.SingleOrDefault(it => it.ID == item.ProductID);
                    WareHouse w = ws.SingleOrDefault(it => it.ID == item.WareHouseID);
                    if (p != null && w != null)
                    {
                        ProductInventoryRecord record = new ProductInventoryRecord();
                        record.Date = item.AddDate;
                        record.Product = p;
                        record.WareHouse = w;
                        record.SheetNo = item.InventorySheet;
                        record.In = item.Count + pis.Sum(it => it.SourceID == item.ID ? it.Count : 0);
                        records.Add(record);
                    }
                }

                var outs = from it in pis
                           where it.State == ProductInventoryState.Shipped
                           group it by new {it.DeliveryItem };
                foreach (var item in outs)
                {
                    Product p = ps.SingleOrDefault(it => it.ID == item.First().ProductID);
                    WareHouse w = ws.SingleOrDefault(it => it.ID == item.First().WareHouseID);
                    if (p != null && w != null)
                    {
                        ProductInventoryRecord record = new ProductInventoryRecord();
                        record.Date = item.Max (it=>it.AddDate);
                        record.Product = p;
                        record.WareHouse = w;
                        record.SheetNo = item.First().DeliverySheet;
                        record.Out = item.Sum(it => it.Count);
                        records.Add(record);
                    }
                }
                return (from item in records
                        orderby item.Date ascending
                        select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemsOnGrid(List<object> items)
        {
            base.ShowItemsOnGrid(items);
            int total = this.gridView.Rows.Add();
            gridView.Rows[total].Cells["colDate"].Value = "合计";
            gridView.Rows[total].Cells["colIn"].Value = items.Sum(it => (it as ProductInventoryRecord).In).Trim();
            gridView.Rows[total].Cells["colOut"].Value = items.Sum(it => (it as ProductInventoryRecord).Out).Trim();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            ProductInventoryRecord record = item as ProductInventoryRecord;
            row.Tag = record;
            row.Cells["colDate"].Value = record.Date.ToString("yyyy-MM-dd");
            row.Cells["colCategory"].Value = record.Product.Category.Name;
            row.Cells["colSpecification"].Value = record.Product.Specification;
            //row.Cells["colModel"].Value = record.Product.Model;
            row.Cells["colWeight"].Value = record.Product.Weight;
            row.Cells["colLength"].Value = record.Product.Length;
            row.Cells["colIn"].Value = record.In != 0 ? record.In.Trim().ToString() : string.Empty;
            row.Cells["colOut"].Value = record.Out != 0 ? record.Out.Trim().ToString() : string.Empty;
            row.Cells["colSheetNo"].Value = record.SheetNo;
        }
        #endregion
    }

    internal class ProductInventoryRecord
    {
        public DateTime Date { get; set; }
        //public string WareHouseID { get; set; }
        //public string ProductID { get; set; }
        public Product Product { get; set; }
        public WareHouse WareHouse { get; set; }
        //public string ProductName { get; set; }
        public decimal In { get; set; }
        public decimal Out { get; set; }
        public string SheetNo { get; set; }
    }
}
