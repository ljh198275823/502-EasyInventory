using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.Resource
{
    public class SheetStateDescription
    {
        public static string GetDescription(SheetState state)
        {
            switch (state)
            {
                case SheetState.Add:
                    return "新建";
                case SheetState.Approved:
                    return "已审核";
                case SheetState.Canceled:
                    return "作废";
                case SheetState.Inventory:
                    return "已收货";
                case SheetState.Shipped:
                    return "已发货";
                default:
                    return string.Empty;
            }
        }
    }
}
