using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class TransportProvider : ProviderBase<Transport, string>, ITransportProvider
    {
        #region 构造函数
        public TransportProvider(string connStr)
            : base(connStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override Transport GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<Transport>().SingleOrDefault(item => item.ID == id);
        }
        #endregion
    }
}
