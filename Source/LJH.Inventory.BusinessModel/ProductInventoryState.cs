using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public enum ProductInventoryState
    {
        /// <summary>
        /// 整卷
        /// </summary>
        Intact = 0,
        /// <summary>
        /// 余卷
        /// </summary>
        Partial = 1,
        /// <summary>
        /// 尾卷,利用价值小，一般做废品卖
        /// </summary>
        OnlyTail = 2,
        /// <summary>
        /// 无余料,无利用价值，做废品卖
        /// </summary>
        RemainLess = 3,
        /// <summary>
        /// 废品处理(余料已经做废品处理)
        /// </summary>
        Nullified = 4,
        /// <summary>
        /// 待发货(已经生成了发货单,但发货还未发货)
        /// </summary>
        WaitShip = 5,
        /// <summary>
        /// 已发货
        /// </summary>
        Shipped = 6
    }
}
