using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryWeb.Controllers
{
    public class ProductController : ApiController
    {
        public string Get()
        {
            return "hello world";
        }
    }
}
