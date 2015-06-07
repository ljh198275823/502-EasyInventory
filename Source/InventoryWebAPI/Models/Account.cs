using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LJH.InventoryWebAPI.Models
{
    public class Account
    {
        #region 构造函数
        public Account() { }
        #endregion

        #region 公共属性
        public string UserName { get; set; }
        
        //public string Email { get; set; }

        public string Password { get; set; }
        #endregion
    }
}