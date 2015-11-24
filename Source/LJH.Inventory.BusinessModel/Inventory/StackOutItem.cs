using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示出库单项
    /// </summary>
    public class StackOutItem
    {
        #region 构造函数
        public StackOutItem()
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
        public string SheetNo { get; set; }
        /// <summary>
        /// 获取或设置订单项ID
        /// </summary>
        public Guid? OrderItem { get; set; }
        /// <summary>
        /// 获取或设置订单编号
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 获取或设置商品ID
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// 获取或设置单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 获取或设置重量
        /// </summary>
        public decimal? Weight { get; set; }
        /// <summary>
        /// 获取或设置长度
        /// </summary>
        public decimal? Length { get; set; }
        /// <summary>
        /// 获取或设置单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 获取或设置商品数量
        /// </summary>
        public decimal Count { get; set; }
        /// <summary>
        /// 获取或设置库存项, 用于直接指定某件库存出货
        /// </summary>
        public Guid? InventoryItem { get; set; }
        /// <summary>
        /// 获取或设置备注信息
        /// </summary>
        public string Memo { get; set; }
        #endregion

        public decimal Amount
        {
            get
            {
                return Weight.HasValue ? Weight.Value * Price * Count : Count * Price;  //如果有重量,即单价为重量计价
            }
        }
    }
}
