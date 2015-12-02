﻿using System;
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
                if (!string.IsNullOrEmpty(con.ProductID)) ret = ret.Where(it => it.ProductID == con.ProductID);
                if (!string.IsNullOrEmpty(con.WareHouseID)) ret = ret.Where(it => it.WarehouseID == con.WareHouseID);
                if (con.SourceID.HasValue) ret =  ret.Where(it => it.SourceID == con.SourceID.Value);
            }
            return ret.ToList();
        }
        #endregion
    }
}
