using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class CustomerPaymentAssignBLL : BLLBase<Guid, CustomerPaymentAssign>
    {
        #region 构造函数
        public CustomerPaymentAssignBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 重写基类方法
        public override CommandResult Add(CustomerPaymentAssign info)
        {
            return new CommandResult(ResultCode.Fail, "不支持的操作，要增加分配项请调用Assign方法");
        }

        public override CommandResult Update(CustomerPaymentAssign info)
        {
            return new CommandResult(ResultCode.Fail, "不支持的操作，要修改分配项请调用Assign方法");
        }

        public override CommandResult Delete(CustomerPaymentAssign info)
        {
            return new CommandResult(ResultCode.Fail, "不支持的操作，要删除分配项请调用UndoAssign方法");
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 客户收款和应收款进行核销
        /// </summary>
        /// <param name="assign"></param>
        /// <returns></returns>
        public CommandResult Assign(CustomerPaymentAssign assign)
        {
            if (assign == null) return new CommandResult(ResultCode.Fail, "没有分配项");
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            CustomerPayment cp = ProviderFactory.Create<IProvider<CustomerPayment, string>>(RepoUri).GetByID(assign.PaymentID).QueryObject;
            if (cp != null && cp.Remain >= assign.Amount)
            {
                CustomerReceivable cr = ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).GetByID(assign.ReceivableID).QueryObject;
                if (cr != null && cr.Remain >= assign.Amount)
                {
                    CustomerPayment cp1 = cp.Clone() as CustomerPayment;
                    CustomerReceivable cr1 = cr.Clone() as CustomerReceivable;
                    cp.Assigned += assign.Amount;
                    cr.Haspaid += assign.Amount;
                    ProviderFactory.Create<IProvider<CustomerPayment, string>>(RepoUri).Update(cp, cp1, unitWork);
                    ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Update(cr, cr1, unitWork);
                    ProviderFactory.Create<IProvider<CustomerPaymentAssign, Guid>>(RepoUri).Insert(assign, unitWork);
                }
            }
            return unitWork.Commit();
        }
        /// <summary>
        /// 取消客户收款和应收款已核销项
        /// </summary>
        /// <param name="assign"></param>
        /// <returns></returns>
        public CommandResult UndoAssign(CustomerPaymentAssign assign)
        {
            if (assign == null) return new CommandResult(ResultCode.Fail, "没有分配项");
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            CustomerPayment cp = ProviderFactory.Create<IProvider<CustomerPayment, string>>(RepoUri).GetByID(assign.PaymentID).QueryObject;
            if (cp != null && cp.Assigned >= assign.Amount)
            {
                CustomerReceivable cr = ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).GetByID(assign.ReceivableID).QueryObject;
                if (cr != null && cr.Haspaid >= assign.Amount)
                {
                    CustomerPayment cp1 = cp.Clone() as CustomerPayment;
                    CustomerReceivable cr1 = cr.Clone() as CustomerReceivable;
                    cp.Assigned -= assign.Amount;
                    cr.Haspaid -= assign.Amount;
                    ProviderFactory.Create<IProvider<CustomerPayment, string>>(RepoUri).Update(cp, cp1, unitWork);
                    ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Update(cr, cr1, unitWork);
                    ProviderFactory.Create<IProvider<CustomerPaymentAssign, Guid>>(RepoUri).Delete(assign, unitWork);
                }
            }
            return unitWork.Commit();
        }
        #endregion
    }
}
