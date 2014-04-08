using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class PurchaseItemState
    {
        #region 构造函数
        public PurchaseItemState()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置出货项ID
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置采购单号
        /// </summary>
        public string PurchaseID { get; set; }
        /// <summary>
        /// 获取或设置商品数量
        /// </summary>
        public decimal Count { get; set; }
        /// <summary>
        /// 获取或设置采购到货数量
        /// </summary>
        public decimal Received { get; set; }
        /// <summary>
        /// 获取或设置订单项是否已经全部出货，也可以表示人工完结未出完货的情况
        /// </summary>
        public bool IsComplete { get; set; }
        #endregion

        #region 只读属性
        /// <summary>
        /// 获取采购项的在途数量
        /// </summary>
        public decimal OnWay
        {
            get
            {
                return Count - Received > 0 ? (Count - Received) : 0;
            }
        }
        #endregion
    }
}
