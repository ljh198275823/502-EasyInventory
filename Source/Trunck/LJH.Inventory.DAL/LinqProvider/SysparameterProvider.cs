using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Linq;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class SysparameterProvider : ProviderBase<SysparameterInfo,string>, ISysParameterProvider
    {
        public SysparameterProvider(string connStr)
            : base(connStr)
        {
        }

        #region 重写模板方法
        protected override SysparameterInfo GetingItemByID(string id, DataContext dc)
        {
            return dc.GetTable<SysparameterInfo>().SingleOrDefault(s => s.Parameter == id);
        }

        protected override void InsertingItem(SysparameterInfo info,DataContext dc)
        {
            string cmd = string.Format(@"delete Sysparameter where Parameter='{0}' " +
                       "insert into SysParameter (Parameter,ParameterValue,Description) " +
                       "values ('{1}','{2}','{3}')", info.Parameter, info.Parameter, info.ParameterValue, info.Description);
            dc.ExecuteCommand(cmd);
        }
        #endregion
    }
}