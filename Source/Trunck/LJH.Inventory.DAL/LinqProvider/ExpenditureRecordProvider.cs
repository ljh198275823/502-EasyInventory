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
            if (search is ExpenditureRecordSearchCondition)
            {
                ExpenditureRecordSearchCondition con = search as ExpenditureRecordSearchCondition;
                if (con.PaidDate != null) ret = ret.Where(item => item.LastActiveDate >= con.PaidDate.Begin && item.LastActiveDate <= con.PaidDate.End);
                if (!string.IsNullOrEmpty(con.Category)) ret = ret.Where(item => item.Category.Contains(con.Category));
                if (!string.IsNullOrEmpty(con.Memo)) ret = ret.Where(item => item.Memo.Contains(con.Memo));
            }
            return ret.ToList();
        }
        #endregion
    }
}
