using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class OperatorProvider : ProviderBase<Operator, string>, IOperatorProvider
    {
        public OperatorProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr,ms)
        {
        }

        #region 重写模板方法
        protected override Operator GetingItemByID(string id, DataContext dc)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<Operator>(o => o.Role);
            dc.LoadOptions = opt;
            return dc.GetTable<Operator>().SingleOrDefault(o => o.ID == id);
        }

        protected override List<Operator> GetingItems(DataContext dc, SearchCondition search)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<Operator>(o => o.Role);
            dc.LoadOptions = opt;
            IQueryable<Operator> ret = dc.GetTable<Operator>();
            if (search != null)
            {
            }
            return ret.ToList();
        }
        #endregion
    }
}
