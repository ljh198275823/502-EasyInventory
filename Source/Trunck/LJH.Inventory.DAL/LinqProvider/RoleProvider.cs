using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class RoleProvider:ProviderBase <Role,string> ,IRoleProvider
    {
        public RoleProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms):base(connStr,ms)
        {
        }

        #region 重写模板方法
        protected override Role GetingItemByID(string id, DataContext dc)
        {
            return dc.GetTable <Role>().SingleOrDefault(r => r.ID == id);
        }
        #endregion
    }
}
