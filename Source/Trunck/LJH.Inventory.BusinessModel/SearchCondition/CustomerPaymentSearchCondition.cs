using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class CustomerPaymentSearchCondition:SearchCondition
    {
        public string CustomerID { get; set; }

        public string CustomerName { get; set; }

        public DateTimeRange PaidDate { get; set; }

        public bool? HasRemain { get; set; }

        public bool ContainCanceled { get; set; }
    }
}
