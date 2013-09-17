using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LJH.Inventory.BusinessModel
{
    public class Attachment
    {
        #region 构造函数

        #endregion

        #region 公共属性
        public Guid ID { get; set; }

        public byte[] Value { get; set; }
        #endregion
    }
}
