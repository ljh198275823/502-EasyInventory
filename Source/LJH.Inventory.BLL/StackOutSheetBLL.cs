﻿using System;
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
            con.UnShipped = true;
            List<ProductInventoryItem> inventoryItems = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con).QueryObjects;
            if (inventoryItems == null || inventoryItems.Count == 0) throw new Exception("没有找到相关的库存项");
            List<ProductInventoryItem> clones = new List<ProductInventoryItem>();
            inventoryItems.ForEach(it => clones.Add(it.Clone())); //备分所有的项的克隆
            List<ProductInventoryItem> addingItems = new List<ProductInventoryItem>(); //要于保存将要增加的项
            ////减少库存
            foreach (StackOutItem si in sheet.Items)
            {
                Product p = ProviderFactory.Create<IProvider<Product, string>>(RepoUri).GetByID(si.ProductID).QueryObject;
                if (p != null && p.IsService != null && p.IsService.Value) continue; //如果是产品是服务的话就不用再从库存中扣除了
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
            if (si.OrderItem != null)  //如果出货单项有相关的订单项，那么出货时只扣除与此订单项相关的库存项和未分配给任何订单的库存项
            {
                items.AddRange(inventoryItems.Where(item => item.ProductID == si.ProductID && item.DeliveryItem == null && item.OrderItem == si.OrderItem));
            }
            if (inventoryOutType == InventoryOutType.FIFO) //根据产品的出货方式将未指定订单项的库存排序
            {
                items.AddRange(from item in inventoryItems
                               where item.ProductID == si.ProductID && item.DeliveryItem == null && item.OrderItem == null
                               orderby item.AddDate ascending
                               select item);
            }
            else
            {
                items.AddRange(from item in inventoryItems
                               where item.ProductID == si.ProductID && item.DeliveryItem == null && item.OrderItem == null
                               orderby item.AddDate descending
                               select item);
            }
            if (items.Sum(item => item.Count) < si.Count) throw new Exception(string.Format("产品 {0} 库存不足，出货失败!", si.ProductID));

            decimal count = si.Count;
            foreach (ProductInventoryItem item in items)
            {
                if (count > 0)
                {
                    if (item.Count > count) //对于部分出货的情况，一条库存记录拆成两条，其中一条表示出货的，另一条表示未出货部分，即要保证DelvieryItem不为空的都是未出货的，为空的都是已经出货的
                    {
                        ProductInventoryItem pii = item.Clone();
                        pii.ID = Guid.NewGuid();
                        pii.OrderItem = si.OrderItem;
                        pii.OrderID = si.OrderID;
                        pii.DeliveryItem = si.ID;
                        pii.DeliverySheet = si.SheetNo;
                        pii.Count = count;
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

        protected override void DoShip(StackOutSheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            IProvider<StackOutSheet, string> provider = ProviderFactory.Create<IProvider<StackOutSheet, string>>(RepoUri);
            if (info.Items == null || info.Items.Count == 0) throw new Exception("单号为 " + info.ID + " 的送货单发货失败，没有送货单项");
            StackOutSheet sheet1 = info.Clone() as StackOutSheet;
            info.LastActiveDate = dt;
            info.State = SheetState.Shipped;
            provider.Update(info, sheet1, unitWork);

            if (!string.IsNullOrEmpty(info.WareHouseID)) InventoryOut(info, UserSettings.Current.InventoryOutType, unitWork);  //送货单指定了仓库时，从指定仓库出货
            if (info.ClassID == StackOutSheetType.DeliverySheet) AddReceivables(info, unitWork);         //类型为送货单的出库单出货时增加应收
        }

        protected override void DoNullify(StackOutSheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            base.DoNullify(info, unitWork, dt, opt);

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
