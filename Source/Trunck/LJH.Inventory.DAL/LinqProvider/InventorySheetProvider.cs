using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class InventorySheetProvider : ProviderBase<InventorySheet, string>, IInventorySheetProvider
    {
        #region 构造函数
        public InventorySheetProvider(string connStr)
            : base(connStr)
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
            if (sheet != null)
            {
                sheet.WareHouse = (new WareHouseProvider(ConnectStr)).GetByID(sheet.WareHouseID).QueryObject;
                sheet.Supplier = (new CustomerProvider(ConnectStr)).GetByID(sheet.SupplierID).QueryObject;
                if (sheet.Items != null && sheet.Items.Count > 0)
                {
                    List<Product> ps = (new ProductProvider(ConnectStr)).GetItems(null).QueryObjects;
                    foreach (InventoryItem item in sheet.Items)
                    {
                        item.Product = ps.SingleOrDefault(p => p.ID == item.ProductID);
                    }
                }
            }
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
                if (!string.IsNullOrEmpty(con.SheetNo)) ret = ret.Where(item => item.ID.Contains(con.SheetNo));
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains((int)item.State));
                if (!string.IsNullOrEmpty(con.Memo)) ret = ret.Where(item => item.Memo.Contains(con.Memo));
            }
            if (search is InventorySheetSearchCondition)
            {
                InventorySheetSearchCondition con = search as InventorySheetSearchCondition;
                if (!string.IsNullOrEmpty(con.SupplierName)) ret = ret.Where(item => item.SupplierID.Contains(con.SupplierName));
            }
            List<InventorySheet> sheets = ret.ToList();
            if (sheets != null && sheets.Count > 0)
            {
                List<WareHouse> ws = (new WareHouseProvider(ConnectStr)).GetItems(null).QueryObjects;
                List<CompanyInfo> ss = (new CustomerProvider(ConnectStr)).GetItems(null).QueryObjects;
                List<Product> ps = (new ProductProvider(ConnectStr)).GetItems(null).QueryObjects;
                foreach (InventorySheet sheet in sheets)
                {
                    sheet.Supplier = ss.SingleOrDefault(item => item.ID == sheet.SupplierID);
                    sheet.WareHouse = ws.SingleOrDefault(item => item.ID == sheet.WareHouseID);
                    if (sheet.Items != null && sheet.Items.Count > 0)
                    {
                        foreach (InventoryItem item in sheet.Items)
                        {
                            item.Product = ps.SingleOrDefault(p => p.ID == item.ProductID);
                        }
                    }
                }
            }
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
