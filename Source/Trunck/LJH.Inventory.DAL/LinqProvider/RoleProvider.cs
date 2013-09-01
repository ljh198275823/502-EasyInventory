using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class RoleProvider:ProviderBase <RoleInfo,string> ,IRoleProvider
    {
        public RoleProvider(string connStr):base(connStr)
        {
        }

        #region 重写模板方法
        protected override RoleInfo GetingItemByID(string id, DataContext dc)
        {
            return dc.GetTable <RoleInfo>().SingleOrDefault(r => r.RoleID == id);
        }
        #endregion
    }
}
