using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class T_CustomerReceivable
    {
        #region 构造函数
        public T_CustomerReceivable()
        {
        }

        public T_CustomerReceivable(CustomerReceivable cr)
        {
            this.ID = cr.ID;
            this.CustomerID = cr.CustomerID;
            this.CreateDate = cr.CreateDate;
            this.Amount = cr.Amount;
            this.Memo = cr.Memo;
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置单据号
        /// </summary>
        public string ID { get; set; }
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
    }
}
