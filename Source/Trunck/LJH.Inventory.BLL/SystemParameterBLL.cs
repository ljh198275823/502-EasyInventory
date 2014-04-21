using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class SystemParameterBLL : LJH.GeneralLibrary.Core.BLL.BLLBase<string, SysparameterInfo>
    {
        #region 构造函数
        public SystemParameterBLL(string repUri)
            : base(repUri)
        {
        }
        #endregion
    }
}
