using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class StackInItem
    {
        #region 公共属性
        /// <summary>
        /// 获取或设置ID
        /// </summary>
        public Guid  ID { get; set; }
        /// <summary>
        /// 获取或设置出货单ID
        /// </summary>
        public string SheetNo { get; set; }
        /// <summary>
        /// 获取或设置采购单项
        /// </summary>
        public Guid? PurchaseItem { get; set; }
        /// <summary>
        /// 获取或设置采购订单编号
        /// </summary>
        public string PurchaseOrder { get; set; }
        /// <summary>
        /// 获取或设置销售订单项
        /// </summary>
        public Guid? OrderItem { get; set; }
        /// <summary>
        /// 获取或设置销售订单编号
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
        /// 获取或设置单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 获取或设置商品数量
        /// </summary>
        public decimal Count { get; set; }
        /// <summary>
        /// 获取或设置货物总金额
        /// </summary>
        public decimal Amount{get;set;}
        /// <summary>
        /// 获取或设置备注信息
        /// </summary>
        public string Memo { get; set; }
        #endregion
    }
}
