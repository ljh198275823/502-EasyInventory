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
            var ret = (from cp in dc.GetTable<CustomerOtherReceivable>()
                       join c in dc.GetTable<CompanyInfo>()
                       on cp.CustomerID equals c.ID
                       select new { v1 = cp, v2 = c }).SingleOrDefault(item => item.v1.ID == id);
            if (ret != null)
            {
                ret.v1.Customer = ret.v2;
                return ret.v1;
            }
            return null;
        }

        protected override List<CustomerOtherReceivable> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            var ret = from cp in dc.GetTable<CustomerOtherReceivable>()
                      join c in dc.GetTable<CompanyInfo>()
                      on cp.CustomerID equals c.ID
                      select new { v1 = cp, v2 = c };
            if (search is SheetSearchCondition)
            {
                SheetSearchCondition con = search as SheetSearchCondition;
                if (con.LastActiveDate != null) ret = ret.Where(item => item.v1.LastActiveDate >= con.LastActiveDate.Begin && item.v1.LastActiveDate <= con.LastActiveDate.End);
                if (con.SheetNo != null && con.SheetNo.Count > 0) ret = ret.Where(item => con.SheetNo.Contains(item.v1.ID));
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains(item.v1.State));
            }
            if (search is CustomerReceivableSearchCondition)
            {
                CustomerReceivableSearchCondition con = search as CustomerReceivableSearchCondition;
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.v1.CustomerID == con.CustomerID);
            }
            List<CustomerOtherReceivable> items = new List<CustomerOtherReceivable>();
            foreach (var item in ret)
            {
                item.v1.Customer = item.v2;
                items.Add(item.v1);
            }
            return items;
        }
        #endregion
    }
}
