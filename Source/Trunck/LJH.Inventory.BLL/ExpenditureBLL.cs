using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.BLL
{
    public class ExpenditureTypeBLL
    {
        #region 构造函数
        public ExpenditureTypeBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        public QueryResultList<ExpenditureType> GetAll()
        {
            return ProviderFactory.Create<IExpenditureTypeProvider>(_RepoUri).GetItems(null);
        }

        public CommandResult Add(ExpenditureType info)
        {
            return ProviderFactory.Create<IExpenditureTypeProvider>(_RepoUri).Insert(info);
        }

        public CommandResult Update(ExpenditureType info)
        {
            ExpenditureType original = ProviderFactory.Create<IExpenditureTypeProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original != null)
            {
                return ProviderFactory.Create<IExpenditureTypeProvider>(_RepoUri).Update(info, original);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "记录不存在");
            }
        }

        public CommandResult Delete(ExpenditureType info)
        {
            return ProviderFactory.Create<IExpenditureTypeProvider>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
