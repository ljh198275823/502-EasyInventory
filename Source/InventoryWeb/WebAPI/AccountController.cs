using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LJH.InventoryWeb.WebAPI
{
    public class AccountController : ApiController
    {
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Register()
        {
            return null;
        }
    }
}
