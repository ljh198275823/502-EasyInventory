using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .DAL .IProvider ;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory.BusinessModel.SearchCondition;

namespace LJH.Inventory.BLL
{
    public class ProductCategoryBLL
    {
        #region 构造函数
        public ProductCategoryBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        public QueryResult<ProductCategory> GetByID(string id)
        {
            return ProviderFactory.Create<IProductCategoryProvider>(_RepoUri).GetByID(id);
        }

        public QueryResultList<ProductCategory> GetAll()
        {
            return ProviderFactory.Create<IProductCategoryProvider>(_RepoUri).GetItems(null);
        }

        public CommandResult Insert(ProductCategory info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.CategoryPrefix, UserSettings.Current.CategorySerialCount, "category");
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                return ProviderFactory.Create<IProductCategoryProvider>(_RepoUri).Insert(info);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "创建类别编号失败，请重试");
            }
        }

        public CommandResult Update(ProductCategory info)
        {
            IProductCategoryProvider provider = ProviderFactory.Create<IProductCategoryProvider>(_RepoUri);
            ProductCategory original = provider.GetByID(info.ID).QueryObject;
            if (original != null)
            {
                return provider.Update(info, original);
            }
            return new CommandResult(ResultCode.Fail, string.Format("ID={0} 的类别在系统中不存在", info.ID));
        }

        public CommandResult Delete(ProductCategory info)
        {
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
