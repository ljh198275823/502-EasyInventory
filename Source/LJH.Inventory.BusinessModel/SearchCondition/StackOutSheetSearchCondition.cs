using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class StackOutSheetSearchCondition : SheetSearchCondition
    {
        /// <summary>
        /// 获取或设置出货记录查询条件中的客户公司编号
        /// </summary>
        public string CustomerID { get; set; }

        public List<StackOutSheetType> SheetTypes { get; set; }

        public string WareHouseID { get; set; }

        public bool? WithTax { get; set; }

        public string SalesPerson { get; set; }
    }
}
