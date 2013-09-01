using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using LJH.Inventory .BusinessModel;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class ProductCategoryProvider : ProviderBase<ProductCategory, string>, IProductCategoryProvider
    {
        #region 构造函数
        public ProductCategoryProvider(string conStr)
            : base(conStr)
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
