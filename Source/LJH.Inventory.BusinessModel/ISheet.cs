using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示各种单据的一个接口
    /// </summary>
    public interface ISheet<TID> : LJH.GeneralLibrary.Core.DAL.IEntity<TID>
    {
        /// <summary>
        /// 获取单据类别
        /// </summary>
        string DocumentType { get; }
        /// <summary>
        /// 获取或设置单据日期
        /// </summary>
        DateTime SheetDate { get; set; }
        /// <summary>
        /// 获取或设置上次活动时间
        /// </summary>
        DateTime LastActiveDate { get; set; }
        /// <summary>
        /// 获取或设置当前状态
        /// </summary>
        SheetState State { get; set; }
        /// <summary>
        /// 检测单据是否可以进行某个操作
        /// </summary>
        bool CanDo(SheetOperation operation);
        /// <summary>
        /// 克隆一个自身复本
        /// </summary>
        /// <returns></returns>
        ISheet<TID> Clone();
    }
}
