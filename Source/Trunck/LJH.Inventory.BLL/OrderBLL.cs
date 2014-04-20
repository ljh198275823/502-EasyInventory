using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory .DAL .IProvider ;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.BLL
{
    public class OrderBLL : ISheetProcessor<Order>
    {
        #region 构造函数
        public OrderBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 私有方法
        /// <summary>
        /// 增加一个订单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private void Add(Order info, IUnitWork unitWork, DateTime dt, string opt)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.OrderPrefix,
                    UserSettings.Current.OrderDateFormat, UserSettings.Current.OrderSerialCount, info.DocumentType);
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                info.Items.ForEach(item => item.OrderID = info.ID);//这一句不能省!!
                info.LastActiveDate = dt; //修改最后活动时间
                IOrderProvider provider = ProviderFactory.Create<IOrderProvider>(_RepoUri);
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
        private void Update(Order info, IUnitWork unitWork, DateTime dt, string opt)
        {
            Order original = ProviderFactory.Create<IOrderProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original != null)
            {
                info.LastActiveDate = dt; //修改最后活动时间
                ProviderFactory.Create<IOrderProvider>(_RepoUri).Update(info, original, unitWork);
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
        private void Approve(Order info, IUnitWork unitWork, DateTime dt, string opt)
        {
            if (info.CanApprove)
            {
                Order original = info.Clone();
                info.State = SheetState.Approved;
                info.LastActiveDate = dt; //修改最后活动时间
                ProviderFactory.Create<IOrderProvider>(_RepoUri).Update(info, original, unitWork);
            }
            else
            {
                throw new Exception("已经审核，不能再次审核");
            }
        }
        /// <summary>
        /// 取消审核
        /// </summary>
        /// <param name="info"></param>
        /// <param name="opt"></param>
        /// <returns></returns>
        private void UndoApprove(Order info, IUnitWork unitWork, DateTime dt, string opt)
        {
            if (info.State == SheetState.Approved)
            {
                Order original = info.Clone();
                info.State = SheetState.Add;
                info.LastActiveDate = dt; //修改最后活动时间
                ProviderFactory.Create<IOrderProvider>(_RepoUri).Update(info, original, unitWork);
            }
            else
            {
                throw new Exception("未审核单据，不能取消审核");
            }
        }
        /// <summary>
        /// 将订单作废
        /// </summary>
        /// <param name="sheetNo"></param>
        /// <param name="opt"></param>
        /// <returns></returns>
        private void Nullify(Order info, IUnitWork unitWork, DateTime dt, string opt)
        {
            if (info.CanCancel)
            {
                Order original = info.Clone();
                info.State = SheetState.Canceled;
                info.LastActiveDate = dt; //修改最后活动时间
                ProviderFactory.Create<IOrderProvider>(_RepoUri).Update(info, original, unitWork);
            }
            else
            {
                throw new Exception("订单不能作废");
            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 通过订单号获取订单
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public QueryResult<Order> GetByID(string orderID)
        {
            IOrderProvider provider = ProviderFactory.Create<IOrderProvider>(_RepoUri);
            return provider.GetByID(orderID);
        }

        public QueryResultList<Order> GetItems(SearchCondition con)
        {
            return ProviderFactory.Create<IOrderProvider>(_RepoUri).GetItems(con);
        }
        /// <summary>
        /// 获取订单记录
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public QueryResultList<OrderItemRecord> GetRecords(SearchCondition con)
        {
            return ProviderFactory.Create<IOrderItemRecordProvider>(_RepoUri).GetItems(con);
        }
        /// <summary>
        /// 通过id获取订单记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public QueryResult<OrderItemRecord> GetRecordById(Guid id)
        {
            return ProviderFactory.Create<IOrderItemRecordProvider>(_RepoUri).GetByID(id);
        }
        #endregion

        #region 实现ISheetProcessor 接口
        public CommandResult ProcessSheet(Order sheet, SheetOperation operation, string opt)
        {
            try
            {
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                DateTime? dt = null;
                if (ProviderFactory.Create<IServerDatetimeProvider>(_RepoUri).GetServerDateTime(out dt).Result != ResultCode.Successful) //从数据库获取时间
                {
                    return new CommandResult(ResultCode.Fail, "从数据库服务器获取时间失败");
                }
                if (operation == SheetOperation.Create)
                {
                    sheet.LastActiveDate = dt.Value;
                    Add(sheet, unitWork, dt.Value, opt);
                }
                else
                {
                    QueryResult<DocumentOperation> docRet = (new DocumentOperationBLL(_RepoUri)).GetLatestOperation(sheet);
                    //单据的最后活动时间与当前单据相同，说明其它操作员在此次修改之前没有修改过单据
                    if (docRet.Result == ResultCode.Successful && docRet.QueryObject.OperatDate == sheet.LastActiveDate)
                    {
                        if (operation == SheetOperation.Modify)
                        {
                            Update(sheet, unitWork, dt.Value, opt);
                        }
                        else if (operation == SheetOperation.Approve)
                        {
                            Approve(sheet, unitWork, dt.Value, opt);
                        }
                        else if (operation == SheetOperation.UndoApprove)
                        {
                            UndoApprove(sheet, unitWork, dt.Value, opt);
                        }
                        else if (operation == SheetOperation.Nullify)
                        {
                            Nullify(sheet, unitWork, dt.Value, opt);
                        }
                        else
                        {
                            return new CommandResult(ResultCode.Fail, string.Format("没有实现 {0} 处理", LJH.Inventory.BusinessModel.Resource.SheetOperationDescription.GetDescription(operation)));
                        }
                    }
                    else
                    {
                        return new CommandResult(ResultCode.Fail, "其它操作员已经修改了数据，请先获取到最新数据后再做修改");
                    }
                }
                (new DocumentOperationBLL(AppSettings.Current.ConnStr)).AddOperationLog(sheet.ID, sheet.DocumentType, operation, opt, unitWork, dt.Value);
                return unitWork.Commit();
            }
            catch (Exception ex)
            {
                return new CommandResult(ResultCode.Fail, ex.Message);
            }
        }
        #endregion
    }
}
