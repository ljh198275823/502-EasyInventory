using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class SupplierTypeProvider : ProviderBase<SupplierType, string>, ISupplierTypeProvider
    {
        #region 构造函数
        public SupplierTypeProvider(string connStr)
            : base(connStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override SupplierType GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<SupplierType>().SingleOrDefault(item => item.ID == id);
        }
        #endregion
    }
}

