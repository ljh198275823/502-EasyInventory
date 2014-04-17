using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.BLL
{
    public class PriceTermBLL
    {
        #region 构造函数
        public PriceTermBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        public QueryResultList<PriceTerm> GetAll()
        {
            return ProviderFactory.Create<IPriceTermProvider>(_RepoUri).GetItems(null);
        }

        public CommandResult Add(PriceTerm info)
        {
            return ProviderFactory.Create<IPriceTermProvider>(_RepoUri).Insert(info);
        }

        public CommandResult Update(PriceTerm info)
        {
            PriceTerm original = ProviderFactory.Create<IPriceTermProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original != null)
            {
                return ProviderFactory.Create<IPriceTermProvider>(_RepoUri).Update(info, original);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "记录不存在");
            }
        }

        public CommandResult Delete(PriceTerm info)
        {
            return ProviderFactory.Create<IPriceTermProvider>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
