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
    public class StackOutSheetBLL : SheetProcessorBase<StackOutSheet>
    {
        #region 构造函数
        public StackOutSheetBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 私有方法
        private void InventoryOut(StackOutSheet sheet, InventoryOutType inventoryOutType, IUnitWork unitWork)
        {
            List<string> pids = sheet.Items.Select(it => it.ProductID).ToList();
            ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
            con.Products = pids;
            con.WareHouseID = sheet.WareHouseID;
            con.States = (int)ProductInventoryState.UnShipped;
            List<ProductInventoryItem> inventoryItems = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con).QueryObjects;
            if (inventoryItems == null || inventoryItems.Count == 0) throw new Exception("没有找到相关的库存项");
            List<ProductInventoryItem> clones = new List<ProductInventoryItem>();
            inventoryItems.ForEach(it => clones.Add(it.Clone())); //备分所有的项的克隆
            List<ProductInventoryItem> addingItems = new List<ProductInventoryItem>(); //要于保存将要增加的项
            ////减少库存
            foreach (StackOutItem si in sheet.Items)
            {
                Assign(si, inventoryOutType, inventoryItems, addingItems);
            }
            foreach (ProductInventoryItem item in inventoryItems)
            {
                ProductInventoryItem clone = clones.Single(it => it.ID == item.ID);
                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(item, clone, unitWork);
            }
            foreach (ProductInventoryItem item in addingItems)
            {
                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(item, unitWork);
            }
        }

        private void Assign(StackOutItem si, InventoryOutType inventoryOutType, List<ProductInventoryItem> inventoryItems, List<ProductInventoryItem> addingItems)
        {
            List<ProductInventoryItem> items = new List<ProductInventoryItem>();
            items.AddRange(inventoryItems.Where(item => item.State == ProductInventoryState.WaitShipping && item.ProductID == si.ProductID && item.DeliveryItem == si.ID)); //出货单项待出货的项最高优先级
            if (items.Sum(item => item.Count) < si.Count) throw new Exception(string.Format("产品 {0} 库存不足，出货失败!", si.ProductID));
            decimal count = si.Count;
            foreach (ProductInventoryItem item in items)
            {
                if (count > 0)
                {
                    if (item.Count > count)
                    {
                        ProductInventoryItem pii = item.Clone();
                        pii.ID = Guid.NewGuid();
                        pii.OrderItem = si.OrderItem;
                        pii.OrderID = si.OrderID;
                        pii.DeliveryItem = si.ID;
                        pii.DeliverySheet = si.SheetNo;
                        pii.Count = count;
                        pii.State = ProductInventoryState.Shipped;
                        addingItems.Add(pii);
                        item.Count -= count;
                        count = 0;
                    }
                    else
                    {
                        item.OrderItem = si.OrderItem;
                        item.OrderID = si.OrderID;
                        item.DeliveryItem = si.ID;
                        item.DeliverySheet = si.SheetNo;
                        item.State = ProductInventoryState.Shipped;
                        count -= item.Count;
                    }
                }
            }
        }

        private void AddReceivables(StackOutSheet sheet, IUnitWork unitWork)
        {
            List<CustomerReceivable> crs = new List<CustomerReceivable>();
            foreach (StackOutItem si in sheet.Items)  //每一个送货项生成一个应收项，因为一个送货单可能包括多个订单的货，所以分别统计
            {
                CustomerReceivable cr = null;
                if (string.IsNullOrEmpty(si.OrderID)) cr = crs.SingleOrDefault(it => string.IsNullOrEmpty(it.OrderID));
                if (!string.IsNullOrEmpty(si.OrderID)) cr = crs.SingleOrDefault(it => it.OrderID == si.OrderID);
                if (cr == null)
                {
                    DateTime dt = DateTime.Now;
                    cr = new CustomerReceivable()
                    {
                        ID = Guid.NewGuid(),
                        CreateDate = dt,
                        ClassID = CustomerReceivableType.CustomerReceivable,
                        CustomerID = sheet.CustomerID,
                        SheetID = sheet.ID,
                        OrderID = si.OrderID,
                        Amount = si.CalAmount(),
                    };
                    crs.Add(cr);
                }
                else
                {
                    cr.Amount += si.CalAmount();
                }
            }
            foreach (CustomerReceivable cr in crs)
            {
                ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Insert(cr, unitWork);
            }
        }

        private void AddTax(StackOutSheet sheet, IUnitWork unitWork)
        {
            CustomerReceivable tax = null;
            DateTime dt = DateTime.Now;
            tax = new CustomerReceivable()
            {
                ID = Guid.NewGuid(),
                CreateDate = dt,
                ClassID = CustomerReceivableType.CustomerTax,
                CustomerID = sheet.CustomerID,
                SheetID = sheet.ID,
                Amount = sheet.Amount,
            };
            ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Insert(tax, unitWork);
        }

        //分配, 为某个送货单项分配指定数量的库存
        private void F_Assign(ProductInventoryItem source, StackOutItem si, List<ProductInventoryItem> addingItems, List<ProductInventoryItem> updatingitems, List<ProductInventoryItem> cloneItems, List<ProductInventoryItem> deletingItems)
        {
            if (source.Count >= si.Count)
            {
                if (!updatingitems.Exists(it => it.ID == source.ID))
                {
                    updatingitems.Add(source);
                    cloneItems.Add(source.Clone());
                }
                source.Count -= si.Count;

                ProductInventoryItem newItem = source.Clone();
                newItem.ID = Guid.NewGuid();
                newItem.SourceID = source.ID;
                newItem.Count = si.Count;
                newItem.State = ProductInventoryState.WaitShipping;
                newItem.DeliveryItem = si.ID;
                newItem.DeliverySheet = si.SheetNo;
                addingItems.Add(newItem);
            }
            else
            {
                throw new Exception("出货数量超出库存数量");
            }
        }

        //更新分配置的数量,
        private void F_Change(ProductInventoryItem source, ProductInventoryItem des, decimal newCount, List<ProductInventoryItem> addingItems, List<ProductInventoryItem> updatingitems, List<ProductInventoryItem> cloneItems, List<ProductInventoryItem> deletingItems)
        {
            if (des.Count == newCount) return;
            if (!updatingitems.Exists(it => it.ID == source.ID))
            {
                updatingitems.Add(source);
                cloneItems.Add(source.Clone());
            }
            if (!updatingitems.Exists(it => it.ID == des.ID))
            {
                updatingitems.Add(des);
                cloneItems.Add(des.Clone());
            }
            //两行的顺序不能反!
            source.Count += des.Count - newCount; //相减的两者不管谁大谁小都用同一个表达式,不会出错的
            des.Count = newCount;
        }

        //合并项,将deleting项的数量合并到source中,并删除deleting
        private void F_Merge(ProductInventoryItem source, ProductInventoryItem deleting, List<ProductInventoryItem> addingItems, List<ProductInventoryItem> updatingitems, List<ProductInventoryItem> cloneItems, List<ProductInventoryItem> deletingItems)
        {
            if (!updatingitems.Exists(it => it.ID == source.ID))
            {
                updatingitems.Add(source);
                cloneItems.Add(source.Clone());
            }
            source.Count += source.Count;
            deletingItems.Add(source);
        }

        private void F_CommitChanges(List<ProductInventoryItem> addingItems, List<ProductInventoryItem> updatingitems, List<ProductInventoryItem> cloneItems, List<ProductInventoryItem> deletingItems, IUnitWork unitWork)
        {
            var provider = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri);
            if (addingItems != null && addingItems.Count > 0)
            {
                foreach (var item in addingItems)
                {
                    provider.Insert(item, unitWork);
                }
            }
            if (updatingitems != null && updatingitems.Count > 0)
            {
                foreach (var item in updatingitems)
                {
                    var clone = cloneItems.Single(it => it.ID == item.ID);
                    provider.Update(item, clone, unitWork);
                }
            }
            if (deletingItems != null && deletingItems.Count > 0)
            {
                foreach (var item in deletingItems)
                {
                    provider.Delete(item, unitWork);
                }
            }
        }
        #endregion

        #region 重写基类方法
        protected override string CreateSheetID(StackOutSheet info)
        {
            if (info.ClassID == StackOutSheetType.DeliverySheet)
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber(UserSettings.Current.DeliverySheetPrefix,
                        UserSettings.Current.DeliverySheetDateFormat, UserSettings.Current.DeliverySheetSerialCount, info.DocumentType);
            }
            else if (info.ClassID == StackOutSheetType.CustomerBorrow)
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("JYD",
                        UserSettings.Current.DeliverySheetDateFormat, UserSettings.Current.DeliverySheetSerialCount, info.DocumentType);
            }
            if (!string.IsNullOrEmpty(info.ID)) info.Items.ForEach(item => item.SheetNo = info.ID);//这一句不能省!!
            return info.ID;
        }

        protected override void DoAdd(StackOutSheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            base.DoAdd(info, unitWork, dt, opt);
            List<ProductInventoryItem> addingItems = new List<ProductInventoryItem>();
            List<ProductInventoryItem> updatingitems = new List<ProductInventoryItem>();
            List<ProductInventoryItem> cloneItems = new List<ProductInventoryItem>();
            List<ProductInventoryItem> deletingItems = new List<ProductInventoryItem>();
            foreach (var item in info.Items)  //将原材料的项的状态变成待出货状态
            {
                var isrp = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri);
                if (item.InventoryItem != null)
                {
                    ProductInventoryItem pi = isrp.GetByID(item.InventoryItem.Value).QueryObject;
                    if (pi != null)
                    {
                        F_Assign(pi, item, addingItems, updatingitems, cloneItems, deletingItems);
                    }
                }
            }
            F_CommitChanges(addingItems, updatingitems, cloneItems, deletingItems, unitWork);
        }

        protected override void DoUpdate(StackOutSheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            base.DoUpdate(info, unitWork, dt, opt);
            var original = GetByID(info.ID).QueryObject;
            List<ProductInventoryItem> addingItems = new List<ProductInventoryItem>();
            List<ProductInventoryItem> updatingitems = new List<ProductInventoryItem>();
            List<ProductInventoryItem> cloneItems = new List<ProductInventoryItem>();
            List<ProductInventoryItem> deletingItems = new List<ProductInventoryItem>();
            var provider = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri);
            foreach (var item in info.Items)
            {
                if (item.InventoryItem != null) //如果有进行分配
                {
                    ProductInventoryItem source = provider.GetByID(item.InventoryItem.Value).QueryObject;
                    if (original.Items.Exists(it => it.ID == item.ID))
                    {
                        ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                        con.DeliveryItem = item.ID;
                        var assigned = provider.GetItems(con).QueryObjects[0];  //每一个出货单项有且只有一项分配项
                        F_Change(source, assigned, item.Count, addingItems, updatingitems, cloneItems, deletingItems);
                    }
                    else
                    {
                        F_Assign(source, item, addingItems, updatingitems, cloneItems, deletingItems);
                    }
                }
            }
            foreach (var item in original.Items)
            {
                if (item.InventoryItem != null && !info.Items.Exists(it => it.ID == item.ID))
                {
                    ProductInventoryItem source = provider.GetByID(item.InventoryItem.Value).QueryObject;
                    ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                    con.DeliveryItem = item.ID;
                    var assigned = provider.GetItems(con).QueryObjects[0];  //每一个出货单项有且只有一项分配项
                    F_Merge(source, assigned, addingItems, updatingitems, cloneItems, deletingItems);
                }
            }
            F_CommitChanges(addingItems, updatingitems, cloneItems, deletingItems, unitWork);
        }

        protected override void DoShip(StackOutSheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            IProvider<StackOutSheet, string> provider = ProviderFactory.Create<IProvider<StackOutSheet, string>>(RepoUri);
            if (info.Items == null || info.Items.Count == 0) throw new Exception("单号为 " + info.ID + " 的送货单发货失败，没有送货单项");
            StackOutSheet sheet1 = info.Clone() as StackOutSheet;
            info.LastActiveDate = dt;
            info.State = SheetState.Shipped;
            provider.Update(info, sheet1, unitWork);

            InventoryOut(info, UserSettings.Current.InventoryOutType, unitWork);  //送货单指定了仓库时，从指定仓库出货
            if (info.ClassID == StackOutSheetType.DeliverySheet)
            {
                AddReceivables(info, unitWork);         //类型为送货单的出库单出货时增加应收
                //AddTax(info, unitWork);
            }
        }

        protected override void DoNullify(StackOutSheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            base.DoNullify(info, unitWork, dt, opt);
            List<ProductInventoryItem> addingItems = new List<ProductInventoryItem>();
            List<ProductInventoryItem> updatingitems = new List<ProductInventoryItem>();
            List<ProductInventoryItem> cloneItems = new List<ProductInventoryItem>();
            List<ProductInventoryItem> deletingItems = new List<ProductInventoryItem>();
            var provider = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri);
            foreach (var item in info.Items)  //将原材料的项的状态恢复到在库状态
            {
                ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                con.DeliveryItem = item.ID;
                List<ProductInventoryItem> piis = provider.GetItems(con).QueryObjects;
                ProductInventoryItem sourcePi = null;
                if (item.InventoryItem != null) sourcePi = provider.GetByID(item.InventoryItem.Value).QueryObject;
                if (piis != null && piis.Count > 0)
                {
                    if (sourcePi != null)
                    {
                        foreach (var pi in piis)
                        {
                            F_Merge(sourcePi, pi, addingItems, updatingitems, cloneItems, deletingItems);
                        }
                    }
                    else
                    {
                        foreach (var pi in piis)
                        {
                            var clone = pi.Clone();
                            pi.State = ProductInventoryState.Inventory;
                            pi.DeliveryItem = null;
                            pi.DeliverySheet = null;
                            provider.Update(pi, clone, unitWork);
                        }
                    }
                }
            }
            F_CommitChanges(addingItems, updatingitems, cloneItems, deletingItems, unitWork);
            //IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            ////如果已经有客户收款分配项了,则先将分配金额转移到别的应收项里面,并删除此项应收项的分配项.
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
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取某个单据的所有付款明细
        /// </summary>
        /// <param name="paymentID"></param>
        /// <returns></returns>
        public QueryResultList<CustomerPaymentAssign> GetAssigns(string sheetNo)
        {
            CustomerReceivableSearchCondition con1 = new CustomerReceivableSearchCondition()
            {
                SheetID = sheetNo,
            };
            List<CustomerReceivable> items = (new CustomerReceivableBLL(RepoUri)).GetItems(con1).QueryObjects;
            if (items != null && items.Count > 0)
            {
                CustomerPaymentAssignSearchCondition con = new CustomerPaymentAssignSearchCondition();
                con.ReceivableIDs = items.Select(it => it.ID).ToList();
                return ProviderFactory.Create<IProvider<CustomerPaymentAssign, Guid>>(RepoUri).GetItems(con);
            }
            return new QueryResultList<CustomerPaymentAssign>(ResultCode.Fail, "没有找到记录", null);
        }
        /// <summary>
        /// 通过查询条件获取相关商品销售记录
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public QueryResultList<StackOutRecord> GetDeliveryRecords(SearchCondition con)
        {
            return ProviderFactory.Create<IProvider<StackOutRecord, Guid>>(RepoUri).GetItems(con);
        }
        #endregion
    }
}
