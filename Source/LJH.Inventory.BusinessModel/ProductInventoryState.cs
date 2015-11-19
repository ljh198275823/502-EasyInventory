using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    [Flags]
    public enum ProductInventoryState
    {
        ALL = 0,
        /// <summary>
        /// 在库, 不包括已预定和待发货的
        /// </summary>
        Inventory = 0x01,
        /// <summary>
        /// 已预订，
        /// </summary>
        Reserved = 0x02,
        /// <summary>
        /// 待发货(已经生成了发货单,但发货还未发货)
        /// </summary>
        WaitShipping = 0x04,
        /// <summary>
        /// 所有未出货, 包括在库,已预定和待发货的
        /// </summary>
        UnShipped = 0x07,
        /// <summary>
        /// 已发货
        /// </summary>
        Shipped = 0x08,
        /// <summary>
        /// 作废(余料已经做废品处理)
        /// </summary>
        Nullified = 0x10,
    }
}
