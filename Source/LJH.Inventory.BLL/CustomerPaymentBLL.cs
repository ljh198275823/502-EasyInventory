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
    public class CustomerPaymentBLL : SheetProcessorBase<CustomerPayment>
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
            if (info.ClassID == CustomerPaymentType.客户收款)
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber(UserSettings.Current.CustomerPaymentPrefix,
                        UserSettings.Current.CustomerPaymentDateFormat, UserSettings.Current.CustomerPaymentSerialCount, info.DocumentType);
            }
            else if (info.ClassID == CustomerPaymentType.供应商付款)
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("HKD",
                        UserSettings.Current.CustomerPaymentDateFormat, UserSettings.Current.CustomerPaymentSerialCount, info.DocumentType);
            }
            else if (info.ClassID == CustomerPaymentType.其它收款)
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("收", "yyMM", 3, info.DocumentType);
            }
            else if (info.ClassID == CustomerPaymentType.转公账)
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("转", "yyMM", 3, info.DocumentType);
            }
            else if (info.ClassID == CustomerPaymentType.客户退款 || info.ClassID == CustomerPaymentType.供应商退款)
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("退", "yyMM", 3, info.DocumentType);
            }
            return info.ID;
        }

        protected override void DoAdd(CustomerPayment info, IUnitWork unitWork, DateTime dt, string opt)
        {
            base.DoAdd(info, unitWork, dt, opt);
            DateTime now = DateTime.Now;
            if (info.ClassID == CustomerPaymentType.转公账)
            {
                AccountRecord ar = new AccountRecord()
                {
                    ID = Guid.NewGuid(),
                    ClassID = CustomerPaymentType.公账,
                    SheetID = info.ID,
                    CustomerID = info.CustomerID,
                    CreateDate = new DateTime(info.SheetDate.Year, info.SheetDate.Month, info.SheetDate.Day, now.Hour, now.Minute, now.Second),
                    StackSheetID = info.StackSheetID,
                    AccountID = info.AccountID,
                    Amount = info.Amount,
                    OtherAccount = info.Payer,
                    Memo = info.Memo
                };
                ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).Insert(ar, unitWork);

                ar = new AccountRecord()
                {
                    ID = Guid.NewGuid(),
                    ClassID = CustomerPaymentType.转账入,
                    SheetID = info.ID,
                    CustomerID = info.CustomerID,
                    CreateDate = new DateTime(info.SheetDate.Year, info.SheetDate.Month, info.SheetDate.Day, now.Hour, now.Minute, now.Second),
                    StackSheetID = info.StackSheetID,
                    AccountID = info.AccountID,
                    Amount = info.Amount,
                    OtherAccount = info.Payer,
                    Memo = info.Memo
                };
                ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).Insert(ar, unitWork);

                ar = new AccountRecord()
                {
                    ID = Guid.NewGuid(),
                    ClassID = CustomerPaymentType.转账出,
                    SheetID = info.ID,
                    CustomerID = info.CustomerID,
                    CreateDate = new DateTime(info.SheetDate.Year, info.SheetDate.Month, info.SheetDate.Day, now.Hour, now.Minute, now.Second),
                    StackSheetID = info.StackSheetID,
                    AccountID = info.Payer,
                    Amount = info.Amount,
                    OtherAccount = info.Payer,
                    Memo = info.Memo
                };
                ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).Insert(ar, unitWork);
            }
            else if (info.ClassID == CustomerPaymentType.客户收款 && info.PaymentMode == PaymentMode.公账)
            {
                AccountRecord ar = new AccountRecord()
                {
                    ID = Guid.NewGuid(),
                    ClassID = info.ClassID,
                    SheetID = info.ID,
                    CustomerID = info.CustomerID,
                    CreateDate = new DateTime(info.SheetDate.Year, info.SheetDate.Month, info.SheetDate.Day, now.Hour, now.Minute, now.Second),
                    StackSheetID = info.StackSheetID,
                    AccountID = info.AccountID,
                    Amount = info.Amount,
                    OtherAccount = info.Payer,
                    Memo = info.Memo
                };
                ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).Insert(ar, unitWork);

                ar = new AccountRecord()
                {
                    ID = Guid.NewGuid(),
                    ClassID = CustomerPaymentType.公账,
                    SheetID = info.ID,
                    CustomerID = info.CustomerID,
                    CreateDate = new DateTime(info.SheetDate.Year, info.SheetDate.Month, info.SheetDate.Day, now.Hour, now.Minute, now.Second),
                    StackSheetID = info.StackSheetID,
                    AccountID = info.AccountID,
                    Amount = info.Amount,
                    OtherAccount = info.Payer,
                    Memo = info.Memo
                };
                ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).Insert(ar, unitWork);
            }
            else if (info.ClassID == CustomerPaymentType.客户增值税发票)
            {
                AccountRecord ar = new AccountRecord()
                {
                    ID = Guid.NewGuid(),
                    ClassID = info.ClassID,
                    SheetID = info.ID,
                    CustomerID = info.CustomerID,
                    CreateDate = new DateTime(info.SheetDate.Year, info.SheetDate.Month, info.SheetDate.Day, now.Hour, now.Minute, now.Second),
                    StackSheetID = info.StackSheetID,
                    AccountID = info.AccountID,
                    Amount = info.Amount,
                    OtherAccount = info.Payer,
                    Memo = info.Memo
                };
                ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).Insert(ar, unitWork);
                if (info.PaymentMode == PaymentMode.公账)
                {
                    CustomerReceivable cr = new CustomerReceivable()
                    {
                        ID = Guid.NewGuid(),
                        ClassID = CustomerReceivableType.公账应收款,
                        CustomerID = info.CustomerID,
                        CreateDate = new DateTime(info.SheetDate.Year, info.SheetDate.Month, info.SheetDate.Day, now.Hour, now.Minute, now.Second),
                        SheetID = info.ID,
                        Amount = info.Amount,
                        Memo = info.Memo,
                    };
                    cr.SetProperty("购货单位", info.Payer);
                    cr.SetProperty("出票单位", info.AccountID);
                    ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Insert(cr, unitWork);
                }
            }
            else if (info.ClassID == CustomerPaymentType.客户退款 || info.ClassID == CustomerPaymentType.供应商退款)
            {
                AccountRecord ar = new AccountRecord()
                {
                    ID = Guid.NewGuid(),
                    ClassID = info.ClassID,
                    SheetID = info.ID,
                    CustomerID = info.CustomerID,
                    CreateDate = new DateTime(info.SheetDate.Year, info.SheetDate.Month, info.SheetDate.Day, now.Hour, now.Minute, now.Second),
                    StackSheetID = info.StackSheetID,
                    AccountID = info.AccountID,
                    Amount = info.Amount,
                    OtherAccount = info.Payer,
                    Memo = info.Memo
                };
                ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).Insert(ar, unitWork);
                CustomerReceivable cr = new CustomerReceivable()
                {
                    ID = Guid.NewGuid(),
                    ClassID = info.ClassID == CustomerPaymentType.客户退款 ? CustomerReceivableType.CustomerReceivable : CustomerReceivableType.SupplierReceivable,
                    CustomerID = info.CustomerID,
                    CreateDate = new DateTime(info.SheetDate.Year, info.SheetDate.Month, info.SheetDate.Day, now.Hour, now.Minute, now.Second),
                    SheetID = info.ID,
                    Amount = info.Amount,
                    Memo = info.Memo,
                };
                ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Insert(cr, unitWork);
            }
            else
            {
                AccountRecord ar = new AccountRecord()
                {
                    ID = Guid.NewGuid(),
                    ClassID = info.ClassID,
                    SheetID = info.ID,
                    CustomerID = info.CustomerID,
                    CreateDate = new DateTime(info.SheetDate.Year, info.SheetDate.Month, info.SheetDate.Day, now.Hour, now.Minute, now.Second),
                    StackSheetID = info.StackSheetID,
                    AccountID = info.AccountID,
                    Amount = info.Amount,
                    OtherAccount = info.Payer,
                    Memo = info.Memo
                };
                ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).Insert(ar, unitWork);
            }
        }

        protected override void DoUpdate(CustomerPayment info, IUnitWork unitWork, DateTime dt, string opt)
        {
            var con = new AccountRecordSearchCondition();
            con.SheetID = info.ID;
            var ars = ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).GetItems(con).QueryObjects;
            foreach (var ar in ars)
            {
                if (info.Amount < ar.Assigned) throw new Exception("请先取消超出核销部分的金额再修改!");
                var clone = ar.Clone();
                clone.Amount = info.Amount;
                ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).Update(clone, ar, unitWork);
            }
            base.DoUpdate(info, unitWork, dt, opt);
        }

        protected override void DoNullify(CustomerPayment info, IUnitWork unitWork, DateTime dt, string opt)
        {
            bool allSuccess = true;
            var items = new AccountRecordBLL(RepoUri).GetItems(new AccountRecordSearchCondition() { SheetID = info.ID }).QueryObjects;
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    var ret = new AccountRecordBLL(RepoUri).Delete(item);
                    if (ret.Result != ResultCode.Successful) allSuccess = false;
                }
            }

            var crs = new CustomerReceivableBLL(AppSettings.Current.ConnStr).GetItems(new CustomerReceivableSearchCondition() { SheetID = info.ID }).QueryObjects;
            if (crs != null && crs.Count > 0)
            {
                foreach (var cr in crs)
                {
                    var ret = new CustomerReceivableBLL(AppSettings.Current.ConnStr).Delete(cr);
                    if (ret.Result != ResultCode.Successful) allSuccess = false;
                }
            }

            if (!allSuccess) throw new Exception("删除失败");
            base.DoNullify(info, unitWork, dt, opt);
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取某个客户收款单的金额分配明细
        /// </summary>
        /// <param name="paymentID"></param>
        /// <returns></returns>
        public QueryResultList<AccountRecordAssign> GetAssigns(string paymentID)
        {
            AccountRecordSearchCondition con = new AccountRecordSearchCondition();
            con.SheetID = paymentID;
            var ars = ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).GetItems(con).QueryObjects;
            if (ars != null && ars.Count > 0)
            {
                List<AccountRecordAssign> ret = new List<AccountRecordAssign>();
                foreach (var ar in ars)
                {
                    AccountRecordAssignSearchCondition con1 = new AccountRecordAssignSearchCondition();
                    con1.PaymentID = ars[0].ID;
                    var assigns = ProviderFactory.Create<IProvider<AccountRecordAssign, Guid>>(RepoUri).GetItems(con1).QueryObjects;
                    if (assigns != null && assigns.Count > 0) ret.AddRange(assigns);
                }
                return new QueryResultList<AccountRecordAssign>(ResultCode.Successful, string.Empty, ret);
            }
            return new QueryResultList<AccountRecordAssign>(ResultCode.Successful, string.Empty, new List<AccountRecordAssign>());
        }

        public void 核销(CustomerPayment payment)
        {
            if (string.IsNullOrEmpty(payment.StackSheetID)) return;
            AccountRecordSearchCondition arsc = new AccountRecordSearchCondition();
            arsc.SheetID = payment.ID;
            arsc.PaymentTypes = new List<CustomerPaymentType>() { payment.ClassID };
            var ars = ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).GetItems(arsc).QueryObjects;
            if (ars == null || ars.Count == 0) return;

            CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
            con.SheetID = payment.StackSheetID;
            con.Settled = false;
            con.ReceivableTypes = new List<CustomerReceivableType>();
            if (payment.ClassID == CustomerPaymentType.客户收款)
            {
                con.ReceivableTypes.Add(CustomerReceivableType.CustomerReceivable);
            }
            else if (payment.ClassID == CustomerPaymentType.供应商付款)
            {
                con.ReceivableTypes.Add(CustomerReceivableType.SupplierReceivable);
            }
            var crs = new CustomerReceivableBLL(AppSettings.Current.ConnStr).GetItems(con).QueryObjects;
            if (crs == null || crs.Count == 0) return;

            foreach (var ar in ars)
            {
                foreach (var cr in crs)
                {
                    var assign = new AccountRecordAssign()
                    {
                        ID = Guid.NewGuid(),
                        PaymentID = ar.ID,
                        ReceivableID = cr.ID,
                        Amount = ar.Remain >= cr.Remain ? cr.Remain : ar.Remain
                    };
                    ar.Assigned += assign.Amount;
                    cr.Haspaid += assign.Amount;
                    new AccountRecordAssignBLL(AppSettings.Current.ConnStr).Assign(assign);
                }
            }
        }

        public List<string> 获取所有出票单位()
        {
            return ProviderFactory.Create<ICustomerPaymentProvider>(RepoUri).获取所有出票单位();
        }
        #endregion
    }
}