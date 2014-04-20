using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示价格条款
    /// </summary>
    [DataContract]
    [Serializable]
    public class PriceTerm : LJH.GeneralLibrary.DAL.IEntity<string>
    {
        #region 构造函数
        public PriceTerm()
        {
        }
        #endregion

        #region  公共属性
        /// <summary>
        /// 获取或设置ID
        /// </summary>
        [DataMember]
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        [DataMember]
        public string Memo { get; set; }
        #endregion
    }
}
