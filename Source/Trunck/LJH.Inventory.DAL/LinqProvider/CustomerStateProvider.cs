using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class CustomerStateProvider : ProviderBase<CustomerState, string>, ICustomerStateProvider
    {
        #region 构造函数
        public CustomerStateProvider(string connStr)
            : base(connStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override CustomerState GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<CustomerState>().SingleOrDefault(item => item.CustomerID == id);
        }
        #endregion
    }
}