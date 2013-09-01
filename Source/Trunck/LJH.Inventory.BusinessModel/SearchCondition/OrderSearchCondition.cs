using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class OrderSearchCondition:SearchCondition 
    {
        public DateTimeRange OrderDate { get; set; }

        public string CustomerID { get; set; }

        public string Sales { get; set; }

        public bool? WithTax { get; set; }

        public List<SheetState> States { get; set; }
    }
}
