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
    public class CustomerOtherReceivableBLL : SheetProcessorBase<CustomerOtherReceivable>
    {
        #region 构造函数
        public CustomerOtherReceivableBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 重写基类方法
        protected override string CreateSheetID(CustomerOtherReceivable info)
        {
            info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.DaiFuPrefix,
                    UserSettings.Current.DaiFuDateFormat, UserSettings.Current.DaiFuSerialCount, info.DocumentType); //代付款
            return info.ID;
        }

        protected override void DoApprove(CustomerOtherReceivable info, IUnitWork unitWork, DateTime dt, string opt)
        {
            CustomerReceivable cr = new CustomerReceivable()
            {
                ID = Guid.NewGuid(),
                ClassID = CustomerReceivableClass.Other,
                SheetID = info.ID,
                CustomerID = info.CustomerID,
                CreateDate = dt,
                Amount = info.Amount,
                Haspaid = 0,
                Memo = info.Memo
            };
            ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(_RepoUri).Insert(cr, unitWork);
            base.DoApprove(info, unitWork, dt, opt);
        }

        protected override void UndoApprove(CustomerOtherReceivable info, IUnitWork unitWork, DateTime dt, string opt)
        {
            CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
            con.SheetID = info.ID;
            List<CustomerReceivable> items = new CustomerReceivableBLL(_RepoUri).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                CustomerReceivable cr = items.FirstOrDefault(it => it.ClassID == CustomerReceivableClass.Other);
                if (cr != null)
                {
                    CustomerPaymentAssignSearchCondition con1 = new CustomerPaymentAssignSearchCondition();
                    con1.ReceivableIDs = new List<Guid>();
                    con1.ReceivableIDs.Add(cr.ID);
                    List<CustomerPaymentAssign> assigns = (new CustomerPaymentAssignBLL(_RepoUri)).GetItems(con1).QueryObjects;
                    if (assigns != null && assigns.Count > 0)
                    {
                        bool allSuccess = true;
                        foreach (CustomerPaymentAssign assign in assigns)
                        {
                            CommandResult ret = (new CustomerPaymentAssignBLL(AppSettings.Current.ConnStr)).UndoAssign(assign);
                            if (ret.Result != ResultCode.Successful) allSuccess = false;
                        }
                        if (!allSuccess) throw new Exception("某些应收抵销项删除失败，请手动删除这些应收抵销项后再继续\"取消审核\"的操作");
                    }
                    ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(_RepoUri).Delete(cr, unitWork); //删除应收
                }
            }
            base.UndoApprove(info, unitWork, dt, opt);
        }

        protected override void DoNullify(CustomerOtherReceivable info, IUnitWork unitWork, DateTime dt, string opt)
        {
            CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
            con.SheetID = info.ID;
            List<CustomerReceivable> items = new CustomerReceivableBLL(_RepoUri).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                CustomerReceivable cr = items.FirstOrDefault(it => it.ClassID == CustomerReceivableClass.Other);
                if (cr != null)
                {
                    CustomerPaymentAssignSearchCondition con1 = new CustomerPaymentAssignSearchCondition();
                    con1.ReceivableIDs = new List<Guid>();
                    con1.ReceivableIDs.Add(cr.ID);
                    List<CustomerPaymentAssign> assigns = (new CustomerPaymentAssignBLL(_RepoUri)).GetItems(con1).QueryObjects;
                    if (assigns != null && assigns.Count > 0)
                    {
                        bool allSuccess = true;
                        foreach (CustomerPaymentAssign assign in assigns)
                        {
                            CommandResult ret = (new CustomerPaymentAssignBLL(AppSettings.Current.ConnStr)).UndoAssign(assign);
                            if (ret.Result != ResultCode.Successful) allSuccess = false;
                        }
                        if (!allSuccess) throw new Exception("某些应收抵销项删除失败，请手动删除这些应收抵销项后再继续\"作废\"的操作");
                    }
                    ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(_RepoUri).Delete(cr, unitWork); //删除应收
                }
            }
            base.DoNullify(info, unitWork, dt, opt);
        }
        #endregion
    }
}
