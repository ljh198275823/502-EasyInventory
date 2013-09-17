using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory .BusinessModel .SearchCondition ;
using LJH.Inventory .DAL .IProvider ;

namespace LJH.Inventory.BLL
{
    public class AttachmentBLL
    {
        #region 构造函数
        public AttachmentBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取某个单据的所有附件
        /// </summary>
        /// <param name="documentID"></param>
        /// <param name="documentType"></param>
        /// <returns></returns>
        public QueryResultList<AttachmentHeader> GetHeaders(string documentID, string documentType)
        {
            return null;
        }
        /// <summary>
        /// 上传附件
        /// </summary>
        /// <param name="header">上传的附件头</param>
        /// <param name="path">附件所在的路径</param>
        /// <returns></returns>
        public CommandResult Upload(AttachmentHeader header, string path)
        {
            return null;
        }
        /// <summary>
        /// 下载附件
        /// </summary>
        /// <param name="header">要下载的附件头部</param>
        /// <param name="path">附件保存的路径</param>
        /// <returns></returns>
        public CommandResult Download(AttachmentHeader header, string path)
        {
            return null;
        }
        #endregion
    }
}
