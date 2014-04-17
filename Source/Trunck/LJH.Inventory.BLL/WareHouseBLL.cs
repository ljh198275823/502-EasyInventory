using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.BLL
{
    public class WareHouseBLL
    {
        #region 构造函数
        public WareHouseBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        public QueryResult<WareHouse> GetByID(string id)
        {
            return ProviderFactory.Create<IWareHouseProvider>(_RepoUri).GetByID(id);
        }

        public QueryResultList<WareHouse> GetAll()
        {
            return ProviderFactory.Create<IWareHouseProvider>(_RepoUri).GetItems(null);
        }

        public CommandResult Add(WareHouse info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.WareHousePrefix, UserSettings.Current.WareHouseSerialCount, "warehouse");
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                return ProviderFactory.Create<IWareHouseProvider>(_RepoUri).Insert(info);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "创建仓库编号失败，请重试");
            }
        }

        public CommandResult Update(WareHouse info)
        {
            WareHouse original = ProviderFactory.Create<IWareHouseProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original == null)
            {
                return new CommandResult(ResultCode.Fail, "系统中不存在ID为 " + info.ID + " 的仓库信息");
            }
            return ProviderFactory.Create<IWareHouseProvider>(_RepoUri).Update(info, original);
        }

        public CommandResult Delete(WareHouse info)
        {
            return ProviderFactory.Create<IWareHouseProvider>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
