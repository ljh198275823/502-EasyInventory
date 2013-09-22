using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.BLL
{
    public class RelatedCompanyTypeBLL
    {
        #region 构造函数
        public RelatedCompanyTypeBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        public QueryResultList<RelatedCompanyType> GetAll()
        {
            return ProviderFactory.Create<IRelatedCompanyTypeProvider>(_RepoUri).GetItems(null);
        }

        public CommandResult Add(RelatedCompanyType info)
        {
            return ProviderFactory.Create<IRelatedCompanyTypeProvider>(_RepoUri).Insert(info);
        }

        public CommandResult Update(RelatedCompanyType info)
        {
            RelatedCompanyType original = ProviderFactory.Create<IRelatedCompanyTypeProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original != null)
            {
                return ProviderFactory.Create<IRelatedCompanyTypeProvider>(_RepoUri).Update(info, original);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "记录不存在");
            }
        }

        public CommandResult Delete(RelatedCompanyType info)
        {
            return ProviderFactory.Create<IRelatedCompanyTypeProvider>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
