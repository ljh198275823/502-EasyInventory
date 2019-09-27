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
    public class SteelRollSliceBLL:ProductInventoryItemBLL 
    {
        #region 构造函数
        public SteelRollSliceBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        private static List<string> MODELS = new List<string>() { ProductModel.开平, ProductModel.开卷, ProductModel.开吨, ProductModel.开条 };

        #region 公共方法
        public QueryResultList<SteelRollSlice> GetSteelRollSlices(SearchCondition con)
        {
            List<SteelRollSlice> items = null;
            QueryResultList<ProductInventoryItem> ret = GetItems(con);
            if (ret.QueryObjects != null && ret.QueryObjects.Count > 0)
            {
                var gs = from it in ret.QueryObjects
                         group it by new { it.ProductID };
                foreach (var g in gs)
                {
                    if (items == null) items = new List<SteelRollSlice>();
                    SteelRollSlice srs = new SteelRollSlice();
                    srs.ID = Guid.Empty;
                    srs.Product = g.First().Product;
                    srs.Unit = g.First().Unit;
                    srs.WaitShipping = g.Sum(it => it.State == ProductInventoryState.WaitShipping ? it.Count : 0);
                    srs.Reserved = g.Sum(it => it.State == ProductInventoryState.Reserved ? it.Count : 0);
                    srs.Valid = g.Sum(it => it.State == ProductInventoryState.Inventory ? it.Count : 0);
                    items.Add(srs);
                }
            }
            return new QueryResultList<SteelRollSlice>(ret.Result, ret.Message, items);
        }

        public override QueryResultList<ProductInventoryItem> GetItems(SearchCondition con)
        {
            if (con == null) con = new ProductInventoryItemSearchCondition();
            if (con is ProductInventoryItemSearchCondition) (con as ProductInventoryItemSearchCondition).Models = MODELS;  //排除原材料库存项
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con);
            return ret;
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
                decimal? uw = info.UnitWeight;
                if (uw != null) clone.Weight = newCount * uw; 
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
                    info.Weight = clone.Weight;
                }
                return ret;
            }
            catch (Exception ex)
            {
                return new CommandResult(ResultCode.Fail, ex.Message);
            }
        }
        /// <summary>
        /// 拆包
        /// </summary>
        public CommandResult Depart(ProductInventoryItem info, WareHouse w, string customer, decimal count, string specification,decimal length, string memo)
        {
            if (info.Count < count) return new CommandResult(ResultCode.Fail, "拆包数量大于原包数量");
            if (info.State == ProductInventoryState.Nullified) return new CommandResult(ResultCode.Fail, "作废的库存项不能进行拆包操作");
            if (info.State != ProductInventoryState.Inventory) return new CommandResult(ResultCode.Fail, "库存项数量处于锁定状态,不能拆包");

            Product p = new ProductBLL(AppSettings.Current.ConnStr).Create(info.Product.CategoryID, specification, info.Product.Model, info.Product.材质, info.Product.Weight, length, info.Product.Density);
            if (p == null) return new CommandResult(ResultCode.Fail, "创建产品信息失败");

            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            decimal? uw = info.UnitWeight;
            ProductInventoryItem clone = info.Clone();
            clone.Count -= count;
            if (uw.HasValue) clone.Weight = clone.Count * uw;
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(clone, info, unitWork);

            ProductInventoryItem depart = info.Clone();
            depart.ID = Guid.NewGuid();
            depart.WareHouseID = w.ID;
            depart.Customer = customer;
            depart.Count = count;
            depart.ProductID = p.ID;
            depart.Product = p;
            if (uw.HasValue)
            {
                depart.OriginalWeight = depart.Count * uw;
                depart.Weight = depart.OriginalWeight;
            }
            else
            {
                depart.OriginalWeight = null;
                depart.Weight = null;
            }
            depart.SourceID = info.ID;
            depart.CostID = info.CostID.HasValue ? info.CostID.Value : info.ID;
            depart.Memo = memo;
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(depart, unitWork);

            var ret = unitWork.Commit();
            if (ret.Result == ResultCode.Successful)
            {
                info.Count = clone.Count;
                info.Weight = clone.Weight;
            }
            return ret;
        }
        #endregion
    }
}
