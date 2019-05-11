using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示单据处理方法的枚举
    /// </summary>
    public enum SheetOperation
    {
        /// <summary>
        /// 新建
        /// </summary>
        新建=0,
        /// <summary>
        /// 修改
        /// </summary>
        修改=1,
        /// <summary>
        /// 审批
        /// </summary>
        审核=2,
        /// <summary>
        /// 发货
        /// </summary>
        出库=3,
        /// <summary>
        /// 入库
        /// </summary>
        入库=4,
        /// <summary>
        /// 作废
        /// </summary>
        作废=5,
        /// <summary>
        /// 取消审核
        /// </summary>
        取消审核=6,
    }
}
