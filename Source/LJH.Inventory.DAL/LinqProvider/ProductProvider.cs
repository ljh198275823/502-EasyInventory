using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class ProductProvider : ProviderBase<Product, string>, IProductProvider
    {
        private static Dictionary<string, Product> _AllProducts = null;
        #region 构造函数
        public ProductProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {

        }
        #endregion

        #region 重写基类方法
        protected override Product GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            if (_AllProducts == null)
            {
                DataLoadOptions opt1 = new DataLoadOptions();
                opt1.LoadWith<Product>(p => p.Category);
                dc.LoadOptions = opt1;
                var items = dc.GetTable<Product>();
                foreach (var p in items)
                {
                    if (_AllProducts == null) _AllProducts = new Dictionary<string, Product>();
                    _AllProducts.Add(p.ID, p);
                }
            }
            if (_AllProducts == null || _AllProducts.Count == 0) return null;
            if (_AllProducts.ContainsKey(id)) return _AllProducts[id];
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<Product>(p => p.Category);
            dc.LoadOptions = opt;
            var ret = dc.GetTable<Product>().SingleOrDefault(item => item.ID == id);
            if (ret != null) _AllProducts.Add(ret.ID, ret);
            return ret;
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
                if (con.ProductIDS != null && con.ProductIDS.Count > 0) ret = ret.Where(item => con.ProductIDS.Contains(item.ID));
                if (!string.IsNullOrEmpty(con.Name)) ret = ret.Where(item => item.Name.Contains(con.Name));
                if (!string.IsNullOrEmpty(con.CategoryID)) ret = ret.Where(item => item.CategoryID == con.CategoryID);
                if (!string.IsNullOrEmpty(con.Specification)) ret = ret.Where(item => item.Specification.Contains(con.Specification));
                if (con.Models != null && con.Models.Count > 0) ret = ret.Where(item => con.Models.Contains(item.Model));
                if (con.IsService.HasValue)
                {
                    if (con.IsService.Value)
                    {
                        ret = ret.Where(it => it.IsService == true);
                    }
                    else
                    {
                        ret = ret.Where(it => it.IsService == false);
                    }
                }
            }
            var items = ret.ToList();
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    if (_AllProducts != null && !_AllProducts.ContainsKey(item.ID)) _AllProducts.Add(item.ID, item);
                }
            }
            return items;
        }

        protected override void InsertingItem(Product info, DataContext dc)
        {
            if (info.Category != null) dc.GetTable<ProductCategory>().Attach(info.Category);
            base.InsertingItem(info, dc);
        }
        #endregion

        /// <summary>
        /// 获取所有的规格
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllSpecifications(ProductSearchCondition search)
        {
            var dc = this.CreateDataContext();
            IQueryable<Product> ret= dc.GetTable<Product>();
            if (search is ProductSearchCondition)
            {
                ProductSearchCondition con = search as ProductSearchCondition;
                if (con.ProductIDS != null && con.ProductIDS.Count > 0) ret = ret.Where(item => con.ProductIDS.Contains(item.ID));
                if (!string.IsNullOrEmpty(con.Name)) ret = ret.Where(item => item.Name.Contains(con.Name));
                if (!string.IsNullOrEmpty(con.CategoryID)) ret = ret.Where(item => item.CategoryID == con.CategoryID);
                if (!string.IsNullOrEmpty(con.Specification)) ret = ret.Where(item => item.Specification.Contains(con.Specification));
                if (con.Models != null && con.Models.Count > 0) ret = ret.Where(item => con.Models.Contains(item.Model));
                if (con.IsService.HasValue)
                {
                    if (con.IsService.Value)
                    {
                        ret = ret.Where(it => it.IsService == true);
                    }
                    else
                    {
                        ret = ret.Where(it => it.IsService == false);
                    }
                }
            }
            return ret.Select(it => it.Specification).Distinct().ToList();
        }
    }
}
