using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示客户付款记录
    /// </summary>
    public class CustomerPayment
    {
        #region 构造函数
        public CustomerPayment()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置付款记录ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置付款客户ID
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 获取或设置付款客户
        /// </summary>
        public Customer Customer { get; set; }
        /// <summary>
        /// 获取或设置付款日期
        /// </summary>
        public DateTime PaidDate { get; set; }
        /// <summary>
        /// 获取或设置付款方式
        /// </summary>
        public PaymentMode PaymentMode { get; set; }
        /// <summary>
        /// 获取或设置付款金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 获取或设置客户付款还有多少余款
        /// </summary>
        public decimal Remain { get; set; }
        /// <summary>
        /// 获取或设置支票号(如果是支票付款)
        /// </summary>
        public string CheckNum { get; set; }
        /// <summary>
        /// 获取或设置送货单号
        /// </summary>
        public string SheetNo { get; set; }
        /// <summary>
        /// 获取或设置是否是预付款
        /// </summary>
        public bool IsPrepay { get; set; }
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
        /// 获取或设置备注信息
        /// </summary>
        public string Memo { get; set; }
        #endregion

        #region 公共方法
        public CustomerPayment Clone()
        {
            return this.MemberwiseClone() as CustomerPayment;
        }
        #endregion
    }
}
