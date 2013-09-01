using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.BLL
{
    public class TransportBLL
    {
        #region 构造函数
        public TransportBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        public QueryResultList<Transport> GetAll()
        {
            ITransportProvider provider = ProviderFactory.Create<ITransportProvider>(_RepoUri);
            return provider.GetItems(null);
        }

        public CommandResult Add(Transport info)
        {
            return ProviderFactory.Create<ITransportProvider>(_RepoUri).Insert(info);
        }

        public CommandResult Update(Transport info)
        {
            Transport original = ProviderFactory.Create<ITransportProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original != null)
            {
                return ProviderFactory.Create<ITransportProvider>(_RepoUri).Update(info, original);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "记录不存在");
            }
        }

        public CommandResult Delete(Transport info)
        {
            return ProviderFactory.Create<ITransportProvider>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
