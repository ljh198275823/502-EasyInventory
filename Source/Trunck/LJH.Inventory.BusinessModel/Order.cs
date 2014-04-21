using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class Order : ISheet<string>
    {
        #region 构造函数
        public Order()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置送货单据编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置创建日期
        /// </summary>
        public DateTime LastActiveDate { get; set; }
        /// <summary>
        /// 获取或设置客户ID
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 获取或设置是否含税
        /// </summary>
        public bool WithTax { get; set; }
        /// <summary>
        /// 获取或设置业务人员
        /// </summary>
        public string SalesPerson { get; set; }
        /// <summary>
        /// 获取或设置下单日期
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// 获取或设置订单要求的发货日期
        /// </summary>
        public DateTime DemandDate { get; set; }
        /// <summary>
        /// 获取或设置当前状态
        /// </summary>
        public SheetState State { get; set; }
        /// <summary>
        /// 获取或设置备注信息
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 获取或设置出货商品项
        /// </summary>
        public List<OrderItem> Items { get; set; }
        #endregion

        #region ISheet 接口
        public bool CanEdit
        {
            get
            {
                return (State == SheetState.Add);
            }
        }

        public bool CanApprove
        {
            get
            {
                return State == SheetState.Add;
            }
        }

        public bool CanCancel
        {
            get
            {
                return State != SheetState.Canceled && State != SheetState.Settled;
            }
        }

        public string DocumentType
        {
            get
            {
                return "Order";
            }
        }
        #endregion

        #region 公共方法
        public ISheet<string> Clone()
        {
            return this.MemberwiseClone() as Order;
        }

        /// <summary>
        /// 计算订单的总金额
        /// </summary>
        public decimal CalAmount()
        {
            decimal amount = 0;
            if (Items != null)
            {
                foreach (OrderItem item in Items)
                {
                    amount += item.Price * item.Count;
                }
            }
            return amount;
        }
        #endregion

        #region 订单的金额情况
        ///// <summary>
        ///// 获取或设置已经应收金额(即已经发货的金额)
        ///// </summary>
        //public decimal Receivable { get; set; }
        ///// <summary>
        ///// 获取或设置已经支付的金额
        ///// </summary>
        //public decimal HasPaid { get; set; }
        ///// <summary>
        ///// 获取或设置销售订单除采购成本外的费用支出
        ///// </summary>
        //public decimal Expenditure { get; set; }

        //public decimal NotPaid
        //{
        //    get
        //    {
        //        return CalAmount() - HasPaid;
        //    }
        //}
        #endregion
    }
}
