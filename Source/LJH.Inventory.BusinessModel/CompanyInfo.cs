﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary.SoftDog;
using Newtonsoft.Json;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示客户
    /// </summary>
    [Serializable]
    public class CompanyInfo : LJH.GeneralLibrary.Core.DAL.IEntity<string>
    {
        public static string 财务上不存在的客户 = "00000000";

        #region 构造函数
        public CompanyInfo()
        {
        }
        #endregion

        #region 私有变量
        public readonly string DocumentType = "CompanyInfo";
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
        /// 获取或设置默认联系人
        /// </summary>
        public Guid? DefaultLinker { get; set; }
        /// <summary>
        /// 获取或设置客户的归档码
        /// </summary>
        public int? FileID { get; set; }
        /// <summary>
        /// 获取或设置客户的税务归档码
        /// </summary>
        public int? TaxFileID { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        public string Memo { get; set; }
        #endregion

        #region 扩展属性
        /// <summary>
        /// 获取或设置扩展属性
        /// </summary>
        public string Note { get; set; }

        private Dictionary<string, string> _Externals = null;

        public string GetProperty(string key)
        {
            if (_Externals == null && !string.IsNullOrEmpty(Note)) _Externals = JsonConvert.DeserializeObject<Dictionary<string, string>>(Note);
            if (_Externals == null) return null;
            if (_Externals.ContainsKey(key)) return _Externals[key];
            return null;
        }

        public void SetProperty(string key, string value)
        {
            if (_Externals == null && !string.IsNullOrEmpty(Note)) _Externals = JsonConvert.DeserializeObject<Dictionary<string, string>>(Note);
            if (_Externals == null) _Externals = new Dictionary<string, string>();
            if (value == null && _Externals.ContainsKey(key)) _Externals.Remove(key);
            else _Externals[key] = value;
            Note = JsonConvert.SerializeObject(_Externals);
        }

        public void RemoveProperty(string key)
        {
            if (_Externals == null && !string.IsNullOrEmpty(Note)) _Externals = JsonConvert.DeserializeObject<Dictionary<string, string>>(Note);
            if (_Externals == null) return;
            if (_Externals.ContainsKey(key)) _Externals.Remove(key);
            Note = JsonConvert.SerializeObject(_Externals);
        }
        #endregion

        #region 公共方法
        public CompanyInfo Clone()
        {
            var ret = MemberwiseClone() as CompanyInfo;
            ret._Externals = null;
            return ret;
        }
        #endregion
    }
}
