using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
