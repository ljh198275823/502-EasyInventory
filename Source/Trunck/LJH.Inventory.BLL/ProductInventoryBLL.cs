using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.BLL
{
    public class ProductInventoryBLL
    {
        #region 构造函数
        public ProductInventoryBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        public QueryResultList<ProductInventory> GetItems(SearchCondition con)
        {
            return ProviderFactory.Create<IProductInventoryProvider>(_RepoUri).GetItems(con);
        }
        /// <summary>
        /// 建立库存
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult CreateInventory(ProductInventory info)
        {
            ProductInventorySearchCondition con = new ProductInventorySearchCondition() { ProductID = info.ProductID, WareHouseID = info.WareHouseID };
            List<ProductInventory> items = ProviderFactory.Create<IProductInventoryProvider>(_RepoUri).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0) return new CommandResult(ResultCode.Fail, "库存项已经存在，如果想要更新库库数量，请通过盘点或收货单收货");
            ProductInventoryItem pii = new ProductInventoryItem()
            {
                ID = Guid.NewGuid(),
                ProductID = info.ProductID,
                WareHouseID = info.WareHouseID,
                Unit = info.Unit,
                Price = info.Amount / info.Count,
                Count = info.Count,
                AddDate = DateTime.Now,
                InventorySheet = "初始库存"
            };
            return ProviderFactory.Create<IProductInventoryItemProvider>(_RepoUri).Insert(pii);
        }

        public CommandResult Delete(ProductInventory info)
        {
            return ProviderFactory.Create<IProductInventoryProvider>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
