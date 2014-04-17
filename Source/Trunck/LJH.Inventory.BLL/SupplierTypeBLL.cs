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

        public QueryResult<SupplierType> GetByID(string id)
        {
            return ProviderFactory.Create<ISupplierTypeProvider>(_RepoUri).GetByID(id);
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
            ICustomerProvider sp = ProviderFactory.Create<ICustomerProvider>(_RepoUri);
            CustomerSearchCondition con = new CustomerSearchCondition() { ClassID = CustomerClass.Supplier, Category = info.ID };
            if (sp.GetItems(con).QueryObjects.Count > 0)
            {
                return new CommandResult(ResultCode.Fail, "此类别不能删除，已经有供应商归到此类别，如果确实要删除此类别，请先更改相关供应商的所属类别");
            }
            return ProviderFactory.Create<ISupplierTypeProvider>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
