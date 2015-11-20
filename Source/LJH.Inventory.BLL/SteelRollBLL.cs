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
        private const string MODEL = "原材料";

        #region 公共方法
        public QueryResult<ProductInventoryItem> GetByID(Guid id)
        {
            ProductInventoryItem sr = null;
            return  ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetByID(id);
        }

        public QueryResultList<ProductInventoryItem> GetItems(SearchCondition con)
        {
            if (con == null)
            {
                con = new ProductInventoryItemSearchCondition() { Model = MODEL };
            }
            else if (con is ProductInventoryItemSearchCondition)
            {
                (con as ProductInventoryItemSearchCondition).Model = MODEL;
            }
            return ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con);
        }

        public CommandResult Add(ProductInventoryItem sr)
        {
            return new ProductInventoryItemBLL(RepoUri).Add(sr);
        }

        public CommandResult Update(ProductInventoryItem sr)
        {
            return new ProductInventoryItemBLL(RepoUri).Update(sr);
        }
        /// <summary>
        /// 原材料加工
        /// </summary>
        /// <param name="sr"></param>
        /// <param name="slicedTo"></param>
        /// <param name="length"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public CommandResult Slice(ProductInventoryItem sr, SteelRollSliceRecord sliceSheet, WareHouse wh)
        {
            Product p = new ProductBLL(RepoUri).Create(sr.Product.CategoryID, sr.Product.Specification, sliceSheet.SliceType, sliceSheet.Weight, sliceSheet.Length, sr.Product.Density);
            if (p == null) return new CommandResult(ResultCode.Fail, "创建相关产品信息失败");

            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            ProviderFactory.Create<IProvider<SteelRollSliceRecord, Guid>>(RepoUri).Insert(sliceSheet, unitWork);

            ProductInventoryItem newVal = sr.Clone();
            newVal.Weight = sliceSheet.AfterWeight;
            newVal.Length = sliceSheet.AfterLength;
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(newVal, sr, unitWork);

            ProductInventoryItem pi = new ProductInventoryItem()
            {
                ID = Guid.NewGuid(),
                ProductID = p.ID,
                AddDate = sliceSheet.SliceDate,
                InventorySheet = "加工入库",
                InventoryItem = sliceSheet.ID,
                Weight = sliceSheet.Weight,
                Length = sliceSheet.Length,
                RealThick = sr.RealThick,
                Count = sliceSheet.Count,
                Model = sliceSheet.SliceType,
                State = ProductInventoryState.Inventory,
                Unit = "件",
                WareHouseID = wh.ID,
                Customer = sliceSheet.Customer,
                SourceRoll = sr.ID,  //设置加工来源
            };
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(pi, unitWork);
            CommandResult ret = unitWork.Commit();
            if (ret.Result == ResultCode.Successful)
            {
                sr.Weight = sliceSheet.AfterWeight;
                sr.Length = sliceSheet.AfterLength;
            }
            return ret;
        }
        /// <summary>
        /// 原材料盘点
        /// </summary>
        /// <returns></returns>
        public CommandResult Check(ProductInventoryItem sr, decimal newWeight, decimal newLength, string memo, string checker, string operatorName)
        {
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            ProductInventoryItem newVal = sr.Clone();
            newVal.Weight = newWeight;
            newVal.Length = newLength;
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(newVal, sr, unitWork);
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
                Customer = sr.Customer,
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
        public CommandResult Nullify(ProductInventoryItem sr)
        {
            ProductInventoryItem newVal = sr.Clone();
            newVal.State = ProductInventoryState.Nullified;
            if (string.IsNullOrEmpty(newVal.Memo))
            {
                newVal.Memo = "废品处理";
            }
            else
            {
                newVal.Memo += ",废品处理";
            }
            var ret = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(newVal, sr);
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
