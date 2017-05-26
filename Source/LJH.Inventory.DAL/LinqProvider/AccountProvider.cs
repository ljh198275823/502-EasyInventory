using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class AccountProvider : ProviderBase<Account, string>
    {
        #region 构造函数
        public AccountProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override Account GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            Account c = dc.GetTable<Account>().SingleOrDefault(item => item.ID == id);
            return c;
        }
        #endregion
    }
}
