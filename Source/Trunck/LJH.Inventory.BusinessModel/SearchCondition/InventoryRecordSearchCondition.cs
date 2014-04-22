using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class InventoryRecordSearchCondition : InventorySheetSearchCondition
    {
        /// <summary>
        /// 获取或设置出货记录查询条件中的货品ID
        /// </summary>
        public string ProductID { get; set; }

        public string CategoryID { get; set; }

        public string OrderID { get; set; }

        public Guid? OrderItem { get; set; }

        public string PurchaseID { get; set; }

        public Guid? PurchaseItem { get; set; }
    }
}
