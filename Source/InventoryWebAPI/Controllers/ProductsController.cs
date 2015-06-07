using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Principal;
using LJH.Inventory.BLL ;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.InventoryWebAPI.Models;

namespace LJH.InventoryWebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private Func<Product, Models.ProductDTO> ConverToDto = p =>
        {
            return new ProductDTO
            {
                ID = p.ID,
                Name = p.Name,
                ShortName = p.ShortName,
                Category = p.Category != null ? p.Category.Name : p.CategoryID,
                BarCode = p.BarCode,
                Specification = p.Specification,
                Model = p.Model,
                Unit = p.Unit,
                IsService = p.IsService,
                Memo = p.Memo,
            };
        };
        #region 公共方法
        public IHttpActionResult Get()
        {
            List<Product> ret = new ProductBLL(Appsetting.Current.ConnStr).GetItems(null).QueryObjects;
            if (ret != null && ret.Count > 0) return Ok<IEnumerable<ProductDTO>>(ret.Select(ConverToDto));
            return NotFound();
        }


        public IHttpActionResult Get(string id)
        {
            Product p = new ProductBLL(Appsetting.Current.ConnStr).GetByID(id).QueryObject;
            if (p != null) return Ok<ProductDTO>(ConverToDto(p));
            return NotFound();
        }

        public IHttpActionResult GetByCategory(string category)
        {
            List<ProductCategory> cs = new ProductCategoryBLL(Appsetting.Current.ConnStr).GetItems(null).QueryObjects;
            if (cs != null && cs.Count > 0)
            {
                ProductCategory pc = cs.FirstOrDefault(it => it.Name == category);
                if (pc != null) category = pc.ID;
            }
            ProductSearchCondition con = new ProductSearchCondition { CategoryID = category };
            List<Product> ret = new ProductBLL(Appsetting.Current.ConnStr).GetItems(con).QueryObjects;
            if (ret != null && ret.Count > 0) return Ok<IEnumerable<ProductDTO>>(ret.Select(ConverToDto));
            return NotFound();
        }
        #endregion
    }
}
