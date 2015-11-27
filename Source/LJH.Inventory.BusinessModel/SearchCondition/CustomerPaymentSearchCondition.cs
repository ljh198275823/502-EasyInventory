using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class CustomerPaymentSearchCondition : SheetSearchCondition
    {
        public string CustomerID { get; set; }

        public string StackSheetID { get; set; }

        public List<CustomerPaymentType> PaymentTypes { get; set; }

        public bool? HasRemain { get; set; }
    }
}
