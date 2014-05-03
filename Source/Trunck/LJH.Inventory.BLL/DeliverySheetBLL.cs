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
    public class DeliverySheetBLL : SheetProcessorBase<DeliverySheet>
    {
        #region 构造函数
        public DeliverySheetBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 私有方法
        private void InventoryOut(DeliverySheet sheet, InventoryOutType inventoryOutType, IUnitWork unitWork)
        {
            ////减少库存
            foreach (DeliveryItem si in sheet.Items)
            {
                ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition()
                {
                    ProductID = si.ProductID,
                    WareHouseID = sheet.WareHouseID, //如果送货单没有指定仓库，这里就为空
                    UnShipped = true,     //所有未发货的库存项
                };
                List<ProductInventoryItem> items = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(_RepoUri).GetItems(con).QueryObjects;
                if (si.OrderItem != null)  //如果出货单项有相关的订单项，那么出货时只扣除与此订单项相关的库存项和未分配给任何订单的库存项
                {
                    items = items.Where(item => item.OrderItem == si.OrderItem).ToList();
                    //items = items.Where(item => item.OrderItem == si.OrderItem || item.OrderItem == null).ToList();
                }
                else
                {
                    items = items.Where(item => item.OrderItem == null).ToList();
                }
                if (items.Sum(item => item.Count) < si.Count) throw new Exception(string.Format("商品 {0} 库存不足，出货失败!", si.ProductID));

                if (inventoryOutType == InventoryOutType.FIFO) //根据产品的出货方式排序
                {
                    items = (from item in items orderby item.AddDate ascending select item).ToList();
                }
                else
                {
                    items = (from item in items orderby item.AddDate descending select item).ToList();
                }
                decimal count = si.Count;
                foreach (ProductInventoryItem pii in items)
                {
                    if (count > 0)
                    {
                        ProductInventoryItem pii1 = pii.Clone();
                        if (pii.Count > count) //对于部分出货的情况，一条库存记录拆成两条，其中一条表示出货的，另一条表示未出货部分，即要保证DelvieryItem不为空的都是未出货的，为空的都是已经出货的
                        {
                            pii.DeliveryItem = si.ID;
                            pii.DeliverySheet = si.SheetNo;
                            pii.Count = count;
                            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(_RepoUri).Update(pii, pii1, unitWork);

                            pii1.ID = Guid.NewGuid();
                            pii1.Count -= count;
                            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(_RepoUri).Insert(pii1, unitWork);
                            count = 0;
                        }
                        else
                        {
                            pii.DeliveryItem = si.ID;
                            pii.DeliverySheet = si.SheetNo;
                            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(_RepoUri).Update(pii, pii1, unitWork);
                            count -= pii.Count;
                        }
                    }
                }
            }
        }

        private void AddReceivables(DeliverySheet sheet, IUnitWork unitWork)
        {
            List<CustomerReceivable> crs = new List<CustomerReceivable>();
            foreach (DeliveryItem si in sheet.Items)  //每一个送货项生成一个应收项，因为一个送货单可能包括多个订单的货，所以分别统计
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
                        ClassID = CustomerReceivableClass.Delivery,
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
                ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(_RepoUri).Insert(cr, unitWork);
            }
        }
        #endregion

        #region 重写基类方法
        protected override string CreateSheetID(DeliverySheet info)
        {
            info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.DeliverySheetPrefix,
                    UserSettings.Current.DeliverySheetDateFormat, UserSettings.Current.DeliverySheetSerialCount, info.DocumentType);
            if (!string.IsNullOrEmpty(info.ID)) info.Items.ForEach(item => item.SheetNo = info.ID);//这一句不能省!!
            return info.ID;
        }

        protected override void DoShip(DeliverySheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            IProvider<DeliverySheet, string> provider = ProviderFactory.Create<IProvider<DeliverySheet, string>>(_RepoUri);
            if (info.Items == null || info.Items.Count == 0) throw new Exception("单号为 " + info.ID + " 的送货单发货失败，没有送货单项");
            DeliverySheet sheet1 = info.Clone() as DeliverySheet;
            info.LastActiveDate = dt;
            info.State = SheetState.Shipped;
            provider.Update(info, sheet1, unitWork);

            if (!string.IsNullOrEmpty(info.WareHouseID)) InventoryOut(info, UserSettings.Current.InventoryOutType, unitWork);  //送货单指定了仓库时，从指定仓库出货
            AddReceivables(info, unitWork);         //增加供应商的应收账款
        }

        protected override void DoNullify(DeliverySheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            base.DoNullify(info, unitWork, dt, opt);

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
            List<CustomerReceivable> items = (new CustomerReceivableBLL(_RepoUri)).GetItems(con1).QueryObjects;
            if (items != null && items.Count > 0)
            {
                CustomerPaymentAssignSearchCondition con = new CustomerPaymentAssignSearchCondition();
                con.ReceivableIDs = items.Select(it => it.ID).ToList();
                return ProviderFactory.Create<IProvider<CustomerPaymentAssign, Guid>>(_RepoUri).GetItems(con);
            }
            return new QueryResultList<CustomerPaymentAssign>(ResultCode.Fail, "没有找到记录", null);
        }
        /// <summary>
        /// 通过查询条件获取相关商品销售记录
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public QueryResultList<DeliveryRecord> GetDeliveryRecords(SearchCondition con)
        {
            return ProviderFactory.Create<IProvider<DeliveryRecord, Guid>>(_RepoUri).GetItems(con);
        }
        #endregion
    }
}
