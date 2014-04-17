using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public abstract class SheetSearchCondition : LJH.GeneralLibrary.DAL.SearchCondition
    {
        /// <summary>
        /// 获取或设置单据号
        /// </summary>
        public string SheetNo { get; set; }
        /// <summary>
        /// 获取或设置录单日期
        /// </summary>
        public DateTimeRange CreateDateTime { get; set; }

        public string WareHouseID { get; set; }

        public string ProductName { get; set; }

        public string ProductID { get; set; }

        public string CategoryID { get; set; }
        /// <summary>
        /// 获取或设置是否已经结清货款
        /// </summary>
        public bool? IsSettled { get; set; }
        /// <summary>
        /// 获取或设置出货记录查询条件中的送货单状态
        /// </summary>
        public List<int> States { get; set; }
        /// <summary>
        /// 获取或设置出货记录查询条件中的送货单备注
        /// </summary>
        public string Memo { get; set; }
    }
}
