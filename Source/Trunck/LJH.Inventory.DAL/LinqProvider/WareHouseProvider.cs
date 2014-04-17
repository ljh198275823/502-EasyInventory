using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class WareHouseProvider : ProviderBase<WareHouse, string>, IWareHouseProvider
    {
        #region 构造函数
        public WareHouseProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr,ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override WareHouse GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<WareHouse>().SingleOrDefault(item => item.ID == id);
        }
        #endregion
    }
}
