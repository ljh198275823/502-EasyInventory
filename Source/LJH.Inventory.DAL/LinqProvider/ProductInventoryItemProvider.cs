﻿using System;
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
            var ret = dc.GetTable<ProductInventoryItem>().SingleOrDefault(item => item.ID == id);
            if (ret != null)
            {
                ret.Product = new ProductProvider(ConnectStr, _MappingResource).GetByID(ret.ProductID).QueryObject;
                ret.WareHouse = new WareHouseProvider(ConnectStr, _MappingResource).GetByID(ret.WareHouseID).QueryObject;
            }
            return ret.Product != null && ret.WareHouse != null ? ret : null;
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
                if (con.OrderItem != null) ret = ret.Where(item => item.OrderItem == con.OrderItem);
                if (!string.IsNullOrEmpty(con.OrderID)) ret = ret.Where(item => item.OrderID == con.OrderID);
                if (con.PurchaseItem != null) ret = ret.Where(item => item.PurchaseItem == con.PurchaseItem);
                if (!string.IsNullOrEmpty(con.PurchaseID)) ret = ret.Where(item => item.PurchaseID == con.PurchaseID);
                if (con.InventoryItem != null) ret = ret.Where(item => item.InventoryItem == con.InventoryItem);
                if (!string.IsNullOrEmpty(con.InventorySheetNo)) ret = ret.Where(item => item.InventorySheet == con.InventorySheetNo);
                if (con.DeliveryItem != null) ret = ret.Where(item => item.DeliveryItem == con.DeliveryItem);
                if (!string.IsNullOrEmpty(con.DeliverySheetNo)) ret = ret.Where(item => item.DeliverySheet == con.DeliverySheetNo);
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
                        ret = ret.Where(item => item.OrderItem != null);
                    }
                }
            }
            var items = ret.ToList();
            if (items != null && items.Count > 0)
            {
                List<Product> ps = (new ProductProvider(ConnectStr, _MappingResource)).GetItems(null).QueryObjects;
                List<WareHouse> ws = (new WareHouseProvider(ConnectStr, _MappingResource)).GetItems(null).QueryObjects;
                foreach (ProductInventoryItem pi in items)
                {
                    pi.Product = ps.SingleOrDefault(p => p.ID == pi.ProductID);
                    pi.WareHouse = ws.SingleOrDefault(w => w.ID == pi.WareHouseID);
                }
            }
            return items.Where(it => it.Product != null && it.WareHouse != null).ToList();
        }
        #endregion
    }
}

