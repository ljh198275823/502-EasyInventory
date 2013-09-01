using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.BLL
{
    public class CollectionTypeBLL
    {
        #region 构造函数
        public CollectionTypeBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        public QueryResultList<CollectionType> GetAll()
        {
            ICollectionTypeProvider provider = ProviderFactory.Create<ICollectionTypeProvider>(_RepoUri);
            return provider.GetItems(null);
        }

        public CommandResult Add(CollectionType info)
        {
            return ProviderFactory.Create<ICollectionTypeProvider>(_RepoUri).Insert(info);
        }

        public CommandResult Update(CollectionType info)
        {
            CollectionType original = ProviderFactory.Create<ICollectionTypeProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original != null)
            {
                return ProviderFactory.Create<ICollectionTypeProvider>(_RepoUri).Update(info, original);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "记录不存在");
            }
        }

        public CommandResult Delete(CollectionType info)
        {
            return ProviderFactory.Create<ICollectionTypeProvider>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
