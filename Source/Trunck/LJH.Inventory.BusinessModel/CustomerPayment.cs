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

        #region 只读变量
        public readonly string DocumentType = "CustomerPayment";
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
        public CompanyInfo Customer { get; set; }
        /// <summary>
        /// 获取或设置付款日期
        /// </summary>
        public DateTime PaidDate { get; set; }
        /// <summary>
        /// 获取或设置币别
        /// </summary>
        public string CurrencyType { get; set; }
        /// <summary>
        /// 获取或设置付款方式
        /// </summary>
        public PaymentMode PaymentMode { get; set; }
        /// <summary>
        /// 获取或设置付款金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 获取或设置付款金额剩余未抵销的金额
        /// </summary>
        public decimal Assigned { get; set; }
        /// <summary>
        /// 获取或设置支票号(如果是支票付款)
        /// </summary>
        public string CheckNum { get; set; }
        /// <summary>
        /// 获取或设置当前状态
        /// </summary>
        public SheetState State { get; set; }
        /// <summary>
        /// 获取或设置备注信息
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 获取或设置客户付款分配列表
        /// </summary>
        public List<CustomerPaymentAssign> Assigns { get; set; }
        #endregion

        #region 公共方法
        public CustomerPayment Clone()
        {
            return this.MemberwiseClone() as CustomerPayment;
        }
        #endregion
    }
}
