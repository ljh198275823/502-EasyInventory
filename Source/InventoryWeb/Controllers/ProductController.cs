using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;
using LJH.GeneralLibrary.Core.DAL;

namespace InventoryWeb.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            string conStr = string.Format("SQLITE:Data Source={0}", System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Inventory"]);
            List<Product> ps = new ProductBLL(conStr).GetItems(null).QueryObjects;
            ViewBag.Products = ps;
            return View();
        }
    }
}
