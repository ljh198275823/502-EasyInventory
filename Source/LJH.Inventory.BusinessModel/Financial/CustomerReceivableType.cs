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
        /// 客户应收款
        /// </summary>
        CustomerReceivable = 1,
        /// <summary>
        /// 客户应开增值税发票
        /// </summary>
        CustomerTax = 2,
        /// <summary>
        /// 供应商应付款
        /// </summary>
        SupplierReceivable = 3,
        /// <summary>
        /// 供应商应开增值税发票
        /// </summary>
        SupplierTax = 4,

        公账应收款 = 5,
    }
}
