using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示公司联系人
    /// </summary>
    public class Contact : LJH.GeneralLibrary.DAL.IEntity<int>
    {
        #region 构造函数
        public Contact()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 获取或设置联系人名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置联系人职位
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 获取或设置所在公司
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 获取或设置联系电话
        /// </summary>
        public string TelPhone { get; set; }
        /// <summary>
        /// 获取或设置手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 获取或设置传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 获取或设置QQ号
        /// </summary>
        public string QQ { get; set; }
        /// <summary>
        /// 获取或设置电子邮件
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        public string Memo { get; set; }
        #endregion
    }
}
