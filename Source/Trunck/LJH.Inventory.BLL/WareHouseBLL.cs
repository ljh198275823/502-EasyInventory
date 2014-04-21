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
    public class WareHouseBLL : LJH.GeneralLibrary.Core.BLL.BLLBase<string, WareHouse>
    {
        #region 构造函数
        public WareHouseBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 公共方法

        public override CommandResult Add(WareHouse info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.WareHousePrefix, UserSettings.Current.WareHouseSerialCount, "warehouse");
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                return base.Add(info);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "创建仓库编号失败，请重试");
            }
        }
        #endregion
    }
}
