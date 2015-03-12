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
    public class PurchaseOrderProvider : ProviderBase<PurchaseOrder, string>
    {
        #region 构造函数
        public PurchaseOrderProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override PurchaseOrder GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<PurchaseOrder>(item => item.Items);
            dc.LoadOptions = opt;
            PurchaseOrder sheet = dc.GetTable<PurchaseOrder>().SingleOrDefault(item => item.ID == id);
            return sheet;
        }

        protected override List<PurchaseOrder> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<PurchaseOrder>(item => item.Items);
            dc.LoadOptions = opt;
            IQueryable<PurchaseOrder> ret = dc.GetTable<PurchaseOrder>();
            if (search is SheetSearchCondition)
            {
                SheetSearchCondition con = search as SheetSearchCondition;
                if (con.SheetDate != null) ret = ret.Where(item => item.SheetDate >= con.SheetDate.Begin && item.SheetDate <= con.SheetDate.End);
                if (con.LastActiveDate != null) ret = ret.Where(item => item.LastActiveDate >= con.LastActiveDate.Begin && item.LastActiveDate <= con.LastActiveDate.End);
                if (con.SheetNo != null && con.SheetNo.Count > 0) ret = ret.Where(item => con.SheetNo.Contains(item.ID));
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains(item.State));
            }
            if (search is PurchaseOrderSearchCondition)
            {
                PurchaseOrderSearchCondition con = search as PurchaseOrderSearchCondition;
                if (!string.IsNullOrEmpty(con.SupplierID )) ret = ret.Where(item => item.SupplierID == con.SupplierID );
                if (!string.IsNullOrEmpty(con.Buyer)) ret = ret.Where(item => item.Buyer == con.Buyer);
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
            List<PurchaseOrder> sheets = ret.ToList();
            return sheets;
        }

        protected override void UpdatingItem(PurchaseOrder newVal, PurchaseOrder original, System.Data.Linq.DataContext dc)
        {
            dc.GetTable<PurchaseOrder>().Attach(newVal, original);
            foreach (PurchaseItem item in newVal.Items)
            {
                PurchaseItem old = original.Items.SingleOrDefault(it => it.ID == item.ID);
                if (old != null)
                {
                    dc.GetTable<PurchaseItem>().Attach(item, old);
                }
                else
                {
                    item.PurchaseID = newVal.ID;
                    dc.GetTable<PurchaseItem>().InsertOnSubmit(item);
                }
            }
            foreach (PurchaseItem item in original.Items)
            {
                if (newVal.Items.SingleOrDefault(it => it.ID == item.ID) == null)
                {
                    dc.GetTable<PurchaseItem>().Attach(item);
                    dc.GetTable<PurchaseItem>().DeleteOnSubmit(item);
                }
            }
        }
        #endregion
    }
}

