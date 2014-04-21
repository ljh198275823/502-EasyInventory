using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class ExpenditureRecordSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public DateTimeRange PaidDate { get; set; }
        public string Category { get; set; }
        public string Memo { get; set; }
    }
}
