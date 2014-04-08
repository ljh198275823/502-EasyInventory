using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class CustomerFinancialStateProvider : ProviderBase<CustomerFinancialState, string>, ICustomerFinancialStateProvider
    {
        #region 构造函数
        public CustomerFinancialStateProvider(string connStr)
            : base(connStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override CustomerFinancialState GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<CustomerFinancialState>().SingleOrDefault(item => item.CustomerID == id);
        }
        #endregion
    }
}