using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .DAL .IProvider ;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory.BusinessModel.SearchCondition;

namespace LJH.Inventory.BLL
{
    public class CustomerBLL
    {
        #region 构造函数
        public CustomerBLL(string repUri)
        {
            _RepoUri  =repUri ;
        }
        #endregion

        #region 私有变量
        private string _RepoUri; 
        #endregion

        private string CreateCustomerID(int classID)
        {
            string id = null;
            if (classID == 5)
            {
                id = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.CustomerPrefix, UserSettings.Current.CustomerSerialCount, "customer");
            }
            else if (classID == 6)
            {
                id = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.SupplierPrefix, UserSettings.Current.SupplierSerialCount, "customer");
            }
            else
            {
                id = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber("RC", 3, "customer");
            }
            return id;
        }

        #region 公共方法
        /// <summary>
        /// 获取所有客户信息
        /// </summary>
        /// <returns></returns>
        public  QueryResultList <Customer> GetItems(SearchCondition con)
        {
            return ProviderFactory.Create<ICustomerProvider>(_RepoUri).GetItems(con);
        }

        public QueryResult<Customer> GetByID(string id)
        {
            return ProviderFactory.Create<ICustomerProvider>(_RepoUri).GetByID(id);
        }

        public CommandResult Insert(Customer info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = CreateCustomerID(info.ClassID);
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                return ProviderFactory.Create<ICustomerProvider>(_RepoUri).Insert(info);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "创建客户编号失败，请重试");
            }
        }

        public CommandResult Insert(Customer info, decimal prepayment, decimal receivables)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.CustomerPrefix, UserSettings.Current.CustomerSerialCount, "customer");
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                ProviderFactory.Create<ICustomerProvider>(_RepoUri).Insert(info, unitWork);
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
                    ProviderFactory.Create<ICustomerReceivableProvider>(_RepoUri).Insert(cr, unitWork);
                }
                if (prepayment > 0)
                {
                    CustomerPayment cp = new CustomerPayment()
                    {
                        ID = info.ID + "初始预付款",
                        CustomerID = info.ID,
                        PaymentMode = PaymentMode.Cash,
                        PaidDate = DateTime.Now,
                        Amount = prepayment,
                        State = SheetState.Add,
                        Memo = "初始预付款"
                    };
                    ProviderFactory.Create<ICustomerPaymentProvider>(_RepoUri).Insert(cp, unitWork);
                }
                return unitWork.Commit();
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "创建客户编号失败，请重试");
            }
        }

        public CommandResult Update(Customer info)
        {
            Customer original = ProviderFactory.Create<ICustomerProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original == null)
            {
                return new CommandResult(ResultCode.Fail, string.Format("系统中不存在 ID={0} 的用户信息", info.ID));
            }
            return ProviderFactory.Create<ICustomerProvider>(_RepoUri).Update(info, original);
        }

        public CommandResult Delete(Customer info)
        {
            DeliverySheetSearchCondition con = new DeliverySheetSearchCondition();
            con.CustomerID = info.ID;
            List<DeliverySheet> items = (new DeliverySheetBLL(_RepoUri)).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                return new CommandResult(ResultCode.Fail, string.Format("不能删除客户 {0} 的资料，系统中已经存在此客户的送货单", info.Name));
            }

            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            CustomerPaymentSearchCondition con1=new CustomerPaymentSearchCondition() { CustomerID = info.ID };
            List<CustomerPayment> cps = ProviderFactory.Create<ICustomerPaymentProvider>(_RepoUri).GetItems(con1).QueryObjects;
            if (cps != null && cps.Count > 0)
            {
                foreach (CustomerPayment cp in cps)
                {
                    ProviderFactory.Create<ICustomerPaymentProvider>(_RepoUri).Delete(cp, unitWork);
                }
            }

            CustomerDaiFuSearchCondition con2 = new CustomerDaiFuSearchCondition() { CustomerID = info.ID };
            List<CustomerOtherReceivable> cds = ProviderFactory.Create<ICustomerOtherReceivableProvider>(_RepoUri).GetItems(con2).QueryObjects;
            if (cds != null && cds.Count > 0)
            {
                foreach (CustomerOtherReceivable cd in cds)
                {
                    ProviderFactory.Create<ICustomerOtherReceivableProvider>(_RepoUri).Delete(cd, unitWork);
                }
            }

            CustomerReceivableSearchCondition con3 = new CustomerReceivableSearchCondition() { CustomerID = info.ID };
            List<CustomerReceivable> crs = ProviderFactory.Create<ICustomerReceivableProvider>(_RepoUri).GetItems(con3).QueryObjects;
            if (crs != null && crs.Count > 0)
            {
                foreach (CustomerReceivable cr in crs)
                {
                    ProviderFactory.Create<ICustomerReceivableProvider>(_RepoUri).Delete(cr, unitWork);
                }
            }
            ProviderFactory.Create<ICustomerProvider>(_RepoUri).Delete(info, unitWork);
            return unitWork.Commit();
        }
        #endregion
    }
}
