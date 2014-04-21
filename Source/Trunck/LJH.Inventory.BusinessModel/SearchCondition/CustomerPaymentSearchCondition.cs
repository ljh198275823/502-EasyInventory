using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class CustomerPaymentSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public string CustomerID { get; set; }

        public DateTimeRange PaidDate { get; set; }

        public bool? HasRemain { get; set; }

        public bool ContainCanceled { get; set; }


    }
}
