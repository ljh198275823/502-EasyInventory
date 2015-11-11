using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory .DAL .IProvider ;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class OrderBLL : SheetProcessorBase<Order>
    {
        #region 构造函数
        public OrderBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 基类重写的方法
        protected override string CreateSheetID(Order info)
        {
            info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber(UserSettings.Current.OrderPrefix,
                UserSettings.Current.OrderDateFormat, UserSettings.Current.OrderSerialCount, info.DocumentType);
            if (!string.IsNullOrEmpty(info.ID))
            {
                info.Items.ForEach(item => item.OrderID = info.ID);//这一句不能省!!
            }
            return info.ID;
        }

        protected override void DoNullify(Order info, IUnitWork unitWork, DateTime dt, string opt)
        {
            //首先取消订单的备货项
            ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
            con.OrderID = info.ID;
            con.States = (int)ProductInventoryState.UnShipped;
            List<ProductInventoryItem> items = ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                foreach (ProductInventoryItem item in items)
                {
                    ProductInventoryItem clone = item.Clone();
                    item.OrderID = null;
                    item.OrderItem = null;
                    ProviderFactory.Create<IProvider<ProductInventoryItem, Guid>>(RepoUri).Update(item, clone, unitWork);
                }
            }
            base.DoNullify(info, unitWork, dt, opt);
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取订单记录
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public QueryResultList<OrderItemRecord> GetRecords(SearchCondition con)
        {
            return ProviderFactory.Create<IProvider<OrderItemRecord, Guid>>(RepoUri).GetItems(con);
        }
        /// <summary>
        /// 通过id获取订单记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public QueryResult<OrderItemRecord> GetRecordById(Guid id)
        {
            return ProviderFactory.Create<IProvider<OrderItemRecord, Guid>>(RepoUri).GetByID(id);
        }
        #endregion
    }
}
