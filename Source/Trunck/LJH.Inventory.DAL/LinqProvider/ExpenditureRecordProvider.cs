using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class ExpenditureRecordProvider : ProviderBase<ExpenditureRecord, string>
    {
        #region 构造函数
        public ExpenditureRecordProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override List<ExpenditureRecord> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<ExpenditureRecord> ret = dc.GetTable<ExpenditureRecord>();
            if (search is SheetSearchCondition)
            {
                SheetSearchCondition con = search as SheetSearchCondition;
                if (con.LastActiveDate != null) ret = ret.Where(item => item.LastActiveDate >= con.LastActiveDate.Begin && item.LastActiveDate <= con.LastActiveDate.End);
                if (con.SheetNo != null && con.SheetNo.Count > 0) ret = ret.Where(item => con.SheetNo.Contains(item.ID));
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains(item.State));
            }
            if (search is ExpenditureRecordSearchCondition)
            {
                ExpenditureRecordSearchCondition con = search as ExpenditureRecordSearchCondition;
                if (!string.IsNullOrEmpty(con.Category)) ret = ret.Where(item => item.Category.Contains(con.Category));
            }
            return ret.ToList();
        }
        #endregion
    }
}
