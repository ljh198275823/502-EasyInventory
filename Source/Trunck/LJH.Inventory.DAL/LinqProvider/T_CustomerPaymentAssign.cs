using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class T_CustomerPaymentAssign
    {
        #region  构造函数
        public T_CustomerPaymentAssign()
        {
        }

        public T_CustomerPaymentAssign(CustomerPaymentAssign cpa)
        {
            this.ID = cpa.ID;
            this.PaymentID = cpa.PaymentID;
            this.ReceivableID = cpa.ReceivableID;
            this.Amount = cpa.Amount;
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置ID号
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// 获取或设置客户付款ID
        /// </summary>
        public string PaymentID { get; set; }
        /// <summary>
        /// 获取或设置客户应收账款ID
        /// </summary>
        public string ReceivableID { get; set; }
        /// <summary>
        /// 获取或设置分配的金额
        /// </summary>
        public decimal Amount { get; set; }
        #endregion
    }
}
