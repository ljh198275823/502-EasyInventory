using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class SysparameterInfo : LJH.GeneralLibrary.Core.DAL.IEntity<string>
    {
        #region 公共属性
        public string ID { get; set; }
        public string ParameterValue { get; set; }
        public string Description { get; set; }
        #endregion

        public SysparameterInfo(string para, string paraValue, string desc)
        {
            this.ID = para;
            this.ParameterValue = paraValue;
            this.Description = desc;
        }

        public SysparameterInfo()
        {
        }
    }
}
