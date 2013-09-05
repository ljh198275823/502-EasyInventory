using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class PurchaseRecordSearchCondition : PurchaseOrderSearchCondition
    {
        public bool? IsComplete { get; set; }
    }
}
