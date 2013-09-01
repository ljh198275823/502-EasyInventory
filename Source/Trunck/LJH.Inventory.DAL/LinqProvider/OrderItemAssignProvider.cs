using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class OrderItemAssignProvider : ProviderBase<OrderItemInventory, long>, IOrderItemAssignProvider
    {
        public OrderItemAssignProvider(string connStr)
            : base(connStr)
        {
        }

        #region 重写模板方法
        protected override OrderItemInventory GetingItemByID(long id, DataContext dc)
        {
            return dc.GetTable<OrderItemInventory>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<OrderItemInventory> GetingItems(DataContext dc, BusinessModel.SearchCondition.SearchCondition search)
        {
            IQueryable<OrderItemInventory> ret = dc.GetTable<OrderItemInventory>();
            if (search != null)
            {
            }
            return ret.ToList();
        }
        #endregion
    }
}

