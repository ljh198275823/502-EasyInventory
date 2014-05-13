using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示出库单类型的枚举
    /// </summary>
    public enum StackOutSheetType
    {
        /// <summary>
        /// 销售出库单
        /// </summary>
        DeliverySheet = 1,
        /// <summary>
        /// 客户借用单
        /// </summary>
        CustomerBorrow = 2,
        /// <summary>
        /// 生产领用单
        /// </summary>
        Production = 3,
    }
}
