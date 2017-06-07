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
                       join c in dc.GetTable<Cost>() on pi.CostID equals c.ID
                       where pi.ID == id
                       select new { A = pi, B = c.Costs }).SingleOrDefault();
            if (ret != null)
            {
                ret.A.Product = new ProductProvider(SqlURI, _MappingResource).GetByID(ret.A.ProductID).QueryObject;
                ret.A.Costs = ret.B;
                return ret.A;
            }
            return null;
        }

        protected override List<ProductInventoryItem> GetingItems(DataContext dc, SearchCondition search)
        {
            var ret = from pi in dc.GetTable<ProductInventoryItem>() join c in dc.GetTable<Cost>() on pi.CostID equals c.ID select new { A = pi, B = c.Costs };
            if (search is ProductInventoryItemSearchCondition)
            {
                ProductInventoryItemSearchCondition con = search as ProductInventoryItemSearchCondition;
                if (!string.IsNullOrEmpty(con.Model)) ret = ret.Where(item => item.A.Model == con.Model);
                if (!string.IsNullOrEmpty(con.ExcludeModel)) ret = ret.Where(item => item.A.Model != con.ExcludeModel);
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
            }
            var items = ret.ToList();
            if (items != null && items.Count > 0)
            {
                foreach (var pi in items)
                {
                    pi.A.Product = new ProductProvider(SqlURI, _MappingResource).GetByID(pi.A.ProductID).QueryObject;
                    pi.A.Costs = pi.B;
                }
                items.RemoveAll(it => it.A.Product == null);
                if (items.Count > 0) return items.Select(it => it.A).ToList();
            }
            return new List<ProductInventoryItem>();
        }

        protected override void InsertingItem(LJH.Inventory.BusinessModel.ProductInventoryItem info, System.Data.Linq.DataContext dc)
        {
            if (!info.CostID.HasValue && !string.IsNullOrEmpty(info.Costs))
            {
                var cs = new Cost() { ID = info.ID, Costs = info.Costs };
                dc.GetTable<Cost>().InsertOnSubmit(cs);
                info.CostID = cs.ID;
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
                cs = new Cost() { ID = newVal.ID, Costs = newVal.Costs };
                dc.GetTable<Cost>().InsertOnSubmit(cs);
                newVal.CostID = cs.ID;
            }
            base.UpdatingItem(newVal, original, dc);
        }
        #endregion
    }
}

