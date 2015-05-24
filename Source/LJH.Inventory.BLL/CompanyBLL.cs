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
                id = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.CustomerPrefix, UserSettings.Current.CustomerSerialCount, "customer");
            }
            else if (classID == CompanyClass.Supplier)
            {
                id = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.SupplierPrefix, UserSettings.Current.SupplierSerialCount, "supplier");
            }
            else if (classID == CompanyClass.Proxy)
            {
                id = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber("P", 3, "ProxyCompany");
            }
            else
            {
                id = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber("RC", 3, "relatedCompany");
            }
            return id;
        }
        #endregion

        #region 公共方法}
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
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                ProviderFactory.Create<IProvider<CompanyInfo, string>>(_RepoUri).Insert(info, unitWork);
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
                    ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(_RepoUri).Insert(cr, unitWork);
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
                    ProviderFactory.Create<IProvider<CustomerPayment, string>>(_RepoUri).Insert(cp, unitWork);
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
            List<StackOutSheet> items = (new StackOutSheetBLL(_RepoUri)).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                return new CommandResult(ResultCode.Fail, string.Format("不能删除客户 {0} 的资料，系统中已经存在此客户的送货单", info.Name));
            }

            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            CustomerPaymentSearchCondition con1 = new CustomerPaymentSearchCondition() { CustomerID = info.ID };
            List<CustomerPayment> cps = ProviderFactory.Create<IProvider<CustomerPayment, string>>(_RepoUri).GetItems(con1).QueryObjects;
            if (cps != null && cps.Count > 0)
            {
                foreach (CustomerPayment cp in cps)
                {
                    ProviderFactory.Create<IProvider<CustomerPayment, string>>(_RepoUri).Delete(cp, unitWork);
                }
            }

            CustomerOtherReceivableSearchCondition con2 = new CustomerOtherReceivableSearchCondition() { CustomerID = info.ID };
            List<CustomerOtherReceivable> cds = ProviderFactory.Create<IProvider<CustomerOtherReceivable, string>>(_RepoUri).GetItems(con2).QueryObjects;
            if (cds != null && cds.Count > 0)
            {
                foreach (CustomerOtherReceivable cd in cds)
                {
                    ProviderFactory.Create<IProvider<CustomerOtherReceivable, string>>(_RepoUri).Delete(cd, unitWork);
                }
            }

            CustomerReceivableSearchCondition con3 = new CustomerReceivableSearchCondition() { CustomerID = info.ID };
            List<CustomerReceivable> crs = ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(_RepoUri).GetItems(con3).QueryObjects;
            if (crs != null && crs.Count > 0)
            {
                foreach (CustomerReceivable cr in crs)
                {
                    ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(_RepoUri).Delete(cr, unitWork);
                }
            }
            ProviderFactory.Create<IProvider<CompanyInfo, string>>(_RepoUri).Delete(info, unitWork);
            return unitWork.Commit();
        }
        #endregion
    }
}
