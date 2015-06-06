using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.InventoryWeb.Models;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.InventoryWeb.WebAPI
{
    public class YouhuiQuanController : ApiController
    {
        // GET api/youhuiquan/5
        public HttpResponseMessage Get(string id)
        {
            var ret = new YouhuiQuanBLL(Appsetting.Current.ConnStr).GetByID(id).QueryObject;
            if (ret != null) return Request.CreateResponse(HttpStatusCode.OK, ret);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "找不到相关信息");
        }

        [Authorize]
        public HttpResponseMessage GetOf(string userID)
        {
            YouhuiQuanSearchCondition con = new YouhuiQuanSearchCondition() { User = userID, CanUseNow = true };
            QueryResultList<YouhuiQuan> ret = new YouhuiQuanBLL(Appsetting.Current.ConnStr).GetItems(con);
            if (ret.Result == ResultCode.Successful) return Request.CreateResponse(HttpStatusCode.OK, ret.QueryObjects);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ret.Message);
        }

        [Authorize]
        public HttpResponseMessage GetOfProxy(string proxyID)
        {
            YouhuiQuanSearchCondition con = new YouhuiQuanSearchCondition() { Proxy = proxyID };
            QueryResultList<YouhuiQuan> ret = new YouhuiQuanBLL(Appsetting.Current.ConnStr).GetItems(con);
            if (ret.Result == ResultCode.Successful) return Request.CreateResponse(HttpStatusCode.OK, ret.QueryObjects);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ret.Message);
        }

        [HttpPut]
        public HttpResponseMessage AssignTo(string id, string proxyID)
        {
            CommandResult ret = new YouhuiQuanBLL(Appsetting.Current.ConnStr).AssignTo(id, proxyID);
            if (ret.Result == ResultCode.Successful)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ret.Message);
        }

        public HttpResponseMessage Delete(string id)
        {
            CommandResult ret = new YouhuiQuanBLL(Appsetting.Current.ConnStr).Delete(id);
            if (ret.Result == ResultCode.Successful)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ret.Message);
        }
    }
}
