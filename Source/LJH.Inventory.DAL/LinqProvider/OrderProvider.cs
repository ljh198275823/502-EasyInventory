using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class OrderProvider : ProviderBase<Order, string>
    {
        #region 构造函数
        public OrderProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr,ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override Order GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<Order>(item => item.Items);
            dc.LoadOptions = opt;
            Order sheet = dc.GetTable<Order>().SingleOrDefault(item => item.ID == id);
            return sheet;
        }

        protected override List<Order> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<Order>(item => item.Items);
            dc.LoadOptions = opt;
            IQueryable<Order> ret = dc.GetTable<Order>();
            if (search is SheetSearchCondition)
            {
                SheetSearchCondition con = search as SheetSearchCondition;
                if (con.SheetDate != null) ret = ret.Where(item => item.SheetDate >= con.SheetDate.Begin && item.SheetDate <= con.SheetDate.End);
                if (con.LastActiveDate != null) ret = ret.Where(item => item.LastActiveDate >= con.LastActiveDate.Begin && item.LastActiveDate <= con.LastActiveDate.End);
                if (con.SheetIDs != null && con.SheetIDs.Count > 0) ret = ret.Where(item => con.SheetIDs.Contains(item.ID));
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains(item.State));
            }
            if (search is OrderSearchCondition)
            {
                OrderSearchCondition con = search as OrderSearchCondition;
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.CustomerID == con.CustomerID);
                if (!string.IsNullOrEmpty(con.Sales)) ret = ret.Where(item => item.SalesPerson == con.Sales);
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
            List<Order> sheets = ret.ToList();
            return sheets;
        }

        protected override void UpdatingItem(Order newVal, Order original, System.Data.Linq.DataContext dc)
        {
            dc.GetTable<Order>().Attach(newVal, original);
            foreach (OrderItem item in newVal.Items)
            {
                OrderItem old = original.Items.SingleOrDefault(it => it.ID == item.ID);
                if (old != null)
                {
                    dc.GetTable<OrderItem>().Attach(item, old);
                }
                else
                {
                    item.OrderID = newVal.ID;
                    dc.GetTable<OrderItem>().InsertOnSubmit(item);
                }
            }
            foreach (OrderItem item in original.Items)
            {
                if (newVal.Items.SingleOrDefault(it => it.ID == item.ID) == null)
                {
                    dc.GetTable<OrderItem>().Attach(item);
                    dc.GetTable<OrderItem>().DeleteOnSubmit(item);
                }
            }
        }
        #endregion
    }
}
