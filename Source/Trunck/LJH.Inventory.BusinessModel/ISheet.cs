using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示各种单据的一个接口
    /// </summary>
    public interface ISheet
    {
        /// <summary>
        /// 获取单据是否可以修改
        /// </summary>
        bool CanEdit { get; }
        /// <summary>
        /// 获取单据是否可以审批
        /// </summary>
        bool CanApprove { get; }
        /// <summary>
        /// 获取单据是否可以作废
        /// </summary>
        bool CanCancel { get; }
        /// <summary>
        /// 获取单据类别
        /// </summary>
        string DocumentType { get; }
    }
}
