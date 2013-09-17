using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.BLL
{
    public class CustomerOtherReceivableBLL
    {
        #region 构造函数
        public CustomerOtherReceivableBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        public QueryResult<CustomerOtherReceivable> GetByID(string id)
        {
            return ProviderFactory.Create<ICustomerOtherReceivableProvider>(_RepoUri).GetByID(id);
        }

        public QueryResultList<CustomerOtherReceivable> GetItems(SearchCondition con)
        {
            return ProviderFactory.Create<ICustomerOtherReceivableProvider>(_RepoUri).GetItems(con);
        }

        public QueryResultList<DocumentOperation> GetHisOperations(string sheetNo)
        {
            DocumentSearchCondition con = new DocumentSearchCondition()
            {
                DocumentID = sheetNo,
                DocumentType = CustomerOtherReceivable.DocumentType
            };
            return ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).GetItems(con);
        }

        public CommandResult Add(CustomerOtherReceivable info, string opt)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.DaiFuPrefix,
                    UserSettings.Current.DaiFuDateFormat, UserSettings.Current.DaiFuSerialCount, CustomerOtherReceivable.DocumentType); //代付款
                if (string.IsNullOrEmpty(info.ID)) return new CommandResult(ResultCode.Fail, "创建单号失败，请重试");
            }
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            Customer c = ProviderFactory.Create<ICustomerProvider>(_RepoUri).GetByID(info.CustomerID).QueryObject;
            if (c != null)
            {
                ProviderFactory.Create<ICustomerOtherReceivableProvider>(_RepoUri).Insert(info, unitWork);
                DocumentOperation doc = new DocumentOperation()
                {
                    DocumentID = info.ID,
                    DocumentType = CustomerOtherReceivable.DocumentType,
                    OperatDate = DateTime.Now,
                    Operation = "新增",
                    State = SheetState.Add,
                    Operator = opt,
                };
                ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).Insert(doc, unitWork);
                return unitWork.Commit();
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "系统中不存在此代付的客户");
            }
        }

        public CommandResult Approve(string sheetNo, string opt)
        {
            CustomerOtherReceivable info = ProviderFactory.Create<ICustomerOtherReceivableProvider>(_RepoUri).GetByID(sheetNo).QueryObject;
            if (info != null)
            {
                if (info.State == SheetState.Add)
                {
                    IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                    CustomerOtherReceivable original = info.Clone();
                    info.State = SheetState.Approved;
                    ProviderFactory.Create<ICustomerOtherReceivableProvider>(_RepoUri).Update(info, original, unitWork);

                    DocumentOperation doc = new DocumentOperation()
                    {
                        DocumentID = info.ID,
                        DocumentType = CustomerOtherReceivable.DocumentType,
                        OperatDate = DateTime.Now,
                        Operation = "审核",
                        State = SheetState.Approved,
                        Operator = opt,
                    };
                    ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).Insert(doc, unitWork);
                    return unitWork.Commit();
                }
                else
                {
                    return new CommandResult(ResultCode.Fail, "已经审核过的单据不能再审核");
                }
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "单据在系统中已经不存在");
            }
        }
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
                DocumentType = CustomerOtherReceivable.DocumentType,
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
