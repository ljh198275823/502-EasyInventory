using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory .BusinessModel .SearchCondition ;
using LJH.Inventory .DAL .IProvider ;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class ExpenditureRecordBLL : SheetProcessorBase<ExpenditureRecord>
    {
        #region 构造函数
        public ExpenditureRecordBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 公共方法
        protected override string CreateSheetID(ExpenditureRecord info)
        {
            info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber(UserSettings.Current.SupplierPaymentPrefix,
                    UserSettings.Current.SupplierPaymentDateFormat, UserSettings.Current.SupplierPaymentSerialCount, info.DocumentType); //支出单
            return info.ID;
        }

        protected override void DoAdd(ExpenditureRecord info, IUnitWork unitWork, DateTime dt, string opt)
        {
            base.DoAdd(info, unitWork, dt, opt);
            DateTime now = DateTime.Now;
            AccountRecord ar = new AccountRecord()
            {
                ID = Guid.NewGuid(),
                ClassID = CustomerPaymentType.公司管理费用,
                SheetID = info.ID,
                CreateDate = new DateTime(info.SheetDate.Year, info.SheetDate.Month, info.SheetDate.Day, now.Hour, now.Minute, now.Second),
                StackSheetID = info.OrderID,
                AccountID = info.AccountID,
                Amount = info.Amount,
                OtherAccount = info.Payee,
                Memo = info.Memo
            };
            ProviderFactory.Create<IProvider<AccountRecord, Guid>>(RepoUri).Insert(ar, unitWork);
        }

        protected override void DoNullify(ExpenditureRecord info, IUnitWork unitWork, DateTime dt, string opt)
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
            if (!allSuccess) throw new Exception("删除失败");
            base.DoNullify(info, unitWork, dt, opt);
        }
        #endregion
    }
}
