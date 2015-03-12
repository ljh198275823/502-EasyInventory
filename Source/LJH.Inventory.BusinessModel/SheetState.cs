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
        //后续增加新属性时最好不要改变这些值，因为数据库中很多视图以当前值表示单据的状态为取消
        /// <summary>
        /// 新增
        /// </summary>
        Add = 0,
        /// <summary>
        /// 已审批
        /// </summary>
        Approved = 1,
        /// <summary>
        /// 已发货
        /// </summary>
        Shipped = 2,
        /// <summary>
        /// 收货
        /// </summary>
        Inventory = 3,
        /// <summary>
        /// 取消
        /// </summary>
        Canceled = 4,
    }
}
