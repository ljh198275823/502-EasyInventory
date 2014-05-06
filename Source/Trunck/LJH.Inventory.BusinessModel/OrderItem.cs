using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class OrderItem
    {
        #region 构造函数
        public OrderItem()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置出货项ID
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置出货单ID
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 获取或设置商品ID
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// 获取或设置商品单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 获取或设置商品单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 获取或设置订货数量
        /// </summary>
        public decimal Count { get; set; }
        /// <summary>
        /// 获取或设置货物总金额
        /// </summary>
        public decimal Amount{get;set;}
        /// <summary>
        /// 获取或设置客户要求的出货时间
        /// </summary>
        public DateTime DemandDate { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        public string Memo { get; set; }
        #endregion
    }
}
