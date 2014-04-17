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
    public class ContactBLL
    {
        #region 构造函数
        public ContactBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        public QueryResultList<Contact> GetAll()
        {
            return ProviderFactory.Create<IContactProvider>(_RepoUri).GetItems(null);
        }

        public QueryResultList<Contact> GetItems(SearchCondition con)
        {
            return ProviderFactory.Create<IContactProvider>(_RepoUri).GetItems(con);
        }

        public CommandResult Add(Contact info)
        {
            return ProviderFactory.Create<IContactProvider>(_RepoUri).Insert(info);
        }

        public CommandResult Update(Contact info)
        {
            Contact original = ProviderFactory.Create<IContactProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original != null)
            {
                return ProviderFactory.Create<IContactProvider>(_RepoUri).Update(info, original);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "记录不存在");
            }
        }

        public CommandResult Delete(Contact info)
        {
            return ProviderFactory.Create<IContactProvider>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
