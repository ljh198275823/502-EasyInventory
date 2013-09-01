using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public  class CustomerPaymentAssignSearchCondition:SearchCondition 
    {
        public string PaymentID { get; set; }

        public string ReceivableID { get; set; }
    }
}
