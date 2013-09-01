using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Linq;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class PurchaseRecordProvider : ProviderBase<PurchaseRecord, Guid>, IPurchaseRecordProvider
    {
        #region 构造函数
        public PurchaseRecordProvider(string conStr)
            : base(conStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override PurchaseRecord GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<PurchaseRecord>(item => item.Supplier );
            opt.LoadWith<PurchaseRecord>(item => item.Product);
            dc.LoadOptions = opt;
            PurchaseRecord c = dc.GetTable<PurchaseRecord>().SingleOrDefault(item => item.ID == id);
            return c;
        }

        protected override List<PurchaseRecord> GetingItems(System.Data.Linq.DataContext dc, BusinessModel.SearchCondition.SearchCondition search)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<PurchaseRecord>(item => item.Supplier);
            opt.LoadWith<PurchaseRecord>(item => item.Product);
            dc.LoadOptions = opt;
            IQueryable<PurchaseRecord> ret = dc.GetTable<PurchaseRecord>();
            if (search is PurchaseRecordSearchCondition)
            {
                PurchaseRecordSearchCondition con = search as PurchaseRecordSearchCondition;
                if (!string.IsNullOrEmpty(con.SheetNo)) ret = ret.Where(item => item.SheetNo == con.SheetNo);
                if (!string.IsNullOrEmpty(con.OrderID)) ret = ret.Where(item => item.OrderID == con.OrderID);
                if (!string.IsNullOrEmpty(con.SupplierID)) ret = ret.Where(item => item.SupplierID == con.SupplierID);
                if (con.DemandDate != null) ret = ret.Where(item => item.DemandDate >= con.DemandDate.Begin && item.DemandDate <= con.DemandDate.End);
                if (!string.IsNullOrEmpty(con.Buyer)) ret = ret.Where(item => item.Buyer.Contains(con.Buyer));
                if (con.IsComplete != null) ret = ret.Where(item => item.IsComplete == con.IsComplete.Value);
            }
            List<PurchaseRecord> cs = ret.ToList();
            return cs;
        }
        #endregion
    }
}

