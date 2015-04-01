using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Configuration;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        public List<Product> GetAll()
        {
            List<Product> ps = new ProductBLL(WebConfigurationManager.ConnectionStrings["Inventory"].ConnectionString).GetItems(null).QueryObjects;
            return ps;
        }

        public Product Get(string id)
        {
            Product p = new ProductBLL(WebConfigurationManager.ConnectionStrings["Inventory"].ConnectionString).GetByID(id).QueryObject;
            return p;
        }
    }
}
