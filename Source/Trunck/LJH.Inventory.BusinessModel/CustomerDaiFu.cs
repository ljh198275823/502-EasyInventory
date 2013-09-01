using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示给客户代付货款的记录
    /// </summary>
    public class CustomerDaiFu
    {
        #region 构造函数
        public CustomerDaiFu()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置代付的客户ID
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 获取或设置代付的客户
        /// </summary>
        public Customer Customer { get; set; }
        /// <summary>
        /// 获取或设置支出日期
        /// </summary>
        public DateTime DaiFuDate { get; set; }
        /// <summary>
        /// 获取或设置支付方式
        /// </summary>
        public PaymentMode PaymentMode { get; set; }
        /// <summary>
        /// 获取或设置支付金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 获取或设置已收回的金额
        /// </summary>
        public decimal Paid { get; set; }
        /// <summary>
        /// 获取或设置录入日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 获取或设置录入操作员
        /// </summary>
        public string CreateOperator { get; set; }
        /// <summary>
        /// 获取或设置取消日期
        /// </summary>
        public DateTime? CancelDate { get; set; }
        /// <summary>
        /// 获取或设置取消操作员
        /// </summary>
        public string CancelOperator { get; set; }
        /// <summary>
        /// 获取或设置支付备注
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 获取送货单是否可支付
        /// </summary>
        public bool Payable
        {
            get
            {
                return CancelDate == null && Receivables > 0;
            }
        }
        /// <summary>
        /// 获取是否可以作废
        /// </summary>
        public bool CanCancel
        {
            get
            {
                return CancelDate == null;
            }
        }
        /// <summary>
        /// 获取应收金额
        /// </summary>
        public decimal Receivables
        {
            get
            {
                return Amount - Paid;
            }
        }
        #endregion

        public CustomerDaiFu Clone()
        {
            return this.MemberwiseClone() as CustomerDaiFu;
        }
    }
}
