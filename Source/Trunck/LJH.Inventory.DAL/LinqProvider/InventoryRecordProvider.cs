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
    public class InventoryRecordProvider : ProviderBase<InventoryRecord, Guid>
    {
        #region 构造函数
        public InventoryRecordProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr,ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override InventoryRecord GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            throw new NotImplementedException();
        }

        protected override void InsertingItem(InventoryRecord info, System.Data.Linq.DataContext dc)
        {
            throw new NotImplementedException();
        }

        protected override void UpdatingItem(InventoryRecord newVal, InventoryRecord original, System.Data.Linq.DataContext dc)
        {
            throw new NotImplementedException();
        }

        protected override void DeletingItem(InventoryRecord info, System.Data.Linq.DataContext dc)
        {
            throw new NotImplementedException();
        }

        protected override List<InventoryRecord> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<InventoryRecord>(item => item.Supplier);
            opt.LoadWith<InventoryRecord>(item => item.WareHouse);
            opt.LoadWith<InventoryRecord>(item => item.Product);
            opt.LoadWith<Product>(item => item.Category);
            dc.LoadOptions = opt;
            IQueryable<InventoryRecord> ret = dc.GetTable<InventoryRecord>();
            if (search is SheetSearchCondition)
            {
                SheetSearchCondition con = search as SheetSearchCondition;
                if (con.LastActiveDate != null) ret = ret.Where(item => item.LastActiveDate >= con.LastActiveDate.Begin && item.LastActiveDate <= con.LastActiveDate.End);
                if (con.SheetNo != null && con.SheetNo.Count > 0) ret = ret.Where(item => con.SheetNo.Contains(item.SheetNo));
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains(item.State));
            }
            if (search is InventorySheetSearchCondition)
            {
                InventorySheetSearchCondition con = search as InventorySheetSearchCondition;
                if (!string.IsNullOrEmpty(con.SupplierID)) ret = ret.Where(item => item.SupplierID == con.SupplierID);
                if (!string.IsNullOrEmpty(con.WareHouseID)) ret = ret.Where(item => item.WareHouseID == con.WareHouseID);
            }
            if (search is InventoryRecordSearchCondition)
            {
                InventoryRecordSearchCondition con = search as InventoryRecordSearchCondition;
                if (!string.IsNullOrEmpty(con.ProductID)) ret = ret.Where(item => item.ProductID == con.ProductID);
                if (!string.IsNullOrEmpty(con.CategoryID)) ret = ret.Where(item => item.Product.CategoryID == con.CategoryID);
                if (!string.IsNullOrEmpty(con.OrderID)) ret = ret.Where(item => item.OrderID == con.OrderID);
                if (!string.IsNullOrEmpty(con.PurchaseID)) ret = ret.Where(item => item.PurchaseOrder == con.PurchaseID);
                if (con.OrderItem != null) ret = ret.Where(item => item.OrderItem == con.OrderItem);
                if (con.PurchaseItem != null) ret = ret.Where(item => item.PurchaseItem == con.PurchaseItem);
            }
            List<InventoryRecord> items = ret.ToList();
            return items;
        }
        #endregion
    }
}