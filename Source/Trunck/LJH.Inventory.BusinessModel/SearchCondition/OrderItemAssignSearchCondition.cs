using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class OrderItemAssignSearchCondition:SearchCondition 
    {
        public Guid? OrderItem { get; set; }

        public Guid? InventoryItem { get; set; }
    }
}
