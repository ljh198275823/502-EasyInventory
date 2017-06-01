using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class CustomerPaymentProvider : ProviderBase<CustomerPayment, string>, ICustomerPaymentProvider
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
                if (con.SheetIDs != null && con.SheetIDs.Count > 0) ret = ret.Where(item => con.SheetIDs.Contains(item.ID));
                if (con.States != null && con.States.Count > 0) ret = ret.Where(item => con.States.Contains(item.State));
            }
            if (search is CustomerPaymentSearchCondition)
            {
                CustomerPaymentSearchCondition con = search as CustomerPaymentSearchCondition;
                if (!string.IsNullOrEmpty(con.CustomerID)) ret = ret.Where(item => item.CustomerID == con.CustomerID);
                if (!string.IsNullOrEmpty(con.AccountID)) ret = ret.Where(item => item.AccountID == con.AccountID);
                if (!string.IsNullOrEmpty(con.StackSheetID)) ret = ret.Where(item => item.StackSheetID == con.StackSheetID);
                if (con.PaymentTypes != null && con.PaymentTypes.Count > 0) ret = ret.Where(item => con.PaymentTypes.Contains(item.ClassID));
            }
            List<CustomerPayment> sheets = ret.ToList();
            return sheets;
        }
        #endregion

        public List<string> GetBanks()
        {
            return CreateDataContext().GetTable<CustomerPayment>().Where(it => it.Bank != null && it.Bank != string.Empty).Select(it => it.Bank).Distinct().ToList();
        }

        public List<string> 获取所有出票单位()
        {
            return CreateDataContext().GetTable<CustomerPayment>().Where(it => it.ClassID == CustomerPaymentType.客户增值税发票 && it.AccountID != null && it.AccountID != string.Empty).Select(it => it.AccountID).Distinct().ToList();
        }
    }
}
