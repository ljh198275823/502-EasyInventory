using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示库存品的出货记录
    /// </summary>
    public class DeliveryRecord
    {
        #region 构造函数
        public DeliveryRecord()
        {
        }
        #endregion

        #region 私有变量
        public long ID { get; set; }
        /// <summary>
        /// 获取或设置客户ID
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// 获取或设置仓库ID
        /// </summary>
        public string WareHouseID { get; set; }

        /// <summary>
        /// 获取或设置送货项的商品ID
        /// </summary>
        public string ProductID { get; set; }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置销售单号
        /// </summary>
        public string SheetNo { get; set; }
        /// <summary>
        /// 获取或设置客户名称
        /// </summary>
        public Customer  Customer { get; set; }
        /// <summary>
        /// 获取或设置仓库名称
        /// </summary>
        public WareHouse  WareHouse { get; set; }
        /// <summary>
        /// 获取或设置订单号
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 获取或设置业务员
        /// </summary>
        public string SalesPerson { get; set; }
        /// <summary>
        /// 获取或设置是否含税
        /// </summary>
        public bool IsWithTax { get; set; }
        /// <summary>
        /// 获取或设置出货时间
        /// </summary>
        public DateTime DeliveryDate { get; set; }
        /// <summary>
        /// 获取或设置送货项的商品名称
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// 获取或设置商品的单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 获取或设置出货数量
        /// </summary>
        public decimal Count { get; set; }
        /// <summary>
        /// 获取货款金额
        /// </summary>
        public decimal Amount
        {
            get { return Price * Count; }
        }
        /// <summary>
        /// 获取或设置成本
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// 获取利润率
        /// </summary>
        public decimal ProfitRate
        {
            get
            {
                return (1 - Cost / Amount);
            }
        }
        #endregion
    }
}
