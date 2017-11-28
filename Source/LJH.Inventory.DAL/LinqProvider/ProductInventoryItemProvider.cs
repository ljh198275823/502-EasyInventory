using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class ProductInventoryItemProvider : ProviderBase<ProductInventoryItem, Guid>
    {
        public ProductInventoryItemProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }

        #region 重写模板方法
        protected override ProductInventoryItem GetingItemByID(Guid id, DataContext dc)
        {
            var ret = (from pi in dc.GetTable<ProductInventoryItem>()
                       from sr in dc.GetTable<ProductInventoryItem>().Where(it => pi.SourceRoll == it.ID).DefaultIfEmpty()
                       from c in dc.GetTable<Cost>().Where(it => pi.CostID == it.ID).DefaultIfEmpty()
                       where pi.ID == id
                       select new { A = pi, B = c.Costs, C = sr.OriginalWeight }).SingleOrDefault();
            if (ret != null)
            {
                ret.A.Product = new ProductProvider(SqlURI, _MappingResource).GetByID(ret.A.ProductID).QueryObject;
                ret.A.Costs = ret.B;
                ret.A.SourceRollWeight = ret.C;
                return ret.A;
            }
            return null;
        }

        protected override List<ProductInventoryItem> GetingItems(DataContext dc, SearchCondition search)
        {
            //dc.Log = Console.Out;
            if (search is StackOutSheetSearchCondition) return GetingItemsEX(dc, search as StackOutSheetSearchCondition);
            var ret = from pi in dc.GetTable<ProductInventoryItem>()
                      from sr in dc.GetTable<ProductInventoryItem>().Where(it => pi.SourceRoll == it.ID).DefaultIfEmpty()
                      from c in dc.GetTable<Cost>().Where(it => pi.CostID == it.ID).DefaultIfEmpty()
                      select new { A = pi, B = c.Costs, C = sr.OriginalWeight };
            if (search is ProductInventoryItemSearchCondition)
            {
                ProductInventoryItemSearchCondition con = search as ProductInventoryItemSearchCondition;
                if (!string.IsNullOrEmpty(con.Model)) ret = ret.Where(item => item.A.Model == con.Model);
                if (con.Models != null && con.Models.Count > 0) ret = ret.Where(item => con.Models.Contains(item.A.Model));
                if (con.AddDateRange != null) ret = ret.Where(item => item.A.AddDate >= con.AddDateRange.Begin && item.A.AddDate <= con.AddDateRange.End);
                if (con.Products != null && con.Products.Count > 0) ret = ret.Where(item => con.Products.Contains(item.A.ProductID));
                if (con.IDS != null && con.IDS.Count > 0) ret = ret.Where(item => con.IDS.Contains(item.A.ID));
                if (!string.IsNullOrEmpty(con.ProductID)) ret = ret.Where(item => item.A.ProductID == con.ProductID);
                if (!string.IsNullOrEmpty(con.WareHouseID)) ret = ret.Where(item => item.A.WareHouseID == con.WareHouseID);
                if (con.OrderItem != null) ret = ret.Where(item => item.A.OrderItem == con.OrderItem);
                if (!string.IsNullOrEmpty(con.OrderID)) ret = ret.Where(item => item.A.OrderID == con.OrderID);
                if (con.PurchaseItem != null) ret = ret.Where(item => item.A.PurchaseItem == con.PurchaseItem);
                if (!string.IsNullOrEmpty(con.PurchaseID)) ret = ret.Where(item => item.A.PurchaseID == con.PurchaseID);
                if (con.InventoryItem != null) ret = ret.Where(item => item.A.InventoryItem == con.InventoryItem);
                if (!string.IsNullOrEmpty(con.InventorySheetNo)) ret = ret.Where(item => item.A.InventorySheet == con.InventorySheetNo);
                if (con.DeliveryItem != null) ret = ret.Where(item => item.A.DeliveryItem == con.DeliveryItem);
                if (!string.IsNullOrEmpty(con.DeliverySheetNo)) ret = ret.Where(item => item.A.DeliverySheet == con.DeliverySheetNo);
                if (con.SourceRoll.HasValue) ret = ret.Where(item => item.A.SourceRoll == con.SourceRoll);
                if (con.SourceID.HasValue) ret = ret.Where(item => item.A.SourceID == con.SourceID.Value);
                if (con.OriginalWeight.HasValue) ret = ret.Where(it => it.A.OriginalWeight == con.OriginalWeight);
                if (con.HasRemain) ret = ret.Where(item => item.A.Count > 0);
                if (con.States != null && con.States.Count > 0) ret = ret.Where(it => con.States.Contains(it.A.State));
                if (con.Sliced.HasValue)
                {
                    if (con.Sliced.Value) ret = ret.Where(it => it.A.OriginalWeight > it.A.Weight);
                    else ret = ret.Where(it => it.A.OriginalWeight == it.A.Weight);
                }
                if (con.HasWeight.HasValue)
                {
                    if (con.HasWeight.Value) ret = ret.Where(it => it.A.Weight > 0);
                    else ret = ret.Where(it => it.A.Weight == 0);
                }
                if (con.CostID.HasValue) ret = ret.Where(it => it.A.CostID == con.CostID.Value);
            }
            var items = ret.ToList();
            if (items != null && items.Count > 0)
            {
                foreach (var pi in items)
                {
                    pi.A.Product = new ProductProvider(SqlURI, _MappingResource).GetByID(pi.A.ProductID).QueryObject;
                    pi.A.Costs = pi.B;
                    pi.A.SourceRollWeight = pi.C;
                }
                items.RemoveAll(it => it.A.Product == null);
                if (items.Count > 0) return items.Select(it => it.A).ToList();
            }
            return new List<ProductInventoryItem>();
        }

        private List<ProductInventoryItem> GetingItemsEX(DataContext dc, StackOutSheetSearchCondition con)
        {
            var ret = from pi in dc.GetTable<ProductInventoryItem>()
                      join sheet in dc.GetTable<StackOutSheet>() on pi.DeliverySheet equals sheet.ID
                      from sr in dc.GetTable<ProductInventoryItem>().Where(it => pi.SourceRoll == it.ID).DefaultIfEmpty()
                      from c in dc.GetTable<Cost>().Where(it => pi.CostID == it.ID).DefaultIfEmpty()
                      select new { A = pi, B = c.Costs, C = sheet, D = sr.OriginalWeight };
            if (con.SheetDate != null) ret = ret.Where(item => item.C.SheetDate >= con.SheetDate.Begin && item.C.SheetDate <= con.SheetDate.End);
            if (con.LastActiveDate != null) ret = ret.Where(item => item.C.LastActiveDate >= con.LastActiveDate.Begin && item.C.LastActiveDate <= con.LastActiveDate.End);
            if (con.SheetIDs != null && con.SheetIDs.Count > 0) ret = ret.Where(item => con.SheetIDs.Contains(item.C.ID));
            if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains(item.C.State));
            if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.C.CustomerID == con.CustomerID);
            if (!string.IsNullOrEmpty(con.WareHouseID)) ret = ret.Where(item => item.C.WareHouseID == con.WareHouseID);
            if (con.SheetTypes != null && con.SheetTypes.Count > 0) ret = ret.Where(item => con.SheetTypes.Contains(item.C.ClassID));
            if (con.WithTax != null)
            {
                if (con.WithTax.Value)
                {
                    ret = ret.Where(item => item.C.WithTax == true);
                }
                else
                {
                    ret = ret.Where(item => item.C.WithTax == false);
                }
            }
            var items = ret.Select(it => new { A = it.A, B = it.B, D = it.D }).ToList();
            if (items != null && items.Count > 0)
            {
                foreach (var pi in items)
                {
                    pi.A.Product = new ProductProvider(SqlURI, _MappingResource).GetByID(pi.A.ProductID).QueryObject;
                    pi.A.Costs = pi.B;
                    pi.A.SourceRollWeight = pi.D;
                }
                items.RemoveAll(it => it.A.Product == null);
                if (items.Count > 0) return items.Select(it => it.A).ToList();
            }
            return new List<ProductInventoryItem>();
        }

        protected override void InsertingItem(LJH.Inventory.BusinessModel.ProductInventoryItem info, System.Data.Linq.DataContext dc)
        {
            if (!info.CostID.HasValue)
            {
                if (!string.IsNullOrEmpty(info.Costs)) //新建库存没有用其它产品项的成本，就创建一个
                {
                    var cs = new Cost() { ID = info.ID, Costs = info.Costs };
                    dc.GetTable<Cost>().InsertOnSubmit(cs);
                    info.CostID = cs.ID;
                }
                else if (info.SourceID == null && info.SourceRoll == null) //如果是新增入库的项，则成本ID设置成其id值 
                {
                    info.CostID = info.ID;
                }
            }
            base.InsertingItem(info, dc);
        }

        protected override void UpdatingItem(ProductInventoryItem newVal, ProductInventoryItem original, DataContext dc)
        {
            Cost cs = null;
            if (newVal.CostID.HasValue) cs = dc.GetTable<Cost>().SingleOrDefault(it => it.ID == newVal.CostID.Value);
            if (cs != null)
            {
                cs.Costs = newVal.Costs;
            }
            else
            {
                if (!string.IsNullOrEmpty(newVal.Costs))
                {
                    cs = new Cost() { ID = newVal.ID, Costs = newVal.Costs };
                    dc.GetTable<Cost>().InsertOnSubmit(cs);
                    newVal.CostID = cs.ID;
                }
            }
            base.UpdatingItem(newVal, original, dc);
        }
        #endregion
    }
}

