using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示送货单
    /// </summary>
    public class DeliverySheet
    {
        #region 构造函数
        public DeliverySheet()
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
        /// 获取或设置客户
        /// </summary>
        public Customer Customer { get; set; }
        /// <summary>
        /// 获取或设置出库仓库ID
        /// </summary>
        public string WareHouseID { get; set; }
        /// <summary>
        /// 获取或设置出库仓库
        /// </summary>
        public WareHouse WareHouse { get; set; }
        /// <summary>
        /// 获取或设置联系人
        /// </summary>
        public string Linker { get; set; }
        /// <summary>
        /// 获取或设置联系人手机号
        /// </summary>
        public string LinkerPhoneCall { get; set; }
        /// <summary>
        /// 获取或设置送货地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 获取或设置送货人
        /// </summary>
        public string Driver { get; set; }
        /// <summary>
        /// 获取或设置送货人电话
        /// </summary>
        public string DriverMobile { get; set; }
        /// <summary>
        /// 获取或设置送货车牌号
        /// </summary>
        public string CarPlate { get; set; }
        /// <summary>
        /// 获取或设置是否含税
        /// </summary>
        public bool IsWithTax { get; set; }
        /// <summary>
        /// 获取或设置送货单的总货款
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 获取或设置送货单的折扣额
        /// </summary>
        public decimal Discount { get; set; }
        /// <summary>
        /// 获取或设置销售人员
        /// </summary>
        public string SalesPerson { get; set; }
        /// <summary>
        /// 获取或设置送货单的状态
        /// </summary>
        public SheetState State { get; set; }
        /// <summary>
        /// 获取或设置备注描述
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 获取或设置出货商品项(如果要在列表中增删改项，请不要直接在此对象中操作，而是调用DeliverySheet类的方法)
        /// </summary>
        public List<DeliveryItem> Items { get; set; }
        #endregion

        #region 只读属性
        /// <summary>
        /// 获取每个送货单最大送货项数量
        /// </summary>
        public static readonly int MaxItemCount = 8;
        /// <summary>
        /// 获取送货单是否可以审批
        /// </summary>
        public bool CanApprove
        {
            get
            {
                return (State == SheetState.Add);
            }
        }
        /// <summary>
        /// 获取送货单是否可以发货
        /// </summary>
        public bool CanShip
        {
            get { return (State == SheetState.Add || State == SheetState.Approved); }
        }
        /// <summary>
        /// 获取是否可以打印送货单
        /// </summary>
        public bool CanPrint
        {
            get { return State != SheetState.Canceled; }
        }
        /// <summary>
        /// 获取是否可以删除送货单
        /// </summary>
        public bool CanDelete
        {
            get { return State == SheetState.Add || State == SheetState.Approved; }
        }
        /// <summary>
        /// 获取是否可以将送货单作废
        /// </summary>
        public bool CanCancel
        {
            get
            {
                return State != SheetState.Canceled;
            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 增加收货项
        /// </summary>
        /// <param name="product"></param>
        /// <param name="weight"></param>
        /// <param name="length"></param>
        public void AddItem(Product product, string unit, decimal price, decimal count)
        {
            DeliveryItem di = new DeliveryItem()
            {
                ID=Guid.NewGuid (),
                SheetNo = this.ID,
                ProductID = product.ID,
                Product = product,
                Price = price,
                Count = count,
            };
            AddItem(di);
        }

        public void AddItem(DeliveryItem item)
        {
            if (Items != null && Items.Exists(it => it.ProductID == item.ProductID)) return;
            if (Items == null) Items = new List<DeliveryItem>();
            if (Items.Count < MaxItemCount)
            {
                Items.Add(item);
            }
            Amount = Items.Sum(it => it.Amount);
        }
        /// <summary>
        /// 清空所有送货单项
        /// </summary>
        public void ClearItems()
        {
            if (Items != null) Items.Clear();
            Amount = 0;
        }

        public DeliverySheet Clone()
        {
            return MemberwiseClone() as DeliverySheet;
        }
        #endregion
    }
}
