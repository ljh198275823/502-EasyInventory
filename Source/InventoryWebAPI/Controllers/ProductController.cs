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
        public string[] GetAll()
        {
            List<Product> ps = new ProductBLL(WebConfigurationManager .ConnectionStrings["Inventory"].ConnectionString ).GetItems(null).QueryObjects;
            if (ps != null && ps.Count > 0)
            {
                return ps.Select(it => it.Name).ToArray();
            }
            return new string[] { "not found" };
        }
    }
}
