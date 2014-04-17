using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class ProductInventoryItemSearchCondition : LJH.GeneralLibrary.DAL.SearchCondition 
    {
        public string ProductID { get; set; }

        public string WareHouseID { get; set; }

        public Guid? OrderItem { get; set; }

        public Guid? PurchaseItem { get; set; }

        public Guid? InventoryItem { get; set; }

        public Guid? DeliveryItem { get; set; }

        public bool? UnShipped { get; set; }

        public bool? UnReserved { get; set; }
    }
}
