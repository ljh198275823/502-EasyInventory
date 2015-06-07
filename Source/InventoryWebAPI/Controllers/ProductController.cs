using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Principal;
using LJH.Inventory.BLL ;
using LJH.Inventory .BusinessModel ;
using LJH.InventoryWebAPI.Models;

namespace LJH.InventoryWebAPI.Controllers
{
    public class ProductController : ApiController
    {
        #region 公共方法
        public HttpResponseMessage  Get()
        {
            IPrincipal p = this.User;
            if (p.Identity.IsAuthenticated)
            {
                List<Product> ret = new ProductBLL(Appsetting.Current.ConnStr).GetItems(null).QueryObjects;
                return Request.CreateResponse(HttpStatusCode.OK, ret);
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Unauthorized);
                response.Headers.Add("WWW-Authenticate", "Basic realm=\"Secure Area\"");
                return response;
            }
        }

        public Product Get(string id)
        {
            Product p = new ProductBLL(Appsetting.Current.ConnStr).GetByID(id).QueryObject;
            return p;
        }
        #endregion
    }
}
