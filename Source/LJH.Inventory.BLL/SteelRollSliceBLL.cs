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
    public class SteelRollSliceBLL
    {
        #region 构造函数
        public SteelRollSliceBLL(string repoUri)
        {
            RepoUri = repoUri;
        }
        #endregion

        private string RepoUri = null;
        private const string MODEL = "原材料";

        #region 私有方法
        private void 盘盈(InventoryCheckRecord record, string model, IUnitWork unitWork)
        {
            ProductInventoryItem pii = new ProductInventoryItem()
            {
                ID = Guid.NewGuid(),
                AddDate = record.CheckDateTime,
                ProductID = record.ProductID,
                WareHouseID = record.WarehouseID,
                Unit = record.Unit,
                Count = record.CheckCount - record.Inventory,
                Model = model,
                InventoryItem = record.ID,
                InventorySheet = "盘盈",
                State = ProductInventoryState.Inventory,
                Memo = record.Memo
            };
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(pii, unitWork);
        }

        private void 盘亏(InventoryCheckRecord record, InventoryOutType inventoryOutType, IUnitWork unitWork)
        {
            ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
            con.ProductID = record.ProductID;
            con.WareHouseID = record.WarehouseID;
            con.States = (int)ProductInventoryState.UnShipped;
            List<ProductInventoryItem> inventoryItems = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con).QueryObjects;
            if (inventoryItems == null || inventoryItems.Count == 0) throw new Exception("没有找到相关的库存项");
            List<ProductInventoryItem> clones = new List<ProductInventoryItem>();
            inventoryItems.ForEach(it => clones.Add(it.Clone())); //备分所有的项的克隆
            List<ProductInventoryItem> addingItems = new List<ProductInventoryItem>(); //要于保存将要增加的项

            IEnumerable<ProductInventoryItem> items = null;
            if (inventoryOutType == InventoryOutType.FIFO) //先从在库的项开始
            {
                items = from item in inventoryItems
                        where item.State == ProductInventoryState.Inventory
                        orderby item.AddDate ascending
                        select item;
            }
            else
            {
                items = from item in inventoryItems
                        where item.State == ProductInventoryState.Inventory
                        orderby item.AddDate descending
                        select item;
            }

            decimal assign = record.Inventory - record.CheckCount;
            assign -= Assign(record, assign, inventoryOutType, inventoryItems, addingItems);
            if (assign > 0) //如果在库的不足以全部扣除，则再从已经预定和待出货的里面扣除
            {
                if (inventoryOutType == InventoryOutType.FIFO)
                {
                    items = from item in inventoryItems
                            where item.State == ProductInventoryState.Reserved || item.State == ProductInventoryState.WaitShipping
                            orderby item.AddDate ascending
                            select item;
                }
                else
                {
                    items = from item in inventoryItems
                            where item.State == ProductInventoryState.Reserved || item.State == ProductInventoryState.WaitShipping
                            orderby item.AddDate descending
                            select item;
                }
                assign -= Assign(record, assign, inventoryOutType, inventoryItems, addingItems);
            }
            if (assign == 0)
            {
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
            else
            {
                throw new Exception("库存不足");
            }
        }

        private decimal Assign(InventoryCheckRecord record, decimal assign, InventoryOutType inventoryOutType, IEnumerable<ProductInventoryItem> inventoryItems, List<ProductInventoryItem> addingItems)
        {
            decimal ret = assign;
            foreach (ProductInventoryItem item in inventoryItems)
            {
                if (assign > 0)
                {
                    if (item.Count > assign) //对于部分出货的情况，一条库存记录拆成两条，其中一条表示出货的，另一条表示未出货部分
                    {
                        ProductInventoryItem pii = item.Clone();
                        pii.ID = Guid.NewGuid();
                        pii.AddDate = record.CheckDateTime;
                        pii.SourceID = item.ID;  //指定之前的记录为源记录
                        pii.Count = assign;
                        pii.DeliverySheet = "盘亏";
                        pii.DeliveryItem = record.ID;
                        pii.State = ProductInventoryState.Shipped;
                        addingItems.Add(pii);
                        item.Count -= assign; //源记录中减除如干数
                        assign = 0;
                        break;
                    }
                    else
                    {
                        item.DeliverySheet = "盘亏";
                        item.DeliveryItem = record.ID;
                        item.State = ProductInventoryState.Shipped;
                        assign -= item.Count;
                    }
                }
            }
            return ret - assign;
        }
        #endregion

        #region 公共方法
        public QueryResultList<SteelRollSlice> GetSteelRollSlices(SearchCondition con)
        {
            List<SteelRollSlice> items = null;
            QueryResultList<ProductInventoryItem> ret = GetItems(con);
            if (ret.QueryObjects != null && ret.QueryObjects.Count > 0)
            {
                List<Product> ps = ProviderFactory.Create<IProvider<Product, string>>(RepoUri).GetItems(null).QueryObjects;
                List<WareHouse> ws = ProviderFactory.Create<IProvider<WareHouse, string>>(RepoUri).GetItems(null).QueryObjects;
                var gs = from it in ret.QueryObjects
                         group it by new { it.ProductID, it.WareHouseID };
                foreach (var g in gs)
                {
                    if (items == null) items = new List<SteelRollSlice>();
                    SteelRollSlice srs = new SteelRollSlice();
                    srs.ID = Guid.Empty;
                    srs.Product = ps.SingleOrDefault(it => it.ID == g.First().ProductID);
                    srs.WareHouse = ws.SingleOrDefault(it => it.ID == g.First().WareHouseID);
                    srs.Unit = g.First().Unit;
                    srs.WaitShipping = g.Sum(it => it.State == ProductInventoryState.WaitShipping ? it.Count : 0);
                    srs.Reserved = g.Sum(it => it.State == ProductInventoryState.Reserved ? it.Count : 0);
                    srs.Valid = g.Sum(it => it.State == ProductInventoryState.Inventory ? it.Count : 0);
                    items.Add(srs);
                }
            }
            return new QueryResultList<SteelRollSlice>(ret.Result, ret.Message, items);
        }

        public QueryResultList<ProductInventoryItem> GetItems(SearchCondition con)
        {
            if (con == null) con = new ProductInventoryItemSearchCondition();
            if (con is ProductInventoryItemSearchCondition) (con as ProductInventoryItemSearchCondition).ExcludeModel = MODEL;  //排除原材料库存项
            return ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con);
        }
        /// <summary>
        /// 建立库存
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult CreateInventory(Product p, WareHouse w, string customer, decimal count, decimal thick, string op, string memo)
        {
            ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition() { ProductID = p.ID, WareHouseID = w.ID };
            con.States = (int)ProductInventoryState.UnShipped;
            List<ProductInventoryItem> items = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0 && items.Exists(it => it.Customer == customer))
            {
                return new CommandResult(ResultCode.Fail, "库存项已经存在，如果想要更新库库数量，请通过盘点来操作");
            }
            ProductInventoryItem pii = new ProductInventoryItem()
            {
                ID = Guid.NewGuid(),
                AddDate = DateTime.Now,
                ProductID = p.ID,
                WareHouseID = w.ID,
                Unit = "件",
                Count = count,
                InventorySheet = "新建库存",
                Weight = p.Weight,
                Length = p.Length,
                Model = p.Model,
                RealThick = thick,
                Customer = customer,
                State = ProductInventoryState.Inventory,
                Operator = op,
                Memo = memo,
            };
            return ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(pii);
        }
        /// <summary>
        /// 盘点
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult Check(ProductInventoryItem info, decimal newCount, string checker, string memo)
        {
            try
            {
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
                InventoryCheckRecord record = new InventoryCheckRecord();
                record.ID = Guid.NewGuid();
                record.CheckDateTime = DateTime.Now;
                record.ProductID = info.ProductID;
                record.WarehouseID = info.WareHouseID;
                record.Unit = info.Unit;
                record.Price = 0;
                record.Inventory = info.Count;
                record.CheckCount = newCount;
                record.SourceID = info.ID;
                record.Customer = info.Customer;
                record.Checker = checker;
                record.Operator = Operator.Current.Name;
                record.Memo = memo;
                ProviderFactory.Create<IProvider<InventoryCheckRecord, Guid>>(RepoUri).Insert(record, unitWork);

                ProductInventoryItem clone = info.Clone();
                clone.Count = newCount;
                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, info, unitWork);
                var ret = unitWork.Commit();
                if (ret.Result == ResultCode.Successful)
                {
                    info.Count = newCount;
                }
                return ret;
            }
            catch (Exception ex)
            {
                return new CommandResult(ResultCode.Fail, ex.Message);
            }
        }
        /// <summary>
        /// 将库存分配给某个订单项,分配给某个订单项的库存不能再用于其它订单的出货，只能用于该订单项出货
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="orderItem"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public CommandResult Reserve(string warehouseID, string productID, Guid orderItem, string orderID, decimal count)
        {
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
            con.Products = new List<string>();
            con.Products.Add(productID);
            con.WareHouseID = warehouseID;
            con.States = (int)ProductInventoryState.Inventory;
            List<ProductInventoryItem> items = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con).QueryObjects;
            if (items.Sum(item => item.Count) < count) return new CommandResult(ResultCode.Fail, string.Format("库存不足，预分配失败!", productID));

            if (UserSettings.Current.InventoryOutType == InventoryOutType.FIFO) //根据产品的出货方式排序
            {
                items = (from item in items orderby item.AddDate ascending select item).ToList();
            }
            else
            {
                items = (from item in items orderby item.AddDate descending select item).ToList();
            }
            foreach (ProductInventoryItem pii in items)
            {
                if (count > 0)
                {
                    ProductInventoryItem pii1 = pii.Clone();
                    if (pii.Count > count) //对于部分出货的情况，一条库存记录拆成两条，其中一条表示出货的，另一条表示未出货部分，即要保证DelvieryItem不为空的都是未出货的，为空的都是已经出货的
                    {
                        pii.OrderItem = orderItem;
                        pii.OrderID = orderID;
                        pii.Count = count;
                        ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(pii, pii1, unitWork);

                        pii1.ID = Guid.NewGuid();
                        pii1.Count -= count;
                        ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(pii1, unitWork);
                        count = 0;
                    }
                    else
                    {
                        pii.OrderItem = orderItem;
                        pii.OrderID = orderID;
                        ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(pii, pii1, unitWork);
                        count -= pii.Count;
                    }
                }
            }
            return unitWork.Commit();
        }
        /// <summary>
        /// 取消备货
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public CommandResult UnReserve(ProductInventoryItem item)
        {
            if (item.State == ProductInventoryState.Reserved || item.State != ProductInventoryState.WaitShipping)
            {
                ProductInventoryItem clone = item.Clone();
                item.OrderItem = null;
                item.OrderID = null;
                item.DeliverySheet = null;
                item.DeliveryItem = null;
                item.State = ProductInventoryState.Inventory;
                return ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(item, clone);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "该项不能取消预定");
            }
        }
        #endregion
    }
}
