using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class ProductInventoryItemSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public List<Guid> IDS { get; set; }

        public DateTimeRange AddDateRange { get; set; }

        public List<string> Products { get; set; }

        public string Model { get; set; }

        public List<string> Models { get; set; }

        public string ProductID { get; set; }

        public string WareHouseID { get; set; }

        public List<ProductInventoryState> States { get; set; }

        public bool HasRemain { get; set; }

        public bool? HasWeight { get; set; }

        public bool? Sliced { get; set; }

        public Guid? OrderItem { get; set; }

        public string OrderID { get; set; }

        public Guid? PurchaseItem { get; set; }

        public string PurchaseID { get; set; }

        public Guid? InventoryItem { get; set; }

        public string InventorySheetNo { get; set; }

        public Guid? DeliveryItem { get; set; }

        public string DeliverySheetNo { get; set; }

        public Guid? SourceRoll { get; set; }

        public Guid? SourceID { get; set; }

        public Guid? CostID { get; set; }

        public decimal? OriginalWeight { get; set; }
    }
}
