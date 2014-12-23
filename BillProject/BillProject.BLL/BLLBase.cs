using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary.Core.DAL;
using LJH.BillProject.DAL;

namespace LJH.BillProject.BLL
{
    public abstract class BLLBase<TID, TEntity> where TEntity : class , IEntity<TID>
    {
        #region 构造函数
        public BLLBase(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region  私有变量
        protected string _RepoUri = null;
        #endregion

        #region 公共方法
        /// <summary>
        /// 通过ID获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual QueryResult<TEntity> GetByID(TID id)
        {
            return ProviderFactory.Create<IProvider<TEntity, TID>>(_RepoUri).GetByID(id);
        }
        /// <summary>
        /// 通过查询条件获取指定的实体信息
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public virtual QueryResultList<TEntity> GetItems(SearchCondition condition)
        {
            return ProviderFactory.Create<IProvider<TEntity, TID>>(_RepoUri).GetItems(condition);
        }
        /// <summary>
        /// 增加实体
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public virtual CommandResult Add(TEntity info)
        {
            return ProviderFactory.Create<IProvider<TEntity, TID>>(_RepoUri).Insert(info);
        }
        /// <summary>
        /// 更新更新实体
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public virtual CommandResult Update(TEntity info)
        {
            TEntity original = ProviderFactory.Create<IProvider<TEntity, TID>>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original != null)
            {
                return ProviderFactory.Create<IProvider<TEntity, TID>>(_RepoUri).Update(info, original);
            }
            return new CommandResult(ResultCode.Fail, "更新失败，记录被删除");
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public virtual CommandResult Delete(TEntity info)
        {
            return ProviderFactory.Create<IProvider<TEntity, TID>>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
