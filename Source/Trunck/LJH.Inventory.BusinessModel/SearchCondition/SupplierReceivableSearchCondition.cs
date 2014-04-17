using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class SupplierReceivableSearchCondition : LJH.GeneralLibrary.DAL.SearchCondition
    {
        public string SupplierID { get; set; }

        public DateTimeRange CreateDate { get; set; }

        public string PurchaseID { get; set; }

        public string InventorySheet { get; set; }
    }
}