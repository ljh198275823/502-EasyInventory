using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory .BusinessModel .SearchCondition ;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.BLL
{
    public class SupplierBLL
    {
        public SupplierBLL(string repUri)
        {
            _RepoUri = repUri;
        }

        #region 私有方法
        private string _RepoUri;
        #endregion

        #region 公共方法
        public QueryResult<Supplier> GetByID(string id)
        {
            return ProviderFactory.Create<ISupplierProvider>(_RepoUri).GetByID(id);
        }

        public QueryResultList<Supplier> GetItems(SearchCondition con)
        {
            return ProviderFactory.Create<ISupplierProvider>(_RepoUri).GetItems(con);
        }

        public CommandResult Add(Supplier info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.SupplierPrefix, UserSettings.Current.SupplierSerialCount, "customer");
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                return ProviderFactory.Create<ISupplierProvider>(_RepoUri).Insert(info);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "创建供应商编号失败，请重试");
            }
        }

        public CommandResult Update(Supplier info)
        {
            Supplier original = ProviderFactory.Create<ISupplierProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original == null)
            {
                return new CommandResult(ResultCode.Fail, string.Format("系统中不存在 ID={0} 的供应商信息", info.ID));
            }
            return ProviderFactory.Create<ISupplierProvider>(_RepoUri).Update(info, original);
        }

        public CommandResult Delete(Supplier info)
        {
            return ProviderFactory.Create<ISupplierProvider>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
