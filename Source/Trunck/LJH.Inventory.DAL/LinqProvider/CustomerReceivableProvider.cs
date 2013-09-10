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
                if (!string.IsNullOrEmpty (con.CustomerID )) ret = ret.Where(item => item.CustomerID == con.CustomerID);
                if (!string.IsNullOrEmpty(con.OrderID)) ret = ret.Where(item => item.OrderID == con.OrderID);
                if (!string.IsNullOrEmpty(con.DeliverySheet)) ret = ret.Where(item => item.DeliverySheet == con.DeliverySheet);
            }
            return ret.ToList();
        }
        #endregion
    }
}
