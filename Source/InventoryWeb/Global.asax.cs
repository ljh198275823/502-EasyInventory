using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LJH.InventoryWeb.Models;

namespace InventoryWeb
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            string temp = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Inventory"].ConnectionString;
            if (string.IsNullOrEmpty(temp)) temp = @"D:\InventoryWeb\Data\Inventory.db";
            Appsetting.Current = new Appsetting() { ConnStr = string.Format("SQLITE:Data Source={0}", temp) };

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}