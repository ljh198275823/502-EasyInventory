using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class UnitProvider : ProviderBase<Unit, string>
    {
        #region 构造函数
        public UnitProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override Unit GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<Unit>().SingleOrDefault(item => item.ID == id);
        }
        #endregion
    }
}
