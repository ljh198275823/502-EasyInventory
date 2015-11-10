using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示加工类型
    /// </summary>
    public enum SliceType
    {
        /// <summary>
        /// 板材
        /// </summary>
        Panel = 0,
        /// <summary>
        /// 卷材
        /// </summary>
        Roll = 1,
        /// <summary>
        /// 开吨
        /// </summary>
        ByWeight = 2
    }
}
