using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class T_OrderItem
    {
        #region 构造函数
        public T_OrderItem()
        {
        }

        public T_OrderItem(OrderItem oi)
        {
            this.ID = oi.ID;
            this.OrderID = oi.OrderID;
            this.ProductID = oi.ProductID;
            this.ProductCode = oi.ProductCode;
            this.Unit = oi.Unit;
            this.Price = oi.Price;
            this.Count = oi.Count;
            this.DemandDate = oi.DemandDate;
            this.IsComplete = oi.IsComplete;
            this.Memo = oi.Memo;
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
    }
}
