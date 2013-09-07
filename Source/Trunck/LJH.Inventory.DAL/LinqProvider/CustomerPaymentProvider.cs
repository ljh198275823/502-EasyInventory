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
                        ret = ret.Where(item => item.v1.NotAssigned > 0);
                    }
                    else
                    {
                        ret = ret.Where(item => item.v1.NotAssigned == 0);
                    }
                }
            }
            List<CustomerPayment> items = new List<CustomerPayment>();
            foreach (var item in ret)
            {
                item.v1.Customer = item.v2;
                items.Add(item.v1);
            }
            return items;
        }

        protected override void UpdatingItem(CustomerPayment newVal, CustomerPayment original, DataContext dc)
        {
            dc.GetTable<CustomerPayment>().Attach(newVal, original);
            if (newVal.Assigns != null)
            {
                foreach (CustomerPaymentAssign item in newVal.Assigns)
                {
                    CustomerPaymentAssign old = original.Assigns != null ? original.Assigns.SingleOrDefault(it => it.ID == item.ID) : null;
                    if (old != null)
                    {
                        dc.GetTable<CustomerPaymentAssign>().Attach(item, old);
                    }
                    else
                    {
                        dc.GetTable<CustomerPaymentAssign>().InsertOnSubmit(item);
                    }
                }
            }
            if (original.Assigns != null)
            {
                foreach (CustomerPaymentAssign item in original.Assigns)
                {
                    if (newVal.Assigns == null || !newVal.Assigns.Exists(it => it.ID == item.ID))
                    {
                        dc.GetTable<CustomerPaymentAssign>().Attach(item);
                        dc.GetTable<CustomerPaymentAssign>().DeleteOnSubmit(item);
                    }
                }
            }
        }

        protected override void DeletingItem(CustomerPayment info, DataContext dc)
        {
            dc.GetTable<CustomerPayment>().Attach(info);
            dc.GetTable<CustomerPayment>().DeleteOnSubmit(info);
            if (info.Assigns != null)
            {
                foreach (CustomerPaymentAssign item in info.Assigns)
                {
                    dc.GetTable<CustomerPaymentAssign>().Attach(item);
                    dc.GetTable<CustomerPaymentAssign>().DeleteOnSubmit(item);
                }
            }
        }
        #endregion
    }
}
