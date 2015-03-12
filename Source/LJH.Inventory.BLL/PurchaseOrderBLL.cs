using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class PurchaseOrderBLL : SheetProcessorBase<PurchaseOrder>
    {
        #region 构造函数
        public PurchaseOrderBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 重写基类方法
        protected override string CreateSheetID(PurchaseOrder info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.PurchaseSheetPrefix,
                    UserSettings.Current.PurchaseSheetDateFormat, UserSettings.Current.PurchaseSheetSerialCount, info.DocumentType);
            }
            if (!string.IsNullOrEmpty(info.ID)) info.Items.ForEach(item => item.PurchaseID = info.ID);//这一句不能省!!
            return info.ID;
        }
        #endregion

        #region 公共方法
        public QueryResultList<PurchaseItemRecord> GetRecords(SearchCondition con)
        {
            return ProviderFactory.Create<IProvider<PurchaseItemRecord, Guid>>(_RepoUri).GetItems(con);
        }
        #endregion
    }
}

