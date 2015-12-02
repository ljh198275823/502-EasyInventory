using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using LJH.Inventory .BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class ProductCategoryProvider : ProviderBase<ProductCategory, string>
    {
        #region 构造函数
        public ProductCategoryProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr,ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override ProductCategory GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<ProductCategory>().SingleOrDefault(item => item.ID == id);
        }
        #endregion
    }
}
