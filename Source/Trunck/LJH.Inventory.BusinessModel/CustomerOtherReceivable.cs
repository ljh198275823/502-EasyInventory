using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示客户其它应收款,包括出口退税等都在这里
    /// </summary>
    public class CustomerOtherReceivable
    {
        #region 构造函数
        public CustomerOtherReceivable()
        {
        }
        #endregion

        #region 只读变量
        public readonly string DocumentType = "CustomerOtherReceivable";
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
        public CompanyInfo Customer { get; set; }
        /// <summary>
        /// 获取或设置创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 获取或设置币别
        /// </summary>
        public string CurrencyType { get; set; }
        /// <summary>
        /// 获取或设置金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 获取或设置当前状态
        /// </summary>
        public SheetState State { get; set; }
        /// <summary>
        /// 获取或设置支付备注
        /// </summary>
        public string Memo { get; set; }
        #endregion

        #region 只读属性
        /// <summary>
        /// 获取是否可以作废
        /// </summary>
        public bool CanCancel
        {
            get
            {
                return State != SheetState.Canceled;
            }
        }
        #endregion

        public CustomerOtherReceivable Clone()
        {
            return this.MemberwiseClone() as CustomerOtherReceivable;
        }
    }
}
