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
    public class CustomerOtherReceivableProvider : ProviderBase<CustomerOtherReceivable, string>
    {
        #region 构造函数
        public CustomerOtherReceivableProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override CustomerOtherReceivable GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<CustomerOtherReceivable>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<CustomerOtherReceivable> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<CustomerOtherReceivable> ret = dc.GetTable<CustomerOtherReceivable>();
            if (search is SheetSearchCondition)
            {
                SheetSearchCondition con = search as SheetSearchCondition;
                if (con.SheetDate != null) ret = ret.Where(item => item.SheetDate >= con.SheetDate.Begin && item.SheetDate <= con.SheetDate.End);
                if (con.LastActiveDate != null) ret = ret.Where(item => item.LastActiveDate >= con.LastActiveDate.Begin && item.LastActiveDate <= con.LastActiveDate.End);
                if (con.SheetNo != null && con.SheetNo.Count > 0) ret = ret.Where(item => con.SheetNo.Contains(item.ID));
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains(item.State));
            }
            if (search is CustomerReceivableSearchCondition)
            {
                CustomerReceivableSearchCondition con = search as CustomerReceivableSearchCondition;
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.CustomerID == con.CustomerID);
            }
            List<CustomerOtherReceivable> items = ret.ToList();
            return items;
        }
        #endregion
    }
}
