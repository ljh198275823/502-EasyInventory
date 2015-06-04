using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LJH.InventoryWeb.Models
{
    public class Appsetting
    {
        public static Appsetting Current { get; set; }


        public Appsetting()
        {
        }

        #region 公共属性
        public string ConnStr { get; set; }
        #endregion
    }
}