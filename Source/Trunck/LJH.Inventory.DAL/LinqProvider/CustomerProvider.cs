using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using LJH.Inventory .DAL .IProvider ;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory.BusinessModel.SearchCondition;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class CustomerProvider : ProviderBase<Customer, string>, ICustomerProvider
    {
        #region 构造函数
        public CustomerProvider(string conStr)
            : base(conStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override Customer GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            Customer c = dc.GetTable<Customer>().SingleOrDefault(item => item.ID == id);
            return c;
        }

        protected override List<Customer> GetingItems(System.Data.Linq.DataContext dc, BusinessModel.SearchCondition.SearchCondition search)
        {
            IQueryable<Customer> ret = dc.GetTable<Customer>();
            if (search is CustomerSearchCondition)
            {
                CustomerSearchCondition con = search as CustomerSearchCondition;
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.ID.Contains(con.CustomerID));
                if (con.ClassID != null) ret = ret.Where(item => item.ClassID == con.ClassID.Value);
            }
            List<Customer> cs = ret.ToList();
            return cs;
        }
        #endregion
    }
}
