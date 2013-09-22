using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class RelatedCompanyTypeProvider : ProviderBase<RelatedCompanyType, string>, IRelatedCompanyTypeProvider
    {
        #region 构造函数
        public RelatedCompanyTypeProvider(string connStr)
            : base(connStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override RelatedCompanyType GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<RelatedCompanyType>().SingleOrDefault(item => item.ID == id);
        }
        #endregion
    }
}

