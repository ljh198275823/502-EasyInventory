using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class PurchaseOrderSearchCondition : SearchCondition 
    {
        public string OrderID { get; set; }

        public DateTimeRange OrderDate { get; set; }

        public string SupplerID { get; set; }

        public string Buyer { get; set; }

        public bool? WithTax { get; set; }

        public List<SheetState> States { get; set; }
    }
}
