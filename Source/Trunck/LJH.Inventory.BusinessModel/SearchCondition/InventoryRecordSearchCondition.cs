using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class InventoryRecordSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        /// <summary>
        /// 获取或设置出货记录查询条件中的货品ID
        /// </summary>
        public string ProductID { get; set; }

        public string CategoryID { get; set; }
        /// <summary>
        /// 获取或设置出货记录查询条件中的出货时间范围
        /// </summary>
        public DateTimeRange InventoryDateTime { get; set; }
        /// <summary>
        /// 获取或设置出货记录查询条件中的客户公司编号
        /// </summary>
        public string SupplierID { get; set; }

        public string OrderID { get; set; }

        public Guid? PurchaseItem { get; set; }

    }
}
