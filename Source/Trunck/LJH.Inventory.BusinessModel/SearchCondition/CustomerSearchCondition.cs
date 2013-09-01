using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class CustomerSearchCondition : SearchCondition
    {
        #region 公共属性
        /// <summary>
        /// 获取或设置查询条件中的客户编号
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 获取或设置查询条件中的用户名
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 获取或设置查询条件中的联系人
        /// </summary>
        public string Linker { get; set; }
        /// <summary>
        ///  获取或设置查询条件中的联系电话
        /// </summary>
        public string TelPhone { get; set; }
        /// <summary>
        ///  获取或设置查询条件中的手机
        /// </summary>
        public string Mobile { get; set; }
        ///// <summary>
        /////  获取或设置查询条件中的是否有应收账款
        ///// </summary>
        //public bool? Credit{get;set;}
        #endregion
    }
}
