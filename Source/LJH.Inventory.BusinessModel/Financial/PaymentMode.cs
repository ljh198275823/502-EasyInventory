using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示付款方式
    /// </summary>
    public enum  PaymentMode
    {
        /// <summary>
        /// 未付款
        /// </summary>
        None=0,
        /// <summary>
        /// 现金
        /// </summary>
        Cash=1,
        /// <summary>
        /// 支票
        /// </summary>
        Check=2,
        /// <summary>
        /// 转账
        /// </summary>
        Transfer=3,
        /// <summary>
        /// 预付款
        /// </summary>
        Prepay=4,
        转公账 = 5,
        付承兑 = 6,
    }
}
