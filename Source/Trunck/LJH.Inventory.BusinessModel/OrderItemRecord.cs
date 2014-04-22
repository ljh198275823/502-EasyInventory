using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class OrderItemRecord : LJH.GeneralLibrary.Core.DAL.IEntity<Guid>
    {
        #region 构造函数
        public OrderItemRecord()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置出货项ID
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置上次活动时间
        /// </summary>
        public DateTime LastActiveDate { get; set; }
        /// <summary>
        /// 获取或设置订单编号
        /// </summary>
        public string SheetNo { get; set; }
        /// <summary>
        /// 获取或设置下单日期
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// 获取或设置客户id
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 获取或设置客户
        /// </summary>
        public CompanyInfo Customer { get; set; }
        /// <summary>
        /// 获取或设置商品ID
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// 获取或设置定单项的商品
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
        /// 获取或设置是否含税
        /// </summary>
        public bool WithTax { get; set; }
        /// <summary>
        /// 获取或设置客户要求的出货时间
        /// </summary>
        public DateTime DemandDate { get; set; }
        /// <summary>
        /// 获取或设置订单项是否已经全部出货，也可以表示人工完结未出完货的情况
        /// </summary>
        public bool IsComplete { get; set; }
        /// <summary>
        /// 获取或设置订货数量
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
        /// 获取或设置业务员
        /// </summary>
        public string SalesPerson { get; set; }
        /// <summary>
        /// 获取或设置订单状态
        /// </summary>
        public SheetState State { get; set; }
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
        /// 获取采购在途数量
        /// </summary>
        public decimal OnWay
        {
            get
            {
                decimal ret = Purchased - Received;
                return ret > 0 ? ret : 0;
            }
        }
        /// <summary>
        /// 获取还需采购的数量
        /// </summary>
        public decimal NotPurchased
        {
            get
            {
                if (IsComplete) return 0;
                decimal ret = NotShipped - OnWay - Inventory;
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

        /// <summary>
        /// 获取订单是否有已过出货日期未交货的项
        /// </summary>
        public bool IsOverDate
        {
            get
            {
                if (State == SheetState.Closed || State == SheetState.Canceled) return false;
                return !IsComplete && DemandDate < DateTime.Today;
            }
        }
        /// <summary>
        /// 获取订单是否有紧急出货的项,如果系统有提前多少天提醒出货的选项，则超过提醒日期的订单都是紧急订单
        /// 否则当天订单为紧急订单
        /// </summary>
        public bool IsEmergency
        {
            get
            {
                if (State == SheetState.Closed || State == SheetState.Canceled) return false;
                return !IsComplete && DemandDate.Date == DateTime.Today;
            }
        }
        #endregion
    }
}
