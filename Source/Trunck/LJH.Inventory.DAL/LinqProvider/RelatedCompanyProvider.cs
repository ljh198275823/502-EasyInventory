using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class RelatedCompanyProvider : ProviderBase<RelatedCompany,int>, IRelatedCompanyProvider
    {
        #region 构造函数
        public RelatedCompanyProvider(string connStr)
            : base(connStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override RelatedCompany GetingItemByID(int id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<RelatedCompany>().SingleOrDefault(item => item.ID == id);
        }
        #endregion
    }
}
