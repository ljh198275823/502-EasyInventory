using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory .BusinessModel .SearchCondition ;
using LJH.Inventory .DAL .IProvider ;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class ExpenditureRecordBLL : SheetProcessorBase<ExpenditureRecord>
    {
        #region 构造函数
        public ExpenditureRecordBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 公共方法
        protected override string CreateSheetID(ExpenditureRecord info)
        {
            info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.ExpenditureRecordPrefix,
                    UserSettings.Current.ExpenditureRecordDateFormat, UserSettings.Current.ExpenditureRecordSerialCount, info.DocumentType); //支出单
            return info.ID;
        }
        #endregion
    }
}
