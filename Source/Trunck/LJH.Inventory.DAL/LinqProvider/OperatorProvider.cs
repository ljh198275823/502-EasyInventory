using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class OperatorProvider : ProviderBase<OperatorInfo, string>, IOperatorProvider
    {
        public OperatorProvider(string connStr)
            : base(connStr)
        {
        }

        #region 重写模板方法
        protected override OperatorInfo GetingItemByID(string id, DataContext dc)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<OperatorInfo>(o => o.Role);
            dc.LoadOptions = opt;
            return dc.GetTable<OperatorInfo>().SingleOrDefault(o => o.OperatorID == id);
        }

        protected override List<OperatorInfo> GetingItems(DataContext dc, BusinessModel.SearchCondition.SearchCondition search)
        {
            DataLoadOptions opt = new DataLoadOptions();
            opt.LoadWith<OperatorInfo>(o => o.Role);
            dc.LoadOptions = opt;
            IQueryable<OperatorInfo> ret = dc.GetTable<OperatorInfo>();
            if (search != null)
            {
            }
            return ret.ToList();
        }
        #endregion
    }
}
