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

        #region 公共方法
        public QueryResultList<SteelRollSlice> GetItems(SearchCondition con)
        {
            List<SteelRollSlice> items = null;
            QueryResultList<ProductInventoryItem> ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con);
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
                    srs.Reserved = g.Sum(it => it.State == ProductInventoryState.Reserved ? it.Count : 0);
                    srs.ReservedAmount = g.Sum(it => it.State == ProductInventoryState.Reserved ? (it.Count * it.Price) : 0);
                    srs.Valid = g.Sum(it => it.State == ProductInventoryState.Inventory ? it.Count : 0);
                    srs.ValidAmount = g.Sum(it => it.State == ProductInventoryState.Inventory ? (it.Count * it.Price) : 0);
                    items.Add(srs);
                }
            }
            return new QueryResultList<SteelRollSlice>(ret.Result, ret.Message, items);
        }
        /// <summary>
        /// 建立库存
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult CreateInventory(SteelRollSlice info, string op, string memo)
        {
            ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition() { ProductID = info.Product.ID, WareHouseID = info.WareHouse.ID };
            List<ProductInventoryItem> items = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0) return new CommandResult(ResultCode.Fail, "库存项已经存在，如果想要更新库库数量，请通过盘点或收货单收货");
            ProductInventoryItem pii = new ProductInventoryItem()
            {
                ID = Guid.NewGuid(),
                AddDate = DateTime.Now,
                ProductID = info.Product.ID,
                WareHouseID = info.WareHouse.ID,
                Unit = "件",
                Price = info.Amount / info.Count,
                Count = info.Count,
                InventorySheet = "初始库存",
                Weight = info.Product.Weight,
                Length = info.Product.Length,
                Model = info.Product.Model,
                State = ProductInventoryState.Inventory,
                Operator = op,
                Memo = memo,
            };
            return ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(pii);
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
            if (item.State == ProductInventoryState.Reserved || item.State != ProductInventoryState.WaitShip)
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
