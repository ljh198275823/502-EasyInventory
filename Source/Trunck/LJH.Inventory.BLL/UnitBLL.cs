using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.BLL
{
    public class UnitBLL
    {
        #region 构造函数
        public UnitBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        public QueryResultList<Unit> GetAll()
        {
            return ProviderFactory.Create<IUnitProvider>(_RepoUri).GetItems(null);
        }

        public CommandResult Add(Unit info)
        {
            return ProviderFactory.Create<IUnitProvider>(_RepoUri).Insert(info);
        }

        public CommandResult Update(Unit info)
        {
            Unit original = ProviderFactory.Create<IUnitProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original != null)
            {
                return ProviderFactory.Create<IUnitProvider>(_RepoUri).Update(info, original);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "记录不存在");
            }
        }

        public CommandResult Delete(Unit info)
        {
            return ProviderFactory.Create<IUnitProvider>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
