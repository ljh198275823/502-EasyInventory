using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel.SearchCondition;

namespace LJH.Inventory.BLL
{
    public class DocumentOperationBLL
    {
        #region 构造函数
        public DocumentOperationBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        public QueryResultList<DocumentOperation> GetHisOperations(string documentID, string documentType)
        {
            DocumentSearchCondition con = new DocumentSearchCondition()
            {
                DocumentID = documentID,
                DocumentType = documentType,
            };
            return ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).GetItems(con);
        }
        #endregion
    }
}
