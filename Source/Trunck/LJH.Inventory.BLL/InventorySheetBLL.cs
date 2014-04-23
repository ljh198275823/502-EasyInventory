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
                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(_RepoUri).Insert(pii, unitWork);
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

        protected override void DoInventory(InventorySheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            if (!info.CanInventory) throw new Exception("状态为" + SheetStateDescription.GetDescription(info.State) + " 的收货单 " + " 不能收货");
            if (info.Items == null || info.Items.Count == 0) throw new Exception("单号为 " + info.ID + " 的收货单发货失败，没有收货单项");

            InventorySheet sheet1 = info.Clone() as InventorySheet;
            info.State = SheetState.Inventory;
            info.LastActiveDate = dt;
            ProviderFactory.Create<IProvider<InventorySheet, string>>(_RepoUri).Update(info, sheet1, unitWork);

            AddToProductInventory(info, unitWork); //更新商品库存
            AddReceivables(info, unitWork);         //增加供应商的应收账款
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
            return ProviderFactory.Create<IProvider<InventoryRecord, Guid>>(_RepoUri).GetItems(con);
        }
        #endregion
    }
}
