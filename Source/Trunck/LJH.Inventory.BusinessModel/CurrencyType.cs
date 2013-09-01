using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示一个货币种类
    /// </summary>
    [DataContract]
    [Serializable]
    public class CurrencyType
    {
        #region 构造函数
        public CurrencyType()
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
        /// 获取或设置符号
        /// </summary>
        [DataMember]
        public string Symbol { get; set; }
        /// <summary>
        /// 获取或设置汇率
        /// </summary>
        [DataMember]
        public decimal ExchangeRate { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        [DataMember]
        public string Memo { get; set; }
        #endregion
    }
}
