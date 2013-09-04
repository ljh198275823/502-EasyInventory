using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class PurchaseOrderSearchCondition : SearchCondition 
    {
        public string PurchaseID { get; set; }

        public string OrderID { get; set; }

        public DateTimeRange OrderDate { get; set; }

        public string SupplierID { get; set; }

        public string Buyer { get; set; }

        public bool? WithTax { get; set; }

        public List<SheetState> States { get; set; }

        public bool? IsComplete { get; set; }
    }
}
