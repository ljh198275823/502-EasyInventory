using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class TransportBLL : LJH.GeneralLibrary.Core.BLL.BLLBase<string, Transport>
    {
        #region 构造函数
        public TransportBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion
    }
}
