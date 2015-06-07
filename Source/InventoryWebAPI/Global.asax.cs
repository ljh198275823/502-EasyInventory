using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace LJH.InventoryWebAPI
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            string temp = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Inventory"].ConnectionString;
            if (string.IsNullOrEmpty(temp)) temp = @"D:\InventoryWeb\Data\Inventory.db";
            Appsetting.Current = new Appsetting() { ConnStr = string.Format("SQLITE:Data Source={0}", temp) };

            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}