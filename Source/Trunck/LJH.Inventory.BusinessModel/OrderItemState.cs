using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示订单项的当前状态
    /// </summary>
    public class OrderItemState
    {
        #region 构造函数
        public OrderItemState()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置订单项的id
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置订单号
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 获取或设置总的订货数量
        /// </summary>
        public decimal Count { get; set; }
        /// <summary>
        /// 获取或设置下单采购总数量，包括这些采购单已经到货的数量和在途的数量
        /// </summary>
        public decimal Purchased { get; set; }
        /// <summary>
        /// 获取或设置采购到货数量
        /// </summary>
        public decimal Received { get; set; }
        /// <summary>
        /// 获取或设置在库数量(即仓库中当前此订单项的备货数量，不包括已经出货的数量)
        /// </summary>
        public decimal Inventory { get; set; }
        /// <summary>
        /// 获取或设置已出货数量
        /// </summary>
        public decimal Shipped { get; set; }
        /// <summary>
        /// 获取或设置订单项是否已经全部出货，也可以表示人工完结未出完货的情况
        /// </summary>
        public bool IsComplete { get; set; }
        #endregion

        #region 只读属性
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
        /// 获取还需采购的数量
        /// </summary>
        public decimal NotPurchased
        {
            get
            {
                decimal ret = Count - OnWay - Inventory;
                return ret > 0 ? ret : 0;
            }
        }
        /// <summary>
        /// 获取未发货数量
        /// </summary>
        public decimal NotShipped
        {
            get
            {
                if (IsComplete) return 0;
                return Count - Shipped >= 0 ? (Count - Shipped) : 0;
            }
        }
        #endregion
    }
}
