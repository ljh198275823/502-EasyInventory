using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory .DAL .IProvider ;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class CustomerReceivableBLL : BLLBase<Guid, CustomerReceivable>
    {
        #region 构造函数
        public CustomerReceivableBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion
    }
}
