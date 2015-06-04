using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class YouhuiQuanBLL : BLLBase<string, YouhuiQuan>
    {
        #region 构造函数
        public YouhuiQuanBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 优惠券使用
        /// </summary>
        /// <param name="id"></param>
        /// <param name="proxyID"></param>
        /// <returns></returns>
        public CommandResult AssignTo(string id, string proxyID)
        {
            YouhuiQuan item = GetByID(id).QueryObject;
            if (item == null) return new CommandResult(ResultCode.Fail, string.Format("ID={0} 的优惠券不存在", id));
            if (!string.IsNullOrEmpty(item.Proxy)) return new CommandResult(ResultCode.Fail, string.Format("ID={0} 的优惠券已经被使用", id));
            CompanyInfo proxy = ProviderFactory.Create<IProvider<CompanyInfo, string>>(RepoUri).GetByID(proxyID).QueryObject;
            if (proxy == null) return new CommandResult(ResultCode.Fail, string.Format("ID={0} 的代理商不存在", proxyID));
            YouhuiQuan original = item.Clone();
            item.Proxy = proxyID;
            item.ComsumeDate = DateTime.Now;
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            ProviderFactory.Create<IProvider<YouhuiQuan, string>>(RepoUri).Update(item, original, unitWork);
            return unitWork.Commit();
        }
        #endregion
    }
}
