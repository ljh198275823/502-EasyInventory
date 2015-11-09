using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class ProductInventoryProvider : ProviderBase<ProductInventory, Guid>
    {
        #region 构造函数
        public ProductInventoryProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override ProductInventory GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            throw new Exception("未实现此方法");
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
                List<Product> ps = (new ProductProvider(ConnectStr, _MappingResource)).GetItems(null).QueryObjects;
                List<WareHouse> ws = (new WareHouseProvider(ConnectStr, _MappingResource)).GetItems(null).QueryObjects;
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