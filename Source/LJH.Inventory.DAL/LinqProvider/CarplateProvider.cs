using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class CarplateProvider : ICarplateProvider
    {
        #region 构造函数
        public CarplateProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
        {
            ConnectStr = connStr;
            _MappingSource = ms;
        }
        #endregion

        #region 私有变量
        private string ConnectStr;
        private System.Data.Linq.Mapping.MappingSource _MappingSource = null;
        #endregion

        #region 公共方法
        public List<string> GetItems()
        {
            DataContext dc = DataContextFactory.CreateDataContext(ConnectStr, _MappingSource);
            IQueryable<ProductInventoryItem> pis = dc.GetTable<ProductInventoryItem>();
            var ret = (from it in pis
                       orderby it.AddDate descending
                       select it.Carplate).Distinct().ToList();
            return ret;
        }
        #endregion
    }

    public class MaterialProvider : IMaterialProvider
    {
        #region 构造函数
        public MaterialProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
        {
            ConnectStr = connStr;
            _MappingSource = ms;
        }
        #endregion

        #region 私有变量
        private string ConnectStr;
        private System.Data.Linq.Mapping.MappingSource _MappingSource = null;
        #endregion

        #region 公共方法
        public List<string> GetItems()
        {
            DataContext dc = DataContextFactory.CreateDataContext(ConnectStr, _MappingSource);
            var pis = dc.GetTable<Product>().ToList();
            var ret = (from it in pis
                       orderby it.材质 ascending
                       select it.材质).Distinct().ToList();
            return ret;
        }
        #endregion
    }
}
