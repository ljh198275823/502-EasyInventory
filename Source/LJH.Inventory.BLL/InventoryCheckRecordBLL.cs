using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .DAL .IProvider ;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class InventoryCheckRecordBLL : BLLBase<Guid, InventoryCheckRecord>
    {
        #region 构造函数
        public InventoryCheckRecordBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 私有方法
        private void InventoryIn(InventoryCheckRecord record, IUnitWork unitWork)
        {
            ProductInventoryItem pii = new ProductInventoryItem()
            {
                ID = Guid.NewGuid(),
                ProductID = record.ProductID,
                WareHouseID = record.WarehouseID,
                Unit = record.Unit,
                Price = record.Price,
                Count = record.CheckCount - record.Inventory,
                AddDate = DateTime.Now,
                InventoryItem = record.ID,
                InventorySheet = "盘盈",
            };
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(pii, unitWork);
        }

        private void InventoryOut(InventoryCheckRecord record, InventoryOutType inventoryOutType, IUnitWork unitWork)
        {
            List<string> pids = new List<string>();
            pids.Add(record.ProductID);
            ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
            con.Products = pids;
            con.WareHouseID = record.WarehouseID;
            con.UnShipped = true;
            List<ProductInventoryItem> inventoryItems = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con).QueryObjects;
            if (inventoryItems == null || inventoryItems.Count == 0) throw new Exception("没有找到相关的库存项");
            List<ProductInventoryItem> clones = new List<ProductInventoryItem>();
            inventoryItems.ForEach(it => clones.Add(it.Clone())); //备分所有的项的克隆
            List<ProductInventoryItem> addingItems = new List<ProductInventoryItem>(); //要于保存将要增加的项
            ////减少库存
            Product p = ProviderFactory.Create<IProvider<Product, string>>(RepoUri).GetByID(record.ProductID).QueryObject;
            if (p != null && p.IsService != null && p.IsService.Value) return; //如果是产品是服务的话就不用再从库存中扣除了
            Assign(record, inventoryOutType, inventoryItems, addingItems);

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

        private void Assign(InventoryCheckRecord si, InventoryOutType inventoryOutType, List<ProductInventoryItem> inventoryItems, List<ProductInventoryItem> addingItems)
        {
            List<ProductInventoryItem> items = new List<ProductInventoryItem>();
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
            if (items.Sum(item => item.Count) < si.Inventory - si.CheckCount) throw new Exception(string.Format("产品 {0} 库存不足，出货失败!", si.ProductID));

            decimal count = si.Inventory - si.CheckCount;
            foreach (ProductInventoryItem item in items)
            {
                if (count > 0)
                {
                    if (item.Count > count) //对于部分出货的情况，一条库存记录拆成两条，其中一条表示出货的，另一条表示未出货部分，即要保证DelvieryItem不为空的都是未出货的，为空的都是已经出货的
                    {
                        ProductInventoryItem pii = item.Clone();
                        pii.ID = Guid.NewGuid();
                        pii.DeliveryItem = si.ID;
                        pii.DeliverySheet = "盘亏";
                        pii.Count = count;
                        addingItems.Add(pii);
                        item.Count -= count;
                        count = 0;
                    }
                    else
                    {
                        item.DeliveryItem = si.ID;
                        item.DeliverySheet = "盘亏";
                        count -= item.Count;
                    }
                }
            }
        }
        #endregion

        #region 重写基类方法
        public override CommandResult Add(InventoryCheckRecord info)
        {
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            ProductInventorySearchCondition con = new ProductInventorySearchCondition();
            con.ProductID = info.ProductID;
            con.WareHouseID = info.WarehouseID;
            List<SteelRollSlice> items = ProviderFactory.Create<IProvider<SteelRollSlice, Guid>>(RepoUri).GetItems(con).QueryObjects;
            if (items == null || items.Count == 0) throw new Exception("没有该产品的库存项");
            SteelRollSlice pi = items[0];
            if (info.Inventory != pi.Count) throw new Exception("产品库存有改动，请重新操作");
            if (info.CheckCount > pi.Count) //盘盈
            {
                InventoryIn(info, unitWork);
            }
            else if (info.CheckCount < pi.Count)  //盘亏
            {
                InventoryOut(info, UserSettings.Current.InventoryOutType, unitWork);
            }
            ProviderFactory.Create<IProvider<InventoryCheckRecord, Guid>>(RepoUri).Insert(info, unitWork);
            return unitWork.Commit();
        }
        #endregion
    }
}
