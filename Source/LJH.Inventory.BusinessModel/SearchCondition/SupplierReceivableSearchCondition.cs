using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class SupplierReceivableSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public string SupplierID { get; set; }

        public DateTimeRange CreateDate { get; set; }

        public string PurchaseID { get; set; }

        public string InventorySheet { get; set; }
    }
}