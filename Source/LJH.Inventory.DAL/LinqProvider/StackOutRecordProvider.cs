using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class StackOutRecordProvider : ProviderBase<StackOutRecord, Guid>
    {
        #region 构造函数
        public StackOutRecordProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override StackOutRecord GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            throw new NotImplementedException();
        }

        protected override void InsertingItem(StackOutRecord info, System.Data.Linq.DataContext dc)
        {
            throw new NotImplementedException();
        }

        protected override void UpdatingItem(StackOutRecord newVal, StackOutRecord original, System.Data.Linq.DataContext dc)
        {
            throw new NotImplementedException();
        }

        protected override void DeletingItem(StackOutRecord info, System.Data.Linq.DataContext dc)
        {
            throw new NotImplementedException();
        }

        protected override List<StackOutRecord> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<StackOutRecord>(item => item.Customer);
            opt.LoadWith<StackOutRecord>(item => item.WareHouse);
            opt.LoadWith<StackOutRecord>(item => item.Product);
            opt.LoadWith<Product>(item => item.Category);
            dc.LoadOptions = opt;
            IQueryable<StackOutRecord> ret = dc.GetTable<StackOutRecord>();
            if (search is SheetSearchCondition)
            {
                SheetSearchCondition con = search as SheetSearchCondition;
                if (con.SheetDate != null) ret = ret.Where(item => item.SheetDate >= con.SheetDate.Begin && item.SheetDate <= con.SheetDate.End);
                if (con.SheetIDs != null && con.SheetIDs.Count > 0) ret = ret.Where(item => con.SheetIDs.Contains(item.SheetNo));
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains(item.State));
            }
            if (search is StackOutSheetSearchCondition)
            {
                StackOutSheetSearchCondition con = search as StackOutSheetSearchCondition;
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.CustomerID == con.CustomerID);
                if (!string.IsNullOrEmpty(con.WareHouseID)) ret = ret.Where(item => item.WareHouseID == con.WareHouseID);
                if (con.SheetTypes != null && con.SheetTypes.Count > 0) ret = ret.Where(item => con.SheetTypes.Contains(item.ClassID));
                if (!string.IsNullOrEmpty(con.SalesPerson)) ret = ret.Where(item => item.SalesPerson == con.SalesPerson);
            }
            if (search is StackOutRecordSearchCondition)
            {
                StackOutRecordSearchCondition con = search as StackOutRecordSearchCondition;
                if (!string.IsNullOrEmpty(con.ProductID)) ret = ret.Where(item => item.ProductID == con.ProductID);
                if (con.ProductIDs != null && con.ProductIDs.Count > 0) ret = ret.Where(item => con.ProductIDs.Contains(item.ProductID));
                if (!string.IsNullOrEmpty(con.CategoryID)) ret = ret.Where(item => item.Product.CategoryID == con.CategoryID);
                if (!string.IsNullOrEmpty(con.OrderID)) ret = ret.Where(item => item.OrderID == con.OrderID);
                if (con.OrderItem != null) ret = ret.Where(item => item.OrderItem == con.OrderItem);
            }
            List<StackOutRecord> items = ret.ToList();
            return items;
        }
        #endregion
    }
}