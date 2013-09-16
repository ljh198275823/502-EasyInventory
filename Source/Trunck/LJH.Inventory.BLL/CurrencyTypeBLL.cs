using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.BLL
{
    public class CurrencyTypeBLL
    {
        #region 构造函数
        public CurrencyTypeBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        public QueryResult<CurrencyType> GetByID(string id)
        {
            return ProviderFactory.Create<ICurrencyTypeProvider>(_RepoUri).GetByID(id);
        }

        public QueryResultList<CurrencyType> GetAll()
        {
            return ProviderFactory.Create<ICurrencyTypeProvider>(_RepoUri).GetItems(null);
        }

        public CommandResult Add(CurrencyType info)
        {
            return ProviderFactory.Create<ICurrencyTypeProvider>(_RepoUri).Insert(info);
        }

        public CommandResult Update(CurrencyType info)
        {
            CurrencyType original = ProviderFactory.Create<ICurrencyTypeProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original != null)
            {
                return ProviderFactory.Create<ICurrencyTypeProvider>(_RepoUri).Update(info, original);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "记录不存在");
            }
        }

        public CommandResult Delete(CurrencyType info)
        {
            return ProviderFactory.Create<ICurrencyTypeProvider>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
