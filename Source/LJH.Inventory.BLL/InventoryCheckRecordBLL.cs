using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .DAL .IProvider ;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class InventoryCheckRecordBLL : BLLBase<Guid, InventoryCheckRecord>
    {
        #region 构造函数
        public InventoryCheckRecordBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion
    }
}
