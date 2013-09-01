using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class PortProvider:ProviderBase <Port,string >,IPortProvider 
    {
        #region 构造函数
        public PortProvider(string connStr)
            : base(connStr)
        {
        }
        #endregion

        #region 重写基类方法
        protected override Port GetingItemByID(string id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<Port>().SingleOrDefault(item => item.ID == id);
        }
        #endregion
    }
}
