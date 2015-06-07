using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using LJH.InventoryWebAPI.Handlers;

namespace LJH.InventoryWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MessageHandlers.Add(new BasicAuthenticateHandler()); 
            config.EnsureInitialized();
        }
    }
}
