using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.BLL
{
    public class SystemParameterBLL
    {
        #region 构造函数
        public SystemParameterBLL(string repUri)
        {
            provider = ProviderFactory.Create<ISysParameterProvider>(repUri);
        }
        #endregion

        #region 私有变量
        private ISysParameterProvider provider;
        #endregion

        #region 公共方法
        public QueryResult<SysparameterInfo> GetSysParameterByID(string id)
        {
            return provider.GetByID(id);
        }

        public CommandResult Insert(SysparameterInfo info)
        {
            return provider.Insert(info);
        }
        #endregion
    }
}
