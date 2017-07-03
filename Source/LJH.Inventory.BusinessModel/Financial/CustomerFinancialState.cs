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

        public decimal 对公已付金额 { get; set; }

        public decimal 发票已核销对公已付金额 { get; set; }

        #region 20170703添加
        public DateTime? 最后一次出货 { get; set; }

        public int? 距最后一次出货天数
        {
            get
            {
                if (!最后一次出货.HasValue) return null;
                var sp = new TimeSpan(DateTime.Now.Ticks - 最后一次出货.Value.Ticks);
                return  (int)(Math.Floor(sp.TotalDays));
            }
        }
        #endregion
        /// <summary>
        /// 获取客户的欠款
        /// </summary>
        public decimal Credit
        {
            get { return Recievables - Prepay; }
        }
    }
}
