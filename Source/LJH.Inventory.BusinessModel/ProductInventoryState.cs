using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public enum ProductInventoryState
    {
        /// <summary>
        /// 在库
        /// </summary>
        Inventory = 0,
        /// <summary>
        /// 已预订，
        /// </summary>
        Reserved = 1,
        /// <summary>
        /// 待发货(已经生成了发货单,但发货还未发货)
        /// </summary>
        WaitShip = 2,
        /// <summary>
        /// 已发货
        /// </summary>
        Shipped = 3,
        /// <summary>
        /// 作废(余料已经做废品处理)
        /// </summary>
        Nullified = 4,
    }
}
