using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public abstract class SheetProcessorBase<TEntity> : BLLBase<string, TEntity> where TEntity : class, ISheet<string>
    {
        #region 构造函数
        public SheetProcessorBase(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 增加一个订单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual void DoAdd(TEntity info, IUnitWork unitWork, DateTime dt, string opt)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = CreateSheetID(info);
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                info.LastActiveDate = dt; //修改最后活动时间
                info.State = SheetState.Add; //单据状态
                IProvider<TEntity, string> provider = ProviderFactory.Create<IProvider<TEntity, string>>(_RepoUri);
                provider.Insert(info, unitWork);
            }
            else
            {
                throw new Exception("创建订单号失败，请重试");
            }
        }
        /// <summary>
        ///更新订单
        /// </summary>
        /// <param name="info"></param>
        /// <param name="opt"></param>
        /// <returns></returns>
        protected virtual void DoUpdate(TEntity info, IUnitWork unitWork, DateTime dt, string opt)
        {
            TEntity original = ProviderFactory.Create<IProvider<TEntity, string>>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original != null)
            {
                info.LastActiveDate = dt; //修改最后活动时间
                ProviderFactory.Create<IProvider<TEntity, string>>(_RepoUri).Update(info, original, unitWork);
            }
            else
            {
                throw new Exception(string.Format("系统中不存在订单号为 {0} 的订单", info.ID));
            }
        }
        /// <summary>
        /// 审批收货单
        /// </summary>
        /// <param name="info"></param>
        /// <param name="opt"></param>
        /// <returns></returns>
        protected virtual void DoApprove(TEntity info, IUnitWork unitWork, DateTime dt, string opt)
        {
            TEntity original = info.Clone() as TEntity;
            info.State = SheetState.Approved;
            info.LastActiveDate = dt; //修改最后活动时间
            ProviderFactory.Create<IProvider<TEntity, string>>(_RepoUri).Update(info, original, unitWork);
        }
        /// <summary>
        /// 取消审核
        /// </summary>
        /// <param name="info"></param>
        /// <param name="opt"></param>
        /// <returns></returns>
        protected virtual void UndoApprove(TEntity info, IUnitWork unitWork, DateTime dt, string opt)
        {
            TEntity original = info.Clone() as TEntity;
            info.State = SheetState.Add;
            info.LastActiveDate = dt; //修改最后活动时间
            ProviderFactory.Create<IProvider<TEntity, string>>(_RepoUri).Update(info, original, unitWork);
        }
        /// <summary>
        /// 将订单作废
        /// </summary>
        /// <param name="sheetNo"></param>
        /// <param name="opt"></param>
        /// <returns></returns>
        protected virtual void DoNullify(TEntity info, IUnitWork unitWork, DateTime dt, string opt)
        {
            TEntity original = info.Clone() as TEntity;
            info.State = SheetState.Canceled;
            info.LastActiveDate = dt; //修改最后活动时间
            ProviderFactory.Create<IProvider<TEntity, string>>(_RepoUri).Update(info, original, unitWork);
        }

        /// <summary>
        /// 将订单作废
        /// </summary>
        /// <param name="sheetNo"></param>
        /// <param name="opt"></param>
        /// <returns></returns>
        protected virtual void DoInventory(TEntity info, IUnitWork unitWork, DateTime dt, string opt)
        {
            throw new Exception(string.Format("没有实现 {0} 处理", SheetOperationDescription.GetDescription(SheetOperation.Inventory)));
        }

        /// <summary>
        /// 将订单作废
        /// </summary>
        /// <param name="sheetNo"></param>
        /// <param name="opt"></param>
        /// <returns></returns>
        protected virtual void DoShip(TEntity info, IUnitWork unitWork, DateTime dt, string opt)
        {
            throw new Exception(string.Format("没有实现 {0} 处理", SheetOperationDescription.GetDescription(SheetOperation.Ship)));
        }
        #endregion

        #region 子类要实现的方法
        /// <summary>
        /// 创建单据编号
        /// </summary>
        /// <returns></returns>
        protected abstract string CreateSheetID(TEntity info);
        /// <summary>
        /// 获取单据最后一次操作日期时间
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        protected virtual DateTime? GetLastActiveDate(TEntity sheet)
        {
            DateTime? dt = null;
            QueryResultList<DocumentOperation> ret = (new DocumentOperationBLL(_RepoUri)).GetHisOperations(sheet.ID, sheet.DocumentType);
            if (ret.Result == ResultCode.Successful && ret.QueryObjects.Count > 0)
            {
                foreach (DocumentOperation item in ret.QueryObjects)
                {
                    if (dt == null) dt = item.OperatDate;
                    if (dt.Value < item.OperatDate) dt = item.OperatDate;
                }
            }
            return dt;
        }
        /// <summary>
        /// 保存单据操作日志
        /// </summary>
        /// <param name="id"></param>
        /// <param name="docType"></param>
        /// <param name="operation"></param>
        /// <param name="opt"></param>
        /// <param name="unitWork"></param>
        /// <param name="dt"></param>
        protected virtual void AddOperationLog(string id, string docType, SheetOperation operation, string opt, IUnitWork unitWork, DateTime dt)
        {
            DocumentOperation doc = new DocumentOperation()
            {
                ID = Guid.NewGuid(),
                DocumentID = id,
                DocumentType = docType,
                OperatDate = dt,
                Operation = SheetOperationDescription.GetDescription(operation),
                Operator = opt,
            };
            ProviderFactory.Create<IProvider<DocumentOperation, Guid>>(_RepoUri).Insert(doc, unitWork);
        }
        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        protected virtual DateTime? GetServerDateTime()
        {
            DateTime? dt = null;
            ProviderFactory.Create<IServerDatetimeProvider>(_RepoUri).GetServerDateTime(out dt);
            return dt;
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 单据处理
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="operation"></param>
        /// <param name="opt"></param>
        /// <returns></returns>
        public CommandResult ProcessSheet(TEntity sheet, SheetOperation operation, string opt)
        {
            try
            {
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                DateTime? dt = GetServerDateTime(); //从数据库获取时间
                if (dt == null) return new CommandResult(ResultCode.Fail, "从数据库服务器获取时间失败");
                if (operation == SheetOperation.Create)
                {
                    sheet.LastActiveDate = dt.Value;
                    DoAdd(sheet, unitWork, dt.Value, opt);
                }
                else
                {
                    if (!sheet.CanDo(operation)) return new CommandResult(ResultCode.Fail, string.Format("单据不能进行 {0} 操作", SheetOperationDescription.GetDescription(operation)));
                    DateTime? lastActiveDate = GetLastActiveDate(sheet);
                    if (lastActiveDate == null) return new CommandResult(ResultCode.Fail, "获取单据最后操作时间失败，请重试");
                    //单据的最后活动时间与当前值不相同，说明其它操作员在此次修改之前修改过单据
                    if (sheet.LastActiveDate != lastActiveDate.Value) return new CommandResult(ResultCode.Fail, "其它操作员已经修改了数据，请先获取到最新数据后再做修改");
                    switch (operation)
                    {
                        case SheetOperation.Modify:
                            DoUpdate(sheet, unitWork, dt.Value, opt);
                            break;
                        case SheetOperation.Approve:
                            DoApprove(sheet, unitWork, dt.Value, opt);
                            break;
                        case SheetOperation.UndoApprove:
                            UndoApprove(sheet, unitWork, dt.Value, opt);
                            break;
                        case SheetOperation.Nullify:
                            DoNullify(sheet, unitWork, dt.Value, opt);
                            break;
                        case SheetOperation.Inventory:
                            DoInventory(sheet, unitWork, dt.Value, opt);
                            break;
                        case SheetOperation.Ship:
                            DoShip(sheet, unitWork, dt.Value, opt);
                            break;
                        default:
                            return new CommandResult(ResultCode.Fail, string.Format("没有实现 {0} 处理", SheetOperationDescription.GetDescription(operation)));
                    }
                }
                AddOperationLog(sheet.ID, sheet.DocumentType, operation, opt, unitWork, dt.Value);
                return unitWork.Commit();
            }
            catch (Exception ex)
            {
                return new CommandResult(ResultCode.Fail, ex.Message);
            }
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public override CommandResult Add(TEntity info)
        {
            return ProcessSheet(info, SheetOperation.Create, string.Empty);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public override CommandResult Update(TEntity info)
        {
            return ProcessSheet(info, SheetOperation.Modify, string.Empty);
        }
        #endregion
    }
}
