using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class ExpenditureRecordSearchCondition : SheetSearchCondition
    {
        public string Category { get; set; }

        public string AccountID { get; set; }
    }
}
