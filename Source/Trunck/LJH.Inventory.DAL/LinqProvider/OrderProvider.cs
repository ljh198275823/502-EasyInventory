using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class OrderProvider : ProviderBase<Order, string>, IOrderProvider
    {
        #region 构造函数
        public OrderProvider(string connStr)
            : base(connStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override Order GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<Order>(order => order.Customer);
            opt.LoadWith<Order>(order => order.Items);
            opt.LoadWith<OrderItem>(oi => oi.Product);
            opt.LoadWith<Product>(p => p.Category);
            dc.LoadOptions = opt;
            Order ord = dc.GetTable<Order>().SingleOrDefault(item => item.ID == id);
            return ord;
        }

        protected override List<Order> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<Order>(order => order.Customer);
            opt.LoadWith<Order>(order => order.Items);
            opt.LoadWith<OrderItem>(oi => oi.Product);
            opt.LoadWith<Product>(p => p.Category);
            dc.LoadOptions = opt;
            IQueryable<Order> ret = dc.GetTable<Order>();
            if (search is OrderSearchCondition)
            {
                OrderSearchCondition con = search as OrderSearchCondition;
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.CustomerID == con.CustomerID);
                if (con.OrderDate != null) ret = ret.Where(item => item.OrderDate >= con.OrderDate.Begin && item.OrderDate <= con.OrderDate.End);
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains(item.State));
                if (!string.IsNullOrEmpty(con.Sales)) ret = ret.Where(item => item.SalesPerson.Contains(con.Sales));
                if (con.WithTax != null)
                {
                    if (con.WithTax.Value)
                    {
                        ret = ret.Where(item => item.WithTax == true);
                    }
                    else
                    {
                        ret = ret.Where(item => item.WithTax == false);
                    }
                }
            }
            List<Order> orders = ret.ToList();
            //if (search is OrderSearchCondition && orders != null && orders.Count > 0)
            //{
            //    OrderSearchCondition con = search as OrderSearchCondition;
            //    if (con.HasNotPaid != null)
            //    {
            //        if (con.HasNotPaid.Value) orders = orders.Where(item => (item.CalAmount() - item.HasPaid) > 0).ToList();
            //        else orders = orders.Where(item => (item.CalAmount() - item.HasPaid) <= 0).ToList();
            //    }
            //}
            return orders;
        }

        protected override void InsertingItem(LJH.Inventory.BusinessModel.Order info, System.Data.Linq.DataContext dc)
        {
            dc.GetTable<T_Order>().InsertOnSubmit(new T_Order(info));
            foreach (OrderItem item in info.Items)
            {
                item.OrderID = info.ID;
                dc.GetTable<T_OrderItem>().InsertOnSubmit(new T_OrderItem(item));
            }
        }

        protected override void UpdatingItem(Order newVal, Order original, System.Data.Linq.DataContext dc)
        {
            dc.GetTable<T_Order>().Attach(new T_Order(newVal), new T_Order(original));
            foreach (OrderItem item in newVal.Items)
            {
                OrderItem old = original.Items.SingleOrDefault(it => it.ID == item.ID);
                if (old != null)
                {
                    dc.GetTable<T_OrderItem>().Attach(new T_OrderItem(item), new T_OrderItem(old));
                }
                else
                {
                    item.OrderID = newVal.ID;
                    dc.GetTable<T_OrderItem>().InsertOnSubmit(new T_OrderItem(item));
                }
            }
            foreach (OrderItem item in original.Items)
            {
                if (newVal.Items.SingleOrDefault(it => it.ID == item.ID) == null)
                {
                    T_OrderItem to = new T_OrderItem(item);
                    dc.GetTable<T_OrderItem>().Attach(to);
                    dc.GetTable<T_OrderItem>().DeleteOnSubmit(to);
                }
            }
        }

        protected override void DeletingItem(Order info, System.Data.Linq.DataContext dc)
        {
            T_Order t = new T_Order(info);
            dc.GetTable<T_Order>().Attach(t);
            dc.GetTable<T_Order>().DeleteOnSubmit(t);
            foreach (OrderItem item in info.Items)
            {
                T_OrderItem to = new T_OrderItem(item);
                dc.GetTable<T_OrderItem>().Attach(to);
                dc.GetTable<T_OrderItem>().DeleteOnSubmit(to);
            }
        }
        #endregion
    }
}
