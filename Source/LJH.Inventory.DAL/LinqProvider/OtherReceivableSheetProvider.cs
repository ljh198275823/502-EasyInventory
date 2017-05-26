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
    public class OtherReceivableSheetProvider : ProviderBase<OtherReceivableSheet, string>
    {
        #region 构造函数
        public OtherReceivableSheetProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override OtherReceivableSheet GetingItemByID(string id, DataContext dc)
        {
            return dc.GetTable<OtherReceivableSheet>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<OtherReceivableSheet> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<OtherReceivableSheet> ret = dc.GetTable<OtherReceivableSheet>();
            if (search is SheetSearchCondition)
            {
                SheetSearchCondition con = search as SheetSearchCondition;
                if (con.SheetDate != null) ret = ret.Where(item => item.SheetDate >= con.SheetDate.Begin && item.SheetDate <= con.SheetDate.End);
                if (con.LastActiveDate != null) ret = ret.Where(item => item.LastActiveDate >= con.LastActiveDate.Begin && item.LastActiveDate <= con.LastActiveDate.End);
                if (con.SheetIDs != null && con.SheetIDs.Count > 0) ret = ret.Where(item => con.SheetIDs.Contains(item.ID));
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains(item.State));
            }
            if (search is CustomerReceivableSearchCondition)
            {
                CustomerReceivableSearchCondition con = search as CustomerReceivableSearchCondition;
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.CustomerID == con.CustomerID);
            }
            List<OtherReceivableSheet> sheets = ret.ToList();
            return sheets;
        }
        #endregion
    }
}
