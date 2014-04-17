using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class ExpenditureRecordSearchCondition : LJH.GeneralLibrary.DAL.SearchCondition
    {
        public DateTimeRange PaidDate { get; set; }
        public string Category { get; set; }
        public string Memo { get; set; }
    }
}
