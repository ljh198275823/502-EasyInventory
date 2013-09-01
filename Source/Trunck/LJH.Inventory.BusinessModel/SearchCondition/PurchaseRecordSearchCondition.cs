using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class PurchaseRecordSearchCondition:SearchCondition 
    {
        public string SheetNo { get; set; }

        public string OrderID { get; set; }

        public DateTimeRange DemandDate { get; set; }

        public string SupplierID { get; set; }

        public string Buyer { get; set; }

        public bool? IsComplete { get; set; }
    }
}
