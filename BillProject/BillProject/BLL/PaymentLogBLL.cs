using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
