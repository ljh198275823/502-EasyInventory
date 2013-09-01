using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示收货单
    /// </summary>
    public class InventorySheet
    {
        #region 构造函数
        public InventorySheet()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置收货单号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置仓库ID
        /// </summary>
        public string WareHouseID { get; set; }
        /// <summary>
        /// 获取或设置收货仓库
        /// </summary>
        public WareHouse WareHouse { get; set; }
        /// <summary>
        /// 获取或设置供应商ID
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 获取或设置供应商
        /// </summary>
        public Supplier Supplier { get; set; }
        /// <summary>
        /// 获取或设置送货单状态
        /// </summary>
        public SheetState State { get; set; }
        /// <summary>
        /// 获取或设置收货单的备注
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 获取或设置所有送货单项
        /// </summary>
        public List<InventoryItem> Items { get; set; }
        #endregion

        #region 只读属性
        /// <summary>
        /// 获取收货单是否可以收货
        /// </summary>
        public bool CanInventory
        {
            get { return State == SheetState.Add || State == SheetState.Approved; }
        }

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
        public void AddItem(Product product, string unit, decimal price, int count)
        {
            InventoryItem di = new InventoryItem()
            {
                SheetNo = this.ID,
                ProductID = product.ID,
                Product = product,
                Price = price,
                Count = count,
            };
            AddItem(di);
        }

        public void AddItem(InventoryItem item)
        {
            if (Items != null && Items.Exists(it => it.ProductID == item.ProductID)) return;
            if (Items == null) Items = new List<InventoryItem>();
            Items.Add(item);
        }
        /// <summary>
        /// 清空所有送货单项
        /// </summary>
        public void ClearItems()
        {
            if (Items != null) Items.Clear();
        }

        public InventorySheet Clone()
        {
            return MemberwiseClone() as InventorySheet;
        }
        #endregion

    }
}
