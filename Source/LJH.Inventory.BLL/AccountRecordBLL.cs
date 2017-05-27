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
    public class AccountRecordBLL : BLLBase<Guid, AccountRecord>
    {
        #region 构造函数
        public AccountRecordBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 重写基类方法
        public override CommandResult Delete(AccountRecord info)
        {
            AccountRecordAssignSearchCondition con = new AccountRecordAssignSearchCondition() { PaymentID = info.ID };
            List<AccountRecordAssign> assigns = new AccountRecordAssignBLL(RepoUri).GetItems(con).QueryObjects;
            if (assigns != null && assigns.Count > 0)
            {
                bool allSuccess = true;
                foreach (AccountRecordAssign assign in assigns)
                {
                    CommandResult ret = (new AccountRecordAssignBLL(RepoUri)).UndoAssign(assign);
                    if (ret.Result != ResultCode.Successful) allSuccess = false;
                }
                if (!allSuccess) return new CommandResult(ResultCode.Fail, "某些核销项删除失败");
            }
            return base.Delete(info);
        }

        public QueryResult<AccountRecord> GetRecord(string sheetID, CustomerPaymentType cpt)
        {
            var con = new AccountRecordSearchCondition() { SheetID = sheetID, PaymentTypes = new List<CustomerPaymentType>() { cpt } };
            var q = new AccountRecordBLL(AppSettings.Current.ConnStr).GetItems(con);
            if (q.Result == ResultCode.Successful && q.QueryObjects != null && q.QueryObjects.Count == 1)
            {
                return new QueryResult<AccountRecord>(ResultCode.Successful, string.Empty, q.QueryObjects[0]);
            }
            return new QueryResult<AccountRecord>(ResultCode.Fail, "失败", null);
        }
        #endregion
    }
}
