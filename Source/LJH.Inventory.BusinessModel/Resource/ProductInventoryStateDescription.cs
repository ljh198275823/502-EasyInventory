using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.Resource
{
    public class ProductInventoryStateDescription
    {
        public static string GetDescription(ProductInventoryState state)
        {
            switch (state)
            {
                case ProductInventoryState.Inventory:
                    return "在库";
                case ProductInventoryState.Nullified:
                    return "作废";
                case ProductInventoryState.Reserved:
                    return "预定";
                case ProductInventoryState.Shipped:
                    return "已出货";
                case ProductInventoryState.WaitShip:
                    return "待出货";
                default:
                    return "未知";
            }
        }
    }
}
