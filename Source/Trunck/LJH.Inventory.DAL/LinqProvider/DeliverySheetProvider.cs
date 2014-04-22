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
    public class DeliverySheetProvider : ProviderBase<DeliverySheet, string>
    {
        #region 构造函数
        public DeliverySheetProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override DeliverySheet GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<DeliverySheet>(item => item.Items);
            dc.LoadOptions = opt;
            DeliverySheet sheet = dc.GetTable<DeliverySheet>().SingleOrDefault(item => item.ID == id);
            return sheet;
        }

        protected override List<DeliverySheet> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<DeliverySheet>(item => item.Items);
            dc.LoadOptions = opt;
            IQueryable<DeliverySheet> ret = dc.GetTable<DeliverySheet>();
            if (search is SheetSearchCondition)
            {
                SheetSearchCondition con = search as SheetSearchCondition;
                if (con.LastActiveDate != null) ret = ret.Where(item => item.LastActiveDate >= con.LastActiveDate.Begin && item.LastActiveDate <= con.LastActiveDate.End);
                if (con.SheetNo != null && con.SheetNo.Count > 0) ret = ret.Where(item => con.SheetNo.Contains(item.ID));
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains(item.State));
            }
            if (search is DeliverySheetSearchCondition)
            {
                DeliverySheetSearchCondition con = search as DeliverySheetSearchCondition;
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.CustomerID == con.CustomerID);
                if (con.WithTax != null)
                {
                    if (con.WithTax.Value)
                    {
                        ret = ret.Where(item => item.IsWithTax == true);
                    }
                    else
                    {
                        ret = ret.Where(item => item.IsWithTax == false);
                    }
                }
            }
            List<DeliverySheet> sheets = ret.ToList();
            return sheets;
        }

        protected override void UpdatingItem(DeliverySheet newVal, DeliverySheet original, DataContext dc)
        {
            dc.GetTable<DeliverySheet>().Attach(newVal, original);
            foreach (DeliveryItem item in newVal.Items)
            {
                DeliveryItem old = original.Items.SingleOrDefault(it => it.ID == item.ID);
                if (old != null)
                {
                    dc.GetTable<DeliveryItem>().Attach(item, old);
                }
                else
                {
                    dc.GetTable<DeliveryItem>().InsertOnSubmit(item);
                }
            }
            foreach (DeliveryItem item in original.Items)
            {
                if (newVal.Items.SingleOrDefault(it => it.ID == item.ID) == null)
                {
                    dc.GetTable<DeliveryItem>().Attach(item);
                    dc.GetTable<DeliveryItem>().DeleteOnSubmit(item);
                }
            }
        }
        #endregion
    }
}
