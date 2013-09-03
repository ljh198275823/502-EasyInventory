using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示客户应收账款项,每个能产生应收的单据都会有对应的一个应收款项,ID号为对应的单据号
    /// </summary>
    public class CustomerReceivable
    {
        #region 构造函数
        public CustomerReceivable()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置单据号
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置销售订单项,每个送货单的一项都生成一个客户应收金额,而送货单项又属于销售订单的一项
        /// </summary>
        public Guid? OrderItem { get; set; }
        /// <summary>
        /// 获取或设置产生应收款的单据编号
        /// </summary>
        public string SheetNo { get; set; }
        /// <summary>
        /// 获取或设置应收账款的产生日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 获取或设置付款客户ID
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 获取或设置应收总额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 获取或设置备注信息
        /// </summary>
        public string Memo { get; set; }
        #endregion

        #region 公共方法
        public CustomerReceivable Clone()
        {
            return this.MemberwiseClone() as CustomerReceivable;
        }
        #endregion
    }
}
