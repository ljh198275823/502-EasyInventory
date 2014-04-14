using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class PurchaseOrder
    {
        #region 构造函数
        public PurchaseOrder()
        {
        }
        #endregion

        #region 只读变量
        public readonly string DocumentType = "PurchaseSheet";
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
        /// 获取或设置客户名称
        /// </summary>
        public CompanyInfo Supplier { get; set; }
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

        #region 只读属性
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

        /// <summary>
        /// 获取订单是否已经全部出货
        /// </summary>
        public bool IsCompleteAll
        {
            get
            {
                //if (State == SheetState.Closed || State == SheetState.Canceled) return true;
                //if (Items != null)
                //{
                //    return !Items.Exists(item => !item.IsComplete && item.OnWay > 0);
                //}
                //return true;
                return false;
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
        #endregion

        #region 公共方法
        /// <summary>
        /// 在订单中增加商品
        /// </summary>
        /// <param name="product"></param>
        /// <param name="unit"></param>
        /// <param name="price"></param>
        /// <param name="count"></param>
        public void AddProduct(Product product, string orderid, string unit, decimal price, decimal count)
        {
            PurchaseItem oi = new PurchaseItem()
            {
                PurchaseID = this.ID,
                OrderID = orderid,
                ProductID = product.ID,
                Product = product,
                Unit = unit,
                Price = price,
                Count = count,
            };
            Items.Add(oi);
        }
        /// <summary>
        /// 在订单中去除某种商品
        /// </summary>
        /// <param name="product"></param>
        public void RemoveItem(Product product)
        {
            if (Items != null)
            {
                foreach (PurchaseItem item in Items)
                {
                    if (item.ProductID == product.ID)
                    {
                        Items.Remove(item);
                        return;
                    }
                }
            }
        }

        public PurchaseOrder Clone()
        {
            return this.MemberwiseClone() as PurchaseOrder;
        }
        #endregion
    }
}

