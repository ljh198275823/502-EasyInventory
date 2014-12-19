using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.BillProject.Model;
using LJH.BillProject.DAL;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.BillProject.BLL
{
    public class PaymentLogBLL : BLLBase<Guid, LJH.BillProject.Model.PaymentLog>
    {
        #region 构造函数
        public PaymentLogBLL(string reporUri)
            : base(reporUri)
        {
        }
        #endregion

        #region 重写基类方法
        public override CommandResult Delete(PaymentLog info)
        {
            PaymentLog original = GetByID(info.ID).QueryObject;
            if (original == null)
            {
                return new CommandResult(ResultCode.Fail, "更新失败，记录被删除");
            }
            original = info.Clone();
            info.Deleted = true;
            return ProviderFactory.Create<IProvider<PaymentLog, Guid>>(_RepoUri).Update(info, original);
        }
        #endregion
    }
}
