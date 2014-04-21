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
        #endregion

        #region 公共方法
        /// <summary>
        /// 取消客户代付款项
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult Cancel(CustomerOtherReceivable info, string opt)
        {
            CustomerOtherReceivable original = ProviderFactory.Create<ICustomerOtherReceivableProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original == null) return new CommandResult(ResultCode.Fail, "系统中不存在此项");
            if (!original.CanCancel) return new CommandResult(ResultCode.Fail, "取消的单据不能再次取消");

            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            //如果已经有客户付款分配项了,则先将分配金额转移到别的应收项里面,并删除此项应收项的分配项.
            CustomerPaymentAssignSearchCondition con = new CustomerPaymentAssignSearchCondition();
            con.ReceivableID = info.ID;
            List<CustomerPaymentAssign> assigns = ProviderFactory.Create<ICustomerPaymentAssignProvider>(_RepoUri).GetItems(con).QueryObjects;
            if (assigns != null && assigns.Count > 0)
            {
                foreach (CustomerPaymentAssign assign in assigns)
                {
                    ProviderFactory.Create<ICustomerPaymentAssignProvider>(_RepoUri).Delete(assign, unitWork);
                }
            }
            //把自身状态设置成取消
            original = info.Clone();
            info.State = SheetState.Canceled;
            ProviderFactory.Create<ICustomerOtherReceivableProvider>(_RepoUri).Update(info, original, unitWork);
            DocumentOperation doc = new DocumentOperation()
            {
                DocumentID = info.ID,
                DocumentType = info.DocumentType,
                OperatDate = DateTime.Now,
                Operation = "作废",
                State = SheetState.Canceled,
                Operator = opt,
            };
            ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).Insert(doc, unitWork);
            return unitWork.Commit();
        }
        #endregion
    }
}
