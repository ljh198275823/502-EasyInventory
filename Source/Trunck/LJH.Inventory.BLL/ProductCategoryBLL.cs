using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .DAL .IProvider ;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.BLL
{
    public class ProductCategoryBLL : BLLBase<string, ProductCategory>
    {
        #region 构造函数
        public ProductCategoryBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 公共方法
        public override CommandResult Add(ProductCategory info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.CategoryPrefix, UserSettings.Current.CategorySerialCount, "category");
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                return base.Add(info);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "创建类别编号失败，请重试");
            }
        }

        public override CommandResult Delete(ProductCategory info)
        {
            List<ProductCategory> tps = ProviderFactory.Create<IProductCategoryProvider>(_RepoUri).GetItems(null).QueryObjects;
            if (tps != null && tps.Count > 0 && tps.Exists(item => item.Parent == info.ID))
            {
                return new CommandResult(ResultCode.Fail, "类别下已经有子类别，请先将所有子类别删除，再删除此类别");
            }
            IProductProvider sp = ProviderFactory.Create<IProductProvider>(_RepoUri);
            ProductSearchCondition con = new ProductSearchCondition() { CategoryID = info.ID };
            if (sp.GetItems(con).QueryObjects.Count > 0)
            {
                return new CommandResult(ResultCode.Fail, "此类别不能删除，已经有物料归到此类别，如果确实要删除此类别，请先更改相关物料的所属类别");
            }
            return ProviderFactory.Create<IProductCategoryProvider>(_RepoUri).Delete(info);
        }
        #endregion

    }
}
