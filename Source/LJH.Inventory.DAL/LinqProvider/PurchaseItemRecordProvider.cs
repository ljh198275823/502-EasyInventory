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
    public class PurchaseItemRecordProvider : ProviderBase<PurchaseItemRecord, Guid>
    {
        #region 构造函数
        public PurchaseItemRecordProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override PurchaseItemRecord GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<PurchaseItemRecord>(item => item.Supplier);
            opt.LoadWith<PurchaseItemRecord>(item => item.Product);
            opt.LoadWith<Product>(item => item.Category);
            dc.LoadOptions = opt;
            return dc.GetTable<PurchaseItemRecord>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<PurchaseItemRecord> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<PurchaseItemRecord>(item => item.Supplier);
            opt.LoadWith<PurchaseItemRecord>(item => item.Product);
            dc.LoadOptions = opt;
            IQueryable<PurchaseItemRecord> ret = dc.GetTable<PurchaseItemRecord>();
            if (search is SheetSearchCondition)
            {
                SheetSearchCondition con = search as SheetSearchCondition;
                if (con.LastActiveDate != null) ret = ret.Where(item => item.LastActiveDate >= con.LastActiveDate.Begin && item.LastActiveDate <= con.LastActiveDate.End);
                if (con.SheetIDs != null && con.SheetIDs.Count > 0) ret = ret.Where(item => con.SheetIDs.Contains(item.SheetNo));
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains(item.State));
            }
            if (search is PurchaseOrderSearchCondition)
            {
                PurchaseOrderSearchCondition con = search as PurchaseOrderSearchCondition;
                if (!string.IsNullOrEmpty(con.SupplierID)) ret = ret.Where(item => item.SupplierID == con.SupplierID);
                if (!string.IsNullOrEmpty(con.Buyer)) ret = ret.Where(item => item.Buyer == con.Buyer);
            }
            if (search is PurchaseItemRecordSearchCondition)
            {
                PurchaseItemRecordSearchCondition con = search as PurchaseItemRecordSearchCondition;
                if (!string.IsNullOrEmpty(con.ProductID)) ret = ret.Where(item => item.ProductID == con.ProductID);
                if (!string.IsNullOrEmpty(con.OrderID)) ret = ret.Where(item => item.OrderID == con.OrderID);
            }
            List<PurchaseItemRecord> items = ret.ToList();
            if (search is PurchaseItemRecordSearchCondition)
            {
                PurchaseItemRecordSearchCondition con = search as PurchaseItemRecordSearchCondition;
                if (con.HasOnway != null)
                {
                    if (con.HasOnway.Value) items = items.Where(item => item.OnWay > 0).ToList();
                    else items = items.Where(item => item.OnWay == 0).ToList();
                }
            }
            return items;
        }
        #endregion
    }
}