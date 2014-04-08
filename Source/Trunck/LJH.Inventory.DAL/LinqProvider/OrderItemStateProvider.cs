using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class OrderItemStateProvider : ProviderBase<OrderItemState, Guid>, IOrderItemStateProvider
    {
        #region 构造函数
        public OrderItemStateProvider(string connStr)
            : base(connStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override OrderItemState GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<OrderItemState>().SingleOrDefault(item => item.ID == id);
        }
        #endregion
    }
}
