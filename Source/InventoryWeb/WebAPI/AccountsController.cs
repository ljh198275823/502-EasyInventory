using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LJH.InventoryWeb.Models;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.InventoryWeb.WebAPI
{
    public class AccountsController : ApiController
    {
        /// <summary>
        /// 注册用户
        /// </summary>
        // post Accounts/
        [AllowAnonymous]
        public HttpResponseMessage Post(Account account)
        {
            if (this.ModelState.IsValid)
            {
                CommandResult ret = new OperatorBLL(Appsetting.Current.ConnStr).Register(account.Email, account.UserName, account.Password);
                if (ret.Result == ResultCode.Successful)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "注册成功");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ret.Message);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState.ToString());
        }

        public Account Get(string id)
        {
            return new Account() { Email = "LJAE", UserName = "测试" };
        }
    }
}
