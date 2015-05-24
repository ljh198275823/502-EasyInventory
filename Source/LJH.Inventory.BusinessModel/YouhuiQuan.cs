using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示优惠券
    /// </summary>
    public class YouhuiQuan:LJH.GeneralLibrary .Core.DAL.IEntity <string>
    {
        #region 构造函数
        public YouhuiQuan() { }
        #endregion

        #region 公共属性
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置优惠券所属的优惠活动
        /// </summary>
        public string YouhuiID { get; set; }
        /// <summary>
        /// 获取或设置券的持有者
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// 获取或设置券的创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 获取或设置券的优惠金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 获取或设置券的过期时间
        /// </summary>
        public DateTime? ExpireDate { get; set; }
        /// <summary>
        /// 获取或设置券兑换的代理商
        /// </summary>
        public string Proxy { get; set; }
        /// <summary>
        /// 获取或设置券的兑换日期
        /// </summary>
        public DateTime? ComsumeDate { get; set; }

        public string Memo { get; set; }
        #endregion
    }
}
