using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class CustomerSearchCondition : LJH.GeneralLibrary.DAL.SearchCondition
    {
        #region 公共属性
        /// <summary>
        /// 获取或设置查询条件中的客户编号
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 获取或设置客户类别,参考客户类中的ClassID属性
        /// </summary>
        public CustomerClass? ClassID { get; set; }
        /// <summary>
        /// 获取或设置客户类别
        /// </summary>
        public string Category { get; set; }
        #endregion
    }
}
