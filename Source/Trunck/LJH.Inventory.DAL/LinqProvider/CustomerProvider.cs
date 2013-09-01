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
            if (c != null && !string.IsNullOrEmpty(c.CategoryID))
            {
                c.Category = (new CustomerTypeProvider(ConnectStr)).GetByID(c.CategoryID).QueryObject;
            }
            return c;
        }

        protected override List<Customer> GetingItems(System.Data.Linq.DataContext dc, BusinessModel.SearchCondition.SearchCondition search)
        {
            IQueryable<Customer> ret = dc.GetTable<Customer>();
            if (search is CustomerSearchCondition)
            {
                CustomerSearchCondition con = search as CustomerSearchCondition;
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.ID.Contains(con.CustomerID));
                if (!string.IsNullOrEmpty(con.CustomerName)) ret = ret.Where(item => item.Name.Contains(con.CustomerName));
                if (!string.IsNullOrEmpty(con.TelPhone)) ret = ret.Where(item => item.TelPhone.Contains(con.TelPhone));
            }
            List<Customer> cs = ret.ToList();
            if (cs != null && cs.Count > 0)
            {
                List<CustomerType> cts = (new CustomerTypeProvider(ConnectStr)).GetItems(null).QueryObjects;
                foreach (Customer c in cs)
                {
                    c.Category = cts.SingleOrDefault(ct => ct.ID == c.CategoryID);
                }
            }
            return cs;
        }
        #endregion
    }
}
