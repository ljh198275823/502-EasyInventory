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
                case SheetOperation.Create:
                    return "新建";
                case SheetOperation.Modify:
                    return "修改";
                case SheetOperation.Approve:
                    return "审核";
                case SheetOperation.UndoApprove:
                    return "取消审核";
                case SheetOperation.Nullify:
                    return "作废";
                case SheetOperation.Inventory:
                    return "收货";
                case SheetOperation.Ship:
                    return "发货";
                default:
                    return string.Empty;
            }
        }
    }
}
