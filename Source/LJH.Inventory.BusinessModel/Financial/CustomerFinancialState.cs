using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示客户的财务状态
    /// </summary>
    public class CustomerFinancialState
    {
        public CompanyInfo Customer { get; set; }
        /// <summary>
        /// 获取或设置应收账款
        /// </summary>
        public decimal Recievables { get; set; }
        /// <summary>
        /// 获取或设置未核销的收款金额
        /// </summary>
        public decimal Prepay { get; set; }
        /// <summary>
        /// 获取或设置应开增值税
        /// </summary>
        public decimal Tax { get; set; }
        /// <summary>
        /// 获取或设置未核销的已开增值税发票金额
        /// </summary>
        public decimal TaxBill { get; set; }
        /// <summary>
        /// 获取客户的欠款
        /// </summary>
        public decimal Credit
        {
            get { return Recievables - Prepay; }
        }
    }
}
