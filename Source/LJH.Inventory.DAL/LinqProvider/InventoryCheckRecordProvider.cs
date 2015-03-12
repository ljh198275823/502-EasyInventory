using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class InventoryCheckRecordProvider : ProviderBase<InventoryCheckRecord, Guid>
    {
        #region 构造函数
        public InventoryCheckRecordProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override InventoryCheckRecord GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<InventoryCheckRecord>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<InventoryCheckRecord> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<InventoryCheckRecord> ret = dc.GetTable<InventoryCheckRecord>();
            List<InventoryCheckRecord> items = ret.ToList();
            return items;
        }
        #endregion
    }
}
