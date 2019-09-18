using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class AccountRecordSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public DateTimeRange CreateDate { get; set; }

        public string SheetID { get; set; }

        public string CustomerID { get; set; }

        public string AccountID { get; set; }

        public string StackSheetID { get; set; }

        public List<CustomerPaymentType> PaymentTypes { get; set; }

        public bool? HasRemain { get; set; }
    }
}
