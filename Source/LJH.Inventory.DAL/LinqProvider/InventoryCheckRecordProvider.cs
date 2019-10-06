using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class InventoryCheckRecordProvider : ProviderBase<InventoryCheckRecord, Guid>
    {
        #region 构造函数
        public InventoryCheckRecordProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override InventoryCheckRecord GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<InventoryCheckRecord>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<InventoryCheckRecord> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<InventoryCheckRecord> ret = dc.GetTable<InventoryCheckRecord>();
            if (search != null && search is InventoryCheckRecordSearchCondition)
            {
                var con = search as InventoryCheckRecordSearchCondition;
                if (con.CheckDate != null) ret = ret.Where(it => it.CheckDateTime >= con.CheckDate.Begin && it.CheckDateTime <= con.CheckDate.End);
                if (!string.IsNullOrEmpty(con.ProductID)) ret = ret.Where(it => it.ProductID == con.ProductID);
                if (con.ProductIDs != null && con.ProductIDs.Count > 0) ret = ret.Where(item => con.ProductIDs.Contains(item.ProductID));
                if (!string.IsNullOrEmpty(con.WareHouseID)) ret = ret.Where(it => it.WarehouseID == con.WareHouseID);
                if (con.SourceID.HasValue) ret =  ret.Where(it => it.SourceID == con.SourceID.Value);
            }
            var items = ret.ToList();
            if (items != null && items.Count > 0)
            {
                List<Product> ps = null;
                var pids = items.Select(it => it.ProductID).Distinct().ToList();
                if (pids.Count > 20)
                {
                    ps = new ProductProvider(SqlURI, _MappingResource).GetItems(null).QueryObjects;
                }
                else
                {
                    ProductSearchCondition pcon = new ProductSearchCondition();
                    pcon.ProductIDS = pids;
                    ps = new ProductProvider(SqlURI, _MappingResource).GetItems(pcon).QueryObjects;
                }
                List<WareHouse> ws = new WareHouseProvider(SqlURI, _MappingResource).GetItems(null).QueryObjects;
                foreach (var pi in items)
                {
                    pi.Product = ps.SingleOrDefault(it => it.ID == pi.ProductID);
                    pi.WareHouse = ws.SingleOrDefault(it => it.ID == pi.WarehouseID);
                }
                items.RemoveAll(it => it.Product == null || it.WareHouse == null);
            }
            return items;
        }
        #endregion
    }
}
