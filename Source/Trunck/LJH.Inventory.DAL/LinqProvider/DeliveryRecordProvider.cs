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
    public class DeliveryRecordProvider : ProviderBase<DeliveryRecord, Guid>, IDeliveryRecordProvider
    {
        #region 构造函数
        public DeliveryRecordProvider(string conStr)
            : base(conStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override DeliveryRecord GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            throw new NotImplementedException();
        }

        protected override void InsertingItem(DeliveryRecord info, System.Data.Linq.DataContext dc)
        {
            throw new NotImplementedException();
        }

        protected override void UpdatingItem(DeliveryRecord newVal, DeliveryRecord original, System.Data.Linq.DataContext dc)
        {
            throw new NotImplementedException();
        }

        protected override void DeletingItem(DeliveryRecord info, System.Data.Linq.DataContext dc)
        {
            throw new NotImplementedException();
        }

        protected override List<DeliveryRecord> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<DeliveryRecord>(item => item.Customer);
            opt.LoadWith<DeliveryRecord>(item => item.WareHouse);
            opt.LoadWith<DeliveryRecord>(item => item.Product);
            opt.LoadWith<Product>(item => item.Category);
            dc.LoadOptions = opt;
            IQueryable<DeliveryRecord> ret = dc.GetTable<DeliveryRecord>();
            if (search is DeliveryRecordSearchCondition)
            {
                DeliveryRecordSearchCondition con = search as DeliveryRecordSearchCondition;
                if (!string.IsNullOrEmpty (con.ProductID )) ret = ret.Where(item => item.ProductID == con.ProductID);
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.CustomerID == con.CustomerID);
                if (!string.IsNullOrEmpty(con.CategoryID)) ret = ret.Where(item => item.Product.CategoryID == con.CategoryID);
                if (!string.IsNullOrEmpty(con.OrderID)) ret = ret.Where(item => item.OrderID == con.OrderID);
                if (con.OrderItem != null) ret = ret.Where(item => item.OrderItem == con.OrderItem);
                if (con.DeliveryDateTime != null)
                {
                    ret = ret.Where(item => item.DeliveryDate >= con.DeliveryDateTime.Begin && item.DeliveryDate <= con.DeliveryDateTime.End);
                }
            }
            List<DeliveryRecord> items = ret.ToList();
            return items;
        }
        #endregion
    }
}