using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class ProductInventoryProvider : ProviderBase<ProductInventory, Guid >, IProductInventoryProvider
    {
        #region 构造函数
        public ProductInventoryProvider(string connStr)
            : base(connStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override ProductInventory GetingItemByID(Guid  id, System.Data.Linq.DataContext dc)
        {
            ProductInventory pi = dc.GetTable<ProductInventory>().SingleOrDefault(item => item.ID ==id);
            if (pi != null)
            {
                pi.Product = dc.GetTable<Product>().SingleOrDefault(p => p.ID == pi.ProductID);
                pi.WareHouse = dc.GetTable<WareHouse>().SingleOrDefault(w => w.ID == pi.WareHouseID);
            }
            return pi;
        }

        protected override List<ProductInventory> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<ProductInventory> ret = dc.GetTable<ProductInventory>();
            if (search is ProductInventorySearchCondition)
            {
                ProductInventorySearchCondition con = search as ProductInventorySearchCondition;
                if (!string.IsNullOrEmpty(con.WareHouseID)) ret = ret.Where(item => item.WareHouseID.Contains(con.WareHouseID));
                if (!string.IsNullOrEmpty(con.ProductID)) ret = ret.Where(item => item.ProductID.Contains(con.ProductID));
            }
            List<ProductInventory> items = ret.ToList();
            if (items != null && items.Count > 0)
            {
                List<Product> ps = (new ProductProvider(ConnectStr)).GetItems(null).QueryObjects;
                List<WareHouse> ws = (new WareHouseProvider(ConnectStr)).GetItems(null).QueryObjects;
                foreach (ProductInventory pi in items)
                {
                    pi.Product = ps.SingleOrDefault(p => p.ID == pi.ProductID);
                    pi.WareHouse = ws.SingleOrDefault(w => w.ID == pi.WareHouseID);
                }
            }
            return items;
        }
        #endregion
    }
}