using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.DAL;

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

        public QueryResult<RelatedCompanyType> GetByID(string id)
        {
            return ProviderFactory.Create<IRelatedCompanyTypeProvider>(_RepoUri).GetByID(id);
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
            ICustomerProvider sp = ProviderFactory.Create<ICustomerProvider>(_RepoUri);
            CustomerSearchCondition con = new CustomerSearchCondition() { ClassID = CustomerClass.Other, Category = info.ID };
            if (sp.GetItems(con).QueryObjects.Count > 0)
            {
                return new CommandResult(ResultCode.Fail, "此类别不能删除，已经有相关公司归到此类别，如果确实要删除此类别，请先更改相关相关公司的所属类别");
            }
            return ProviderFactory.Create<IRelatedCompanyTypeProvider>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
