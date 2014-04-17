using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory .BusinessModel .SearchCondition ;
using LJH.Inventory .DAL .IProvider ;
using LJH.GeneralLibrary.DAL;

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

        private readonly int MAXFILENAME = 5 * 1024 * 1024;  //最大上传5M的文件
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
            AttachmentSearchCondition con = new AttachmentSearchCondition();
            con.DocumentID = documentID;
            con.DocumentType = documentType;
            return ProviderFactory.Create<IAttachmentHeaderProvider>(_RepoUri).GetItems(con);
        }
        /// <summary>
        /// 上传附件
        /// </summary>
        /// <param name="header">上传的附件头</param>
        /// <param name="path">附件所在的路径</param>
        /// <returns></returns>
        public CommandResult Upload(AttachmentHeader header, string path)
        {
            try
            {
                if (!File.Exists(path)) return new CommandResult(ResultCode.Fail, string.Format("文件\"{0}\"不存在", path));
                byte[] bs = null;
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    if (fs.Length <= MAXFILENAME)
                    {
                        bs = new byte[fs.Length];
                        fs.Position = 0;
                        fs.Read(bs, 0, (int)fs.Length);
                        IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
                        ProviderFactory.Create<IAttachmentHeaderProvider>(_RepoUri).Insert(header, unitWork); //插入附件头
                        Attachment a = new Attachment();
                        a.ID = header.ID;
                        a.Value = bs;
                        ProviderFactory.Create<IAttachmentProvider>(_RepoUri).Insert(a, unitWork); //插入附件内容
                        return unitWork.Commit();
                    }
                    else
                    {
                        return new CommandResult(ResultCode.Fail, string.Format("文件\"{0}\" 太大，不能上传超过5M的文件", path));
                    }
                }
            }
            catch (Exception ex)
            {
                return new CommandResult(ResultCode.Fail, ex.Message);
            }
        }
        /// <summary>
        /// 下载附件
        /// </summary>
        /// <param name="header">要下载的附件头部</param>
        /// <param name="path">附件保存的路径</param>
        /// <returns></returns>
        public CommandResult Download(AttachmentHeader header, string path)
        {
            QueryResult<Attachment> ret = ProviderFactory.Create<IAttachmentProvider>(_RepoUri).GetByID(header.ID);
            Attachment a = ret.QueryObject;
            if (a != null && a.Value != null)
            {
                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(a.Value, 0, a.Value.Length);
                    }
                    return new CommandResult(ResultCode.Successful, "ok");
                }
                catch (Exception ex)
                {
                    return new CommandResult(ResultCode.Fail, ex.Message);
                }
            }
            else
            {
                return new CommandResult(ret.Result, ret.Message);
            }
        }

        public CommandResult Delete(AttachmentHeader header)
        {
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            ProviderFactory.Create<IAttachmentHeaderProvider>(_RepoUri).Delete(header, unitWork);
            Attachment att = ProviderFactory.Create<IAttachmentProvider>(_RepoUri).GetByID(header.ID).QueryObject;
            if (att != null)
            {
                ProviderFactory.Create<IAttachmentProvider>(_RepoUri).Delete(att, unitWork);
            }
            return unitWork.Commit();
        }
        #endregion
    }
}
