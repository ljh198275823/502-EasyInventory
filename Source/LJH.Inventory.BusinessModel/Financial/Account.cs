using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LJH.Inventory.BusinessModel
{
    public class Account : LJH.GeneralLibrary.Core.DAL.IEntity<string>
    {
        #region 构造函数
        public Account()
        {
        }
        #endregion

        #region 公共属性
        public string ID { get; set; }

        public AccountType Class { get; set; }

        public string Name { get; set; }
        /// <summary>
        /// 获取或设置是否是对公账号
        /// </summary>
        public bool Ispublic { get; set; }

        public string Operator { get; set; }

        public DateTime AddDate { get; set; }

        public decimal Amount { get; set; }

        public string Memo { get; set; }
        #endregion

        #region 扩展属性
        /// <summary>
        /// 获取或设置扩展属性
        /// </summary>
        public string Note { get; set; }

        private Dictionary<string, string> _Externals = null;

        public string GetProperty(SheetNote pn)
        {
            if (_Externals == null && !string.IsNullOrEmpty(Note)) _Externals = JsonConvert.DeserializeObject<Dictionary<string, string>>(Note);
            if (_Externals == null) return null;
            if (_Externals.ContainsKey(((int)pn).ToString())) return _Externals[((int)pn).ToString()];
            if (_Externals.ContainsKey(pn.ToString())) return _Externals[pn.ToString()];
            return null;
        }

        public void SetProperty(SheetNote pn, string value)
        {
            var key = ((int)pn).ToString();
            if (_Externals == null && !string.IsNullOrEmpty(Note)) _Externals = JsonConvert.DeserializeObject<Dictionary<string, string>>(Note);
            if (_Externals == null) _Externals = new Dictionary<string, string>();
            if (value == null && _Externals.ContainsKey(key)) _Externals.Remove(key);
            else _Externals[key] = value;
            Note = JsonConvert.SerializeObject(_Externals);
        }

        public void RemoveProperty(SheetNote pn)
        {
            var key = ((int)pn).ToString();
            if (_Externals == null && !string.IsNullOrEmpty(Note)) _Externals = JsonConvert.DeserializeObject<Dictionary<string, string>>(Note);
            if (_Externals == null) return;
            if (_Externals.ContainsKey(key)) _Externals.Remove(key);
            Note = JsonConvert.SerializeObject(_Externals);
        }
        #endregion
    }
}
