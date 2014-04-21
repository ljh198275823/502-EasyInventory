using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class CustomerPaymentBLL:SheetProcessorBase <CustomerPayment>
    {
        #region 构造函数
        public CustomerPaymentBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 动态库内部方法
        /// <summary>
        /// 结算各项应收账款明细
        /// </summary>
        /// <param name="paymentID">客户付款ID</param>
        /// <param name="customerID">客户ID</param>
        /// <param name="amount">结算的金额</param>
        /// <param name="firstSheet">结算的送货单,没有指定的话填空或null</param>
        /// <param name="exceptID">不用结算的送货单,没有指定的话填空或null</param>
        /// <param name="exceptDaiFu">不用结算的代付款项,没有指定的话填0</param>
        /// <param name="unitWork">工作单元</param>
        /// <returns></returns>
        internal void SettleReceivables(string paymentID, string customerID, decimal amount, string receivableID, string exceptID, IUnitWork unitWork)
        {
            //if (amount <= 0) return;
            //if (!string.IsNullOrEmpty(receivableID))
            //{
            //    CustomerReceivable cr = ProviderFactory.Create<ICustomerReceivableProvider>(_RepoUri).GetByID(receivableID).QueryObject;
            //    if (cr != null && cr.Receivable >0)
            //    {
            //        decimal temp = cr.Receivable >= amount ? amount : cr.Receivable;
            //        CustomerPaymentAssign cpa = new CustomerPaymentAssign()
            //        {
            //            PaymentID = paymentID,
            //            ReceivableID = cr.ID,
            //            Amount = temp
            //        };
            //        ProviderFactory.Create<ICustomerPaymentAssignProvider>(_RepoUri).Insert(cpa, unitWork);
            //    }
            //}
            //else
            //{
            //    List<CustomerReceivable> items = (new CustomerBLL(_RepoUri)).GetUnSettleReceivables(customerID);
            //    if (items != null && items.Count > 0)
            //    {
            //        items = (from item in items orderby item.CreateDate ascending select item).ToList();
            //        foreach (CustomerReceivable cr in items)
            //        {
            //            if (cr.ID != exceptID)
            //            {
            //                decimal temp = cr.Receivable >= amount ? amount : cr.Receivable;
            //                CustomerPaymentAssign cpa = new CustomerPaymentAssign()
            //                {
            //                    PaymentID = paymentID,
            //                    ReceivableID = cr.ID,
            //                    Amount = temp
            //                };
            //                ProviderFactory.Create<ICustomerPaymentAssignProvider>(_RepoUri).Insert(cpa, unitWork);
            //                amount -= temp;
            //                if (amount == 0) return;
            //            }
            //        }
            //    }
            //}
        }
        #endregion

        #region 重写基类方法
        protected override string CreateSheetID(CustomerPayment info)
        {
            info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.CustomerPaymentPrefix,
                    UserSettings.Current.CustomerPaymentDateFormat, UserSettings.Current.CustomerPaymentSerialCount, info.DocumentType );
            return info.ID;
        }

        protected override void DoNullify(CustomerPayment info, IUnitWork unitWork, DateTime dt, string opt)
        {
            base.DoNullify(info, unitWork, dt, opt);
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取某个客户的所有还有余额的付款单
        /// </summary>
        /// <returns></returns>
        public QueryResultList<CustomerPayment> GetAllRemains(string customerID)
        {
            CustomerPaymentSearchCondition con = new CustomerPaymentSearchCondition();
            con.CustomerID = customerID;
            con.HasRemain = true;
            return GetItems(con);
        }
        #endregion
    }
}