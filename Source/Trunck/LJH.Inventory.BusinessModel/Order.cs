using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class Order
    {
        public static readonly string DocumentType = "Order";

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
        /// 获取或设置客户ID
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 获取或设置客户名称
        /// </summary>
        public Customer Customer { get; set; }
        /// <summary>
        /// 获取或设置最终客户ID
        /// </summary>
        public string FinalCustomerID { get; set; }
        /// <summary>
        /// 获取或设置最终客户
        /// </summary>
        public Customer FinalCustomer { get; set; }
        /// <summary>
        /// 获取或设置是否含税
        /// </summary>
        public bool WithTax { get; set; }
        /// <summary>
        /// 获取或设置币别
        /// </summary>
        public string CurrencyType { get; set; }
        /// <summary>
        /// 获取或设置货币符号
        /// </summary>
        public string Symbol { get; set; }
        /// <summary>
        /// 获取或设置合同签订时的汇率
        /// </summary>
        public decimal ExchangeRate { get; set; }
        /// <summary>
        /// 获取或设置价格条款
        /// </summary>
        public string PriceTerm { get; set; }
        /// <summary>
        /// 获取或设置收汇方式
        /// </summary>
        public string CollectionType { get; set; }
        /// <summary>
        /// 获取或设置运输方式
        /// </summary>
        public string Transport { get; set; }
        /// <summary>
        /// 获取或设置装运港
        /// </summary>
        public string LoadPort { get; set; }
        /// <summary>
        /// 获取或设置目的港
        /// </summary>
        public string DestinationPort { get; set; }
        /// <summary>
        /// 获取或设置是否可分批
        /// </summary>
        public bool CanBatch { get; set; }
        /// <summary>
        /// 获取或设置是否可中转
        /// </summary>
        public bool CanRelay { get; set; }
        /// <summary>
        /// 获取或设置唛头
        /// </summary>
        public string Mark { get; set; }
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
        /// 获取或设置已经应收金额(即已经发货的金额)
        /// </summary>
        public decimal Receivable { get; set; }
        /// <summary>
        /// 获取或设置已经支付的金额
        /// </summary>
        public decimal HasPaid { get; set; }
        /// <summary>
        /// 获取或设置销售订单除采购成本外的费用支出
        /// </summary>
        public decimal Expenditure { get; set; }
        /// <summary>
        /// 获取或设置备注信息
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 获取或设置出货商品项
        /// </summary>
        public List<OrderItem> Items { get; set; }
        #endregion

        #region 只读属性
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

        /// <summary>
        /// 获取订单是否已经全部出货
        /// </summary>
        public bool IsCompleteAll
        {
            get
            {
                if (State == SheetState.Closed || State == SheetState.Canceled) return true;
                if (Items != null)
                {
                    return !Items.Exists(item => !item.IsComplete && item.NotShipped > 0);
                }
                return true;
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
                if (Items != null)
                {
                    return Items.Exists(item => !item.IsComplete && item.DemandDate < DateTime.Today);
                }
                return false;
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
                if (Items != null)
                {
                    return Items.Exists(item => !item.IsComplete && item.DemandDate.Date == DateTime.Today);
                }
                return false;
            }
        }

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

        public decimal NotPaid
        {
            get
            {
                return CalAmount() - HasPaid;
            }
        }
        #endregion

        #region 公共方法
        public Order Clone()
        {
            return this.MemberwiseClone() as Order;
        }
        #endregion
    }
}
