﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class CustomerPaymentProvider : ProviderBase<CustomerPayment, string>
    {
        #region 构造函数
        public CustomerPaymentProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override CustomerPayment GetingItemByID(string id, DataContext dc)
        {
            return dc.GetTable<CustomerPayment>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<CustomerPayment> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<CustomerPayment> ret = dc.GetTable<CustomerPayment>();
            if (search is SheetSearchCondition)
            {
                SheetSearchCondition con = search as SheetSearchCondition;
                if (con.SheetDate != null) ret = ret.Where(item => item.SheetDate >= con.SheetDate.Begin && item.SheetDate <= con.SheetDate.End);
                if (con.LastActiveDate != null) ret = ret.Where(item => item.LastActiveDate >= con.LastActiveDate.Begin && item.LastActiveDate <= con.LastActiveDate.End);
                if (con.SheetNo != null && con.SheetNo.Count > 0) ret = ret.Where(item => con.SheetNo.Contains(item.ID));
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains(item.State));
            }
            if (search is CustomerPaymentSearchCondition)
            {
                CustomerPaymentSearchCondition con = search as CustomerPaymentSearchCondition;
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.CustomerID == con.CustomerID);
                if (con.PaymentTypes != null && con.PaymentTypes.Count > 0) ret = ret.Where(item => con.PaymentTypes.Contains(item.ClassID));
                if (con.HasRemain != null)
                {
                    if (con.HasRemain.Value) ret = ret.Where(item => item.Assigned < item.Amount);
                    else ret = ret.Where(item => item.Assigned >= item.Amount);
                }
            }
            List<CustomerPayment> sheets = ret.ToList();
            return sheets;
        }
        #endregion
    }
}
