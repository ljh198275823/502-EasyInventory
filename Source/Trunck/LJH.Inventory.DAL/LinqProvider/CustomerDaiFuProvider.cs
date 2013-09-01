using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class CustomerDaiFuProvider : ProviderBase<CustomerDaiFu, string>, ICustomerDaiFuProvider
    {
        #region 构造函数
        public CustomerDaiFuProvider(string connStr)
            : base(connStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override CustomerDaiFu GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            var ret = (from cp in dc.GetTable<CustomerDaiFu>()
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

        protected override List<CustomerDaiFu> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            var ret = from cp in dc.GetTable<CustomerDaiFu>()
                      join c in dc.GetTable<Customer>()
                      on cp.CustomerID equals c.ID
                      select new { v1 = cp, v2 = c };
            if (search is CustomerReceivableSearchCondition)
            {
                CustomerReceivableSearchCondition con = search as CustomerReceivableSearchCondition;
                if (con.CreateDate != null) ret = ret.Where(item => item.v1.DaiFuDate >= con.CreateDate.Begin && item.v1.DaiFuDate <= con.CreateDate.End);
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.v1.CustomerID == con.CustomerID);
                if (!string.IsNullOrEmpty(con.CustomerName)) ret = ret.Where(item => item.v2.Name.Contains(con.CustomerName));
                if (con.IsSettled != null)
                {
                    if (con.IsSettled.Value)
                    {
                        ret = ret.Where(item => item.v1.Amount - item.v1.Paid == 0);
                    }
                    else
                    {
                        ret = ret.Where(item => item.v1.Amount - item.v1.Paid > 0);
                    }
                }
                if (!string.IsNullOrEmpty(con.Memo)) ret = ret.Where(item => item.v1.Memo.Contains(con.Memo));
            }
            if (search is CustomerDaiFuSearchCondition)
            {
                CustomerDaiFuSearchCondition con = search as CustomerDaiFuSearchCondition;
                if (!con.ContainCanceled) ret = ret.Where(item => item.v1.CancelDate == null);
            }
            List<CustomerDaiFu> items = new List<CustomerDaiFu>();
            foreach (var item in ret)
            {
                item.v1.Customer = item.v2;
                items.Add(item.v1);
            }
            return items;
        }

        protected override void InsertingItem(LJH.Inventory.BusinessModel.CustomerDaiFu info, System.Data.Linq.DataContext dc)
        {
            dc.GetTable<T_CustomerDaiFu>().InsertOnSubmit(new T_CustomerDaiFu(info));
        }

        protected override void UpdatingItem(CustomerDaiFu newVal, CustomerDaiFu original, System.Data.Linq.DataContext dc)
        {
            dc.GetTable<T_CustomerDaiFu>().Attach(new T_CustomerDaiFu(newVal), new T_CustomerDaiFu(original));
        }

        protected override void DeletingItem(CustomerDaiFu info, System.Data.Linq.DataContext dc)
        {
            T_CustomerDaiFu tcd = new T_CustomerDaiFu(info);
            dc.GetTable<T_CustomerDaiFu>().Attach(tcd);
            dc.GetTable<T_CustomerDaiFu>().DeleteOnSubmit(tcd);
        }
        #endregion
    }
}
