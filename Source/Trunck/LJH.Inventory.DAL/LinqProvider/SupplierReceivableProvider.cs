using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class SupplierReceivableProvider : ProviderBase<SupplierReceivable, Guid>, ISupplierReceivableProvider
    {
        #region 构造函数
        public SupplierReceivableProvider(string connStr)
            : base(connStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override SupplierReceivable GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<SupplierReceivable>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<SupplierReceivable> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<SupplierReceivable> ret = dc.GetTable<SupplierReceivable>();
            if (search is SupplierReceivableSearchCondition)
            {
                SupplierReceivableSearchCondition con = search as SupplierReceivableSearchCondition;
                if (con.CreateDate != null) ret = ret.Where(item => item.CreateDate >= con.CreateDate.Begin && item.CreateDate <= con.CreateDate.End);
                if (con.SupplierID != null) ret = ret.Where(item => item.SupplierID == con.SupplierID);
                if (!string.IsNullOrEmpty(con.PurchaseID)) ret = ret.Where(item => item.PurchaseID == con.PurchaseID);
                if (!string.IsNullOrEmpty(con.InventorySheet)) ret = ret.Where(item => item.InventorySheet == con.InventorySheet);
            }
            return ret.ToList();
        }
        #endregion
    }
}
