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

        protected override List<Account> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<Account> ret = dc.GetTable<Account>();
            if (search is AccountSearchCondition)
            {
                var con = search as AccountSearchCondition;
                if (con.IsPublic.HasValue)
                {
                    if (con.IsPublic.Value) ret = ret.Where(it => it.Ispublic == true);
                    else ret = ret.Where(it => it.Ispublic == false);
                }
                if (con.AccountTypes != null && con.AccountTypes.Count > 0) ret = ret.Where(it => con.AccountTypes.Contains(it.Class));
            }
            return ret.ToList();
        }
        #endregion
    }
}
