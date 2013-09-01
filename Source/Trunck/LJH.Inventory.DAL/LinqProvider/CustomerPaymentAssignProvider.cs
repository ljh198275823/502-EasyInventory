using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory .BusinessModel .SearchCondition ;
using LJH.Inventory .DAL .IProvider ;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class CustomerPaymentAssignProvider:ProviderBase <CustomerPaymentAssign ,long>,ICustomerPaymentAssignProvider
    {
        #region 构造函数
        public CustomerPaymentAssignProvider(string connStr)
            : base(connStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override CustomerPaymentAssign GetingItemByID(long id, System.Data.Linq.DataContext dc)
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

        protected override void InsertingItem(CustomerPaymentAssign info, System.Data.Linq.DataContext dc)
        {
            dc.GetTable<T_CustomerPaymentAssign>().InsertOnSubmit(new T_CustomerPaymentAssign(info));
        }

        protected override void UpdatingItem(CustomerPaymentAssign newVal, CustomerPaymentAssign original, System.Data.Linq.DataContext dc)
        {
            dc.GetTable<T_CustomerPaymentAssign>().Attach(new T_CustomerPaymentAssign(newVal), new T_CustomerPaymentAssign(original));
        }

        protected override void DeletingItem(CustomerPaymentAssign info, System.Data.Linq.DataContext dc)
        {
            T_CustomerPaymentAssign tcpa = new T_CustomerPaymentAssign(info);
            dc.GetTable<T_CustomerPaymentAssign>().Attach(tcpa);
            dc.GetTable<T_CustomerPaymentAssign>().DeleteOnSubmit(tcpa);
        }
        #endregion
    }
}
