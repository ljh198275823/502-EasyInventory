using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class PurchaseOrderSearchCondition : SheetSearchCondition
    {
        public string SupplierID { get; set; }

        public string Buyer { get; set; }

        public bool? WithTax { get; set; }
    }
}
