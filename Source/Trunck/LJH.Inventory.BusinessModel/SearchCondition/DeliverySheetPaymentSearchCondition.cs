using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class DeliverySheetPaymentSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public Guid? CustomerPaymentID { get; set; }

        public string SheetNo { get; set; }
    }
}
