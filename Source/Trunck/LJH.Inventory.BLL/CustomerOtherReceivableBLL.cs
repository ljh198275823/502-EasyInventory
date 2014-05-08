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

        protected override void DoNullify(CustomerOtherReceivable info, IUnitWork unitWork, DateTime dt, string opt)
        {
            base.DoNullify(info, unitWork, dt, opt);
            ////如果已经有客户付款分配项了,则先将分配金额转移到别的应收项里面,并删除此项应收项的分配项.
            //CustomerPaymentAssignSearchCondition con = new CustomerPaymentAssignSearchCondition();
            //con.ReceivableID = info.ID;
            //List<CustomerPaymentAssign> assigns = ProviderFactory.Create<IProvider<CustomerPaymentAssign, Guid>>(_RepoUri).GetItems(con).QueryObjects;
            //if (assigns != null && assigns.Count > 0)
            //{
            //    foreach (CustomerPaymentAssign assign in assigns)
            //    {
            //        ProviderFactory.Create<IProvider<CustomerPaymentAssign, Guid>>(_RepoUri).Delete(assign, unitWork);
            //    }
            //}
        }
        #endregion
    }
}
