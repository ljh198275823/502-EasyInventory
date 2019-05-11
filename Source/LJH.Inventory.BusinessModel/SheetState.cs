using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示单据的状态
    /// </summary>
    public enum SheetState
    {
        新增 = 0,
        已审核 = 1,
        已发货 = 2,
        已入库 = 3,
        作废 = 4,
    }
}
