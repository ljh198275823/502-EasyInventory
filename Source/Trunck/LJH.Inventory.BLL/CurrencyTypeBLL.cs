using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class CurrencyTypeBLL : BLLBase<string, CurrencyType>
    {
        #region 构造函数
        public CurrencyTypeBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion
    }
}
