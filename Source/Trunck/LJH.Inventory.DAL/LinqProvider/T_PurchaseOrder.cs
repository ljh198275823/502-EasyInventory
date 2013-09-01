using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.DAL.LinqProvider
{
    public class T_PurchaseOrder
    {
        #region 构造函数
        public T_PurchaseOrder()
        {
        }

        public T_PurchaseOrder(PurchaseOrder purchase)
        {
            this.ID = purchase.ID;
            this.SupplierID = purchase.SupplierID;
            this.OrderDate = purchase.OrderDate;
            this.DemandDate = purchase.DemandDate;
            this.CurrencyType = purchase.CurrencyType;
            this.Buyer = purchase.Buyer;
            this.WithTax = purchase.WithTax;
            this.State = purchase.State;
            this.Memo = purchase.Memo;
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
        public string SupplierID { get; set; }
        /// <summary>
        /// 获取或设置币别
        /// </summary>
        public string CurrencyType { get; set; }
        /// <summary>
        /// 获取或设置是否含税
        /// </summary>
        public bool WithTax { get; set; }
        /// <summary>
        /// 获取或设置下单日期
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// 获取或设置订单要求的发货日期
        /// </summary>
        public DateTime DemandDate { get; set; }
        /// <summary>
        /// 获取或设置业务人员
        /// </summary>
        public string Buyer { get; set; }
        /// <summary>
        /// 获取或设置采购单当前状态
        /// </summary>
        public SheetState State { get; set; }
        /// <summary>
        /// 获取或设置备注信息
        /// </summary>
        public string Memo { get; set; }
        #endregion
    }
}
