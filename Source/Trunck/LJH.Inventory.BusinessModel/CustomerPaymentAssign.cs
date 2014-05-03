using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示客户付款与客户应收账款之间的分配
    /// </summary>
    public class CustomerPaymentAssign : LJH.GeneralLibrary.Core.DAL.IEntity<Guid>
    {
        #region 构造函数
        public CustomerPaymentAssign()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置ID号
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置客户付款ID
        /// </summary>
        public string PaymentID { get; set; }
        /// <summary>
        /// 获取或设置客户应收账款ID
        /// </summary>
        public Guid ReceivableID { get; set; }
        /// <summary>
        /// 获取或设置付款项的总金额
        /// </summary>
        public decimal Amount { get; set; }
        #endregion
    }
}
