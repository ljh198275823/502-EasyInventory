using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示客户应收账款项,每个能产生应收的单据都会有对应的一个应收款项,ID号为对应的单据号
    /// </summary>
    public class SupplierReceivable : LJH.GeneralLibrary.Core.DAL.IEntity<Guid>
    {
        #region 构造函数
        public SupplierReceivable()
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
        public int ClassID { get; set; }
        /// <summary>
        /// 获取或设置应收账款的产生日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 获取或设置付款客户ID
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 获取或设置收货单编号
        /// </summary>
        public string SheetID { get; set; }
        /// <summary>
        /// 获取或设置产生应收款的采购订单号
        /// </summary>
        public string PurchaseID { get; set; }
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

        #region 公共方法
        public SupplierReceivable Clone()
        {
            return this.MemberwiseClone() as SupplierReceivable;
        }
        #endregion
    }
}
