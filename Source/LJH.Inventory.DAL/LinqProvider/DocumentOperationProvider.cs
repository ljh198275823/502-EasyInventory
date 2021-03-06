﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory .DAL .IProvider ;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class DocumentOperationProvider : ProviderBase<DocumentOperation, Guid>
    {
        #region 构造函数
        public DocumentOperationProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
            : base(connStr,ms)
        {
        }
        #endregion

        #region 重写基类方法
        protected override DocumentOperation GetingItemByID(Guid id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<DocumentOperation>().SingleOrDefault(item => item.ID == id);
        }

        protected override List<DocumentOperation> GetingItems(System.Data.Linq.DataContext dc, SearchCondition search)
        {
            IQueryable<DocumentOperation> ret = dc.GetTable<DocumentOperation>();
            if (search is DocumentSearchCondition)
            {
                DocumentSearchCondition con = search as DocumentSearchCondition;
                if (!string.IsNullOrEmpty(con.DocumentID)) ret = ret.Where(item => item.DocumentID == con.DocumentID);
                if (!string.IsNullOrEmpty(con.DocumentType)) ret = ret.Where(item => item.DocumentType == con.DocumentType);
            }
            return ret.ToList();
        }
        #endregion
    }
}
