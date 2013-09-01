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
    public class DeliverySheetProvider : ProviderBase<DeliverySheet, string>, IDeliverySheetProvider
    {
        #region 构造函数
        public DeliverySheetProvider(string conStr)
            : base(conStr)
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
            if (sheet != null)
            {
                sheet.Customer = (new CustomerProvider(ConnectStr)).GetByID(sheet.CustomerID).QueryObject;
                if (sheet.Items != null && sheet.Items.Count > 0)
                {
                    List<Product> ps = (new ProductProvider(ConnectStr)).GetItems(null).QueryObjects;
                    foreach (DeliveryItem item in sheet.Items)
                    {
                        item.Product = ps.SingleOrDefault(p => p.ID == item.ProductID);
                    }
                }
            }
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
                if (!string.IsNullOrEmpty(con.SheetNo)) ret = ret.Where(item => item.ID.Contains(con.SheetNo));
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains((int)item.State));
                if (!string.IsNullOrEmpty(con.Memo)) ret = ret.Where(item => item.Memo.Contains(con.Memo));
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
            if (sheets != null && sheets.Count > 0)  //有些查询不能直接用SQL语句查询
            {
                List<Customer> cs = (new CustomerProvider(ConnectStr)).GetItems(null).QueryObjects;
                List<Product> ps = (new ProductProvider(ConnectStr)).GetItems(null).QueryObjects;
                foreach (DeliverySheet sheet in sheets)
                {
                    sheet.Customer = cs.SingleOrDefault(item => item.ID == sheet.CustomerID);
                    if (sheet.Items != null && sheet.Items.Count > 0)
                    {
                        foreach (DeliveryItem si in sheet.Items)
                        {
                            si.Product = ps.SingleOrDefault(item => item.ID == si.ProductID);
                        }
                    }
                }
            }
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
