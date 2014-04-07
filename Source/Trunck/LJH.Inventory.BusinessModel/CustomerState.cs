using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示客户的财务状况
    /// </summary>
    public class CustomerState
    {
        #region 构造函数
        public CustomerState()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置客户ID
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 获取或设置客户预付款
        /// </summary>
        public decimal Prepay { get; set; }
        /// <summary>
        /// 获取或设置客户应收款
        /// </summary>
        public decimal Receivable { get; set; }
        #endregion
    }
}
