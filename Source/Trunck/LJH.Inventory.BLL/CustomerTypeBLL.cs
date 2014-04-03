using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;

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
            ICustomerProvider sp = ProviderFactory.Create<ICustomerProvider>(_RepoUri);
            CustomerSearchCondition con = new CustomerSearchCondition() { ClassID = CustomerClass.Customer, Category = info.ID };
            if (sp.GetItems(con).QueryObjects.Count > 0)
            {
                return new CommandResult(ResultCode.Fail, "此类别不能删除，已经有客户归到此类别，如果确实要删除此类别，请先更改相关客户的所属类别");
            }
            return ProviderFactory.Create<ICustomerTypeProvider>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
