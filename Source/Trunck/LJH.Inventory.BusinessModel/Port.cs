using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示港口
    /// </summary>
    [DataContract]
    [Serializable]
    public class Port : LJH.GeneralLibrary.Core.DAL.IEntity<string>
    {
        #region 构造函数
        public Port()
        {
        }
        #endregion

        #region 公共属性
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
        /// 获取或设置是否是国外港口
        /// </summary>
        [DataMember]
        public bool IsForeign { get; set; }
        /// <summary>
        /// 获取或设置所在国家
        /// </summary>
        [DataMember]
        public string Country { get; set; }
        /// <summary>
        /// 获取或设置所在地区（省份)
        /// </summary>
        [DataMember]
        public string Region { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        [DataMember]
        public string Memo { get; set; }
        #endregion
    }
}
