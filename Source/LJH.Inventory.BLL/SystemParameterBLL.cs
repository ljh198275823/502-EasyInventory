using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class SystemParameterBLL : BLLBase<string, SysparameterInfo>
    {
        #region 构造函数
        public SystemParameterBLL(string repUri)
            : base(repUri)
        {
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 保存参数
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public CommandResult Save(SysparameterInfo parameter)
        {
            SysparameterInfo original = ProviderFactory.Create<IProvider<SysparameterInfo, string>>(_RepoUri).GetByID(parameter.ID).QueryObject;
            if (original != null)
            {
                return ProviderFactory.Create<IProvider<SysparameterInfo, string>>(_RepoUri).Update(parameter, original);
            }
            else
            {
                return ProviderFactory.Create<IProvider<SysparameterInfo, string>>(_RepoUri).Insert(parameter);
            }
        }

        public override CommandResult Add(SysparameterInfo info)
        {
            return Save(info);
        }
        #endregion
    }
}
