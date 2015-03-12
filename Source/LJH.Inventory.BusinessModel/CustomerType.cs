using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示客户类别
    /// </summary>
    public class CustomerType : LJH.GeneralLibrary.Core.DAL.IEntity<string>
    {
        #region 构造函数
        public CustomerType()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置客户类别ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置客户类别名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置父类别
        /// </summary>
        public string Parent { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        public string Memo { get; set; }
        #endregion
    }
}
