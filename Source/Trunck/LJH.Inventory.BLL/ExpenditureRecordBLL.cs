using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory .BusinessModel .SearchCondition ;
using LJH.Inventory .DAL .IProvider ;

namespace LJH.Inventory.BLL
{
    public class ExpenditureRecordBLL
    {
        #region 构造函数
        public ExpenditureRecordBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        public QueryResult<ExpenditureRecord> GetByID(string id)
        {
            return ProviderFactory.Create<IExpenditureRecordProvider>(_RepoUri).GetByID(id);
        }

        public QueryResultList<ExpenditureRecord> GetItems(SearchCondition con)
        {
            return ProviderFactory.Create<IExpenditureRecordProvider>(_RepoUri).GetItems(con);
        }

        public CommandResult Add(ExpenditureRecord info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(UserSettings.Current.ExpenditureRecordPrefix,
                    UserSettings.Current.ExpenditureRecordDateFormat,UserSettings.Current.ExpenditureRecordSerialCount, "expenditure"); //支出单
                if (string.IsNullOrEmpty(info.ID)) return new CommandResult(ResultCode.Fail, "创建单号失败，请重试");
            }
            return ProviderFactory.Create<IExpenditureRecordProvider>(_RepoUri).Insert(info);
        }

        public CommandResult Update(ExpenditureRecord info)
        {
            ExpenditureRecord original = ProviderFactory.Create<IExpenditureRecordProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original != null)
            {
                return ProviderFactory.Create<IExpenditureRecordProvider>(_RepoUri).Update(info, original);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "系统中不存在此对象");
            }
        }

        public CommandResult Cancel(ExpenditureRecord info, string opt)
        {
            ExpenditureRecord original = ProviderFactory.Create<IExpenditureRecordProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original == null) return new CommandResult(ResultCode.Fail, "系统中不存在此对象");
            if (original.CancelDate != null) return new CommandResult(ResultCode.Fail, "已经取消的项不能再取消");

            info.CancelDate = DateTime.Now;
            info.CancelOperator = opt;
            return ProviderFactory.Create<IExpenditureRecordProvider>(_RepoUri).Update(info, original);
        }
        #endregion
    }
}
