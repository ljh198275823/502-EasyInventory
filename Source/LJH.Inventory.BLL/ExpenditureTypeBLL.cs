using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class ExpenditureTypeBLL : BLLBase<string, ExpenditureType>
    {
        #region 构造函数
        public ExpenditureTypeBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 公共方法
        public override CommandResult Delete(ExpenditureType info)
        {
            List<ExpenditureType> tps = ProviderFactory.Create<IProvider<ExpenditureType, string>>(RepoUri).GetItems(null).QueryObjects;
            if (tps != null && tps.Count > 0 && tps.Exists(item => item.Parent == info.ID))
            {
                return new CommandResult(ResultCode.Fail, "类别下已经有子类别，请先将所有子类别删除，再删除此类别");
            }
            return ProviderFactory.Create<IProvider<ExpenditureType, string>>(RepoUri).Delete(info);
        }
        #endregion
    }
}
