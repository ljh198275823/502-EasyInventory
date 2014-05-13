using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.Resource
{
    public class StackOutSheetTypeDescription
    {
        public static string GetDescription(StackOutSheetType sheetType)
        {
            switch (sheetType)
            {
                case StackOutSheetType.DeliverySheet:
                    return "送货单";
                case StackOutSheetType.CustomerBorrow:
                    return "客户借用单";
                case StackOutSheetType.Production:
                    return "生产领用单";
                default:
                    return string.Empty;
            }
        }
    }
}
