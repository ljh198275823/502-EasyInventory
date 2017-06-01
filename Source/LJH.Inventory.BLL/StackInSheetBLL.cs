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
    public class StackInSheetBLL : SheetProcessorBase<StackInSheet>
    {
        #region 构造函数
        public StackInSheetBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 私有方法
        private void AddToProductInventory(StackInSheet sheet, IUnitWork unitWork)
        {
            foreach (StackInItem si in sheet.Items)
            {
                ProductInventoryItem pii = new ProductInventoryItem()
                {
                    ID = Guid.NewGuid(),
                    ProductID = si.ProductID,
                    WareHouseID = sheet.WareHouseID,
                    Unit = si.Unit,
                    Price = si.Price,
                    Count = si.Count,
                    Length = si.Length.Value,
                    AddDate = DateTime.Now,
                    OrderItem = si.OrderItem,
                    OrderID = si.OrderID,
                    PurchaseItem = si.PurchaseItem,
                    PurchaseID = si.PurchaseOrder,
                    InventoryItem = si.ID,
                    InventorySheet = si.SheetNo,
                };
                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(pii, unitWork);
            }
        }

        private void AddReceivables(StackInSheet sheet, IUnitWork unitWork)
        {
            List<CustomerReceivable> crs = new List<CustomerReceivable>();
            foreach (StackInItem si in sheet.Items)  //每一个送货项生成一个应收项，因为一个送货单可能包括多个订单的货，所以分别统计
            {
                CustomerReceivable cr = null;
                if (string.IsNullOrEmpty(si.PurchaseOrder)) cr = crs.SingleOrDefault(it => string.IsNullOrEmpty(it.OrderID));
                if (!string.IsNullOrEmpty(si.PurchaseOrder)) cr = crs.SingleOrDefault(it => it.OrderID == si.PurchaseOrder);
                if (cr == null)
                {
                    DateTime dt = DateTime.Now;
                    cr = new CustomerReceivable()
                    {
                        ID = Guid.NewGuid(),
                        CreateDate = new DateTime(sheet.SheetDate.Year, sheet.SheetDate.Month, sheet.SheetDate.Day, dt.Hour, dt.Minute, dt.Second),
                        ClassID = CustomerReceivableType.SupplierReceivable,
                        CustomerID = sheet.SupplierID,
                        SheetID = sheet.ID,
                        OrderID = si.PurchaseOrder,
                        Amount = si.Amount,
                    };
                    crs.Add(cr);
                }
                else
                {
                    cr.Amount += si.Amount;
                }
            }
            foreach (CustomerReceivable cr in crs)
            {
                ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Insert(cr, unitWork);
            }
        }
        #endregion

        #region 重写基类方法
        protected override string CreateSheetID(StackInSheet info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber(UserSettings.Current.InventorySheetPrefix,
                    UserSettings.Current.InventorySheetDateFormat, UserSettings.Current.InventorySheetSerialCount, info.DocumentType);
            }
            if (!string.IsNullOrEmpty(info.ID)) info.Items.ForEach(item => item.SheetNo = info.ID);//这一句不能省!!
            return info.ID;
        }

        protected override void DoInventory(StackInSheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            if (info.Items == null || info.Items.Count == 0) throw new Exception("单号为 " + info.ID + " 的收货单发货失败，没有收货单项");

            StackInSheet sheet1 = info.Clone() as StackInSheet;
            info.State = SheetState.Inventory;
            info.LastActiveDate = dt;
            ProviderFactory.Create<IProvider<StackInSheet, string>>(RepoUri).Update(info, sheet1, unitWork);

            AddToProductInventory(info, unitWork); //更新商品库存
            if (info.ClassID == StackInSheetType.InventorySheet) AddReceivables(info, unitWork);         //增加供应商的应收账款
        }

        protected override void DoNullify(StackInSheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            base.DoNullify(info, unitWork, dt, opt);
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 通过查询条件获取相关商品销售记录
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public QueryResultList<StackInRecord> GetInventoryRecords(SearchCondition con)
        {
            return ProviderFactory.Create<IProvider<StackInRecord, Guid>>(RepoUri).GetItems(con);
        }
        #endregion
    }
}
