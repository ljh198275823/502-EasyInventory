using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using LJH.Inventory.BusinessModel;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class DepartmentProvider : ProviderBase<Department, string>
    {
        #region 构造函数
        public DepartmentProvider(string connStr, MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override Department GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<Department>().SingleOrDefault(item => item.ID == id);
        }
        #endregion
    }
}
