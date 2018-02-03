using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LJH.Inventory.BusinessModel
{
    public class AccountRecord : LJH.GeneralLibrary.Core.DAL.IEntity<Guid>
    {
        #region 构造函数
        public AccountRecord()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置付款记录ID
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置单据类型
        /// </summary>
        public CustomerPaymentType ClassID { get; set; }
        /// <summary>
        /// 获取或设置创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 获取或设置单据编号
        /// </summary>
        public string SheetID { get; set; }
        /// <summary>
        /// 获取或设置付款客户ID
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 获取或设置到款账号
        /// </summary>
        public string AccountID { get; set; }
        /// <summary>
        /// 获取或设置付款金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 获取或设置已核销的金额
        /// </summary>
        public decimal Assigned { get; set; }
        /// <summary>
        /// 获取或设置送货单ID
        /// </summary>
        public string StackSheetID { get; set; }
        /// <summary>
        /// 获取或设置对方账号
        /// </summary>
        public string OtherAccount { get; set; }
        /// <summary>
        /// 获取或设置备注信息
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

        /// <summary>
        /// 获取待抵消金额
        /// </summary>
        public decimal Remain
        {
            get { return Amount - Assigned; }
        }

        public AccountRecord Clone()
        {
            return this.MemberwiseClone() as AccountRecord;
        }
    }
}
