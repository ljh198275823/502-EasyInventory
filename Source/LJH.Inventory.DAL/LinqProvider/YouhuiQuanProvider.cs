using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class YouhuiQuanProvider : ProviderBase<YouhuiQuan, string>
    {
        #region 构造函数
        public YouhuiQuanProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override YouhuiQuan GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            YouhuiQuan c = dc.GetTable<YouhuiQuan>().SingleOrDefault(item => item.ID == id);
            return c;
        }

        protected override List<YouhuiQuan> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<YouhuiQuan> ret = dc.GetTable<YouhuiQuan>();
            if (search is YouhuiQuanSearchCondition)
            {
                YouhuiQuanSearchCondition con = search as YouhuiQuanSearchCondition;
                if (!string.IsNullOrEmpty(con.YouhuiID)) ret = ret.Where(item => item.YouhuiID == con.YouhuiID);
                if (!string.IsNullOrEmpty(con.User)) ret = ret.Where(item => item.User.ToUpper() == con.User);
                if (con.CreateDate != null) ret = ret.Where(item => item.CreateDate >= con.CreateDate.Begin && item.CreateDate <= con.CreateDate.End);
                if (!string.IsNullOrEmpty(con.Proxy)) ret = ret.Where(it => it.Proxy.ToUpper() == con.Proxy);
                if (con.ComsumeDate != null) ret = ret.Where(item => item.ComsumeDate >= con.ComsumeDate.Begin && item.ComsumeDate <= con.ComsumeDate.End);
                if (con.CanUseNow != null && con.CanUseNow.Value)
                {
                    ret = ret.Where(item => item.ComsumeDate == null && (item.From == null || item.From.Value <= DateTime.Now) && (item.To == null || item.To >= DateTime.Now));
                }
            }
            List<YouhuiQuan> cs = ret.ToList();
            return cs;
        }
        #endregion
    }
}
