using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .DAL .IProvider ;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class CompanyBLL : BLLBase<string, CompanyInfo>
    {
        #region 构造函数
        public CompanyBLL(string repUri)
            : base(repUri)
        {
        }
        #endregion

        #region 私有方法
        private string CreateCustomerID(CompanyClass classID)
        {
            string id = null;
            if (classID == CompanyClass.Customer)
            {
                id = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber(UserSettings.Current.CustomerPrefix, UserSettings.Current.CustomerSerialCount, "customer");
            }
            else if (classID == CompanyClass.Supplier)
            {
                id = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber(UserSettings.Current.SupplierPrefix, UserSettings.Current.SupplierSerialCount, "supplier");
            }
            else if (classID == CompanyClass.Proxy)
            {
                id = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("P", 3, "ProxyCompany");
            }
            else
            {
                id = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("RC", 3, "relatedCompany");
            }
            return id;
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取所有客户信息
        /// </summary>
        /// <returns></returns>
        public QueryResultList<CompanyInfo> GetAllCustomers()
        {
            CustomerSearchCondition con = new CustomerSearchCondition();
            con.ClassID = CompanyClass.Customer;
            return GetItems(con);
        }
        /// <summary>
        /// 获取所有供应商信息
        /// </summary>
        /// <returns></returns>
        public QueryResultList<CompanyInfo> GetAllSuppliers()
        {
            CustomerSearchCondition con = new CustomerSearchCondition();
            con.ClassID = CompanyClass.Supplier;
            return GetItems(con);
        }

        public override CommandResult Add(CompanyInfo info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = CreateCustomerID(info.ClassID);
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                return base.Add(info);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "创建编号失败，请重试");
            }
        }

        public override CommandResult Delete(CompanyInfo info)
        {
            StackOutSheetSearchCondition con = new StackOutSheetSearchCondition();
            con.CustomerID = info.ID;
            List<StackOutSheet> sheets = (new StackOutSheetBLL(RepoUri)).GetItems(con).QueryObjects;
            if (sheets != null && sheets.Count > 0) // 如果存在未作废的送货单，则不能删除
            {
                return new CommandResult(ResultCode.Fail, string.Format("不能删除客户 {0} 的资料，系统中已经存在此客户的送货单", info.Name));
            }

            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            ProviderFactory.Create<IProvider<CompanyInfo, string>>(RepoUri).Delete(info, unitWork);
            return unitWork.Commit();
        }

        public CommandResult SetFileID(CompanyInfo customer, int fid)
        {
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            var provider = ProviderFactory.Create<IProvider<CompanyInfo, string>>(RepoUri);
            List<CompanyInfo> cs = GetAllCustomers().QueryObjects;
            foreach (var c in cs)
            {
                if (c.ID != customer.ID && c.City == customer.City && c.FileID == fid) //将同一个城市的其它有相同归档码的客户的归档码设置成空
                {
                    var newVal = c.Clone();
                    newVal.FileID = null;
                    provider.Update(newVal, c, unitWork);
                }
            }
            var clone = customer.Clone();
            clone.FileID = fid;
            provider.Update(clone, customer, unitWork);
            var ret = unitWork.Commit();
            if (ret.Result == ResultCode.Successful)
            {
                customer.FileID = fid;
            }
            return ret;
        }

        public QueryResultList<CustomerFinancialState> GetAllCustomerStates()
        {
            AccountRecordSearchCondition cpsc = new AccountRecordSearchCondition();
            cpsc.PaymentTypes = new List<CustomerPaymentType>() { CustomerPaymentType.Customer, CustomerPaymentType.CustomerTax };
            cpsc.HasRemain = true;
            var customerPayments = (new AccountRecordBLL(RepoUri)).GetItems(cpsc).QueryObjects;

            CustomerReceivableSearchCondition crsc = new CustomerReceivableSearchCondition();
            crsc.ReceivableTypes = new List<CustomerReceivableType>() { CustomerReceivableType.CustomerReceivable, CustomerReceivableType.CustomerTax };
            crsc.Settled = false;
            var customerReceivables = (new CustomerReceivableBLL(RepoUri)).GetItems(crsc).QueryObjects;

            List<CompanyInfo> customers = GetAllCustomers().QueryObjects;
            if (customers != null && customers.Count > 0)
            {
                var items = new List<CustomerFinancialState>();
                foreach (var c in customers)
                {
                    CustomerFinancialState cs = new CustomerFinancialState()
                    {
                        Customer = c,
                        Recievables = customerReceivables != null ? customerReceivables.Sum(it => it.CustomerID == c.ID && it.ClassID == CustomerReceivableType.CustomerReceivable ? it.Remain : 0) : 0,
                        Prepay = customerPayments != null ? customerPayments.Sum(it => it.CustomerID == c.ID && it.ClassID == CustomerPaymentType.Customer ? it.Remain : 0) : 0,
                        Tax = customerReceivables != null ? customerReceivables.Sum(it => it.CustomerID == c.ID && it.ClassID == CustomerReceivableType.CustomerTax ? it.Remain : 0) : 0,
                        TaxBill = customerPayments != null ? customerPayments.Sum(it => it.CustomerID == c.ID && it.ClassID == CustomerPaymentType.CustomerTax ? it.Remain : 0) : 0,
                    };
                    items.Add(cs);
                }
                return new QueryResultList<CustomerFinancialState>(ResultCode.Successful, string.Empty, items);
            }
            return new QueryResultList<CustomerFinancialState>(ResultCode.Successful, string.Empty, null);
        }

        public QueryResult<CustomerFinancialState> GetCustomerState(string customerID)
        {
            var c = GetByID(customerID).QueryObject;
            if (c == null) return new QueryResult<CustomerFinancialState>(ResultCode.Fail, string.Empty, null);

            AccountRecordSearchCondition cpsc = new AccountRecordSearchCondition();
            cpsc.PaymentTypes = new List<CustomerPaymentType>() { CustomerPaymentType.Customer, CustomerPaymentType.CustomerTax };
            cpsc.HasRemain = true;
            cpsc.CustomerID = c.ID;
            var customerPayments = (new AccountRecordBLL(RepoUri)).GetItems(cpsc).QueryObjects;

            CustomerReceivableSearchCondition crsc = new CustomerReceivableSearchCondition();
            crsc.ReceivableTypes = new List<CustomerReceivableType>() { CustomerReceivableType.CustomerReceivable, CustomerReceivableType.CustomerTax };
            crsc.Settled = false;
            crsc.CustomerID = c.ID;
            var customerReceivables = (new CustomerReceivableBLL(RepoUri)).GetItems(crsc).QueryObjects;

            CustomerFinancialState cs = new CustomerFinancialState()
            {
                Customer = c,
                Recievables = customerReceivables != null ? customerReceivables.Sum(it => it.CustomerID == c.ID && it.ClassID == CustomerReceivableType.CustomerReceivable ? it.Remain : 0) : 0,
                Prepay = customerPayments != null ? customerPayments.Sum(it => it.CustomerID == c.ID && it.ClassID == CustomerPaymentType.Customer ? it.Remain : 0) : 0,
                Tax = customerReceivables != null ? customerReceivables.Sum(it => it.CustomerID == c.ID && it.ClassID == CustomerReceivableType.CustomerTax ? it.Remain : 0) : 0,
                TaxBill = customerPayments != null ? customerPayments.Sum(it => it.CustomerID == c.ID && it.ClassID == CustomerPaymentType.CustomerTax ? it.Remain : 0) : 0,
            };
            return new QueryResult<CustomerFinancialState>(ResultCode.Successful, string.Empty, cs);
        }

        public QueryResultList<CustomerFinancialState> GetAllSupplierStates()
        {
            AccountRecordSearchCondition cpsc = new AccountRecordSearchCondition();
            cpsc.PaymentTypes = new List<CustomerPaymentType>() { CustomerPaymentType.Supplier, CustomerPaymentType.SupplierTax };
            cpsc.HasRemain = true;
            var customerPayments = (new AccountRecordBLL(RepoUri)).GetItems(cpsc).QueryObjects;

            CustomerReceivableSearchCondition crsc = new CustomerReceivableSearchCondition();
            crsc.ReceivableTypes = new List<CustomerReceivableType>() { CustomerReceivableType.SupplierReceivable, CustomerReceivableType.SupplierTax };
            crsc.Settled = false;
            var customerReceivables = (new CustomerReceivableBLL(RepoUri)).GetItems(crsc).QueryObjects;

            List<CompanyInfo> customers = GetAllSuppliers().QueryObjects;
            if (customers != null && customers.Count > 0)
            {
                var items = new List<CustomerFinancialState>();
                foreach (var c in customers)
                {
                    CustomerFinancialState cs = new CustomerFinancialState()
                    {
                        Customer = c,
                        Recievables = customerReceivables != null ? customerReceivables.Sum(it => it.CustomerID == c.ID && it.ClassID == CustomerReceivableType.SupplierReceivable ? it.Remain : 0) : 0,
                        Prepay = customerPayments != null ? customerPayments.Sum(it => it.CustomerID == c.ID && it.ClassID == CustomerPaymentType.Supplier ? it.Remain : 0) : 0,
                        Tax = customerReceivables != null ? customerReceivables.Sum(it => it.CustomerID == c.ID && it.ClassID == CustomerReceivableType.SupplierTax ? it.Remain : 0) : 0,
                        TaxBill = customerPayments != null ? customerPayments.Sum(it => it.CustomerID == c.ID && it.ClassID == CustomerPaymentType.SupplierTax ? it.Remain : 0) : 0,
                    };
                    items.Add(cs);
                }
                return new QueryResultList<CustomerFinancialState>(ResultCode.Successful, string.Empty, items);
            }
            return new QueryResultList<CustomerFinancialState>(ResultCode.Successful, string.Empty, null);
        }

        public QueryResult<CustomerFinancialState> GetSupplierState(string customerID)
        {
            var c = GetByID(customerID).QueryObject;
            if (c == null) return new QueryResult<CustomerFinancialState>(ResultCode.Fail, string.Empty, null);

            AccountRecordSearchCondition cpsc = new AccountRecordSearchCondition();
            cpsc.PaymentTypes = new List<CustomerPaymentType>() { CustomerPaymentType.Supplier, CustomerPaymentType.SupplierTax };
            cpsc.HasRemain = true;
            cpsc.CustomerID = c.ID;
            var customerPayments = (new AccountRecordBLL(RepoUri)).GetItems(cpsc).QueryObjects;

            CustomerReceivableSearchCondition crsc = new CustomerReceivableSearchCondition();
            crsc.ReceivableTypes = new List<CustomerReceivableType>() { CustomerReceivableType.SupplierReceivable, CustomerReceivableType.SupplierTax };
            crsc.Settled = false;
            crsc.CustomerID = c.ID;
            var customerReceivables = (new CustomerReceivableBLL(RepoUri)).GetItems(crsc).QueryObjects;

            CustomerFinancialState cs = new CustomerFinancialState()
            {
                Customer = c,
                Recievables = customerReceivables != null ? customerReceivables.Sum(it => it.CustomerID == c.ID && it.ClassID == CustomerReceivableType.SupplierReceivable ? it.Remain : 0) : 0,
                Prepay = customerPayments != null ? customerPayments.Sum(it => it.CustomerID == c.ID && it.ClassID == CustomerPaymentType.Supplier ? it.Remain : 0) : 0,
                Tax = customerReceivables != null ? customerReceivables.Sum(it => it.CustomerID == c.ID && it.ClassID == CustomerReceivableType.SupplierTax ? it.Remain : 0) : 0,
                TaxBill = customerPayments != null ? customerPayments.Sum(it => it.CustomerID == c.ID && it.ClassID == CustomerPaymentType.SupplierTax ? it.Remain : 0) : 0,
            };
            return new QueryResult<CustomerFinancialState>(ResultCode.Successful, string.Empty, cs);
        }

        /// <summary>
        /// 将指定的公司合并到另一个公司
        /// </summary>
        /// <param name="source"></param>
        /// <param name="des"></param>
        /// <returns></returns>
        public CommandResult Merge(string source, string des)
        {
            var sc = GetByID(source).QueryObject;
            var dc = GetByID(des).QueryObject;
            if (sc == null) return new CommandResult(ResultCode.Fail, "系统中不存在被合并的公司信息");
            if (dc == null) return new CommandResult(ResultCode.Fail, "系统中不存在合并公司的信息");
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            SearchCondition con = null;
            con = new StackOutSheetSearchCondition() { CustomerID = source };
            List<StackOutSheet> sheets = ProviderFactory.Create<IProvider<StackOutSheet, string>>(RepoUri).GetItems(con).QueryObjects;
            if (sheets != null && sheets.Count > 0)
            {
                foreach (StackOutSheet sheet in sheets)
                {
                    StackOutSheet clone = sheet.Clone() as StackOutSheet;
                    clone.CustomerID = des;
                    ProviderFactory.Create<IProvider<StackOutSheet, string>>(RepoUri).Update(clone, sheet, unitWork);
                }
            }

            con = new CustomerReceivableSearchCondition() { CustomerID = source };
            var ors = ProviderFactory.Create<IProvider<OtherReceivableSheet, string>>(RepoUri).GetItems(con).QueryObjects;
            if (ors != null && ors.Count > 0)
            {
                foreach (var or in ors)
                {
                    var clone = or.Clone() as OtherReceivableSheet;
                    clone.CustomerID = des;
                    ProviderFactory.Create<IProvider<OtherReceivableSheet, string>>(RepoUri).Update(clone, or, unitWork);
                }
            }

            con = new CustomerReceivableSearchCondition() { CustomerID = source };
            List<CustomerReceivable> crs = ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).GetItems(con).QueryObjects;
            if (crs != null && crs.Count > 0)
            {
                foreach (var cr in crs)
                {
                    var clone = cr.Clone();
                    clone.CustomerID = des;
                    ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Update(clone, cr, unitWork);
                }
            }

            con = new CustomerPaymentSearchCondition() { CustomerID = source };
            List<CustomerPayment> cps = ProviderFactory.Create<IProvider<CustomerPayment, string>>(RepoUri).GetItems(con).QueryObjects;
            if (cps != null && cps.Count > 0)
            {
                foreach (var cp in cps)
                {
                    var clone = cp.Clone() as CustomerPayment;
                    clone.CustomerID = des;
                    ProviderFactory.Create<IProvider<CustomerPayment, string>>(RepoUri).Update(clone, cp, unitWork);
                }
            }

            con = new AccountRecordSearchCondition() { CustomerID = source };
            var ars = ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).GetItems(con).QueryObjects;
            if (ars != null && ars.Count > 0)
            {
                foreach (var ar in ars)
                {
                    var clone = ar.Clone();
                    clone.CustomerID = des;
                    ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).Update(clone, ar, unitWork);
                }
            }

            ProviderFactory.Create<IProvider<CompanyInfo, string>>(RepoUri).Delete(sc, unitWork);
            return unitWork.Commit();
        }
        #endregion
    }
}
