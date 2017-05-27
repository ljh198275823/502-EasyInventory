using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class AccountRecord : LJH.GeneralLibrary.Core.DAL.IEntity<Guid>
    {
        #region 构造函数
        public AccountRecord()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置付款记录ID
        /// </summary>
        public Guid  ID { get; set; }
        /// <summary>
        /// 获取或设置单据类型
        /// </summary>
        public CustomerPaymentType ClassID { get; set; }
        /// <summary>
        /// 获取或设置创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 获取或设置单据编号
        /// </summary>
        public string SheetID { get; set; }
        /// <summary>
        /// 获取或设置付款客户ID
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 获取或设置到款账号
        /// </summary>
        public string AccountID { get; set; }
        /// <summary>
        /// 获取或设置付款金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 获取或设置已核销的金额
        /// </summary>
        public decimal Assigned { get; set; }
        /// <summary>
        /// 获取或设置送货单ID
        /// </summary>
        public string StackSheetID { get; set; }
        /// <summary>
        /// 获取或设置备注信息
        /// </summary>
        public string Memo { get; set; }
        #endregion

        /// <summary>
        /// 获取待抵消金额
        /// </summary>
        public decimal Remain
        {
            get { return Amount - Assigned; }
        }

        public AccountRecord Clone()
        {
            return this.MemberwiseClone() as AccountRecord;
        }
    }
}
