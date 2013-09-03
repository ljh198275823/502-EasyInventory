using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory .BusinessModel .SearchCondition ;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.BLL
{
    public class ProductBLL
    {
        #region 构造函数
        public ProductBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region  私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        /// <summary>
        /// 通过ID获取商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public QueryResult<Product> GetByID(string id)
        {
            return ProviderFactory.Create<IProductProvider>(_RepoUri).GetByID(id);
        }
        /// <summary>
        /// 通过查询条件获取指定的商品信息
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public QueryResultList<Product> GetItems(SearchCondition condition)
        {
            return ProviderFactory.Create<IProductProvider>(_RepoUri).GetItems(condition);
        }
        /// <summary>
        /// 增加商品信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult AddProduct(Product info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                if (info.Category != null && !string.IsNullOrEmpty(info.Category.Prefix))
                {
                    info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(info.Category.Prefix, UserSettings.Current.ProductSerialCount, "product");
                }
                else
                {
                    info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(info.CategoryID, UserSettings.Current.ProductSerialCount, "product");
                }
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                return ProviderFactory.Create<IProductProvider>(_RepoUri).Insert(info);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "创建商品编号失败，请重试");
            }
        }
        /// <summary>
        /// 增加商品信息，同时指定初始库存
        /// </summary>
        /// <param name="info"></param>
        /// <param name="wareHouseID"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public CommandResult AddProduct(Product info, string wareHouseID, decimal count)
        {
            WareHouse ws = ProviderFactory.Create<IWareHouseProvider>(_RepoUri).GetByID(wareHouseID).QueryObject;
            if (ws == null) return new CommandResult(ResultCode.Fail, "指定的仓库 \"" + wareHouseID + "\" 不存在");
            if (info.Category != null && !string.IsNullOrEmpty(info.Category.Prefix))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(info.Category.Prefix, UserSettings.Current.ProductSerialCount, "product");
            }
            else
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(info.CategoryID, UserSettings.Current.ProductSerialCount, "product");
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                ProviderFactory.Create<IProductProvider>(_RepoUri).Insert(info, unitWork);
                ProductInventoryItem pii = new ProductInventoryItem()
                {
                    ID = Guid.NewGuid(),
                    ProductID = info.ID,
                    WareHouseID = wareHouseID,
                    Unit = info.Unit,
                    Price = info.Price,
                    Count = count,
                    AddDate = DateTime.Now,
                    InventorySheet = "初始库存"
                };
                ProviderFactory.Create<IProductInventoryItemProvider>(_RepoUri).Insert(pii, unitWork);
                return unitWork.Commit();
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "创建商品编号失败，请重试");
            }
        }
        /// <summary>
        /// 更新商品资料
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult UpdateProduct(Product info)
        {
            Product original = ProviderFactory.Create<IProductProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original != null)
            {
                return ProviderFactory.Create<IProductProvider>(_RepoUri).Update(info, original);
            }
            return new CommandResult(ResultCode.Fail, "编号为 " + info.ID + " 的商品不存在");
        }
        /// <summary>
        /// 删除商品资料
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CommandResult Delete(Product info)
        {
            return ProviderFactory.Create<IProductProvider>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
