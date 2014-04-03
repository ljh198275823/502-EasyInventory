using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class RelatedCompanyType
    {
        #region 构造函数
        public RelatedCompanyType()
        {
        }
        #endregion

        #region 公共属性
        public string ID { get; set; }

        public string Name { get; set; }

        public string Parent { get; set; }

        public string Memo { get; set; }
        #endregion
    }
}

