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
    public class OrderItemRecordProvider : ProviderBase<OrderItemRecord, Guid>
    {
        #region 构造函数
        public OrderItemRecordProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr,ms)
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
            if (search is SheetSearchCondition)
            {
                SheetSearchCondition con = search as SheetSearchCondition;
                if (con.LastActiveDate != null) ret = ret.Where(item => item.LastActiveDate >= con.LastActiveDate.Begin && item.LastActiveDate <= con.LastActiveDate.End);
                if (con.SheetNo != null && con.SheetNo.Count > 0) ret = ret.Where(item => con.SheetNo.Contains(item.SheetNo));
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains(item.State));
            }
            if (search is OrderSearchCondition)
            {
                OrderSearchCondition con = search as OrderSearchCondition;
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.CustomerID == con.CustomerID);
                if (!string.IsNullOrEmpty(con.Sales)) ret = ret.Where(item => item.SalesPerson == con.Sales);
                if (con.OrderDate != null) ret = ret.Where(item => item.OrderDate >= con.OrderDate.Begin && item.OrderDate <= con.OrderDate.End);
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
            if (search is OrderItemRecordSearchCondition)
            {
                OrderItemRecordSearchCondition con = search as OrderItemRecordSearchCondition;
                if (!string.IsNullOrEmpty(con.ProductID)) ret = ret.Where(item => item.ProductID == con.ProductID);
                if (!string.IsNullOrEmpty(con.CategoryID)) ret = ret.Where(item => item.Product.CategoryID == con.CategoryID);
            }
            List<OrderItemRecord> items = ret.ToList();
            if (search is OrderItemRecordSearchCondition) //从数据库获取回来数据后再筛选
            {
                OrderItemRecordSearchCondition con = search as OrderItemRecordSearchCondition;
                if (con.HasToDelivery != null)
                {
                    if (con.HasToDelivery.Value) items = items.Where(item => item.NotShipped > 0).ToList();
                    else items = items.Where(item => item.IsComplete || item.NotShipped == 0).ToList();
                }
                if (con.HasToPurchase != null)
                {
                    if (con.HasToPurchase.Value) items = items.Where(item => item.NotPurchased > 0).ToList();
                    else items = items.Where(item => item.NotPurchased == 0).ToList();
                }
            }
            return items;
        }
        #endregion
    }
}