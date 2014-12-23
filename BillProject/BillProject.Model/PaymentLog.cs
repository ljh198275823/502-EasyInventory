using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.BillProject.Model
{
    public class PaymentLog : LJH.GeneralLibrary.Core.DAL.IEntity<Guid>
    {
        #region 构造函数
        public PaymentLog() { }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置ID
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置消费日期
        /// </summary>
        public DateTime PaymentDate { get; set; }
        /// <summary>
        /// 获取或设置消费类别
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 获取或设置消费金额
        /// </summary>
        public Decimal Amount { get; set; }
        /// <summary>
        /// 获取或设置支付方式
        /// </summary>
        public string PaymentMode { get; set; }
        /// <summary>
        /// 获取或设置消费人员
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// 获取或设置记录是否已经删除
        /// </summary>
        public bool? Deleted { get; set; }
        /// <summary>
        /// 获取或设置备注信息
        /// </summary>
        public string Memo { get; set; }
        #endregion

        public PaymentLog Clone()
        {
            return this.MemberwiseClone() as PaymentLog;
        }
    }
}
