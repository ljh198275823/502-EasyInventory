using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.BLL
{
    public class CustomerTypeBLL
    {
        #region 构造函数
        public CustomerTypeBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        public QueryResultList<CustomerType> GetAll()
        {
            return ProviderFactory.Create<ICustomerTypeProvider>(_RepoUri).GetItems(null);
        }

        public CommandResult Add(CustomerType info)
        {
            return ProviderFactory.Create<ICustomerTypeProvider>(_RepoUri).Insert(info);
        }

        public CommandResult Update(CustomerType info)
        {
            CustomerType original = ProviderFactory.Create<ICustomerTypeProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original != null)
            {
                return ProviderFactory.Create<ICustomerTypeProvider>(_RepoUri).Update(info, original);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "记录不存在");
            }
        }

        public CommandResult Delete(CustomerType info)
        {
            return ProviderFactory.Create<ICustomerTypeProvider>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
