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
    public class ProductInventoryItemProvider : ProviderBase<ProductInventoryItem, Guid >
    {
        public ProductInventoryItemProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr,ms)
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
                if (con.OrderItem != null) ret = ret.Where(item => item.OrderItem == con.OrderItem);
                if (con.PurchaseItem != null) ret = ret.Where(item => item.PurchaseItem == con.PurchaseItem);
                if (con.InventoryItem != null) ret = ret.Where(item => item.InventoryItem == con.InventoryItem);
                if (con.DeliveryItem != null) ret = ret.Where(item => item.DeliveryItem == con.DeliveryItem);
                if (con.UnShipped != null)
                {
                    if (con.UnShipped.Value)
                    {
                        ret = ret.Where(item => item.DeliveryItem == null);
                    }
                    else
                    {
                        ret = ret.Where(item => item.DeliveryItem != null);
                    }
                }
                if (con.UnReserved != null)
                {
                    if (con.UnReserved.Value)
                    {
                        ret = ret.Where(item => item.OrderItem == null);
                    }
                    else
                    {
                        ret = ret.Where(item => item.DeliveryItem != null);
                    }
                }
            }
            return ret.ToList();
        }
        #endregion
    }
}

