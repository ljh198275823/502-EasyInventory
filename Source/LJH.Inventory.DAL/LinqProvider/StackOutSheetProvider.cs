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
    public class StackOutSheetProvider : ProviderBase<StackOutSheet, string>
    {
        #region 构造函数
        public StackOutSheetProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override StackOutSheet GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<StackOutSheet>(item => item.Items);
            dc.LoadOptions = opt;
            StackOutSheet sheet = dc.GetTable<StackOutSheet>().SingleOrDefault(item => item.ID == id);
            return sheet;
        }

        protected override List<StackOutSheet> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<StackOutSheet>(item => item.Items);
            dc.LoadOptions = opt;
            IQueryable<StackOutSheet> ret = dc.GetTable<StackOutSheet>();
            if (search is SheetSearchCondition)
            {
                SheetSearchCondition con = search as SheetSearchCondition;
                if (con.SheetDate != null) ret = ret.Where(item => item.SheetDate >= con.SheetDate.Begin && item.SheetDate <= con.SheetDate.End);
                if (con.LastActiveDate != null) ret = ret.Where(item => item.LastActiveDate >= con.LastActiveDate.Begin && item.LastActiveDate <= con.LastActiveDate.End);
                if (con.SheetIDs != null && con.SheetIDs.Count > 0) ret = ret.Where(item => con.SheetIDs.Contains(item.ID));
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains(item.State));
            }
            if (search is StackOutSheetSearchCondition)
            {
                StackOutSheetSearchCondition con = search as StackOutSheetSearchCondition;
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.CustomerID == con.CustomerID);
                if (!string.IsNullOrEmpty(con.WareHouseID)) ret = ret.Where(item => item.WareHouseID == con.WareHouseID);
                if (con.SheetTypes != null && con.SheetTypes.Count > 0) ret = ret.Where(item => con.SheetTypes.Contains(item.ClassID));
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
            List<StackOutSheet> sheets = ret.ToList();
            return sheets;
        }

        protected override void UpdatingItem(StackOutSheet newVal, StackOutSheet original, DataContext dc)
        {
            dc.GetTable<StackOutSheet>().Attach(newVal, original);
            foreach (StackOutItem item in newVal.Items)
            {
                StackOutItem old = original.Items.SingleOrDefault(it => it.ID == item.ID);
                if (old != null)
                {
                    dc.GetTable<StackOutItem>().Attach(item, old);
                }
                else
                {
                    dc.GetTable<StackOutItem>().InsertOnSubmit(item);
                }
            }
            foreach (StackOutItem item in original.Items)
            {
                if (newVal.Items.SingleOrDefault(it => it.ID == item.ID) == null)
                {
                    dc.GetTable<StackOutItem>().Attach(item);
                    dc.GetTable<StackOutItem>().DeleteOnSubmit(item);
                }
            }
        }
        #endregion
    }
}
