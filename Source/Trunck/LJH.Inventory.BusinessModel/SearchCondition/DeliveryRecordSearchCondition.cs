using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class DeliveryRecordSearchCondition:SearchCondition 
    {
        /// <summary>
        /// 获取或设置出货记录查询条件中的货品ID
        /// </summary>
        public string  ProductID { get; set; }

        public string ProductName { get; set; }

        public string CategoryID { get; set; }
        /// <summary>
        /// 获取或设置出货记录查询条件中的出货时间范围
        /// </summary>
        public DateTimeRange  DeliveryDateTime { get; set; }
        /// <summary>
        /// 获取或设置出货记录查询条件中的客户公司名称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 获取或设置出货记录查询条件中的客户公司编号
        /// </summary>
        public string CustomerID { get; set; }

        public string SalesPerson { get; set; }
        /// <summary>
        /// 获取或设置出货记录查询条件中的送货单备注
        /// </summary>
        public string Memo { get; set; }
    }
}
