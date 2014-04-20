using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.DAL;
using LJH.Inventory.BusinessModel.Resource;
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
            return ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).GetItems(con);
        }

        /// <summary>
        /// 获取单据最后一次操作的操作记录
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        public QueryResult<DocumentOperation> GetLatestOperation(Order sheet)
        {
            QueryResultList<DocumentOperation> ret = (new DocumentOperationBLL(AppSettings.Current.ConnStr)).GetHisOperations(sheet.ID, sheet.DocumentType);
            DocumentOperation log = null;
            if (ret.Result == ResultCode.Successful)
            {
                List<DocumentOperation> items = ret.QueryObjects;
                if (items != null && items.Count > 0)
                {
                    foreach (DocumentOperation item in items)
                    {
                        if (log == null || item.OperatDate > log.OperatDate) log = item;
                    }
                }
            }
            return new QueryResult<DocumentOperation>(ret.Result, ret.Message, log);
        }

        internal void AddOperationLog(string id, string docType, SheetOperation operation, string opt, IUnitWork unitWork, DateTime dt)
        {
            DocumentOperation doc = new DocumentOperation()
            {
                DocumentID = id,
                DocumentType = docType,
                OperatDate = dt,
                Operation = SheetOperationDescription.GetDescription(operation),
                Operator = opt,
            };
            ProviderFactory.Create<IDocumentOperationProvider>(_RepoUri).Insert(doc, unitWork);
        }
        #endregion
    }
}
