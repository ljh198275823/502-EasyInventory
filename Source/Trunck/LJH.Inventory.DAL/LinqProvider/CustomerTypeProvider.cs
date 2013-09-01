using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class CustomerTypeProvider : ProviderBase<CustomerType, string>, ICustomerTypeProvider
    {
        #region 构造函数
        public CustomerTypeProvider(string connStr)
            : base(connStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override CustomerType GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<CustomerType>().SingleOrDefault(item => item.ID == id);
        }
        #endregion
    }
}
