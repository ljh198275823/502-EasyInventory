using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class AttachmentHeaderProvider : ProviderBase<AttachmentHeader, Guid>, IAttachmentHeaderProvider
    {
        #region 构造函数
        public AttachmentHeaderProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr,ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override AttachmentHeader GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<AttachmentHeader>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<AttachmentHeader> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<AttachmentHeader> ret = dc.GetTable<AttachmentHeader>();
            if(search is AttachmentSearchCondition )
            {
                AttachmentSearchCondition con=search as AttachmentSearchCondition ;
                if (!string.IsNullOrEmpty(con.DocumentID)) ret = ret.Where(item => item.DocumentID == con.DocumentID);
                if (!string.IsNullOrEmpty(con.DocumentType)) ret = ret.Where(item => item.DocumentType == con.DocumentType);
            }
            return ret.ToList();
        }
        #endregion
    }
}

