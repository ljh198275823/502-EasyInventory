﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示库存品的出货记录
    /// </summary>
    public class InventoryRecord
    {
        #region 构造函数
        public InventoryRecord()
        {
        }
        #endregion

        #region 公共属性
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置销售单号
        /// </summary>
        public string SheetNo { get; set; }
        /// <summary>
        /// 获取或设置订单项ID
        /// </summary>
        public Guid? OrderItem { get; set; }
        /// <summary>
        /// 获取或设置订单号
        /// </summary>
        public string OrderID { get; set; }

        public Guid? PurchaseItem { get; set; }

        public string PurchaseID { get; set; }
        /// <summary>
        /// 获取或设置客户ID
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 获取或设置客户名称
        /// </summary>
        public Supplier Supplier { get; set; }
        /// <summary>
        /// 获取或设置仓库ID
        /// </summary>
        public string WareHouseID { get; set; }
        /// <summary>
        /// 获取或设置仓库名称
        /// </summary>
        public WareHouse WareHouse { get; set; }
        /// <summary>
        /// 获取或设置送货项的商品ID
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// 获取或设置送货项的商品名称
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// 获取或设置商品单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 获取或设置商品的单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 获取或设置出货数量
        /// </summary>
        public decimal Count { get; set; }
        /// <summary>
        /// 获取或设置出货时间
        /// </summary>
        public DateTime InventoryDate { get; set; }
        /// <summary>
        /// 获取货款金额
        /// </summary>
        public decimal Amount
        {
            get { return Price * Count; }
        }
        #endregion
    }
}
