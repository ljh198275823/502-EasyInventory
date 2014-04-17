using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class ProductProvider : ProviderBase<Product, string>, IProductProvider
    {
        #region 构造函数
        public ProductProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr,ms)
        {

        }
        #endregion

        #region 重写基类方法
        protected override Product GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<Product>(p => p.Category);
            dc.LoadOptions = opt;
            return dc.GetTable<Product>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<Product> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<Product>(p => p.Category);
            dc.LoadOptions = opt;
            IQueryable<Product> ret = dc.GetTable<Product>();
            if (search is ProductSearchCondition)
            {
                ProductSearchCondition con = search as ProductSearchCondition;
                if (!string.IsNullOrEmpty(con.Number)) ret = ret.Where(item => item.ID.Contains(con.Number));
                if (!string.IsNullOrEmpty(con.Name)) ret = ret.Where(item => item.Name.Contains(con.Name));
                if (!string.IsNullOrEmpty(con.BarCode)) ret = ret.Where(item => item.BarCode.Contains(con.BarCode));
                if (!string.IsNullOrEmpty(con.CategoryID)) ret = ret.Where(item => item.CategoryID == con.CategoryID);
                if (!string.IsNullOrEmpty(con.Specification)) ret = ret.Where(item => item.Specification.Contains(con.Specification));
            }
            return ret.ToList();
        }

        protected override void InsertingItem(Product info, DataContext dc)
        {
            if (info.Category != null) dc.GetTable<ProductCategory>().Attach(info.Category);
            base.InsertingItem(info, dc);
        }
        #endregion
    }
}
