using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LJH.Inventory.BLL ;
using LJH.Inventory .BusinessModel ;
using LJH.InventoryWeb.Models;

namespace InventoryWeb.Controllers
{
    public class ProductController : ApiController
    {
        #region 公共方法
        public List<Product> Get()
        {
            List<Product> ret = new ProductBLL(Appsetting.Current.ConnStr).GetItems(null).QueryObjects;
            return ret;
        }

        public Product Get(string id)
        {
            Product p = new ProductBLL(Appsetting.Current.ConnStr).GetByID(id).QueryObject;
            return p;
        }
        #endregion
    }
}
