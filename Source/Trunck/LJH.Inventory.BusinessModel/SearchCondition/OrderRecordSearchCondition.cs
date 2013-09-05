using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class OrderRecordSearchCondition : OrderSearchCondition
    {
        /// <summary>
        /// 获取或设置是否还需要采购
        /// </summary>
        public bool? HasToPurchase { get; set; }
        /// <summary>
        /// 获取或设置是否还需要出货
        /// </summary>
        public bool? HasToDelivery { get; set; }
    }
}
