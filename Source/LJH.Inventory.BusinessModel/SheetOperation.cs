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
        Create=0,
        /// <summary>
        /// 修改
        /// </summary>
        Modify=1,
        /// <summary>
        /// 审批
        /// </summary>
        Approve=2,
        /// <summary>
        /// 发货
        /// </summary>
        StackOut=3,
        /// <summary>
        /// 入库
        /// </summary>
        StackIn=4,
        /// <summary>
        /// 作废
        /// </summary>
        Nullify=5,
        /// <summary>
        /// 取消审核
        /// </summary>
        UndoApprove=6,
    }
}
