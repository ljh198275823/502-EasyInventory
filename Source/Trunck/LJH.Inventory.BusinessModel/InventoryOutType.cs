using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示库存出货方式
    /// </summary>
    public enum InventoryOutType
    {
        /// <summary>
        /// 先进先出
        /// </summary>
        FIFO=0,
        /// <summary>
        /// 先进后出
        /// </summary>
        FILO=1
    }
}
