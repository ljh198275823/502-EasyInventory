using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class CustomerReceivableProvider : ProviderBase<CustomerReceivable, Guid>, ICustomerReceivableProvider
    {
        #region 构造函数
        public CustomerReceivableProvider(string connStr)
            : base(connStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override CustomerReceivable GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<CustomerReceivable>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<CustomerReceivable> GetingItems(System.Data.Linq.DataContext dc, BusinessModel.SearchCondition.SearchCondition search)
        {
            IQueryable<CustomerReceivable> ret = dc.GetTable<CustomerReceivable>();
            if (search is CustomerReceivableSearchCondition)
            {
                CustomerReceivableSearchCondition con = search as CustomerReceivableSearchCondition;
                if (con.CreateDate != null) ret = ret.Where(item => item.CreateDate >= con.CreateDate.Begin && item.CreateDate <= con.CreateDate.End);
                if (con.CustomerID != null) ret = ret.Where(item => item.CustomerID == con.CustomerID);
            }
            return ret.ToList();
        }

        protected override void InsertingItem(CustomerReceivable info, System.Data.Linq.DataContext dc)
        {
            dc.GetTable<T_CustomerReceivable>().InsertOnSubmit(new T_CustomerReceivable(info));
        }

        protected override void UpdatingItem(CustomerReceivable newVal, CustomerReceivable original, System.Data.Linq.DataContext dc)
        {
            dc.GetTable<T_CustomerReceivable>().Attach(new T_CustomerReceivable(newVal), new T_CustomerReceivable(original));
        }

        protected override void DeletingItem(CustomerReceivable info, System.Data.Linq.DataContext dc)
        {
            T_CustomerReceivable tcr = new T_CustomerReceivable(info);
            dc.GetTable<T_CustomerReceivable>().Attach(tcr);
            dc.GetTable<T_CustomerReceivable>().DeleteOnSubmit(tcr);
        }
        #endregion
    }
}
