using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class ContactBLL : BLLBase<int, Contact>
    {
        #region 构造函数
        public ContactBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion
    }
}
