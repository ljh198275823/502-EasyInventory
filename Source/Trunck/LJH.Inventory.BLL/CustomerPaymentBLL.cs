using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.BLL
{
    public class CustomerPaymentBLL
    {
        #region 构造函数
        public CustomerPaymentBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 动态库内部方法
        /// <summary>
        /// 结算各项应收账款明细
        /// </summary>
        /// <param name="paymentID">客户付款ID</param>
        /// <param name="customerID">客户ID</param>
        /// <param name="amount">结算的金额</param>
        /// <param name="firstSheet">结算的送货单,没有指定的话填空或null</param>
        /// <param name="exceptID">不用结算的送货单,没有指定的话填空或null</param>
        /// <param name="exceptDaiFu">不用结算的代付款项,没有指定的话填0</param>
        /// <param name="unitWork">工作单元</param>
        /// <returns></returns>
        internal void SettleReceivables(string paymentID, string customerID, decimal amount, string receivableID, string exceptID, IUnitWork unitWork)
        {
            //if (amount <= 0) return;
            //if (!string.IsNullOrEmpty(receivableID))
            //{
            //    CustomerReceivable cr = ProviderFactory.Create<ICustomerReceivableProvider>(_RepoUri).GetByID(receivableID).QueryObject;
            //    if (cr != null && cr.Receivable >0)
            //    {
            //        decimal temp = cr.Receivable >= amount ? amount : cr.Receivable;
            //        CustomerPaymentAssign cpa = new CustomerPaymentAssign()
            //        {
            //            PaymentID = paymentID,
            //            ReceivableID = cr.ID,
            //            Amount = temp
            //        };
            //        ProviderFactory.Create<ICustomerPaymentAssignProvider>(_RepoUri).Insert(cpa, unitWork);
            //    }
            //}
            //else
            //{
            //    List<CustomerReceivable> items = (new CustomerBLL(_RepoUri)).GetUnSettleReceivables(customerID);
            //    if (items != null && items.Count > 0)
            //    {
            //        items = (from item in items orderby item.CreateDate ascending select item).ToList();
            //        foreach (CustomerReceivable cr in items)
            //        {
            //            if (cr.ID != exceptID)
            //            {
            //                decimal temp = cr.Receivable >= amount ? amount : cr.Receivable;
            //                CustomerPaymentAssign cpa = new CustomerPaymentAssign()
            //                {
            //                    PaymentID = paymentID,
            //                    ReceivableID = cr.ID,
            //                    Amount = temp
            //                };
            //                ProviderFactory.Create<ICustomerPaymentAssignProvider>(_RepoUri).Insert(cpa, unitWork);
            //                amount -= temp;
            //                if (amount == 0) return;
            //            }
            //        }
            //    }
            //}
        }
        #endregion

        #region 公共方法
        public QueryResult<CustomerPayment> GetByID(string paymentID)
        {
            return ProviderFactory.Create<ICustomerPaymentProvider>(_RepoUri).GetByID(paymentID);
        }
        /// <summary>
        /// 通过指定条件获取符合的客户付款单
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public QueryResultList<CustomerPayment> GetItems(SearchCondition con)
        {
            ICustomerPaymentProvider provider = ProviderFactory.Create<ICustomerPaymentProvider>(_RepoUri);
            return provider.GetItems(con);
        }
        /// <summary>
        /// 获取某个客户的所有还有余额的付款单
        /// </summary>
        /// <returns></returns>
        public QueryResultList<CustomerPayment> GetAllRemains(string customerID)
        {
            CustomerPaymentSearchCondition con = new CustomerPaymentSearchCondition();
            con.CustomerID = customerID;
            con.HasRemain = true;
            return ProviderFactory.Create<ICustomerPaymentProvider>(_RepoUri).GetItems(con);
        }
        /// <summary>
        /// 分配客户付款金额
        /// </summary>
        /// <param name="assigns"></param>
        /// <returns></returns>
        public CommandResult AssignPayment(List<CustomerPaymentAssign> assigns)
        {
            //IUnitWork unitwork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            //foreach (CustomerPaymentAssign assign in assigns)
            //{
            //    ProviderFactory.Create<ICustomerPaymentAssignProvider>(_RepoUri).Insert(assign, unitwork);
            //}
            //return unitwork.Commit();
            return null;
        }

        public QueryResultList<DocumentOperation> GetHisOperations(string sheetNo)
        {
            DocumentSearchCondition con = new DocumentSearchCondition()
            {
                DocumentID = sheetNo,
                DocumentType = CustomerPayment.DocumentType
            };
            return ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).GetItems(con);
        }
        /// <summary>
        /// 增加客户付款信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult Add(CustomerPayment info, string opt)
        {
            Customer customer = (new CustomerBLL(_RepoUri)).GetByID(info.CustomerID).QueryObject;
            if (customer == null) return new CommandResult(ResultCode.Fail, "系统中不存在编号为 " + info.CustomerID + " 的客户");
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.CustomerPaymentPrefix,
                    UserSettings.Current.CustomerPaymentDateFormat, UserSettings.Current.CustomerPaymentSerialCount, "customerPayment"); //付款单
                if (string.IsNullOrEmpty(info.ID)) return new CommandResult(ResultCode.Fail, "创建单号失败，请重试");
            }
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            if (info.Assigns != null) info.Assigns.ForEach(item => item.PaymentID = info.ID);
            ICustomerPaymentProvider provider = ProviderFactory.Create<ICustomerPaymentProvider>(_RepoUri);
            provider.Insert(info, unitWork);

            DocumentOperation doc = new DocumentOperation()
            {
                DocumentID = info.ID,
                DocumentType = CustomerPayment.DocumentType,
                OperatDate = DateTime.Now,
                Operation = "新增",
                State = SheetState.Add,
                Operator = opt,
            };
            ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).Insert(doc, unitWork);
            return unitWork.Commit();
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sheetNo"></param>
        /// <param name="opt"></param>
        /// <returns></returns>
        public CommandResult Approve(string sheetNo, string opt)
        {
            CustomerPayment info = ProviderFactory.Create<ICustomerPaymentProvider>(_RepoUri).GetByID(sheetNo).QueryObject;
            if (info != null)
            {
                if (info.State == SheetState.Add)
                {
                    IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                    CustomerPayment original = info.Clone();
                    info.State = SheetState.Approved;
                    ProviderFactory.Create<ICustomerPaymentProvider>(_RepoUri).Update(info, original, unitWork);

                    DocumentOperation doc = new DocumentOperation()
                    {
                        DocumentID = info.ID,
                        DocumentType = CustomerPayment.DocumentType,
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
        /// 增加并全部分配
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult Update(CustomerPayment info, string opt)
        {
            ICustomerPaymentProvider provider = ProviderFactory.Create<ICustomerPaymentProvider>(_RepoUri);
            CustomerPayment original = provider.GetByID(info.ID).QueryObject;
            if (original != null)
            {
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                provider.Update(info, original, unitWork);

                DocumentOperation doc = new DocumentOperation()
                {
                    DocumentID = info.ID,
                    DocumentType = CustomerPayment.DocumentType,
                    OperatDate = DateTime.Now,
                    Operation = "修改",
                    State = info.State,
                    Operator = opt,
                };
                ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).Insert(doc, unitWork);
                return unitWork.Commit();
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "系统中已经不存在单号为 " + info.ID + " 的客户收款流水单");
            }
        }
        /// <summary>
        /// 取消客户的付款记录
        /// </summary>
        /// <param name="info"></param>
        /// <param name="firstFromPrepay"></param>
        /// <returns></returns>
        public CommandResult Cancel(CustomerPayment info, string opt)
        {
            CustomerPayment original = ProviderFactory.Create<ICustomerPaymentProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original == null) return new CommandResult(ResultCode.Fail, "系统中不存在此项");
            if (original.State == SheetState.Canceled) return new CommandResult(ResultCode.Fail, "取消的单据不能再次取消");
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            //首先删除付款流水，然后再增加回来，这样做要达到的效果是把付款流水状态变成作废，而且分配项全部删除。
            CustomerPayment cp = info.Clone();
            info.State = SheetState.Canceled;
            info.Assigns.Clear();
            ProviderFactory.Create<ICustomerPaymentProvider>(_RepoUri).Update(info, cp, unitWork);

            DocumentOperation doc = new DocumentOperation()
            {
                DocumentID = info.ID,
                DocumentType = CustomerPayment.DocumentType,
                OperatDate = DateTime.Now,
                Operation = "取消",
                State = info.State,
                Operator = opt,
            };
            ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).Insert(doc, unitWork);
            return unitWork.Commit();
        }
        #endregion
    }
}