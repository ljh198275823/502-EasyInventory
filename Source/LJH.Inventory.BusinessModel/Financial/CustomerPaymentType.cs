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
        公司管理费用 = 5,
        其它收款 = 6,
        转公账 = 7,
        转账入 = 8,
        转账出 = 9,
        公账 = 10,
    }
}
