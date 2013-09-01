using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示相关联系的公司，包括货代，保险，运输等公司
    /// </summary>
    public class RelatedCompany
    {
        #region 构造函数
        public RelatedCompany()
        {

        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置客户编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 获取或设置客户公司名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置简称
        /// </summary>
        public string ForeignName { get; set; }
        /// <summary>
        /// 获取或设置客户联系人
        /// </summary>
        public string Linker { get; set; }
        /// <summary>
        /// 获取或设置客户联系电话
        /// </summary>
        public string TelPhone { get; set; }
        /// <summary>
        /// 获取或设置客户手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 获取或设置客户传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 获取或设置邮政编码
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// 获取或设置QQ号
        /// </summary>
        public string QQ { get; set; }
        /// <summary>
        /// 获取或设置电子邮件
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 获取或设置公司网站
        /// </summary>
        public string Website { get; set; }
        /// <summary>
        /// 获取或设置客户地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 获取或设置相关银行账户信息
        /// </summary>
        public string BankInfo { get; set; }
        /// <summary>
        /// 获取或设置相关公司类型代码，如1表示货代公司，2表示船公司，3表示保险公司，4表示快递公司...
        /// </summary>
        public int CodeNum { get; set; }
        /// <summary>
        /// 获取或设置客户备注
        /// </summary>
        public string Memo { get; set; }
        #endregion
    }
}
