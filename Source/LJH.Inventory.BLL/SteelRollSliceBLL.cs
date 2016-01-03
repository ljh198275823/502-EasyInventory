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

        #region 公共方法
        public QueryResultList<SteelRollSlice> GetSteelRollSlices(SearchCondition con)
        {
            List<SteelRollSlice> items = null;
            QueryResultList<ProductInventoryItem> ret = GetItems(con);
            if (ret.QueryObjects != null && ret.QueryObjects.Count > 0)
            {
                List<Product> ps = ProviderFactory.Create<IProvider<Product, string>>(RepoUri).GetItems(null).QueryObjects;
                var gs = from it in ret.QueryObjects
                         group it by new { it.ProductID };
                foreach (var g in gs)
                {
                    if (items == null) items = new List<SteelRollSlice>();
                    SteelRollSlice srs = new SteelRollSlice();
                    srs.ID = Guid.Empty;
                    srs.Product = ps.SingleOrDefault(it => it.ID == g.First().ProductID);
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
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con);
            if (ret.QueryObjects != null)
            {
                List<ProductInventoryItem> srs = new SteelRollBLL(RepoUri).GetItems(null).QueryObjects;
                if (srs != null && srs.Count > 0)
                {
                    foreach (var item in ret.QueryObjects)
                    {
                        if (item.SourceRoll.HasValue)
                        {
                            var sr = srs.SingleOrDefault(it => it.ID == item.SourceRoll);
                            if (sr != null) item.SourceRollWeight = sr.OriginalWeight;
                        }
                    }
                }
            }
            return ret;
        }

        public CommandResult Add(ProductInventoryItem pi)
        {
            return ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(pi);
        }

        /// <summary>
        /// 建立库存
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult CreateInventory(Product p, WareHouse w, string customer, decimal count,decimal weight, decimal thick, string op, string memo)
        {
            ProductInventoryItem pii = new ProductInventoryItem()
            {
                ID = Guid.NewGuid(),
                AddDate = DateTime.Now,
                ProductID = p.ID,
                WareHouseID = w.ID,
                Unit = "件",
                Count = count,
                InventorySheet = "新建库存",
                Weight = weight,
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
                if (info.Count == newCount) return new CommandResult(ResultCode.Fail, "实盘数量和库存数量一致");
                if (info.State == ProductInventoryState.Nullified) return new CommandResult(ResultCode.Fail, "作废的库存项不能进行盘点操作");
                if (info.State != ProductInventoryState.Inventory) return new CommandResult(ResultCode.Fail, "库存项数量处于锁定状态,不能盘点");
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
                ProductInventoryItem clone = info.Clone();
                clone.Count = newCount;
                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, info, unitWork);

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

                var ret = unitWork.Commit();
                if (ret.Result == ResultCode.Successful)
                {
                    info.Count = clone.Count;
                }
                return ret;
            }
            catch (Exception ex)
            {
                return new CommandResult(ResultCode.Fail, ex.Message);
            }
        }

        public CommandResult Depart(ProductInventoryItem info, WareHouse w, string customer, decimal count, string memo)
        {
            if (info.Count < count) return new CommandResult(ResultCode.Fail, "拆包数量大于原包数量");
            if (info.State == ProductInventoryState.Nullified) return new CommandResult(ResultCode.Fail, "作废的库存项不能进行拆包操作");
            if (info.State != ProductInventoryState.Inventory) return new CommandResult(ResultCode.Fail, "库存项数量处于锁定状态,不能拆包");
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            ProductInventoryItem clone = info.Clone();
            clone.Count -= count;
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, info, unitWork);

            ProductInventoryItem depart = info.Clone ();
            depart.ID =Guid.NewGuid ();
            depart.WareHouseID = w.ID;
            depart.Customer =customer ;
            depart.Count =count;
            depart.SourceID =info.ID ;
            depart.Memo =memo ;
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(depart, unitWork);

            var ret = unitWork.Commit();
            if (ret.Result == ResultCode.Successful)
            {
                info.Count = clone.Count;
            }
            return ret;
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
