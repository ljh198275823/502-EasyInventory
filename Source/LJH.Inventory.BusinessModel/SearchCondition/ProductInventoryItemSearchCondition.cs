using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class ProductInventoryItemSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public List<string> Products { get; set; }

        public string WareHouseID { get; set; }

        public Guid? OrderItem { get; set; }

        public string OrderID { get; set; }

        public Guid? PurchaseItem { get; set; }

        public string PurchaseID { get; set; }

        public Guid? InventoryItem { get; set; }

        public string InventorySheetNo { get; set; }

        public Guid? DeliveryItem { get; set; }

        public string DeliverySheetNo { get; set; }

        public bool? UnShipped { get; set; }

        public bool? UnReserved { get; set; }

        public string Model { get; set; }
    }
}
