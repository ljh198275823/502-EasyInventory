using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public abstract class SheetSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        /// <summary>
        /// 获取或设置单据号
        /// </summary>
        public List<string> SheetNo { get; set; }
        /// <summary>
        /// 获取或设置录单日期
        /// </summary>
        public DateTimeRange LastActiveDate { get; set; }
        /// <summary>
        /// 获取或设置出货记录查询条件中的送货单状态
        /// </summary>
        public List<SheetState> States { get; set; }
    }
}
