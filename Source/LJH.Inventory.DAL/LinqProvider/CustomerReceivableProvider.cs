using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class CustomerReceivableProvider : ProviderBase<CustomerReceivable, Guid>
    {
        #region 构造函数
        public CustomerReceivableProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override CustomerReceivable GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<CustomerReceivable>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<CustomerReceivable> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<CustomerReceivable> ret = dc.GetTable<CustomerReceivable>();
            if (search is CustomerReceivableSearchCondition)
            {
                CustomerReceivableSearchCondition con = search as CustomerReceivableSearchCondition;
                if (con.CreateDate != null) ret = ret.Where(item => item.CreateDate >= con.CreateDate.Begin && item.CreateDate <= con.CreateDate.End);
                if (con.ReceivableTypes != null && con.ReceivableTypes.Count > 0) ret = ret.Where(item => con.ReceivableTypes.Contains(item.ClassID));
                if (con.ReceivableIDS != null && con.ReceivableIDS.Count > 0) ret = ret.Where(item => con.ReceivableIDS.Contains(item.ID));
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.CustomerID == con.CustomerID);
                if (!string.IsNullOrEmpty(con.OrderID)) ret = ret.Where(item => item.OrderID == con.OrderID);
                if (!string.IsNullOrEmpty(con.SheetID)) ret = ret.Where(item => item.SheetID == con.SheetID);
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains(item.State));
                if (con.Settled != null)
                {
                    if (con.Settled.Value)
                    {
                        ret = ret.Where(item => item.Haspaid == item.Amount);
                    }
                    else
                    {
                        ret = ret.Where(item => item.Haspaid < item.Amount);
                    }
                }

            }
            return ret.ToList();
        }
        #endregion
    }
}
