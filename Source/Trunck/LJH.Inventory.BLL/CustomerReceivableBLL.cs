using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory .DAL .IProvider ;

namespace LJH.Inventory.BLL
{
    public class CustomerReceivableBLL
    {
        #region 构造函数
        public CustomerReceivableBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri = null;
        #endregion

        #region 公共方法
        /// <summary>
        /// 通过查询条件获取相关的客户应收账款数据
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public QueryResultList<CustomerReceivable> GetItems(SearchCondition con)
        {
            return ProviderFactory.Create<ICustomerReceivableProvider>(_RepoUri).GetItems(con);
        }
        #endregion
    }
}
