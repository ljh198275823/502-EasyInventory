using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 应收/应付款的类型
    /// </summary>
    public enum CustomerReceivableType
    {
        /// <summary>
        /// 客户其它应收款
        /// </summary>
        CustomerOtherReceivable = 1,
        /// <summary>
        /// 客户应收款
        /// </summary>
        CustomerReceivable = 2,
        /// <summary>
        /// 供应商应付款
        /// </summary>
        SupplierReceivable = 3,
        /// <summary>
        /// 供应商其它应付款
        /// </summary>
        SupplierOtherReceivable = 4,
    }
}
