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
            Account ac = dc.GetTable<Account>().SingleOrDefault(item => item.ID == id);
            if (ac != null) //计算余额，所有记录的收入项减支出项
            {
                dc.Log = Console.Out;
                var ru = (from it in dc.GetTable<AccountRecord>()
                          where it.AccountID == ac.ID && (it.ClassID == CustomerPaymentType.客户收款 || it.ClassID == CustomerPaymentType.其它收款 || it.ClassID == CustomerPaymentType.转账入 || it.ClassID == CustomerPaymentType.供应商退款)
                          group it by it.AccountID into g
                          select new { AccountID = g.Key, Amount = g.Sum(it => it.Amount) }).ToList();
                if (ru != null && ru.Count > 0) ac.Amount += ru.Sum(it => it.AccountID == ac.ID ? it.Amount : 0);
                var ch = (from it in dc.GetTable<AccountRecord>()
                          where it.AccountID == ac.ID && (it.ClassID == CustomerPaymentType.供应商付款 || it.ClassID == CustomerPaymentType.公司管理费用 || it.ClassID == CustomerPaymentType.转账出 || it.ClassID == CustomerPaymentType.客户退款)
                          group it by it.AccountID into g
                          select new { AccountID = g.Key, Amount = g.Sum(it => it.Amount) }).ToList();
                if (ch != null && ch.Count > 0) ac.Amount -= ch.Sum(it => it.AccountID == ac.ID ? it.Amount : 0);
            }
            return ac;
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
            var items = ret.ToList();
            if (items != null && items.Count > 0) //计算余额，所有记录的收入项减支出项
            {
                var ru = (from it in dc.GetTable<AccountRecord>()
                          where it.ClassID == CustomerPaymentType.客户收款 || it.ClassID == CustomerPaymentType.其它收款 || it.ClassID == CustomerPaymentType.转账入 || it.ClassID == CustomerPaymentType.供应商退款
                          group it by it.AccountID into g
                          select new { AccountID = g.Key, Amount = g.Sum(it => it.Amount) }).ToList();
                if (ru != null && ru.Count > 0)
                {
                    foreach (var ac in items)
                    {
                        ac.Amount += ru.Sum(it => it.AccountID == ac.ID ? it.Amount : 0);
                    }
                }
                var ch = (from it in dc.GetTable<AccountRecord>()
                          where it.ClassID == CustomerPaymentType.供应商付款 || it.ClassID == CustomerPaymentType.公司管理费用 || it.ClassID == CustomerPaymentType.转账出 || it.ClassID == CustomerPaymentType.客户退款
                          group it by it.AccountID into g
                          select new { AccountID = g.Key, Amount = g.Sum(it => it.Amount) }).ToList();
                if (ch != null && ch.Count > 0)
                {
                    foreach (var ac in items)
                    {
                        ac.Amount -= ch.Sum(it => it.AccountID == ac.ID ? it.Amount : 0);
                    }
                }
            }
            return items;
        }
        #endregion
    }
}
