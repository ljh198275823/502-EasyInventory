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
    public class OrderItemRecordProvider : ProviderBase<OrderItemRecord, Guid>, IOrderItemRecordProvider
    {
        #region 构造函数
        public OrderItemRecordProvider(string conStr)
            : base(conStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override OrderItemRecord GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<OrderItemRecord>(item => item.Customer);
            opt.LoadWith<OrderItemRecord>(item => item.Product);
            opt.LoadWith<Product>(item => item.Category);
            dc.LoadOptions = opt;
            return dc.GetTable<OrderItemRecord>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<OrderItemRecord> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<OrderItemRecord>(item => item.Customer);
            opt.LoadWith<OrderItemRecord>(item => item.Product);
            dc.LoadOptions = opt;
            IQueryable<OrderItemRecord> ret = dc.GetTable<OrderItemRecord>();
            if (search is OrderItemRecordSearchCondition)
            {
                OrderItemRecordSearchCondition con = search as OrderItemRecordSearchCondition;
                if (!string.IsNullOrEmpty(con.ProductID)) ret = ret.Where(item => item.ProductID == con.ProductID);
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.CustomerID == con.CustomerID);
                if (!string.IsNullOrEmpty(con.CategoryID)) ret = ret.Where(item => item.Product.CategoryID == con.CategoryID);
                if (!string.IsNullOrEmpty(con.OrderID)) ret = ret.Where(item => item.OrderID == con.OrderID);
                if (con.OrderDate != null)
                {
                    ret = ret.Where(item => item.OrderDate >= con.OrderDate.Begin && item.OrderDate <= con.OrderDate.End);
                }
            }
            List<OrderItemRecord> items = ret.ToList();
            return items;
        }
        #endregion
    }
}