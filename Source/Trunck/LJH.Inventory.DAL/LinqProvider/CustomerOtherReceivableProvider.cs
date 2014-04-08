using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class CustomerOtherReceivableProvider : ProviderBase<CustomerOtherReceivable, string>, ICustomerOtherReceivableProvider
    {
        #region 构造函数
        public CustomerOtherReceivableProvider(string connStr)
            : base(connStr)
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
            if (search is CustomerReceivableSearchCondition)
            {
                CustomerReceivableSearchCondition con = search as CustomerReceivableSearchCondition;
                if (con.CreateDate != null) ret = ret.Where(item => item.v1.CreateDate >= con.CreateDate.Begin && item.v1.CreateDate <= con.CreateDate.End);
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
