using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class SupplierSearchCondition : LJH.GeneralLibrary.DAL.SearchCondition
    {
        /// <summary>
        /// 获取或设置查询条件中的客户编号
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 获取或设置查询条件中的用户名
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        ///  获取或设置查询条件中的联系电话
        /// </summary>
        public string TelPhone { get; set; }
    }
}
