using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class OtherReceivableSheetBLL : SheetProcessorBase<OtherReceivableSheet>
    {
        #region 构造函数
        public OtherReceivableSheetBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 重写基类方法
        protected override string CreateSheetID(OtherReceivableSheet info)
        {
            if (info.ClassID == CustomerReceivableType.CustomerReceivable)
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("CR", "yyyyMM", 3, info.DocumentType);
            }
            else if (info.ClassID == CustomerReceivableType.CustomerTax)
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("CRT", "yyyyMM", 3, info.DocumentType);
            }
            else if (info.ClassID == CustomerReceivableType.SupplierReceivable)
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("SR", "yyyyMM", 3, info.DocumentType);
            }
            else if (info.ClassID == CustomerReceivableType.SupplierTax)
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber("SRT", "yyyyMM", 3, info.DocumentType);
            }
            return info.ID;
        }

        protected override void DoAdd(OtherReceivableSheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            base.DoAdd(info, unitWork, dt, opt);
            CustomerReceivable cr = new CustomerReceivable()
            {
                ID = Guid.NewGuid(),
                SheetID = info.ID,
                ClassID = info.ClassID,
                CreateDate = new DateTime(info.SheetDate.Year, info.SheetDate.Month, info.SheetDate.Day, dt.Hour, dt.Minute, dt.Second),
                Amount = info.Amount,
                CustomerID = info.CustomerID,
                Memo = info.Memo
            };
            ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Insert(cr, unitWork);
        }

        protected override void DoUpdate(OtherReceivableSheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
            con.SheetID = info.ID;
            var crs = new CustomerReceivableBLL(AppSettings.Current.ConnStr).GetItems(con).QueryObjects;
            {
                if (crs != null && crs.Count == 1)
                {
                    var cr = crs[0];
                    if (cr.Haspaid > info.Amount)
                    {
                        throw new Exception("请先取消超出核销部分的金额再修改!");
                    }
                    var clone = cr.Clone();
                    clone.Amount = info.Amount;
                    clone.CustomerID = info.CustomerID;
                    ProviderFactory.Create<IProvider<CustomerReceivable, Guid>>(RepoUri).Update(clone, cr, unitWork);
                }
            }
            base.DoUpdate(info, unitWork, dt, opt);
        }

        protected override void UndoApprove(OtherReceivableSheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            base.UndoApprove(info, unitWork, dt, opt);
        }

        protected override void DoNullify(OtherReceivableSheet info, IUnitWork unitWork, DateTime dt, string opt)
        {
            bool allSuccess = true;
            CustomerReceivableSearchCondition con = new CustomerReceivableSearchCondition();
            con.SheetID = info.ID;
            var crs = new CustomerReceivableBLL(AppSettings.Current.ConnStr).GetItems(con).QueryObjects;
            if (crs != null && crs.Count > 0)
            {
                foreach (var cr in crs)
                {
                    var ret = new CustomerReceivableBLL(AppSettings.Current.ConnStr).Delete(cr);
                    if (ret.Result != ResultCode.Successful) allSuccess = false;
                }
            }
            if (!allSuccess) throw new Exception("删除失败");
            base.DoNullify(info, unitWork, dt, opt);
        }
        #endregion
    }
}
