using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class DeliverySheetSearchCondition : SheetSearchCondition
    {
        /// <summary>
        /// 获取或设置出货记录查询条件中的客户公司编号
        /// </summary>
        public string CustomerID { get; set; }

        public string WareHouseID { get; set; }

        public bool? WithTax { get; set; }
    }
}
