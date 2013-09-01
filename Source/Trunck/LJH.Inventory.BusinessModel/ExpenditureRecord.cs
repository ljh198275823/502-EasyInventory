using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示公司的资金支出记录
    /// </summary>
    public  class ExpenditureRecord
    {
        #region 构造函数
        public ExpenditureRecord()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置支出日期
        /// </summary>
        public DateTime ExpenditureDate { get; set; }
        /// <summary>
        /// 获取或设置支付方式
        /// </summary>
        public PaymentMode PaymentMode { get; set; }
        /// <summary>
        /// 获取或设置支付金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 获取或设置支出类别
        /// </summary>
        public string Category { get; set; }
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
        #endregion
    }
}
