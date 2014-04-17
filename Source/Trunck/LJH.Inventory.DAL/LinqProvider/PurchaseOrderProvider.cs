using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class PurchaseOrderProvider : ProviderBase<PurchaseOrder, string>, IPurchaseOrderProvider
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
            if (sheet != null)
            {
                sheet.Supplier = (new CustomerProvider(ConnectStr, _MappingResource)).GetByID(sheet.SupplierID).QueryObject;
                if (sheet.Items != null && sheet.Items.Count > 0)
                {
                    List<Product> ps = (new ProductProvider(ConnectStr, _MappingResource)).GetItems(null).QueryObjects;
                    foreach (PurchaseItem item in sheet.Items)
                    {
                        item.Product = ps.SingleOrDefault(p => p.ID == item.ProductID);
                    }
                }
            }
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
                if (!string.IsNullOrEmpty(con.SheetNo)) ret = ret.Where(item => item.ID.Contains(con.SheetNo));
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains((int)item.State));
                if (!string.IsNullOrEmpty(con.Memo)) ret = ret.Where(item => item.Memo.Contains(con.Memo));
            }
            if (search is PurchaseOrderSearchCondition)
            {
                OrderSearchCondition con = search as OrderSearchCondition;
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.SupplierID == con.CustomerID);
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
            if (sheets != null && sheets.Count > 0)  //有些查询不能直接用SQL语句查询
            {
                List<CompanyInfo> cs = (new CustomerProvider(ConnectStr, _MappingResource)).GetItems(null).QueryObjects;
                List<Product> ps = (new ProductProvider(ConnectStr, _MappingResource)).GetItems(null).QueryObjects;
                foreach (PurchaseOrder sheet in sheets)
                {
                    sheet.Supplier = cs.SingleOrDefault(item => item.ID == sheet.SupplierID);
                    if (sheet.Items != null && sheet.Items.Count > 0)
                    {
                        foreach (PurchaseItem si in sheet.Items)
                        {
                            si.Product = ps.SingleOrDefault(item => item.ID == si.ProductID);
                        }
                    }
                }
            }
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

