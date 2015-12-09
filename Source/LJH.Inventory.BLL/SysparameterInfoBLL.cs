using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.GeneralLibrary .Core .DAL ;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.BLL
{
    public class SysparameterInfoBLL : BLLBase<string, LJH.Inventory.BusinessModel.SysparameterInfo>
    {
        public SysparameterInfoBLL(string repoUri)
            : base(repoUri)
        {
        }

        #region 公共方法
        public CommandResult Save(SysparameterInfo info)
        {
            var original = GetByID(info.ID).QueryObject;
            if (original == null)
            {
                return ProviderFactory.Create<IProvider<SysparameterInfo, string>>(RepoUri).Insert(info);
            }
            else
            {
                return ProviderFactory.Create<IProvider<SysparameterInfo, string>>(RepoUri).Update(info, original);
            }
        }
        #endregion
    }
}
