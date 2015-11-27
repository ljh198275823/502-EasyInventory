using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory .DAL .IProvider ;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class CustomerReceivableBLL : BLLBase<Guid, CustomerReceivable>
    {
        #region 构造函数
        public CustomerReceivableBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        public CommandResult Delete(CustomerReceivable info)
        {
            CustomerPaymentAssignSearchCondition con = new CustomerPaymentAssignSearchCondition() { ReceivableID = info.ID };
            List<CustomerPaymentAssign> assigns = new CustomerPaymentAssignBLL(RepoUri).GetItems(con).QueryObjects;
            if (assigns != null && assigns.Count > 0)
            {
                bool allSuccess = true;
                foreach (CustomerPaymentAssign assign in assigns)
                {
                    CommandResult ret = (new CustomerPaymentAssignBLL(RepoUri)).UndoAssign(assign);
                    if (ret.Result != ResultCode.Successful) allSuccess = false;
                }
                if (!allSuccess) return new CommandResult(ResultCode.Fail, "某些应收核销项删除失败");
            }
            return base.Delete(info);
        }
    }
}
