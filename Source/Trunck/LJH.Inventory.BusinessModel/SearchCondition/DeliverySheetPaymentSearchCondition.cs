using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class DeliverySheetPaymentSearchCondition : LJH.GeneralLibrary.DAL.SearchCondition
    {
        public Guid? CustomerPaymentID { get; set; }

        public string SheetNo { get; set; }
    }
}
