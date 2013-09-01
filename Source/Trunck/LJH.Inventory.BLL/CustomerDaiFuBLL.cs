using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.BLL
{
    public class CustomerDaiFuBLL
    {
        #region 构造函数
        public CustomerDaiFuBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        public QueryResult<CustomerDaiFu> GetByID(string id)
        {
            return ProviderFactory.Create<ICustomerDaiFuProvider>(_RepoUri).GetByID(id);
        }

        public QueryResultList<CustomerDaiFu> GetItems(SearchCondition con)
        {
            return ProviderFactory.Create<ICustomerDaiFuProvider>(_RepoUri).GetItems(con);
        }

        public CommandResult Add(CustomerDaiFu info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.DaiFuPrefix ,
                    UserSettings.Current.DaiFuDateFormat, UserSettings.Current.DaiFuSerialCount, "customerDaiFu"); //代付款
                if (string.IsNullOrEmpty(info.ID)) return new CommandResult(ResultCode.Fail, "创建单号失败，请重试");
            }
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            Customer c = ProviderFactory.Create<ICustomerProvider>(_RepoUri).GetByID(info.CustomerID).QueryObject;
            if (c != null)
            {
                CustomerReceivable cr = new CustomerReceivable()
                {
                    ID = info.ID,
                    CreateDate = info.DaiFuDate,
                    CustomerID = info.CustomerID,
                    Amount = info.Amount,
                    Memo = "代付款"
                };
                ProviderFactory.Create<ICustomerReceivableProvider>(_RepoUri).Insert(cr, unitWork);
                ProviderFactory.Create<ICustomerDaiFuProvider>(_RepoUri).Insert(info, unitWork);
                return unitWork.Commit();
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "系统中不存在此代付的客户");
            }
        }
        /// <summary>
        /// 取消客户代付款项
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult Cancel(CustomerDaiFu info, string opt, bool payforOtherReceivables)
        {
            CustomerDaiFu original = ProviderFactory.Create<ICustomerDaiFuProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original == null) return new CommandResult(ResultCode.Fail, "系统中不存在此项");
            if (original.CancelDate != null) return new CommandResult(ResultCode.Fail, "取消的单据不能再次取消");

            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            Customer c = ProviderFactory.Create<ICustomerProvider>(_RepoUri).GetByID(info.CustomerID).QueryObject;
            if (c != null)
            {
                //如果已经有客户付款分配项了,则先将分配金额转移到别的应收项里面,并删除此项应收项的分配项.
                CustomerPaymentAssignSearchCondition con = new CustomerPaymentAssignSearchCondition();
                con.ReceivableID = info.ID;
                List<CustomerPaymentAssign> assigns = ProviderFactory.Create<ICustomerPaymentAssignProvider>(_RepoUri).GetItems(con).QueryObjects;
                if (assigns != null && assigns.Count > 0)
                {
                    foreach (CustomerPaymentAssign assign in assigns)
                    {
                        if(payforOtherReceivables )(new CustomerPaymentBLL(_RepoUri)).SettleReceivables(assign.PaymentID, c.ID, assign.Amount, null, info.ID, unitWork);
                        ProviderFactory.Create<ICustomerPaymentAssignProvider>(_RepoUri).Delete(assign);
                    }
                }
                //删除对应的应收项
                CustomerReceivable cr = ProviderFactory.Create<ICustomerReceivableProvider>(_RepoUri).GetByID(info.ID).QueryObject;
                if (cr != null) ProviderFactory.Create<ICustomerReceivableProvider>(_RepoUri).Delete(cr, unitWork);

                //把自身状态设置成取消
                original = info.Clone();
                info.CancelDate = DateTime.Now;
                info.CancelOperator = opt;
                ProviderFactory.Create<ICustomerDaiFuProvider>(_RepoUri).Update(info, original, unitWork);
                return unitWork.Commit();
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "系统中不存在此代付的客户");
            }
        }
        #endregion
    }
}
