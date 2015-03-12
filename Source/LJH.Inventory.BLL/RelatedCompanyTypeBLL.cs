using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class RelatedCompanyTypeBLL : BLLBase<string, RelatedCompanyType>
    {
        #region 构造函数
        public RelatedCompanyTypeBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 公共方法
        public override CommandResult Delete(RelatedCompanyType info)
        {
            List<RelatedCompanyType> tps = ProviderFactory.Create<IProvider<RelatedCompanyType, string>>(_RepoUri).GetItems(null).QueryObjects;
            if (tps != null && tps.Count > 0 && tps.Exists(item => item.Parent == info.ID))
            {
                return new CommandResult(ResultCode.Fail, "客户类别下已经有子类别，请先将所有子类别删除，再删除此类别");
            }
            IProvider<CompanyInfo, string> sp = ProviderFactory.Create<IProvider<CompanyInfo, string>>(_RepoUri);
            CustomerSearchCondition con = new CustomerSearchCondition() { ClassID = CompanyClass.Other, Category = info.ID };
            if (sp.GetItems(con).QueryObjects.Count > 0)
            {
                return new CommandResult(ResultCode.Fail, "已经有客户归到此类别，如果确实要删除此类别，请先更改相关客户的所属类别");
            }
            return ProviderFactory.Create<IProvider<RelatedCompanyType, string>>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
