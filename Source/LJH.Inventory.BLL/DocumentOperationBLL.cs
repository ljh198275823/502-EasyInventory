using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;

namespace LJH.Inventory.BLL
{
    public class DocumentOperationBLL : BLLBase<Guid, DocumentOperation>
    {
        #region 构造函数
        public DocumentOperationBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取某个单据的所有操作记录
        /// </summary>
        /// <param name="documentID"></param>
        /// <param name="documentType"></param>
        /// <returns></returns>
        public QueryResultList<DocumentOperation> GetHisOperations(string documentID, string documentType)
        {
            DocumentSearchCondition con = new DocumentSearchCondition()
            {
                DocumentID = documentID,
                DocumentType = documentType,
            };
            return base.GetItems(con);
        }
        #endregion
    }
}
