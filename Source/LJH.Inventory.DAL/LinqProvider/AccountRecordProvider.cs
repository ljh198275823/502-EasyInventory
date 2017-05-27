using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class AccountRecordProvider : ProviderBase<AccountRecord, Guid>
    {
        #region 构造函数
        public AccountRecordProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override AccountRecord GetingItemByID(Guid id, DataContext dc)
        {
            return dc.GetTable<AccountRecord>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<AccountRecord> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<AccountRecord> ret = dc.GetTable<AccountRecord>();
            if (search is AccountRecordSearchCondition)
            {
                AccountRecordSearchCondition con = search as AccountRecordSearchCondition;
                if (con.CreateDate != null) ret = ret.Where(item => item.CreateDate >= con.CreateDate.Begin && item.CreateDate <= con.CreateDate.End);
                if (!string.IsNullOrEmpty(con.SheetID)) ret = ret.Where(it => it.SheetID == con.SheetID);
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.CustomerID == con.CustomerID);
                if (!string.IsNullOrEmpty(con.AccountID)) ret = ret.Where(item => item.AccountID == con.AccountID);
                if (!string.IsNullOrEmpty(con.StackSheetID)) ret = ret.Where(item => item.StackSheetID == con.StackSheetID);
                if (con.PaymentTypes != null && con.PaymentTypes.Count > 0) ret = ret.Where(item => con.PaymentTypes.Contains(item.ClassID));
                if (con.HasRemain != null)
                {
                    if (con.HasRemain.Value) ret = ret.Where(item => item.Assigned < item.Amount);
                    else ret = ret.Where(item => item.Assigned >= item.Amount);
                }
            }
            List<AccountRecord> sheets = ret.ToList();
            return sheets;
        }
        #endregion
    }
}
