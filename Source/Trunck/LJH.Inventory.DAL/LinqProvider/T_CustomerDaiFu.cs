using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.DAL.LinqProvider
{
    internal class T_CustomerDaiFu
    {
        #region 构造 函数
        public T_CustomerDaiFu()
        {
        }

        public T_CustomerDaiFu(CustomerDaiFu cdf)
        {
            this.ID = cdf.ID;
            this.CustomerID = cdf.CustomerID;
            this.DaiFuDate = cdf.DaiFuDate;
            this.PaymentMode = cdf.PaymentMode;
            this.Amount = cdf.Amount;
            this.CreateDate = cdf.CreateDate;
            this.CreateOperator = cdf.CreateOperator;
            this.CancelDate = cdf.CancelDate;
            this.CancelOperator = cdf.CancelOperator;
            this.Memo = cdf.Memo;
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
