using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.BLL
{
    public class DeliveryRecordBLL
    {
        #region 构造函数
        public DeliveryRecordBLL(string repUri)
        {
            _Provider = ProviderFactory.Create <IDeliveryRecordProvider>(repUri);
        }
        #endregion

        #region 私有变量
        private IDeliveryRecordProvider _Provider;
        #endregion

        #region 公共方法
        /// <summary>
        /// 通过查询条件获取相关商品销售记录
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public QueryResultList<DeliveryRecord> GetItems(SearchCondition con)
        {
            return _Provider.GetItems(con);
        }
        /// <summary>
        /// 获取所有商品销售记录
        /// </summary>
        /// <returns></returns>
        public QueryResultList<DeliveryRecord> GetAll()
        {
            return _Provider.GetItems(null);
        }
        #endregion
    }
}
