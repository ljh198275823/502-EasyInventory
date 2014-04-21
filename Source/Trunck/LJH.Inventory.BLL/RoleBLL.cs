using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class RoleBLL : LJH.GeneralLibrary.Core.BLL.BLLBase<string, Role>
    {
        #region 构造函数
        public RoleBLL(string repUri)
            : base(repUri)
        {

        }
        #endregion
    }
}
