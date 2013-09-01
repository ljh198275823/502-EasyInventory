using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class T_OrderItem
    {
        #region 构造函数
        public T_OrderItem()
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
        /// 获取或设置定单项的商品
        /// </summary>
        public Product Product { get; set; }
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
        /// 获取或设置已备货数量
        /// </summary>
        public decimal Inventory { get; set; }
        /// <summary>
        /// 获取或设置采购在途数量（已下采购单但还未到货)
        /// </summary>
        public decimal OnPurchased { get; set; }
        /// <summary>
        /// 获取或设置已出货数量
        /// </summary>
        public decimal Shipped { get; set; }
        /// <summary>
        /// 获取或设置客户要求的出货时间
        /// </summary>
        public DateTime DemandDate { get; set; }
        /// <summary>
        /// 获取或设置订单项是否已经全部出货，也可以表示人工完结未出完货的情况
        /// </summary>
        public bool IsComplete { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        public string Memo { get; set; }
        #endregion

        #region 只读属性
        /// <summary>
        /// 获取货物总金额(不含税)
        /// </summary>
        public decimal Amount
        {
            get
            {
                return Price * Count;
            }
        }
        #endregion
    }
}
