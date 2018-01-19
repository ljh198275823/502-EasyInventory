﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class SteelRollSliceRecordProvider : ProviderBase<SteelRollSliceRecord, Guid>
    {
        #region 构造函数
        public SteelRollSliceRecordProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override SteelRollSliceRecord GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            var ret = (from r in dc.GetTable<SteelRollSliceRecord>()
                       join p in dc.GetTable<ProductInventoryItem>() on r.SliceSource equals p.ID
                       select new { A = r, B = p.OriginalWeight }).SingleOrDefault(it => it.A.ID == id);
            if (ret != null) ret.A.SourceRollWeight = ret.B;
            return ret.A;
        }

        protected override List<SteelRollSliceRecord> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            var ret = from r in dc.GetTable<SteelRollSliceRecord>()
                      join p in dc.GetTable<ProductInventoryItem>() on r.SliceSource equals p.ID
                      select new { A = r, B = p.OriginalWeight };
            if (search is SliceRecordSearchCondition)
            {
                SliceRecordSearchCondition con = search as SliceRecordSearchCondition;
                if (con.SliceDate != null) ret = ret.Where(item => item.A.SliceDate >= con.SliceDate.Begin && item.A.SliceDate <= con.SliceDate.End);
                if (con.SourceRoll != null) ret = ret.Where(item => item.A.SliceSource == con.SourceRoll.Value);
                if (!string.IsNullOrEmpty(con.SliceType)) ret = ret.Where(item => item.A.SliceType == con.SliceType);
                if (!string.IsNullOrEmpty(con.Customer)) ret = ret.Where(it => it.A.Customer == con.Customer);
                if (!string.IsNullOrEmpty(con.Warehouse)) ret = ret.Where(it => it.A.Warehouse == con.Warehouse);
            }
            var items = ret.ToList();
            if (items != null && items.Count > 0)
            {
                items.ForEach(it => it.A.SourceRollWeight = it.B);
                return items.Select(it => it.A).ToList();
            }
            return new List<SteelRollSliceRecord>();
        }
        #endregion
    }
}
