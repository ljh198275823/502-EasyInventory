using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory .DAL .IProvider ;
namespace LJH.Inventory.DAL.LinqProvider
{
    public class ItemKeyProvider : IItemKeyProvider
    {
        #region 构造函数
        public ItemKeyProvider(string connStr)
        {
            _ConnStr = connStr;
        }

        private string _ConnStr;
        #endregion

        #region 实现接口 IItemKeyProvider
        public long GetNewItemKey()
        {
            DataContext dc = DataContextFactory.CreateDataContext(_ConnStr);
            var ret = dc.ExecuteQuery<long>("select isnull(max(id),0) +1 from itemkey");
            var f= ret.GetEnumerator();
            f.MoveNext ();
            return f.Current;
        }

        public void SaveKey(long key, IUnitWork unitWork)
        {
            UnitWork u = unitWork as UnitWork;
            var ret = u.Inventory.ExecuteCommand("insert into ItemKey (ID) values (" + key.ToString() + ")");
        }
        #endregion
    }
}
