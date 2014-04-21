using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class DeliveryRecordSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        /// <summary>
        /// 获取或设置出货记录查询条件中的货品ID
        /// </summary>
        public string ProductID { get; set; }

        public string CategoryID { get; set; }
        /// <summary>
        /// 获取或设置出货记录查询条件中的出货时间范围
        /// </summary>
        public DateTimeRange DeliveryDateTime { get; set; }
        /// <summary>
        /// 获取或设置出货记录查询条件中的客户公司编号
        /// </summary>
        public string CustomerID { get; set; }

        public string OrderID { get; set; }

        public Guid? OrderItem { get; set; }
    }
}
