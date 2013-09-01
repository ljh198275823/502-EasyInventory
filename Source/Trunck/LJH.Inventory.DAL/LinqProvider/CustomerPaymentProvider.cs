using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel.SearchCondition;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class CustomerPaymentProvider : ProviderBase<CustomerPayment, string>, ICustomerPaymentProvider
    {
        #region 构造函数
        public CustomerPaymentProvider(string connStr)
            : base(connStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override CustomerPayment GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            var ret = (from cp in dc.GetTable<CustomerPayment>()
                       join c in dc.GetTable<Customer>()
                       on cp.CustomerID equals c.ID
                       select new { v1 = cp, v2 = c }).SingleOrDefault(item => item.v1.ID == id);
            if (ret != null)
            {
                ret.v1.Customer = ret.v2;
                return ret.v1;
            }
            return null;
        }

        protected override List<CustomerPayment> GetingItems(System.Data.Linq.DataContext dc, BusinessModel.SearchCondition.SearchCondition search)
        {
            var ret = from cp in dc.GetTable<CustomerPayment>()
                      join c in dc.GetTable<Customer>()
                      on cp.CustomerID equals c.ID
                      select new { v1 = cp, v2 = c };
            if (search is CustomerPaymentSearchCondition)
            {
                CustomerPaymentSearchCondition con = search as CustomerPaymentSearchCondition;
                if (con.PaidDate != null) ret = ret.Where(item => item.v1.PaidDate >= con.PaidDate.Begin && item.v1.PaidDate <= con.PaidDate.End);
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.v2.ID == con.CustomerID);
                if (!string.IsNullOrEmpty(con.CustomerName)) ret = ret.Where(item => item.v2.Name.Contains(con.CustomerName));
                if (con.HasRemain != null)
                {
                    if (con.HasRemain.Value)
                    {
                        ret = ret.Where(item => item.v1.Remain > 0);
                    }
                    else
                    {
                        ret = ret.Where(item => item.v1.Remain == 0);
                    }
                }
                if (!con.ContainCanceled) ret = ret.Where(item => item.v1.CancelDate == null);
            }
            List<CustomerPayment> items = new List<CustomerPayment>();
            foreach (var item in ret)
            {
                item.v1.Customer = item.v2;
                items.Add(item.v1);
            }
            return items;
        }

        protected override void InsertingItem(CustomerPayment info, DataContext dc)
        {
            T_CustomerPayment tcp = new T_CustomerPayment(info);
            dc.GetTable<T_CustomerPayment>().InsertOnSubmit(tcp);
        }

        protected override void UpdatingItem(CustomerPayment newVal, CustomerPayment original, DataContext dc)
        {
            dc.GetTable<T_CustomerPayment>().Attach(new T_CustomerPayment(newVal), new T_CustomerPayment(original));
        }

        protected override void DeletingItem(CustomerPayment info, DataContext dc)
        {
            T_CustomerPayment tcp = new T_CustomerPayment(info);
            dc.GetTable<T_CustomerPayment>().Attach(tcp);
            dc.GetTable<T_CustomerPayment>().DeleteOnSubmit(tcp);
        }
        #endregion
    }
}
