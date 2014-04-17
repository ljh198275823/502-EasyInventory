using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class ExpenditureTypeProvider : ProviderBase<ExpenditureType, string>, IExpenditureTypeProvider
    {
        #region 构造函数
        public ExpenditureTypeProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr,ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override ExpenditureType GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<ExpenditureType>().SingleOrDefault(item => item.ID == id);
        }
        #endregion
    }
}
