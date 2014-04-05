using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class OrderRecord
    {
        #region 构造函数
        public OrderRecord()
        {
        }
        #endregion

        #region 公共属性
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置采购项相关的销售订单
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 获取或设置供应商ID
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 获取或设置客户名称
        /// </summary>
        public CompanyInfo Customer { get; set; }
        /// <summary>
        /// 获取或设置商品ID
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// 获取或设置定商品名称
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
        /// 获取或设置已采购数量
        /// </summary>
        public decimal Purchased { get; set; }
        /// <summary>
        /// 获取或设置采购到货数量
        /// </summary>
        public decimal Received { get; set; }
        /// <summary>
        /// 获取或设置订单项的库存数量
        /// </summary>
        public decimal Inventory { get; set; }
        /// <summary>
        /// 获取或设置已出货数量
        /// </summary>
        public decimal Shipped { get; set; }
        /// <summary>
        /// 获取或设置订单要求的发货日期
        /// </summary>
        public DateTime DemandDate { get; set; }
        /// <summary>
        /// 获取或设置业务员
        /// </summary>
        public string SalesPerson { get; set; }
        /// <summary>
        /// 获取或设置订单当前状态
        /// </summary>
        public SheetState State { get; set; }
        /// <summary>
        /// 获取或设置订单项是否已经全部出货，也可以表示人工完结未出完货的情况
        /// </summary>
        public bool IsComplete { get; set; }
        /// <summary>
        /// 获取或设置备注信息
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
                decimal ret = NotShipped - OnWay - Inventory;
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
        #endregion
    }
}

