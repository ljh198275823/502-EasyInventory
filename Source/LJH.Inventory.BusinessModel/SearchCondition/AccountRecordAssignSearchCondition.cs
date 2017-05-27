using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class AccountRecordAssignSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public Guid? PaymentID { get; set; }

        public Guid? ReceivableID { get; set; }

    }
}
