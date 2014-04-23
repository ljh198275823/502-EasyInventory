using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory .BusinessModel .SearchCondition ;
using LJH.Inventory .DAL .IProvider ;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class CustomerPaymentAssignProvider : ProviderBase<CustomerPaymentAssign, Guid>
    {
        #region 构造函数
        public CustomerPaymentAssignProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 构造函数
        protected override CustomerPaymentAssign GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<CustomerPaymentAssign>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<CustomerPaymentAssign> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<CustomerPaymentAssign> ret = dc.GetTable<CustomerPaymentAssign>();
            if (search is CustomerPaymentAssignSearchCondition)
            {
                CustomerPaymentAssignSearchCondition con = search as CustomerPaymentAssignSearchCondition;
                if (!string.IsNullOrEmpty(con.PaymentID)) ret = ret.Where(item => item.PaymentID == con.PaymentID);
                if (!string.IsNullOrEmpty(con.ReceivableID)) ret = ret.Where(item => item.ReceivableID == con.ReceivableID);
            }
            return ret.ToList();
        }
        #endregion
    }
}
