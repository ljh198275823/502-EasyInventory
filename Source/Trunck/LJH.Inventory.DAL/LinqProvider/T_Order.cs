using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class T_Order
    {
        #region 构造函数
        public T_Order()
        {
        }

        public T_Order(Order order)
        {
            this.ID = order.ID;
            this.CustomerID = order.CustomerID;
            this.FinalCustomerID = order.FinalCustomerID;
            this.OrderDate = order.OrderDate;
            this.DemandDate = order.DemandDate;
            this.CurrencyType = order.CurrencyType;
            this.Symbol = order.Symbol;
            this.ExchangeRate = order.ExchangeRate;
            this.CollectionType = order.CollectionType;
            this.PriceTerm = order.PriceTerm;
            this.Transport = order.Transport;
            this.LoadPort = order.LoadPort;
            this.DestinationPort = order.DestinationPort;
            this.SalesPerson = order.SalesPerson;
            this.WithTax = order.WithTax;
            this.CanBatch = order.CanBatch;
            this.CanRelay = order.CanRelay;
            this.Mark = order.Mark;
            this.State = order.State;
            this.Memo = order.Memo;
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
        /// 获取或设置最终客户ID
        /// </summary>
        public string FinalCustomerID { get; set; }
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
        /// 获取或设置备注信息
        /// </summary>
        public string Memo { get; set; }
        #endregion
    }
}
