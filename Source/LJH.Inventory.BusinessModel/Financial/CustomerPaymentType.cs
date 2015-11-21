using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示客户/供应商收付款类型
    /// </summary>
    public enum CustomerPaymentType
    {
        /// <summary>
        /// 客户收款
        /// </summary>
        Customer=1,
        /// <summary>
        /// 供应商付款
        /// </summary>
        Supplier=2,
        /// <summary>
        /// 开给客户的增值税发票
        /// </summary>
        CustomerTax=3,
    }
}
