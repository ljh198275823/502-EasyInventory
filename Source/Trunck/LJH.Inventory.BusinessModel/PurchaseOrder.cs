using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class PurchaseOrder : ISheet<string>
    {
        #region 构造函数
        public PurchaseOrder()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置送货单据编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置最近活动时间
        /// </summary>
        public DateTime LastActiveDate { get; set; }
        /// <summary>
        /// 获取或设置客户ID
        /// </summary>
        public string SupplierID { get; set; }
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
        /// <summary>
        /// 获取或设置出货商品项
        /// </summary>
        public List<PurchaseItem> Items { get; set; }
        #endregion

        #region 实现ISheet接口
        public bool CanEdit
        {
            get { return (State == SheetState.Add); }
        }

        public bool CanApprove
        {
            get { return State == SheetState.Add; }
        }

        public bool CanCancel
        {
            get { return State != SheetState.Canceled && State != SheetState.Settled; }
        }

        public string DocumentType
        {
            get { return "PurchaseSheet"; }
        }
        #endregion

        #region 公共方法
        public ISheet<string> Clone()
        {
            return this.MemberwiseClone() as PurchaseOrder;
        }
        /// <summary>
        /// 计算订单的总金额
        /// </summary>
        public decimal CalAmount()
        {
            decimal amount = 0;
            if (Items != null)
            {
                foreach (PurchaseItem item in Items)
                {
                    amount += item.Price * item.Count;
                }
            }
            return amount;
        }
        #endregion
    }
}


