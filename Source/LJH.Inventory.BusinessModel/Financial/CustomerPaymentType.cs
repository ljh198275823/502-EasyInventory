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
        未知类型 = 0,
        客户收款 = 1,
        供应商付款 = 2,
        客户增值税发票 = 3,
        供应商增值税发票 = 4,
        管理费用 = 5,
        其它收款 = 6,
        转公账 = 7,
        转账入 = 8,
        转账出 = 9,
        公账 = 10,
        客户退款 = 11,
        供应商退款 = 12,
        转账 = 13,
        管理费用退款 = 14,
    }
}
