using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class UnitBLL : LJH.GeneralLibrary.Core.BLL.BLLBase<string, Unit>
    {
        #region 构造函数
        public UnitBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion
    }
}
