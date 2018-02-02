using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class AccountBLL : BLLBase<string, Account>
    {
        #region 构造函数
        public AccountBLL(string repUri)
            : base(repUri)
        {
        }
        #endregion

        #region 私有方法
        private string CreateCustomerID()
        {
            string id = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("BNK", 3, "Account");
            return id;
        }
        #endregion

        #region 公共方法
        public override CommandResult Add(Account info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = CreateCustomerID();
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                return base.Add(info);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "创建编号失败，请重试");
            }
        }

        public override CommandResult Delete(Account info)
        {
            CustomerPaymentSearchCondition con = new CustomerPaymentSearchCondition();
            con.AccountID = info.ID;
            var sheets = (new CustomerPaymentBLL(RepoUri)).GetItems(con).QueryObjects;
            if (sheets != null && sheets.Count > 0)
            {
                return new CommandResult(ResultCode.Fail, string.Format("不能删除账户 {0} 的资料，系统中已经存在此账号的收付款流水", info.Name));
            }
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            ProviderFactory.Create<IProvider<Account, string>>(RepoUri).Delete(info, unitWork);
            return unitWork.Commit();
        }

        public decimal GetRemain(string accountID)
        {
            decimal ret = 0;
            var con = new AccountRecordSearchCondition() { AccountID = accountID };
            var cps = new AccountRecordBLL(RepoUri).GetItems(con).QueryObjects;
            if (cps != null && cps.Count > 0)
            {
                foreach (var it in cps)
                {
                    switch (it.ClassID)
                    {
                        case CustomerPaymentType.客户收款:
                        case CustomerPaymentType.其它收款:
                        case CustomerPaymentType.转账入:
                        case CustomerPaymentType.供应商退款:
                        case CustomerPaymentType.管理费用退款:
                            ret += it.Amount;
                            break;
                        case CustomerPaymentType.供应商付款:
                        case CustomerPaymentType.管理费用:
                        case CustomerPaymentType.转账出:
                        case CustomerPaymentType.客户退款:
                            ret -= it.Amount;
                            break;
                        default:
                            break;
                    }
                }
            }
            return ret;
        }
        #endregion
    }
}
