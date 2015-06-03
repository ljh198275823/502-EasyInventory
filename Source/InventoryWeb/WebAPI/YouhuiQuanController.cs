using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory .BusinessModel .SearchCondition ;
using LJH.Inventory .BLL;
using LJH.InventoryWeb.Models;

namespace LJH.InventoryWeb.WebAPI
{
    public class YouhuiQuanController : ApiController
    {
        // GET api/youhuiquan/5
        public YouhuiQuan Get(string id)
        {
            var ret = new YouhuiQuanBLL(Appsetting.Current.ConnStr).GetByID(id).QueryObject;
            return ret;
        }

        public IEnumerable<YouhuiQuan> GetOf(string userID)
        {
            YouhuiQuanSearchCondition con = new YouhuiQuanSearchCondition() { User = userID, CanUseNow = true };
            return new YouhuiQuanBLL(Appsetting.Current.ConnStr).GetItems(con).QueryObjects;
        }

        // POST api/youhuiquan
        public void Post([FromBody]string value)
        {
        }

        // PUT api/youhuiquan/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/youhuiquan/5
        public void Delete(int id)
        {
        }
    }
}
