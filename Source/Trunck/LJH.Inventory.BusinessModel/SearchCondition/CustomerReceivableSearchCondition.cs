using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class CustomerReceivableSearchCondition:SearchCondition 
    {
        public string CustomerID { get; set; }

        public string CustomerName { get; set; }

        public DateTimeRange CreateDate { get; set; }

        public bool? IsSettled { get; set; }

        public string Memo { get; set; }
    }
}
