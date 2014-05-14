using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示客户应收账款项,每个能产生应收的单据都会有对应的一个应收款项,ID号为对应的单据号
    /// </summary>
    public class CustomerReceivable : LJH.GeneralLibrary.Core.DAL.IEntity<Guid>
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
        /// 获取或设置应收款的类型
        /// </summary>
        public CustomerReceivableClass ClassID { get; set; }
        /// <summary>
        /// 获取或设置应收账款的产生日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 获取或设置付款客户ID
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 获取或设置产生应收账款的单据号，比如送货单号，其它应收款单号等
        /// </summary>
        public string SheetID { get; set; }
        /// <summary>
        /// 获取或设置产生应收款的销售订单号,某些项目可能需要区分不同订单产生的应收账款，这些订单可能是通过一个送货单发货的
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 获取或设置应收总额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 获取或设置已经核销的金额
        /// </summary>
        public decimal Haspaid { get; set; }
        /// <summary>
        /// 获取或设置备注信息
        /// </summary>
        public string Memo { get; set; }
        #endregion

        #region 只读属性
        /// <summary>
        /// 获取未支付的金额
        /// </summary>
        public decimal Remain
        {
            get { return Amount - Haspaid; }
        }
        #endregion

        #region 公共方法
        public CustomerReceivable Clone()
        {
            return this.MemberwiseClone() as CustomerReceivable;
        }
        #endregion
    }

    /// <summary>
    /// 客户应收款的类型
    /// </summary>
    public enum CustomerReceivableClass
    {
        /// <summary>
        /// 其它应收款
        /// </summary>
        Other = 0,
        /// <summary>
        /// 送货单产生的应收款
        /// </summary>
        Delivery = 1,
    }
}
