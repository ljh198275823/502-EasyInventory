using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.BLL
{
    public class DeliverySheetBLL
    {
        #region 构造函数
        public DeliverySheetBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        private string _DocumentType = "DeliverySheet";
        #endregion

        #region 库内部方法
        internal void InventoryOut(ProductInventory info, long deliveryItem, decimal count, InventoryOutType inventoryOutType, IUnitWork unitWork)
        {
            //List<InventoryItem> inventoryItems = (new ProductInventoryBLL(_RepoUri)).GetInventoryDetail(info).QueryObjects;
            //if (inventoryItems != null && inventoryItems.Count > 0)
            //{
            //    if (inventoryOutType == InventoryOutType.FIFO)
            //    {
            //        inventoryItems = (from item in inventoryItems orderby item.InventoryDate ascending select item).ToList();
            //    }
            //    else if (inventoryOutType == InventoryOutType.FILO)
            //    {
            //        inventoryItems = (from item in inventoryItems orderby item.InventoryDate descending select item).ToList();
            //    }
            //    foreach (InventoryItem item in inventoryItems)
            //    {
            //        if (count > 0)
            //        {
            //            decimal temp = item.Remain >= count ? count : item.Remain;
            //            InventoryItemAssign assign = new InventoryItemAssign()
            //            {
            //                InventoryItem = item.ID,
            //                DeliveryItem = deliveryItem,
            //                Count = temp
            //            };
            //            ProviderFactory.Create<IInventoryItemAssignProvider>(_RepoUri).Insert(assign, unitWork);
            //            count -= temp;
            //        }
            //        if (count == 0) break;
            //    }
            //}
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 通过送货单号查询相关送货单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public QueryResult<DeliverySheet> GetByID(string id)
        {
            IDeliverySheetProvider provider = ProviderFactory.Create<IDeliverySheetProvider>(_RepoUri);
            return provider.GetByID(id);
        }
        /// <summary>
        /// 获取符合指定条件的送货单
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public QueryResultList<DeliverySheet> GetItems(SearchCondition con)
        {
            IDeliverySheetProvider provider = ProviderFactory.Create<IDeliverySheetProvider>(_RepoUri);
            return provider.GetItems(con);
        }
        /// <summary>
        /// 获取某个客户的所有已发货但未结算的送货单
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public QueryResultList<DeliverySheet> GetUnSettleSheets(string customerID)
        {
            DeliverySheetSearchCondition con = new DeliverySheetSearchCondition();
            con.CustomerID = customerID;
            con.States = new List<int>();
            con.States.Add((int)SheetState.Shipped);
            con.IsSettled = false;
            IDeliverySheetProvider dsp = ProviderFactory.Create<IDeliverySheetProvider>(_RepoUri);
            return dsp.GetItems(con);
        }
        /// <summary>
        /// 获取某个客户付款单的金额分配
        /// </summary>
        /// <param name="paymentID"></param>
        /// <returns></returns>
        public QueryResultList<CustomerPaymentAssign> GetAssigns(string sheetNo)
        {
            CustomerPaymentAssignSearchCondition con = new CustomerPaymentAssignSearchCondition();
            con.ReceivableID = sheetNo;
            return ProviderFactory.Create<ICustomerPaymentAssignProvider>(_RepoUri).GetItems(con);
        }
        /// <summary>
        /// 查询某个单据的所有历史操作记录
        /// </summary>
        /// <param name="sheetNO"></param>
        /// <returns></returns>
        public QueryResultList<DocumentOperation> GetHisOperations(string sheetNO)
        {
            DocumentSearchCondition con = new DocumentSearchCondition()
            {
                DocumentID = sheetNO,
                DocumentType = _DocumentType
            };
            return ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).GetItems(con);
        }
        /// <summary>
        /// 增加送货单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult Add(DeliverySheet info,string opt)
        {
            IDeliverySheetProvider provider = ProviderFactory.Create<IDeliverySheetProvider>(_RepoUri);
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.DeliverySheetPrefix,
                    UserSettings.Current.DeliverySheetDateFormat, UserSettings.Current.DeliverySheetSerialCount, _DocumentType );
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                info.Items.ForEach(item => item.SheetNo = info.ID);//这一句不能省!!
                provider.Insert(info, unitWork);

                DocumentOperation doc = new DocumentOperation()
                {
                    DocumentID = info.ID,
                    DocumentType = _DocumentType,
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
                return new CommandResult(ResultCode.Fail, "创建送货单号失败，请重试");
            }
        }
        /// <summary>
        /// 更新送货单
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult Update(DeliverySheet info,string opt)
        {
            IDeliverySheetProvider provider = ProviderFactory.Create<IDeliverySheetProvider>(_RepoUri);
            DeliverySheet original = provider.GetByID(info.ID).QueryObject;
            if (original != null)
            {
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                provider.Update(info, original, unitWork);

                DocumentOperation doc = new DocumentOperation()
                {
                    DocumentID = info.ID,
                    DocumentType = _DocumentType,
                    OperatDate = DateTime.Now,
                    Operation = "修改",
                    State = info.State ,
                    Operator = opt,
                };
                ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).Insert(doc, unitWork);
                return unitWork.Commit();
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "系统中已经不存在单号为 " + info.ID + " 的送货单");
            }
        }
        /// <summary>
        /// 审批送货单
        /// </summary>
        /// <param name="info"></param>
        /// <param name="approver"></param>
        /// <returns></returns>
        public CommandResult Approve(string sheetNo, string opt)
        {
            DeliverySheet info = ProviderFactory.Create<IDeliverySheetProvider>(_RepoUri).GetByID(sheetNo).QueryObject;
            if (info != null)
            {
                if (info.CanApprove)
                {
                    IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                    DeliverySheet original = info.Clone();
                    info.State = SheetState.Approved;

                    DocumentOperation doc = new DocumentOperation()
                    {
                        DocumentID = info.ID,
                        DocumentType = _DocumentType,
                        OperatDate = DateTime.Now,
                        Operation = "审核",
                        State = SheetState.Approved,
                        Operator = opt,
                    };
                    ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).Insert(doc, unitWork);
                    ProviderFactory.Create<IDeliverySheetProvider>(_RepoUri).Update(info, original, unitWork);
                    return unitWork.Commit();
                }
                else
                {
                    return new CommandResult(ResultCode.Fail, "单号为 " + info.ID + " 的送货单不能再审批，只有待发货的送货单才能审批");
                }
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "系统中已经不存在单号为 " + info.ID + " 的送货单");
            }
        }
        /// <summary>
        /// 发货
        /// </summary>
        /// <param name="info"></param>
        /// <param name="shipper"></param>
        /// <returns></returns>
        public CommandResult Delivery(string sheetNo, string shipper)
        {
            //IDeliverySheetProvider provider = ProviderFactory.Create<IDeliverySheetProvider>(_RepoUri);
            //DeliverySheet sheet = provider.GetByID(sheetNo).QueryObject;
            //if (sheet == null) return new CommandResult(ResultCode.Fail, "单号为 " + sheet.ID + " 的送货单发货失败，系统中不存在该送货单");
            //if (!sheet.CanShip) return new CommandResult(ResultCode.Fail, "单号为 " + sheet.ID + " 的送货单发货失败，只有待发货或者已审批的送货单才能发货");
            //if (sheet.Items == null || sheet.Items.Count == 0) return new CommandResult(ResultCode.Fail, "单号为 " + sheet.ID + " 的送货单发货失败，没有送货单项");

            //IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            ////查询客户资料
            //ICustomerProvider icp = ProviderFactory.Create<ICustomerProvider>(_RepoUri);
            //Customer c = icp.GetByID(sheet.CustomerID).QueryObject;
            //if (c != null)
            //{
            //    //增加应收账款项
            //    CustomerReceivable cr = new CustomerReceivable()
            //    {
            //        ID = sheet.ID,
            //        CreateDate = DateTime.Now,
            //        CustomerID = sheet.CustomerID,
            //        Amount = sheet.Amount,
            //    };
            //    ProviderFactory.Create<ICustomerReceivableProvider>(_RepoUri).Insert(cr, unitWork);
            //    //减少库存
            //    IProductInventoryProvider inp = ProviderFactory.Create<IProductInventoryProvider>(_RepoUri);
            //    foreach (DeliveryItem si in sheet.Items)
            //    {
            //        ProductInventory ii = inp.GetByID(new InventoryItemID(si.ProductID, sheet.WareHouseID)).QueryObject;
            //        if (ii != null && ii.Count >= si.Count)
            //        {
            //            InventoryOut(ii, si.ID, si.Count, UserSettings.Current.InventoryOutType, unitWork);
            //        }
            //        else
            //        {
            //            return new CommandResult(ResultCode.Fail, "单号为 " + sheet.ID + " 的送货单发货失败,某些送货项在系统中不存在或数量不足");
            //        }
            //    }
            //    DeliverySheet sheet1 = sheet.Clone();
            //    sheet.State = SheetState.Shipped;
            //    //sheet.DeliveryOperator = shipper;
            //    //sheet.DeliveryDate = DateTime.Now;
            //    provider.Update(sheet, sheet1, unitWork);
            //    return unitWork.Commit();
            //}
            //else
            //{
            return new CommandResult(ResultCode.Fail, "系统中不存在送货单的客户");
            //}
        }
        /// <summary>
        /// 作废
        /// </summary>
        /// <param name="info"></param>
        /// <param name="opt"></param>
        /// <returns></returns>
        public CommandResult Cancel(DeliverySheet info, string opt, bool payforOtherReceivables)
        {
            //if (!info.CanCancel) return new CommandResult(ResultCode.Fail, "单号为 " + info.ID + " 的送货单不能作废");
            //DeliverySheet original = ProviderFactory.Create<IDeliverySheetProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            //if (original == null) return new CommandResult(ResultCode.Fail, "系统中已经不存在单号为 " + info.ID + " 的送货单");
            //Customer c = ProviderFactory.Create<ICustomerProvider>(_RepoUri).GetByID(info.CustomerID).QueryObject;
            //if (c == null) return new CommandResult(ResultCode.Fail, "系统中不存在送货单的客户");

            //IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            ////如果已经有客户付款分配项了,则先将分配金额转移到别的应收项里面,并删除此项应收项的分配项.
            //CustomerPaymentAssignSearchCondition con = new CustomerPaymentAssignSearchCondition();
            //con.ReceivableID = info.ID;
            //List<CustomerPaymentAssign> assigns = ProviderFactory.Create<ICustomerPaymentAssignProvider>(_RepoUri).GetItems(con).QueryObjects;
            //if (assigns != null && assigns.Count > 0)
            //{
            //    foreach (CustomerPaymentAssign assign in assigns)
            //    {
            //        if (payforOtherReceivables) (new CustomerPaymentBLL(_RepoUri)).SettleReceivables(assign.PaymentID, c.ID, assign.Amount, null, info.ID, unitWork);
            //        ProviderFactory.Create<ICustomerPaymentAssignProvider>(_RepoUri).Delete(assign);
            //    }
            //}
            ////删除对应的应收项
            //CustomerReceivable cr = ProviderFactory.Create<ICustomerReceivableProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            //if (cr != null) ProviderFactory.Create<ICustomerReceivableProvider>(_RepoUri).Delete(cr, unitWork);

            ////删除相关的库存分配项
            //foreach (DeliveryItem si in info.Items)
            //{
            //    InventoryItemAssignSearchCondition con1 = new InventoryItemAssignSearchCondition();
            //    con1.DeliveryItem = si.ID;
            //    List<InventoryItemAssign> inventoryAssigns = ProviderFactory.Create<IInventoryItemAssignProvider>(_RepoUri).GetItems(con1).QueryObjects;
            //    if (inventoryAssigns != null && inventoryAssigns.Count > 0)
            //    {
            //        foreach (InventoryItemAssign iia in inventoryAssigns)
            //        {
            //            ProviderFactory.Create<IInventoryItemAssignProvider>(_RepoUri).Delete(iia, unitWork);
            //        }
            //    }
            //}

            ////original.CancelOperator = opt;
            ////original.CancelDate = DateTime.Now;
            //original.State = SheetState.Canceled;
            //ProviderFactory.Create<IDeliverySheetProvider>(_RepoUri).Update(original, info, unitWork);
            //CommandResult ret = unitWork.Commit();
            //if (ret.Result == ResultCode.Successful)
            //{
            //    //info.CancelOperator = original.CancelOperator;
            //    //info.CancelDate = original.CancelDate;
            //    info.State = original.State;
            //}
            //return ret;
            return null;
        }
        #endregion
    }
}
