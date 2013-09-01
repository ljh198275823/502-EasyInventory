using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class SupplierProvider : ProviderBase<Supplier, string>, ISupplierProvider
    {
        #region 构造函数
        public SupplierProvider(string connStr)
            : base(connStr)
        {

        }
        #endregion

        #region 重写基类方法
        protected override Supplier GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            Supplier s= dc.GetTable<Supplier>().SingleOrDefault(item => item.ID == id);
            if (s != null && !string.IsNullOrEmpty(s.CategoryID))
            {
                s.Category = (new SupplierTypeProvider(ConnectStr)).GetByID(s.CategoryID).QueryObject;
            }
            return s;
        }

        protected override List<Supplier> GetingItems(System.Data.Linq.DataContext dc, BusinessModel.SearchCondition.SearchCondition search)
        {
            IQueryable<Supplier> ret = dc.GetTable<Supplier>();
            if (search is SupplierSearchCondition)
            {
                SupplierSearchCondition con = search as SupplierSearchCondition;
                if (!string.IsNullOrEmpty(con.SupplierID)) ret = ret.Where(item => item.ID.Contains(con.SupplierID));
                if (!string.IsNullOrEmpty(con.SupplierName)) ret = ret.Where(item => item.Name.Contains(con.SupplierName));
                if (!string.IsNullOrEmpty(con.TelPhone)) ret = ret.Where(item => item.TelPhone.Contains(con.TelPhone));
            }
            List<Supplier> ss = ret.ToList();
            if (ss != null && ss.Count > 0)
            {
                List<SupplierType> cts = (new SupplierTypeProvider(ConnectStr)).GetItems(null).QueryObjects;
                foreach (Supplier c in ss)
                {
                    c.Category = cts.SingleOrDefault(ct => ct.ID == c.CategoryID);
                }
            }
            return ss;
        }
        #endregion
    }
}
