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
    public class AccountRecordAssignBLL : BLLBase<Guid, AccountRecordAssign>
    {
        #region 构造函数
        public AccountRecordAssignBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 重写基类方法
        public override CommandResult Add(AccountRecordAssign info)
        {
            return new CommandResult(ResultCode.Fail, "不支持的操作，要增加分配项请调用Assign方法");
        }

        public override CommandResult Update(AccountRecordAssign info)
        {
            return new CommandResult(ResultCode.Fail, "不支持的操作，要修改分配项请调用Assign方法");
        }

        public override CommandResult Delete(AccountRecordAssign info)
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
        public CommandResult Assign(AccountRecordAssign assign)
        {
            if (assign == null) return new CommandResult(ResultCode.Fail, "没有分配项");
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            AccountRecord cp = ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).GetByID(assign.PaymentID).QueryObject;
            if (cp != null && cp.Remain >= assign.Amount)
            {
                CustomerReceivable cr = ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).GetByID(assign.ReceivableID).QueryObject;
                if (cr != null && cr.Remain >= assign.Amount)
                {
                    if ((cp.ClassID == CustomerPaymentType.客户收款 && cr.ClassID == CustomerReceivableType.CustomerReceivable) ||
                        (cp.ClassID == CustomerPaymentType.供应商付款 && cr.ClassID == CustomerReceivableType.SupplierReceivable) ||
                        (cp.ClassID == CustomerPaymentType.客户增值税发票 && cr.ClassID == CustomerReceivableType.CustomerTax) ||
                        (cp.ClassID == CustomerPaymentType.供应商增值税发票 && cr.ClassID == CustomerReceivableType.SupplierTax) ||
                        (cp.ClassID == CustomerPaymentType.公账 && cr.ClassID == CustomerReceivableType.公账应收款))
                    {
                        AccountRecord cp1 = cp.Clone();
                        CustomerReceivable cr1 = cr.Clone();
                        cp.Assigned += assign.Amount;
                        cr.Haspaid += assign.Amount;
                        ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).Update(cp, cp1, unitWork);
                        ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Update(cr, cr1, unitWork);
                        ProviderFactory.Create<IProvider<AccountRecordAssign, Guid>>(RepoUri).Insert(assign, unitWork);
                    }
                    else
                    {
                        return new CommandResult(ResultCode.Fail, "核销双方的类型不匹配，不能核销");
                    }
                }
            }
            return unitWork.Commit();
        }
        /// <summary>
        /// 取消客户收款和应收款已核销项
        /// </summary>
        /// <param name="assign"></param>
        /// <returns></returns>
        public CommandResult UndoAssign(AccountRecordAssign assign)
        {
            if (assign == null) return new CommandResult(ResultCode.Fail, "没有分配项");
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            AccountRecord cp = ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).GetByID(assign.PaymentID).QueryObject;
            if (cp != null && cp.Assigned >= assign.Amount)
            {
                CustomerReceivable cr = ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).GetByID(assign.ReceivableID).QueryObject;
                if (cr != null && cr.Haspaid >= assign.Amount)
                {
                    AccountRecord cp1 = cp.Clone();
                    CustomerReceivable cr1 = cr.Clone();
                    cp.Assigned -= assign.Amount;
                    cr.Haspaid -= assign.Amount;
                    ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).Update(cp, cp1, unitWork);
                    ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Update(cr, cr1, unitWork);
                    ProviderFactory.Create<IProvider<AccountRecordAssign, Guid>>(RepoUri).Delete(assign, unitWork);
                }
            }
            return unitWork.Commit();
        }

        public CommandResult UndoAssign(CustomerReceivable cr, decimal undoMoney)
        {
            try
            {
                if (undoMoney <= 0) return new CommandResult(ResultCode.Fail, "取消的金额不大于零");
                if (cr.Haspaid <= 0) return new CommandResult(ResultCode.Fail, "没有核销金额");
                var crClone = cr.Clone();
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
                var con = new AccountRecordAssignSearchCondition() { ReceivableID = cr.ID };
                var assigns = ProviderFactory.Create<IProvider<AccountRecordAssign, Guid>>(RepoUri).GetItems(con).QueryObjects;
                var cps = new List<AccountRecord>();
                var cpclones = new List<AccountRecord>();
                if (assigns != null && assigns.Count > 0)
                {
                    foreach (var assign in assigns)
                    {
                        if (!cps.Exists(it => it.ID == assign.PaymentID)) //把所有相关的核销缓存下来，因为有那种多对多的情况
                        {
                            var ar = ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).GetByID(assign.PaymentID).QueryObject;
                            //判断是否是可以核销的金额
                            if ((ar.ClassID == CustomerPaymentType.客户收款 && cr.ClassID == CustomerReceivableType.CustomerReceivable) ||
                                (ar.ClassID == CustomerPaymentType.供应商付款 && cr.ClassID == CustomerReceivableType.SupplierReceivable) ||
                                (ar.ClassID == CustomerPaymentType.客户增值税发票 && cr.ClassID == CustomerReceivableType.CustomerTax) ||
                                (ar.ClassID == CustomerPaymentType.供应商增值税发票 && cr.ClassID == CustomerReceivableType.SupplierTax) ||
                                (ar.ClassID == CustomerPaymentType.公账 && cr.ClassID == CustomerReceivableType.公账应收款))
                            {
                                cps.Add(ar);
                            }
                            else
                            {
                                continue;
                            }
                        }

                        var cp = cps.Single(it => it.ID == assign.PaymentID);
                        if (!cpclones.Exists(it => it.ID == cp.ID)) cpclones.Add(cp.Clone());
                        var cpClone = cpclones.Single(it => it.ID == cp.ID);
                        if (assign.Amount > undoMoney)
                        {
                            cpClone.Assigned -= undoMoney;
                            crClone.Haspaid -= undoMoney;
                            var assignClone = assign.Clone();
                            assign.Amount -= undoMoney;
                            ProviderFactory.Create<IProvider<AccountRecordAssign, Guid>>(RepoUri).Update(assign, assignClone, unitWork);
                            break;
                        }
                        else
                        {
                            cpClone.Assigned -= undoMoney;
                            crClone.Haspaid -= undoMoney;
                            ProviderFactory.Create<IProvider<AccountRecordAssign, Guid>>(RepoUri).Delete(assign, unitWork);
                        }
                    }
                }
                foreach (var newVal in cpclones)
                {
                    var cp = cps.Single(it => it.ID == newVal.ID);
                    ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).Update(newVal, cp, unitWork);
                }
                ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Update(crClone, cr, unitWork);
                var ret = unitWork.Commit();
                if (ret.Result == ResultCode.Successful) cr.Haspaid = crClone.Haspaid;
                return ret;
            }
            catch (Exception ex)
            {
                return new CommandResult(ResultCode.Fail, ex.Message);
            }
        }
        #endregion
    }
}
