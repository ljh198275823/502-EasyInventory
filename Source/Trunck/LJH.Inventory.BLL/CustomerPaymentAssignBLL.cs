﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class CustomerPaymentAssignBLL:BLLBase <Guid,CustomerPaymentAssign>
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
        /// 客户付款和应收款进行抵销
        /// </summary>
        /// <param name="assigns"></param>
        /// <returns></returns>
        public CommandResult Assign(List<CustomerPaymentAssign> assigns)
        {
            if (assigns == null || assigns.Count == 0) return new CommandResult(ResultCode.Fail, "没有分配项");
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            foreach (CustomerPaymentAssign assign in assigns)
            {
                CustomerPayment cp = ProviderFactory.Create<IProvider<CustomerPayment, string>>(_RepoUri).GetByID(assign.PaymentID).QueryObject;
                if (cp != null && cp.Remain >= assign.Amount)
                {

                    CustomerReceivable cr = ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(_RepoUri).GetByID(assign.ReceivableID).QueryObject;
                    if (cr != null && cr.Remain >= assign.Amount)
                    {
                        CustomerPayment cp1 = cp.Clone() as CustomerPayment;
                        CustomerReceivable cr1 = cr.Clone() as CustomerReceivable;
                        cp.Assigned += assign.Amount;
                        cr.Haspaid += assign.Amount;
                        ProviderFactory.Create<IProvider<CustomerPayment, string>>(_RepoUri).Update(cp, cp1, unitWork);
                        ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(_RepoUri).Update(cr, cr1, unitWork);
                        ProviderFactory.Create<IProvider<CustomerPaymentAssign, Guid>>(_RepoUri).Insert(assign, unitWork);
                    }
                }
            }
            return unitWork.Commit();
        }
        /// <summary>
        /// 取消客户付款和应收款已抵销项
        /// </summary>
        /// <param name="assigns"></param>
        /// <returns></returns>
        public CommandResult UndoAssign(List<CustomerPaymentAssign> assigns)
        {
            if (assigns == null || assigns.Count == 0) return new CommandResult(ResultCode.Fail, "没有分配项");
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            foreach (CustomerPaymentAssign assign in assigns)
            {
                CustomerPayment cp = ProviderFactory.Create<IProvider<CustomerPayment, string>>(_RepoUri).GetByID(assign.PaymentID).QueryObject;
                if (cp != null)
                {
                    CustomerReceivable cr = ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(_RepoUri).GetByID(assign.ReceivableID).QueryObject;
                    if (cr != null)
                    {
                        CustomerPayment cp1 = cp.Clone() as CustomerPayment;
                        CustomerReceivable cr1 = cr.Clone() as CustomerReceivable;
                        cp.Assigned -= assign.Amount;
                        cr.Haspaid -= assign.Amount;
                        ProviderFactory.Create<IProvider<CustomerPayment, string>>(_RepoUri).Update(cp, cp1, unitWork);
                        ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(_RepoUri).Update(cr, cr1, unitWork);
                        ProviderFactory.Create<IProvider<CustomerPaymentAssign, Guid>>(_RepoUri).Delete(assign, unitWork);
                    }
                }
            }
            return unitWork.Commit();
        }
        #endregion
    }
}
