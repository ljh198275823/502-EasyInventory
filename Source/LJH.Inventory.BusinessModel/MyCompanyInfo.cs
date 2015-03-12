using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LJH.Inventory.BusinessModel
{
    [DataContract]
    public class MyCompanyInfo
    {
        #region 静态属性
        public MyCompanyInfo Current { get; set; }
        #endregion 

        #region 构造函数
        public MyCompanyInfo()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置编号
        /// </summary>
       [DataMember ]
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置客户公司名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置所在国家
        /// </summary>
       [DataMember]
        public string Nation { get; set; }
        /// <summary>
        /// 获取或设置所在城市
        /// </summary>
        [DataMember]
        public string City { get; set; }
        /// <summary>
        /// 获取或设置类别
        /// </summary>
        [DataMember]
        public string Category { get; set; }
        /// <summary>
        /// 获取或设置联系电话
        /// </summary>
        [DataMember]
        public string TelPhone { get; set; }
        /// <summary>
        /// 获取或设置传真
        /// </summary>
        [DataMember]
        public string Fax { get; set; }
        /// <summary>
        /// 获取或设置网站
        /// </summary>
        [DataMember]
        public string Website { get; set; }
        /// <summary>
        /// 获取或设置邮政编码
        /// </summary>
        [DataMember]
        public string PostalCode { get; set; }
        /// <summary>
        /// 获取或设置地址
        /// </summary>
        [DataMember]
        public string Address { get; set; }
        /// <summary>
        /// 获取或设置开户行
        /// </summary>
       [DataMember]
        public string Bank { get; set; }
        /// <summary>
        /// 获取或设置银行账号
        /// </summary>
        [DataMember]
        public string BankAccount { get; set; }
        /// <summary>
        /// 获取或设置SwiftNo
        /// </summary>
        [DataMember]
        public string SwiftNO { get; set; }
        /// <summary>
        /// 获取或设置信用限额
        /// </summary>
        [DataMember]
        public decimal CreditLine { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        [DataMember]
        public string Memo { get; set; }
        #endregion
    }
}
