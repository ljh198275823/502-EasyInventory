using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory .BusinessModel .SearchCondition ;
using LJH.Inventory .DAL .IProvider ;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class InventorySheetBLL : SheetProcessorBase<InventorySheet>
    {
        #region 构造函数
        public InventorySheetBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 私有方法
        private void AddToProductInventory(InventorySheet sheet, IUnitWork unitWork)
        {
            foreach (InventoryItem si in sheet.Items)
            {
                ProductInventoryItem pii = new ProductInventoryItem()
                {
                    ID = Guid.NewGuid(),
                    ProductID = si.ProductID,
                    WareHouseID = sheet.WareHouseID,
                    Unit = si.Unit,
                    Price = si.Price,
                    Count = si.Count,
                    AddDate = DateTime.Now,
                    OrderItem = si.OrderItem,
                    PurchaseItem = si.PurchaseItem,
                    InventoryItem = si.ID,
                    InventorySheet = si.SheetNo,
                };
                ProviderFactory.Create<IProvider <ProductInventoryItem ,Guid>>(_RepoUri).Insert(pii, unitWork);
            }
        }

        private void AddReceivables(InventorySheet sheet, IUnitWork unitWork)
        {
            foreach (InventoryItem si in sheet.Items)  //每一个送货项生成一个应收项，因为一个送货单可能包括多个订单的货，所以分别统计
            {
                //增加应收账款项
                SupplierReceivable cr = new SupplierReceivable()
                {
                    ID = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    SupplierID = sheet.SupplierID,
                    PurchaseID = si.PurchaseOrder,
                    PurchaseItem = si.PurchaseItem,
                    InventorySheet = sheet.ID,
                    InventoryItem = si.ID,
                    Amount = si.Amount,
                };
                ProviderFactory.Create<IProvider<SupplierReceivable, Guid>>(_RepoUri).Insert(cr, unitWork);
            }
        }
        #endregion

        #region 重写基类方法
        protected override string CreateSheetID(InventorySheet info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.InventorySheetPrefix,
                    UserSettings.Current.InventorySheetDateFormat, UserSettings.Current.InventorySheetSerialCount, info.DocumentType);
            }
            if (!string.IsNullOrEmpty(info.ID)) info.Items.ForEach(item => item.SheetNo = info.ID);//这一句不能省!!
            return info.ID;
        }

        protected override void DoNullify(InventorySheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            base.DoNullify(info, unitWork, dt, opt);
            if (info.State == SheetState.Inventory) //
            {
                foreach (InventoryItem si in info.Items)
                {
                    ProductInventoryItemSearchCondition piSearch = new ProductInventoryItemSearchCondition()
                    {
                        ProductID = si.ProductID,
                        InventoryItem = si.ID
                    };
                    List<ProductInventoryItem> piItems = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(_RepoUri).GetItems(piSearch).QueryObjects;
                    foreach (ProductInventoryItem pii in piItems)
                    {
                        if (pii.FromInventory) //如果已经被别的订单分配了，那么这些订单就要重新分配库存，包括已经出货的。
                        {
                        }
                        else
                        {
                            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(_RepoUri).Delete(pii, unitWork);
                        }
                    }
                    //删除供应商应付款项。
                }
            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 通过查询条件获取相关商品销售记录
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public QueryResultList<InventoryRecord> GetInventoryRecords(SearchCondition con)
        {
            return ProviderFactory.Create<IInventoryRecordProvider>(_RepoUri).GetItems(con);
        }
        /// <summary>
        /// 收货单收货
        /// </summary>
        /// <param name="sheetNo">收货单单号</param>
        /// <param name="opt">收货操作员</param>
        /// <returns></returns>
        public CommandResult Inventory(string sheetNo, string opt)
        {
            DateTime? dt = GetServerDateTime(); //从服务器获取时间
            if (dt == null) return new CommandResult(ResultCode.Fail, "从数据库服务器获取时间失败");
            InventorySheet sheet = ProviderFactory.Create<IProvider<InventorySheet, string>>(_RepoUri).GetByID(sheetNo).QueryObject;
            if (sheet == null) return new CommandResult(ResultCode.Fail, "系统中已经不存在单号为 " + sheetNo + " 的收货单");
            if (!sheet.CanInventory) return new CommandResult(ResultCode.Fail, "状态为" + SheetStateDescription.GetDescription(sheet.State) + " 的收货单 " + " 不能收货");

            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            InventorySheet sheet1 = sheet.Clone() as InventorySheet;
            sheet.State = SheetState.Inventory;
            sheet.InventoryDate = dt.Value;
            sheet.LastActiveDate = dt.Value;
            ProviderFactory.Create<IProvider<InventorySheet, string>>(_RepoUri).Update(sheet, sheet1, unitWork);

            AddToProductInventory(sheet, unitWork); //更新商品库存
            AddReceivables(sheet, unitWork);         //增加供应商的应收账款
            AddOperationLog(sheetNo, sheet.DocumentType, SheetOperation.Inventory, Operator.Current.Name, unitWork, dt.Value);
            return unitWork.Commit();
        }
        #endregion
    }
}
