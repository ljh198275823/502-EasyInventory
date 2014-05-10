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

        #region 重写基类方法
        protected override string CreateSheetID(CustomerPayment info)
        {
            info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.CustomerPaymentPrefix,
                    UserSettings.Current.CustomerPaymentDateFormat, UserSettings.Current.CustomerPaymentSerialCount, info.DocumentType );
            return info.ID;
        }

        protected override void UndoApprove(CustomerPayment info, IUnitWork unitWork, DateTime dt, string opt)
        {
            List<CustomerPaymentAssign> assigns = (new CustomerPaymentBLL(_RepoUri )).GetAssigns(info.ID).QueryObjects;
            if (assigns != null && assigns.Count > 0)
            {
                bool allSuccess = true;
                foreach (CustomerPaymentAssign assign in assigns)
                {
                    CommandResult ret = (new CustomerPaymentAssignBLL(_RepoUri )).UndoAssign(assign);
                    if (ret.Result != ResultCode.Successful) allSuccess = false;
                }
                if (!allSuccess) throw new Exception("某些应收抵销项删除失败，请手动删除这些应收抵销项后再继续\"取消审核\"的操作");
            }
            base.UndoApprove(info, unitWork, dt, opt);
        }

        protected override void DoNullify(CustomerPayment info, IUnitWork unitWork, DateTime dt, string opt)
        {
            List<CustomerPaymentAssign> assigns = (new CustomerPaymentBLL(_RepoUri )).GetAssigns(info.ID).QueryObjects;
            if (assigns != null && assigns.Count > 0)
            {
                bool allSuccess = true;
                foreach (CustomerPaymentAssign assign in assigns)
                {
                    CommandResult ret = (new CustomerPaymentAssignBLL(_RepoUri)).UndoAssign(assign);
                    if (ret.Result != ResultCode.Successful) allSuccess = false;
                }
                if (!allSuccess) throw new Exception("某些应收抵销项删除失败，请手动删除这些应收抵销项后再继续\"作废\"的操作");
            }
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
        /// <summary>
        /// 获取某个客户付款单的金额分配明细
        /// </summary>
        /// <param name="paymentID"></param>
        /// <returns></returns>
        public QueryResultList<CustomerPaymentAssign> GetAssigns(string paymentID)
        {
            CustomerPaymentAssignSearchCondition con = new CustomerPaymentAssignSearchCondition();
            con.PaymentID = paymentID;
            return ProviderFactory.Create<IProvider<CustomerPaymentAssign, Guid>>(_RepoUri).GetItems(con);
        }
        #endregion
    }
}