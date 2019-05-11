using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.Resource
{
    public class SheetOperationDescription
    {
        public static string GetDescription(SheetOperation state)
        {
            switch (state)
            {
                case SheetOperation.新建:
                    return "新建";
                case SheetOperation.修改:
                    return "修改";
                case SheetOperation.审核:
                    return "审核";
                case SheetOperation.取消审核:
                    return "取消审核";
                case SheetOperation.作废:
                    return "作废";
                case SheetOperation.入库:
                    return "收货";
                case SheetOperation.出库:
                    return "发货";
                default:
                    return string.Empty;
            }
        }
    }
}
