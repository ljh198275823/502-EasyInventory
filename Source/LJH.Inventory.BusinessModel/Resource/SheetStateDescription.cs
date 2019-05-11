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
                case SheetState.新增:
                    return "新建";
                case SheetState.已审核:
                    return "已审核";
                case SheetState.作废:
                    return "作废";
                case SheetState.已入库:
                    return "已收货";
                case SheetState.已发货:
                    return "已发货";
                default:
                    return string.Empty;
            }
        }
    }
}
