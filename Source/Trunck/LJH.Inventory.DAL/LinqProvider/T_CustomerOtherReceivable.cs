using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.DAL.LinqProvider
{
    internal class T_CustomerOtherReceivable
    {
        #region 构造函数
        public T_CustomerOtherReceivable()
        {
        }

        public T_CustomerOtherReceivable(CustomerOtherReceivable info)
        {
            this.ID = info.ID;
            this.CustomerID = info.CustomerID;
            this.CreateDate = info.CreateDate;
            this.CurrencyType = info.CurrencyType;
            this.Amount = info.Amount;
            this.State = info.State;
            this.Memo = info.Memo;
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
        /// 获取或设置已收回的金额
        /// </summary>
        public decimal Paid { get; set; }
        /// <summary>
        /// 获取或设置当前状态
        /// </summary>
        public SheetState State { get; set; }
        /// <summary>
        /// 获取或设置支付备注
        /// </summary>
        public string Memo { get; set; }
        #endregion
    }
}
