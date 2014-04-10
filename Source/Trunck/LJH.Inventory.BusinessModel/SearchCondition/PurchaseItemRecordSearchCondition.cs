using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class PurchaseItemRecordSearchCondition : PurchaseOrderSearchCondition
    {
        public bool? HasOnway { get; set; }

        public string ProductID { get; set; }
    }
}
