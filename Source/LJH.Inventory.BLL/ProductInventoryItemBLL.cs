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
    public class ProductInventoryItemBLL : BLLBase<Guid, ProductInventoryItem>
    {
        #region 构造函数
        public ProductInventoryItemBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 原材料加工
        /// </summary>
        /// <param name="item"></param>
        /// <param name="slicedTo"></param>
        /// <param name="length"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public CommandResult SteelRollSlice(ProductInventoryItem item, SteelRollSliceRecord slice, WareHouse wh)
        {
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            ProviderFactory.Create<IProvider<SteelRollSliceRecord, Guid>>(RepoUri).Insert(slice, unitWork);
            ProductInventoryItem newVal = item.Clone();
            newVal.Weight = slice.AfterWeight;
            newVal.Length = slice.AfterLength;
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(newVal, item, unitWork);

            ProductInventoryItem pi = new ProductInventoryItem()
            {
                ID = Guid.NewGuid(),
                ProductID = item.ProductID,
                Product = item.Product,
                AddDate = slice.SliceDate,
                SourceID = item.ID,
                Weight = slice.Weight,
                Length = slice.Length,
                Count = slice.Count,
                Model = slice.SliceType, //slice.SliceType == "开平" ? "板材" : "卷材",
                State = ProductInventoryState.Inventory,
                Unit = "件",
                WareHouseID = wh.ID,
                WareHouse = wh,
                Memo = slice.Customer,
            };
            ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(pi, unitWork);
            CommandResult ret = unitWork.Commit();
            if (ret.Result == ResultCode.Successful)
            {
                item.Weight = slice.AfterWeight;
                item.Length = slice.AfterLength;
            }
            return ret;
        }
        #endregion
    }
}
