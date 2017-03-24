using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

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
            var ret = dc.GetTable<ProductInventoryItem>().SingleOrDefault(item => item.ID == id);
            if (ret != null)
            {
                ret.Product = new ProductProvider(SqlURI, _MappingResource).GetByID(ret.ProductID).QueryObject;
                if (ret.Product == null) ret = null;
            }
            return ret;
        }

        protected override List<ProductInventoryItem> GetingItems(DataContext dc, SearchCondition search)
        {
            IQueryable<ProductInventoryItem> ret = dc.GetTable<ProductInventoryItem>();
            if (search is ProductInventoryItemSearchCondition)
            {
                ProductInventoryItemSearchCondition con = search as ProductInventoryItemSearchCondition;
                if (!string.IsNullOrEmpty(con.Model)) ret = ret.Where(item => item.Model == con.Model);
                if (!string.IsNullOrEmpty(con.ExcludeModel)) ret = ret.Where(item => item.Model != con.ExcludeModel);
                if (con.AddDateRange != null) ret = ret.Where(item => item.AddDate >= con.AddDateRange.Begin && item.AddDate <= con.AddDateRange.End);
                if (con.Products != null && con.Products.Count > 0) ret = ret.Where(item => con.Products.Contains(item.ProductID));
                if (con.IDS != null && con.IDS.Count > 0) ret = ret.Where(item => con.IDS.Contains(item.ID));
                if (!string.IsNullOrEmpty(con.ProductID)) ret = ret.Where(item => item.ProductID == con.ProductID);
                if (!string.IsNullOrEmpty(con.WareHouseID)) ret = ret.Where(item => item.WareHouseID == con.WareHouseID);
                if (con.OrderItem != null) ret = ret.Where(item => item.OrderItem == con.OrderItem);
                if (!string.IsNullOrEmpty(con.OrderID)) ret = ret.Where(item => item.OrderID == con.OrderID);
                if (con.PurchaseItem != null) ret = ret.Where(item => item.PurchaseItem == con.PurchaseItem);
                if (!string.IsNullOrEmpty(con.PurchaseID)) ret = ret.Where(item => item.PurchaseID == con.PurchaseID);
                if (con.InventoryItem != null) ret = ret.Where(item => item.InventoryItem == con.InventoryItem);
                if (!string.IsNullOrEmpty(con.InventorySheetNo)) ret = ret.Where(item => item.InventorySheet == con.InventorySheetNo);
                if (con.DeliveryItem != null) ret = ret.Where(item => item.DeliveryItem == con.DeliveryItem);
                if (!string.IsNullOrEmpty(con.DeliverySheetNo)) ret = ret.Where(item => item.DeliverySheet == con.DeliverySheetNo);
                if (con.SourceRoll.HasValue) ret = ret.Where(item => item.SourceRoll == con.SourceRoll);
                if (con.OriginalWeight.HasValue) ret = ret.Where(it => it.OriginalWeight == con.OriginalWeight);
                if (con.HasRemain) ret = ret.Where(item => item.Count > 0);
                if (con.States != null && con.States.Count > 0) ret = ret.Where(it => con.States.Contains(it.State));
                if (con.Sliced.HasValue)
                {
                    if (con.Sliced.Value) ret = ret.Where(it => it.OriginalWeight > it.Weight);
                    else ret = ret.Where(it => it.OriginalWeight == it.Weight);
                }
                if (con.HasWeight.HasValue)
                {
                    if (con.HasWeight.Value) ret = ret.Where(it => it.Weight > 0);
                    else ret = ret.Where(it => it.Weight == 0);
                }
            }
            var items = ret.ToList();
            if (items != null && items.Count > 0)
            {
                foreach (var pi in items)
                {
                    pi.Product = new ProductProvider(SqlURI, _MappingResource).GetByID(pi.ProductID).QueryObject;
                }
                items.RemoveAll(it => it.Product == null);
            }
            return items;
        }
        #endregion
    }
}

