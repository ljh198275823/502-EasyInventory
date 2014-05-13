using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class InventorySheetProvider : ProviderBase<InventorySheet, string>
    {
        #region 构造函数
        public InventorySheetProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override InventorySheet GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<InventorySheet>(s => s.Items);
            dc.LoadOptions = opt;
            InventorySheet sheet = dc.GetTable<InventorySheet>().SingleOrDefault(item => item.ID == id);
            return sheet;
        }

        protected override List<InventorySheet> GetingItems(DataContext dc, SearchCondition search)
        {
            //这种通过两次查询获取信息的方式，在商品很多时会引起性能问题，以后看能不能做联接查询，一次出结果
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<InventorySheet>(sheet => sheet.Items);
            dc.LoadOptions = opt;
            IQueryable<InventorySheet> ret = dc.GetTable<InventorySheet>();
            if (search is SheetSearchCondition)
            {
                SheetSearchCondition con = search as SheetSearchCondition;
                if (con.SheetDate != null) ret = ret.Where(item => item.SheetDate >= con.SheetDate.Begin && item.SheetDate <= con.SheetDate.End);
                if (con.LastActiveDate != null) ret = ret.Where(item => item.LastActiveDate >= con.LastActiveDate.Begin && item.LastActiveDate <= con.LastActiveDate.End);
                if (con.SheetNo != null && con.SheetNo.Count > 0) ret = ret.Where(item => con.SheetNo.Contains(item.ID));
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains(item.State));
            }
            if (search is InventorySheetSearchCondition)
            {
                InventorySheetSearchCondition con = search as InventorySheetSearchCondition;
                if (!string.IsNullOrEmpty(con.SupplierID)) ret = ret.Where(item => item.SupplierID == con.SupplierID);
                if (!string.IsNullOrEmpty(con.WareHouseID)) ret = ret.Where(item => item.WareHouseID == con.WareHouseID);
            }
            List<InventorySheet> sheets = ret.ToList();
            return sheets;
        }

        protected override void UpdatingItem(InventorySheet newVal, InventorySheet original, DataContext dc)
        {
            dc.GetTable<InventorySheet>().Attach(newVal, original);
            foreach (InventoryItem item in newVal.Items)
            {
                InventoryItem old = original.Items.SingleOrDefault(it => it.ID == item.ID);
                if (old != null)
                {
                    dc.GetTable<InventoryItem>().Attach(item, old);
                }
                else
                {
                    dc.GetTable<InventoryItem>().InsertOnSubmit(item);
                }
            }
            foreach (InventoryItem item in original.Items)
            {
                if (newVal.Items.SingleOrDefault(it => it.ID == item.ID) == null)
                {
                    dc.GetTable<InventoryItem>().Attach(item);
                    dc.GetTable<InventoryItem>().DeleteOnSubmit(item);
                }
            }
        }

        protected override void DeletingItem(InventorySheet info, DataContext dc)
        {
            dc.GetTable<InventorySheet>().Attach(info);
            dc.GetTable<InventorySheet>().DeleteOnSubmit(info);
            foreach (InventoryItem item in info.Items)
            {
                dc.GetTable<InventoryItem>().Attach(item);
                dc.GetTable<InventoryItem>().DeleteOnSubmit(item);
            }
        }
        #endregion
    }
}
