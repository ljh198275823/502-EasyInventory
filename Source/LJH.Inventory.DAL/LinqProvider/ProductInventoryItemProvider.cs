using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class ProductInventoryItemProvider : ProviderBase<ProductInventoryItem, Guid>
    {
        public ProductInventoryItemProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }

        #region 重写模板方法
        protected override ProductInventoryItem GetingItemByID(Guid id, DataContext dc)
        {
            return dc.GetTable<ProductInventoryItem>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<ProductInventoryItem> GetingItems(DataContext dc, SearchCondition search)
        {
            IQueryable<ProductInventoryItem> ret = dc.GetTable<ProductInventoryItem>();
            if (search is ProductInventoryItemSearchCondition)
            {
                ProductInventoryItemSearchCondition con = search as ProductInventoryItemSearchCondition;
                if (con.Products != null && con.Products.Count > 0) ret = ret.Where(item => con.Products.Contains(item.ProductID));
                if (!string.IsNullOrEmpty(con.WareHouseID)) ret = ret.Where(item => item.WareHouseID == con.WareHouseID);
                if (!string.IsNullOrEmpty(con.Model)) ret = ret.Where(item => item.Model == con.Model);
                if (!string.IsNullOrEmpty(con.ExcludeModel)) ret = ret.Where(item => item.Model != con.ExcludeModel);
                if (con.OrderItem != null) ret = ret.Where(item => item.OrderItem == con.OrderItem);
                if (!string.IsNullOrEmpty(con.OrderID)) ret = ret.Where(item => item.OrderID == con.OrderID);
                if (con.PurchaseItem != null) ret = ret.Where(item => item.PurchaseItem == con.PurchaseItem);
                if (!string.IsNullOrEmpty(con.PurchaseID)) ret = ret.Where(item => item.PurchaseID == con.PurchaseID);
                if (con.InventoryItem != null) ret = ret.Where(item => item.InventoryItem == con.InventoryItem);
                if (!string.IsNullOrEmpty(con.InventorySheetNo)) ret = ret.Where(item => item.InventorySheet == con.InventorySheetNo);
                if (con.DeliveryItem != null) ret = ret.Where(item => item.DeliveryItem == con.DeliveryItem);
                if (!string.IsNullOrEmpty(con.DeliverySheetNo)) ret = ret.Where(item => item.DeliverySheet == con.DeliverySheetNo);
            }
            var items = ret.ToList();
            if (items != null && items.Count > 0)
            {
                if (search is ProductInventoryItemSearchCondition)
                {
                    ProductInventoryItemSearchCondition con = search as ProductInventoryItemSearchCondition;
                    if (con.States.HasValue && con.States.Value > 0)
                    {
                        int s = con.States.Value;
                        items = items.Where(it => ((s & (int)ProductInventoryState.Inventory) > 0 && it.State == ProductInventoryState.Inventory) ||
                                                  ((s & (int)ProductInventoryState.Reserved) > 0 && it.State == ProductInventoryState.Reserved) ||
                                                  ((s & (int)ProductInventoryState.WaitShip) > 0 && it.State == ProductInventoryState.WaitShip) ||
                                                  ((s & (int)ProductInventoryState.Shipped) > 0 && it.State == ProductInventoryState.Shipped) ||
                                                  ((s & (int)ProductInventoryState.Nullified) > 0 && it.State == ProductInventoryState.Nullified)
                                           ).ToList();
                    }
                }
            }
            return items;
        }
        #endregion
    }
}

