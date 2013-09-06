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
        /// 获取或设置定单项的商品
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// 获取或设置产品代码
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// 获取或设置商品单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 获取或设置商品单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 获取或设置最终客户价格
        /// </summary>
        public decimal FinalCustomerPrice { get; set; }
        /// <summary>
        /// 获取或设置订货数量
        /// </summary>
        public decimal Count { get; set; }
        /// <summary>
        /// 获取或设置已采购数量
        /// </summary>
        public decimal Purchased { get; set; }
        /// <summary>
        /// 获取或设置采购到货数量
        /// </summary>
        public decimal Received { get; set; }
        /// <summary>
        /// 获取或设置订单项的库存数量(包括已经出货的数量)
        /// </summary>
        public decimal TotalInventory { get; set; }
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
        /// 获取货物总金额
        /// </summary>
        public decimal Amount
        {
            get
            {
                return Price * Count;
            }
        }
        /// <summary>
        /// 获取还需采购的数量
        /// </summary>
        public decimal NotPurchased
        {
            get
            {
                decimal ret = Count - OnWay - TotalInventory;
                return ret > 0 ? ret : 0;
            }
        }
        /// <summary>
        /// 获取采购在途数量
        /// </summary>
        public decimal OnWay
        {
            get
            {
                return Purchased - Received;
            }
        }
        /// <summary>
        /// 获取未发货数量
        /// </summary>
        public decimal NotShipped
        {
            get
            {
                return Count - Shipped >= 0 ? (Count - Shipped) : 0;
            }
        }
        /// <summary>
        /// 获取当前还剩的库存，总共库存-已发货数量
        /// </summary>
        public decimal Inventory
        {
            get
            {
                return TotalInventory - Shipped;
            }
        }
        #endregion
    }
}
