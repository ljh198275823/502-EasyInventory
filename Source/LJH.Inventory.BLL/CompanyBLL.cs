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

        public CommandResult Add(CompanyInfo info, decimal prepayment, decimal receivables)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = CreateCustomerID(info.ClassID);
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
                ProviderFactory.Create<IProvider<CompanyInfo, string>>(RepoUri).Insert(info, unitWork);
                if (receivables > 0) //增加一条客户应收项
                {
                    CustomerReceivable cr = new CustomerReceivable()
                    {
                        ID = Guid.NewGuid(),
                        OrderID = info.ID + "初始应收",
                        CreateDate = DateTime.Now,
                        CustomerID = info.ID,
                        Amount = receivables,
                        Memo = "初始应收",
                    };
                    ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Insert(cr, unitWork);
                }
                if (prepayment > 0)
                {
                    CustomerPayment cp = new CustomerPayment()
                    {
                        ID = info.ID + "初始预付款",
                        CustomerID = info.ID,
                        PaymentMode = PaymentMode.Cash,
                        LastActiveDate = DateTime.Now,
                        Amount = prepayment,
                        State = SheetState.Add,
                        Memo = "初始预付款"
                    };
                    ProviderFactory.Create<IProvider<CustomerPayment, string>>(RepoUri).Insert(cp, unitWork);
                }
                return unitWork.Commit();
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "创建客户编号失败，请重试");
            }
        }

        public override CommandResult Delete(CompanyInfo info)
        {
            StackOutSheetSearchCondition con = new StackOutSheetSearchCondition();
            con.CustomerID = info.ID;
            List<StackOutSheet> items = (new StackOutSheetBLL(RepoUri)).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                return new CommandResult(ResultCode.Fail, string.Format("不能删除客户 {0} 的资料，系统中已经存在此客户的送货单", info.Name));
            }

            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            CustomerPaymentSearchCondition con1 = new CustomerPaymentSearchCondition() { CustomerID = info.ID };
            List<CustomerPayment> cps = ProviderFactory.Create<IProvider<CustomerPayment, string>>(RepoUri).GetItems(con1).QueryObjects;
            if (cps != null && cps.Count > 0)
            {
                foreach (CustomerPayment cp in cps)
                {
                    ProviderFactory.Create<IProvider<CustomerPayment, string>>(RepoUri).Delete(cp, unitWork);
                }
            }

            CustomerOtherReceivableSearchCondition con2 = new CustomerOtherReceivableSearchCondition() { CustomerID = info.ID };
            List<CustomerOtherReceivable> cds = ProviderFactory.Create<IProvider<CustomerOtherReceivable, string>>(RepoUri).GetItems(con2).QueryObjects;
            if (cds != null && cds.Count > 0)
            {
                foreach (CustomerOtherReceivable cd in cds)
                {
                    ProviderFactory.Create<IProvider<CustomerOtherReceivable, string>>(RepoUri).Delete(cd, unitWork);
                }
            }

            CustomerReceivableSearchCondition con3 = new CustomerReceivableSearchCondition() { CustomerID = info.ID };
            List<CustomerReceivable> crs = ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).GetItems(con3).QueryObjects;
            if (crs != null && crs.Count > 0)
            {
                foreach (CustomerReceivable cr in crs)
                {
                    ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Delete(cr, unitWork);
                }
            }
            ProviderFactory.Create<IProvider<CompanyInfo, string>>(RepoUri).Delete(info, unitWork);
            return unitWork.Commit();
        }

        public CommandResult SetFileID(CompanyInfo customer, int fid)
        {
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            var provider=ProviderFactory .Create <IProvider <CompanyInfo ,string>>(RepoUri );
            List<CompanyInfo> cs = GetAllCustomers().QueryObjects;
            foreach (var c in cs)
            {
                if (c.ID != customer.ID && c.City ==customer .City &&  c.FileID == fid) //将同一个城市的其它有相同归档码的客户的归档码设置成空
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
            CustomerPaymentSearchCondition cpsc = new CustomerPaymentSearchCondition();
            cpsc.PaymentTypes = new List<CustomerPaymentType>();
            cpsc.PaymentTypes.Add(CustomerPaymentType.Customer);
            cpsc.States = new List<SheetState>();
            cpsc.States.Add(SheetState.Add);
            cpsc.States.Add(SheetState.Approved);
            cpsc.HasRemain = true;
            var customerPayments = (new CustomerPaymentBLL(RepoUri )).GetItems(cpsc).QueryObjects;

            CustomerReceivableSearchCondition crsc = new CustomerReceivableSearchCondition();
            crsc.Settled = false;
            crsc.ReceivableTypes = new List<CustomerReceivableType>();
            crsc.ReceivableTypes.Add(CustomerReceivableType.CustomerOtherReceivable);
            crsc.ReceivableTypes.Add(CustomerReceivableType.CustomerReceivable);
            var customerReceivables = (new CustomerReceivableBLL(RepoUri )).GetItems(crsc).QueryObjects;

            List<CompanyInfo> customers = GetAllCustomers().QueryObjects;
            if (customers != null && customers.Count > 0)
            {
                var items = new List<CustomerFinancialState>();
                foreach (var c in customers)
                {
                    CustomerFinancialState cs = new CustomerFinancialState()
                    {
                        Customer = c,
                        Recievables = customerReceivables != null ? customerReceivables.Sum(it => it.CustomerID == c.ID ? it.Remain : 0) : 0,
                        Prepay = customerPayments != null ? customerPayments.Sum(it => it.CustomerID == c.ID ? it.Remain : 0) : 0,
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

            CustomerPaymentSearchCondition cpsc = new CustomerPaymentSearchCondition();
            cpsc.PaymentTypes = new List<CustomerPaymentType>();
            cpsc.PaymentTypes.Add(CustomerPaymentType.Customer);
            cpsc.States = new List<SheetState>();
            cpsc.States.Add(SheetState.Add);
            cpsc.States.Add(SheetState.Approved);
            cpsc.HasRemain = true;
            cpsc.CustomerID = customerID;
            var customerPayments = (new CustomerPaymentBLL(RepoUri)).GetItems(cpsc).QueryObjects;

            CustomerReceivableSearchCondition crsc = new CustomerReceivableSearchCondition();
            crsc.Settled = false;
            crsc.CustomerID = customerID;
            crsc.ReceivableTypes = new List<CustomerReceivableType>();
            crsc.ReceivableTypes.Add(CustomerReceivableType.CustomerOtherReceivable);
            crsc.ReceivableTypes.Add(CustomerReceivableType.CustomerReceivable);
            var customerReceivables = (new CustomerReceivableBLL(RepoUri)).GetItems(crsc).QueryObjects;

            CustomerFinancialState cs = new CustomerFinancialState()
            {
                Customer = c,
                Recievables = customerReceivables != null ? customerReceivables.Sum(it => it.CustomerID == c.ID ? it.Remain : 0) : 0,
                Prepay = customerPayments != null ? customerPayments.Sum(it => it.CustomerID == c.ID ? it.Remain : 0) : 0,
            };
            return new QueryResult<CustomerFinancialState>(ResultCode.Successful, string.Empty, cs);
        }
        #endregion
    }
}
