using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.BLL
{
    public class SupplierTypeBLL
    {
        #region 构造函数
        public SupplierTypeBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        public QueryResultList<SupplierType> GetAll()
        {
            return ProviderFactory.Create<ISupplierTypeProvider>(_RepoUri).GetItems(null);
        }

        public CommandResult Add(SupplierType info)
        {
            return ProviderFactory.Create<ISupplierTypeProvider>(_RepoUri).Insert(info);
        }

        public CommandResult Update(SupplierType info)
        {
            SupplierType original = ProviderFactory.Create<ISupplierTypeProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original != null)
            {
                return ProviderFactory.Create<ISupplierTypeProvider>(_RepoUri).Update(info, original);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "记录不存在");
            }
        }

        public CommandResult Delete(SupplierType info)
        {
            return ProviderFactory.Create<ISupplierTypeProvider>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
