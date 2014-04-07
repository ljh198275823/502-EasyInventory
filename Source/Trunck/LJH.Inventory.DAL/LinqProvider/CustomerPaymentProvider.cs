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
            DataLoadOptions opts = new DataLoadOptions();
            opts.LoadWith<CustomerPayment>(item => item.Assigns);
            dc.LoadOptions = opts;
            var ret = dc.GetTable<CustomerPayment>().SingleOrDefault(item => item.ID == id);
            return ret;
        }

        protected override List<CustomerPayment> GetingItems(System.Data.Linq.DataContext dc, BusinessModel.SearchCondition.SearchCondition search)
        {
            DataLoadOptions opts = new DataLoadOptions();
            opts.LoadWith<CustomerPayment>(item => item.Assigns);
            dc.LoadOptions = opts;
            IQueryable<CustomerPayment> ret = dc.GetTable<CustomerPayment>();
            if (search is CustomerPaymentSearchCondition)
            {
                CustomerPaymentSearchCondition con = search as CustomerPaymentSearchCondition;
                if (con.PaidDate != null) ret = ret.Where(item => item.PaidDate >= con.PaidDate.Begin && item.PaidDate <= con.PaidDate.End);
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.CustomerID == con.CustomerID);
                if (con.HasRemain != null)
                {
                    if (con.HasRemain.Value)
                    {
                        ret = ret.Where(item => item.Remain > 0);
                    }
                    else
                    {
                        ret = ret.Where(item => item.Remain == 0);
                    }
                }
            }
            return ret.ToList();
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
