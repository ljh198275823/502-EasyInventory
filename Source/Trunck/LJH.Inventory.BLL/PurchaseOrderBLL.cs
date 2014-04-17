using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.BLL
{
    public class PurchaseOrderBLL
    {
        #region 构造函数
        public PurchaseOrderBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        /// <summary>
        /// 通过订单号获取订单
        /// </summary>
        /// <param name="PurchaseSheetID"></param>
        /// <returns></returns>
        public QueryResult<PurchaseOrder> GetByID(string PurchaseSheetID)
        {
            IPurchaseOrderProvider provider = ProviderFactory.Create<IPurchaseOrderProvider>(_RepoUri);
            return provider.GetByID(PurchaseSheetID);
        }

        public QueryResultList<PurchaseOrder> GetItems(SearchCondition con)
        {
            return ProviderFactory.Create<IPurchaseOrderProvider>(_RepoUri).GetItems(con);
        }

        public QueryResultList<PurchaseItemRecord> GetRecords(SearchCondition con)
        {
            return ProviderFactory.Create<IPurchaseItemRecordProvider>(_RepoUri).GetItems(con);
        }

        /// <summary>
        /// 增加一个订单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult Add(PurchaseOrder info, string opt)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.PurchaseSheetPrefix,
                    UserSettings.Current.PurchaseSheetDateFormat, UserSettings.Current.PurchaseSheetSerialCount, info.DocumentType);
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                info.Items.ForEach(item => item.PurchaseID = info.ID);//这一句不能省!!

                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                IPurchaseOrderProvider provider = ProviderFactory.Create<IPurchaseOrderProvider>(_RepoUri);
                provider.Insert(info, unitWork);

                DocumentOperation doc = new DocumentOperation()
                {
                    DocumentID = info.ID,
                    DocumentType = info.DocumentType,
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
                return new CommandResult(ResultCode.Fail, "创建订单号失败，请重试");
            }
        }

        public CommandResult Update(PurchaseOrder info, string opt)
        {
            PurchaseOrder original = ProviderFactory.Create<IPurchaseOrderProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original != null)
            {
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                ProviderFactory.Create<IPurchaseOrderProvider>(_RepoUri).Update(info, original, unitWork);
                DocumentOperation doc = new DocumentOperation()
                {
                    DocumentID = info.ID,
                    DocumentType = info.DocumentType,
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
                return new CommandResult(ResultCode.Fail, string.Format("系统中不存在订单号为 {0} 的订单", info.ID));
            }
        }
        /// <summary>
        /// 审批收货单
        /// </summary>
        /// <param name="info"></param>
        /// <param name="approver"></param>
        /// <returns></returns>
        public CommandResult Approve(string sheetNo, string approver)
        {
            PurchaseOrder info = ProviderFactory.Create<IPurchaseOrderProvider>(_RepoUri).GetByID(sheetNo).QueryObject;
            if (info != null)
            {
                if (info.CanApprove)
                {
                    IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                    PurchaseOrder original = info.Clone();
                    info.State = SheetState.Approved;
                    ProviderFactory.Create<IPurchaseOrderProvider>(_RepoUri).Update(info, original, unitWork);

                    DocumentOperation doc = new DocumentOperation()
                    {
                        DocumentID = info.ID,
                        DocumentType = info.DocumentType,
                        OperatDate = DateTime.Now,
                        Operation = "审核",
                        State = SheetState.Approved,
                        Operator = approver,
                    };
                    ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).Insert(doc, unitWork);
                    return unitWork.Commit();
                }
                else
                {
                    return new CommandResult(ResultCode.Fail, "单号为 " + info.ID + " 的订单不能再审核");
                }
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "系统中已经不存在单号为 " + info.ID + " 的订单");
            }
        }
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="PurchaseSheet"></param>
        /// <returns></returns>
        public CommandResult Delete(PurchaseOrder PurchaseSheet)
        {
            IPurchaseOrderProvider provider = ProviderFactory.Create<IPurchaseOrderProvider>(_RepoUri);
            return provider.Delete(PurchaseSheet);
        }
        /// <summary>
        /// 将订单作废
        /// </summary>
        /// <param name="sheetNo"></param>
        /// <param name="operatorName"></param>
        /// <returns></returns>
        public CommandResult Nullify(string sheetNo, string operatorName)
        {
            PurchaseOrder info = ProviderFactory.Create<IPurchaseOrderProvider>(_RepoUri).GetByID(sheetNo).QueryObject;
            if (info != null)
            {
                if (info.CanCancel)
                {
                    IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                    PurchaseOrder original = info.Clone();
                    info.State = SheetState.Canceled;
                    ProviderFactory.Create<IPurchaseOrderProvider>(_RepoUri).Update(info, original, unitWork);
                    DocumentOperation doc = new DocumentOperation()
                    {
                        DocumentID = info.ID,
                        DocumentType = info.DocumentType,
                        OperatDate = DateTime.Now,
                        Operation = "作废",
                        State = SheetState.Canceled,
                        Operator = operatorName
                    };
                    ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).Insert(doc, unitWork);
                    return unitWork.Commit();
                }
                else
                {
                    return new CommandResult(ResultCode.Fail, "单号为 " + info.ID + " 的订单已经作废");
                }
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "系统中已经不存在单号为 " + info.ID + " 的订单");
            }
        }
        #endregion
    }
}

