using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary.SoftDog;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示客户
    /// </summary>
    [Serializable]
    public class CompanyInfo : LJH.GeneralLibrary.Core.DAL.IEntity<string>
    {
        #region 构造函数
        public CompanyInfo()
        {
        }
        #endregion

        #region 私有变量
        public readonly string DocumentType = "CompanyInfo";

        private string _Password;
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置客户公司名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置简称
        /// </summary>
        public string ForeignName { get; set; }
        /// <summary>
        /// 获取或设置信用限额
        /// </summary>
        public decimal CreditLine { get; set; }
        /// <summary>
        /// 获取或设置相关公司类型代码，如1表示货代公司，2表示船公司，3表示保险公司，4表示快递公司 ,5表示客户，6表示供应商...
        /// </summary>
        public CompanyClass ClassID { get; set; }
        /// <summary>
        /// 获取或设置所在国家
        /// </summary>
        public string Nation { get; set; }
        /// <summary>
        /// 获取或设置所在城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 获取或设置类别
        /// </summary>
        public string CategoryID { get; set; }
        /// <summary>
        /// 获取或设置联系电话
        /// </summary>
        public string TelPhone { get; set; }
        /// <summary>
        /// 获取或设置传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 获取或设置邮政编码
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// 获取或设置网站
        /// </summary>
        public string Website { get; set; }
        /// <summary>
        /// 获取或设置电子邮件
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 获取或设置地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 获取或设置客户的归档码
        /// </summary>
        public int? FileID { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        public string Memo { get; set; }
        #endregion

        #region 公共方法
        public CompanyInfo Clone()
        {
            return MemberwiseClone() as CompanyInfo;
        }
        #endregion
    }
}
