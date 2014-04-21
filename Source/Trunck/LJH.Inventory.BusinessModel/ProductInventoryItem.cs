using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class ProductInventoryItem : LJH.GeneralLibrary.Core.DAL.IEntity<Guid>
    {
        #region 构造函数
        public ProductInventoryItem()
        {
        }
        #endregion

        #region 公共属性
        public Guid ID { get; set; }

        public string ProductID { get; set; }

        public string WareHouseID { get; set; }

        public string Unit { get; set; }

        public decimal Price { get; set; }
        /// <summary>
        /// 获取或设置库存数量
        /// </summary>
        public decimal Count { get; set; }
        /// <summary>
        /// 获取收货或分配时间
        /// </summary>
        public DateTime AddDate { get; set; }
        /// <summary>
        /// 获取或设置订单的备货是否是从库存中分配
        /// </summary>
        public bool FromInventory { get; set; }
        /// <summary>
        /// 获取或设置销售订单项
        /// </summary>
        public Guid? OrderItem { get; set; }
        /// <summary>
        /// 获取或设置采购单项
        /// </summary>
        public Guid? PurchaseItem { get; set; }
        /// <summary>
        /// 获取或设置收货单项
        /// </summary>
        public Guid? InventoryItem { get; set; }

        public string InventorySheet { get; set; }

        public Guid? DeliveryItem { get; set; }

        public string DeliverySheet { get; set; }
        #endregion

        public ProductInventoryItem Clone()
        {
            return this.MemberwiseClone() as ProductInventoryItem;
        }
    }
}