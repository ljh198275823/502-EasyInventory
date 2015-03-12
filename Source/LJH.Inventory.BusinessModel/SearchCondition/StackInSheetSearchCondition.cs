using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class StackInSheetSearchCondition : SheetSearchCondition
    {
        /// <summary>
        /// 获取或设置出货记录查询条件中的客户公司名称
        /// </summary>
        public string SupplierID { get; set; }

        public List<StackInSheetType> SheetTypes { get; set; }

        public string WareHouseID { get; set; }

        public bool? WithTax { get; set; }
    }
}
