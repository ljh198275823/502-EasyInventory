using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory .BusinessModel .SearchCondition ;
using LJH.Inventory .DAL .IProvider ;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class AccountRecordAssignProvider : ProviderBase<AccountRecordAssign, Guid>
    {
        #region 构造函数
        public AccountRecordAssignProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 构造函数
        protected override AccountRecordAssign GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<AccountRecordAssign>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<AccountRecordAssign> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<AccountRecordAssign> ret = dc.GetTable<AccountRecordAssign>();
            if (search is AccountRecordAssignSearchCondition)
            {
                AccountRecordAssignSearchCondition con = search as AccountRecordAssignSearchCondition;
                if (con.PaymentID.HasValue) ret = ret.Where(item => item.PaymentID == con.PaymentID);
                if (con.ReceivableID.HasValue) ret = ret.Where(it => it.ReceivableID == con.ReceivableID.Value);
            }
            return ret.ToList();
        }
        #endregion
    }
}
