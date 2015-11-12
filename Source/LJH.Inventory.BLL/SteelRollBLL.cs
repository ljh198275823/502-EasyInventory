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
    public class SteelRollBLL
    {
        #region 构造函数
        public SteelRollBLL(string repoUri)
        {
            RepoUri = repoUri;
        }
        #endregion

        private string RepoUri = null;

        #region 私有方法
        private SteelRoll Convert(ProductInventoryItem info)
        {
            return new SteelRoll()
            {
                ID = info.ID,
                WareHouseID = info.WareHouseID,
                ProductID = info.ProductID,
                Model = info.Model,
                OriginalLength = info.OriginalLength,
                OriginalWeight = info.OriginalWeight,
                Weight = info.Weight,
                Length = info.Length,
                Unit = info.Unit,
                Price = info.Price,
                Count = info.Count,
                AddDate = info.AddDate,
                State = info.State,
                SupplierID = info.SupplierID,
                Manufacture = info.Manufacture,
                SerialNumber = info.SerialNumber,
                OrderID = info.OrderID,
                OrderItem = info.OrderItem,
                PurchaseID = info.PurchaseID,
                PurchaseItem = info.PurchaseItem,
                InventoryItem = info.InventoryItem,
                InventorySheet = info.InventorySheet,
                DeliveryItem = info.DeliveryItem,
                DeliverySheet = info.DeliverySheet,
                SourceID = info.SourceID,
                Operator = info.Operator,
                Memo = info.Memo
            };
        }

        private ProductInventoryItem Convert(SteelRoll info)
        {
            return new ProductInventoryItem()
            {
                ID = info.ID,
                WareHouseID = info.WareHouseID,
                ProductID = info.ProductID,
                Model = info.Model,
                OriginalLength = info.OriginalLength,
                OriginalWeight = info.OriginalWeight,
                Weight = info.Weight,
                Length = info.Length,
                Unit = info.Unit,
                Price = info.Price,
                Count = info.Count,
                AddDate = info.AddDate,
                State = info.State,
                SupplierID = info.SupplierID,
                Manufacture = info.Manufacture,
                SerialNumber = info.SerialNumber,
                OrderID = info.OrderID,
                OrderItem = info.OrderItem,
                PurchaseID = info.PurchaseID,
                PurchaseItem = info.PurchaseItem,
                InventoryItem = info.InventoryItem,
                InventorySheet = info.InventorySheet,
                DeliveryItem = info.DeliveryItem,
                DeliverySheet = info.DeliverySheet,
                SourceID = info.SourceID,
                Operator = info.Operator,
                Memo = info.Memo
            };
        }
        #endregion

        #region 公共方法
        public QueryResult<SteelRoll> GetByID(Guid id)
        {
            SteelRoll sr = null;
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetByID(id);
            if (ret.QueryObject != null)
            {
                sr = Convert(ret.QueryObject);
                sr.Product = new ProductBLL(RepoUri).GetByID(sr.ProductID).QueryObject;
                sr.WareHouse = new WareHouseBLL(RepoUri).GetByID(sr.WareHouseID).QueryObject;
                if (sr.Product == null || sr.WareHouse == null) sr = null;
            }
            return new QueryResult<SteelRoll>(ret.Result, ret.Message, sr);
        }

        public QueryResultList<SteelRoll> GetItems(SearchCondition con)
        {
            List<SteelRoll> items = null;
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con);
            if (ret.QueryObjects != null && ret.QueryObjects.Count > 0)
            {
                List<Product> ps = ProviderFactory.Create<IProvider<Product, string>>(RepoUri).GetItems(null).QueryObjects;
                List<WareHouse> ws = ProviderFactory.Create<IProvider<WareHouse, string>>(RepoUri).GetItems(null).QueryObjects;
                if (items == null) items = new List<SteelRoll>();
                foreach (var pi in ret.QueryObjects)
                {
                    var sr = Convert(pi);
                    sr.Product = ps.SingleOrDefault(it => it.ID == sr.ProductID);
                    sr.WareHouse = ws.SingleOrDefault(it => it.ID == sr.WareHouseID);
                    if (sr.Product != null && sr.WareHouse != null) items.Add(sr);
                }
            }
            return new QueryResultList<SteelRoll>(ret.Result, ret.Message, items);
        }

        public CommandResult Add(SteelRoll sr)
        {
            var pi = Convert(sr);
            return new ProductInventoryItemBLL(RepoUri).Add(pi);
        }

        public CommandResult Update(SteelRoll sr)
        {
            return new ProductInventoryItemBLL(RepoUri).Update(Convert(sr));
        }
        /// <summary>
        /// 原材料加工
        /// </summary>
        /// <param name="sr"></param>
        /// <param name="slicedTo"></param>
        /// <param name="length"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public CommandResult Slice(SteelRoll sr, SteelRollSliceRecord slice, WareHouse wh)
        {
            Product p = new ProductBLL(RepoUri).Create(sr.Product.CategoryID, sr.Product.Specification, slice.SliceType, slice.Weight, slice.Length);
            if (p == null) return new CommandResult(ResultCode.Fail, "创建相关产品信息失败");

            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            ProviderFactory.Create<IProvider<SteelRollSliceRecord, Guid>>(RepoUri).Insert(slice, unitWork);

            ProductInventoryItem item = Convert(sr);
            ProductInventoryItem newVal = item.Clone();
            newVal.Weight = slice.AfterWeight;
            newVal.Length = slice.AfterLength;
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(newVal, item, unitWork);

            ProductInventoryItem pi = new ProductInventoryItem()
            {
                ID = Guid.NewGuid(),
                ProductID = p.ID,
                AddDate = slice.SliceDate,
                InventorySheet = "加工入库",
                InventoryItem = slice.ID,
                Weight = slice.Weight,
                Length = slice.Length,
                Count = slice.Count,
                Model = slice.SliceType, 
                State = ProductInventoryState.Inventory,
                Unit = "件",
                WareHouseID = wh.ID,
                Memo = slice.Customer,
            };
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(pi, unitWork);
            CommandResult ret = unitWork.Commit();
            if (ret.Result == ResultCode.Successful)
            {
                sr.Weight = slice.AfterWeight;
                sr.Length = slice.AfterLength;
            }
            return ret;
        }
        /// <summary>
        /// 原材料盘点
        /// </summary>
        /// <returns></returns>
        public CommandResult Check(SteelRoll sr, decimal newWeight, decimal newLength, string memo, string checker, string operatorName)
        {
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            ProductInventoryItem newVal = Convert(sr);
            ProductInventoryItem item = newVal.Clone();
            newVal.Weight = newWeight;
            newVal.Length = newLength;
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(newVal, item, unitWork);
            InventoryCheckRecord citem = new InventoryCheckRecord()
            {
                ID = Guid.NewGuid(),
                CheckDateTime = DateTime.Now,
                ProductID = sr.ProductID,
                WarehouseID = sr.WareHouseID,
                SourceID = sr.ID,
                BeforeLength = sr.Length,
                BeforeWeight = sr.Weight,
                Length = newLength,
                Weight = newWeight,
                Inventory = 1,
                CheckCount = 1,
                Unit = sr.Unit,
                Price = 0,
                Operator = operatorName,
                Checker = checker,
                Memo = memo
            };
            ProviderFactory.Create<IProvider<InventoryCheckRecord, Guid>>(RepoUri).Insert(citem, unitWork);
            CommandResult ret = unitWork.Commit();
            if (ret.Result == ResultCode.Successful)
            {
                sr.Weight = newWeight;
                sr.Length = newLength;
            }
            return ret;
        }
        /// <summary>
        /// 废品处理
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public CommandResult Nullify(SteelRoll sr)
        {
            ProductInventoryItem newVal = Convert(sr);
            ProductInventoryItem item = newVal.Clone();
            newVal.State = ProductInventoryState.Nullified;
            if (string.IsNullOrEmpty(newVal.Memo))
            {
                newVal.Memo = "废品处理";
            }
            else
            {
                newVal.Memo += ",废品处理";
            }
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(newVal, item);
            if (ret.Result == ResultCode.Successful)
            {
                sr.State = newVal.State;
                sr.Memo = newVal.Memo;
            }
            return ret;
        }
        #endregion
    }
}
