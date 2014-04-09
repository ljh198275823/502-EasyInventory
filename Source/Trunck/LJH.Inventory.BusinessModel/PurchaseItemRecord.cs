using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class PurchaseItemRecord
    {
        #region 构造函数
        public PurchaseItemRecord()
        {
        }
        #endregion

        #region 公共属性
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置下单日期
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// 获取或设置采购单编号
        /// </summary>
        public string PurchaseID { get; set; }
        /// <summary>
        /// 获取或设置采购项相关的销售订单
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 获取或设置采购项相关的销售订单项
        /// </summary>
        public Guid? OrderItem { get; set; }
        /// <summary>
        /// 获取或设置供应商ID
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 获取或设置客户名称
        /// </summary>
        public CompanyInfo Supplier { get; set; }
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
        /// 获取或设置采购到货数量
        /// </summary>
        public decimal Received { get; set; }
        /// <summary>
        /// 获取或设置订单要求的发货日期
        /// </summary>
        public DateTime DemandDate { get; set; }
        /// <summary>
        /// 获取或设置业务员
        /// </summary>
        public string Buyer { get; set; }
        /// <summary>
        /// 获取或设置订单当前状态
        /// </summary>
        public SheetState State { get; set; }
        /// <summary>
        /// 获取或设置是否人工结束引项
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
        /// 获取未到货数量
        /// </summary>
        public decimal OnWay
        {
            get
            {
                decimal ret = Count - Received;
                return ret > 0 ? ret : 0;
            }
        }
        #endregion
    }
}

