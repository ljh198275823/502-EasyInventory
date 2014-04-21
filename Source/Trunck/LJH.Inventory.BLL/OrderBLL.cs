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
            info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.OrderPrefix,
                UserSettings.Current.OrderDateFormat, UserSettings.Current.OrderSerialCount, info.DocumentType);
            if (!string.IsNullOrEmpty(info.ID))
            {
                info.Items.ForEach(item => item.OrderID = info.ID);//这一句不能省!!
            }
            return info.ID;
        }

        protected override DateTime? GetLastActiveDate(Order sheet)
        {
            throw new NotImplementedException();
        }

        protected override DateTime? GetServerDateTime()
        {
            DateTime? dt = null;
            ProviderFactory.Create<IServerDatetimeProvider>(_RepoUri).GetServerDateTime(out dt);
            return dt;
        }

        protected override void AddOperationLog(string id, string docType, SheetOperation operation, string opt, IUnitWork unitWork, DateTime dt)
        {
            (new DocumentOperationBLL(AppSettings.Current.ConnStr)).AddOperationLog(id, docType, operation, opt, unitWork, dt);
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
            return ProviderFactory.Create<IProvider<OrderItemRecord, Guid>>(_RepoUri).GetItems(con);
        }
        /// <summary>
        /// 通过id获取订单记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public QueryResult<OrderItemRecord> GetRecordById(Guid id)
        {
            return ProviderFactory.Create<IProvider<OrderItemRecord, Guid>>(_RepoUri).GetByID(id);
        }
        #endregion
    }
}
