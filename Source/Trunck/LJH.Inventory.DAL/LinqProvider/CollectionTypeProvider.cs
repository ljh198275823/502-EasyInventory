using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class  CollectionTypeProvider:ProviderBase <CollectionType ,string >,ICollectionTypeProvider
    {
        #region 构造函数
        public CollectionTypeProvider(string connStr)
            : base(connStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override CollectionType GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<CollectionType>().SingleOrDefault(item => item.ID == id);
        }
        #endregion
    }
}
