using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory .BusinessModel .SearchCondition ;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class ProductBLL : BLLBase<string, Product>
    {
        #region 构造函数
        public ProductBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public override CommandResult Add(Product info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                if (info.Category != null && !string.IsNullOrEmpty(info.Category.Prefix))
                {
                    info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber(info.Category.Prefix, UserSettings.Current.ProductSerialCount, "product");
                }
                else
                {
                    info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("P", UserSettings.Current.ProductSerialCount, "product");
                }
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                return base.Add(info);
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
            WareHouse ws = ProviderFactory.Create<IProvider<WareHouse, string>>(RepoUri).GetByID(wareHouseID).QueryObject;
            if (ws == null) return new CommandResult(ResultCode.Fail, "指定的仓库 \"" + wareHouseID + "\" 不存在");
            if (info.Category != null && !string.IsNullOrEmpty(info.Category.Prefix))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber(info.Category.Prefix, UserSettings.Current.ProductSerialCount, "product");
            }
            else
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("P", UserSettings.Current.ProductSerialCount, "product");
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
                ProviderFactory.Create<IProvider<Product, string>>(RepoUri).Insert(info, unitWork);
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
                ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Insert(pii, unitWork);
                return unitWork.Commit();
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "创建商品编号失败，请重试");
            }
        }

        public Product Create(string categoryID, string specification)
        {
            List<Product> ps = GetItems(null).QueryObjects;
            if (ps != null && ps.Exists(it => it.CategoryID == categoryID && it.Specification == specification))
            {
                return ps.Single(it => it.CategoryID == categoryID && it.Specification == specification);
            }
            else
            {
                Product p = new Product();
                p.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("P", UserSettings.Current.ProductSerialCount, "product");
                p.Specification = specification;
                p.CategoryID = categoryID;
                p.Name = p.ID;
                p.Unit = string.Empty;
                if (!string.IsNullOrEmpty(p.ID))
                {
                    var ret = base.Add(p);
                    if (ret.Result == ResultCode.Successful) return Create(categoryID, specification);
                }
            }
            return null;
        }
        #endregion
    }
}
