﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using LJH.Inventory .DAL .IProvider ;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory.BusinessModel.SearchCondition;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class CustomerProvider : ProviderBase<CompanyInfo, string>, ICustomerProvider
    {
        #region 构造函数
        public CustomerProvider(string conStr)
            : base(conStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override CompanyInfo GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            CompanyInfo c = dc.GetTable<CompanyInfo>().SingleOrDefault(item => item.ID == id);
            return c;
        }

        protected override List<CompanyInfo> GetingItems(System.Data.Linq.DataContext dc, BusinessModel.SearchCondition.SearchCondition search)
        {
            IQueryable<CompanyInfo> ret = dc.GetTable<CompanyInfo>();
            if (search is CustomerSearchCondition)
            {
                CustomerSearchCondition con = search as CustomerSearchCondition;
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.ID.Contains(con.CustomerID));
                if (con.ClassID != null) ret = ret.Where(item => item.ClassID == con.ClassID.Value);
                if (!string.IsNullOrEmpty(con.Category)) ret = ret.Where(item => item.CategoryID == con.Category);
            }
            List<CompanyInfo> cs = ret.ToList();
            return cs;
        }
        #endregion
    }
}
