using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class SteelRollSliceRecordBLL : BLLBase<Guid, SteelRollSliceRecord>
    {
        #region 构造函数
        public SteelRollSliceRecordBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 公共方法

        #endregion
    }
}
