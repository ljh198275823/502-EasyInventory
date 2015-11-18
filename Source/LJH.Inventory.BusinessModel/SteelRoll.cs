using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class SteelRoll
    {
        #region 构造函数
        public SteelRoll()
        {
        }
        #endregion

        #region 公共属性
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置仓库ID
        /// </summary>
        public string WareHouseID { get; set; }
        /// <summary>
        /// 获取或设置仓库
        /// </summary>
        public WareHouse WareHouse { get; set; }
        /// <summary>
        /// 获取或设置商品ID
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// 获取或设置商品信息
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// 获取或设置库存单个重量
        /// </summary>
        public decimal? OriginalWeight { get; set; }
        /// <summary>
        /// 获取或设置库存单个长度
        /// </summary>
        public decimal? OriginalLength { get; set; }
        /// <summary>
        /// 获取或设置库存单个重量
        /// </summary>
        public decimal? Weight { get; set; }
        /// <summary>
        /// 获取或设置库存单个长度
        /// </summary>
        public decimal? Length { get; set; }
        /// <summary>
        /// 获取或设置真实厚度
        /// </summary>
        public decimal? RealThick { get; set; }
        /// <summary>
        /// 获取或设置库存项的单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 获取或设置库存项的价格
        /// </summary>
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
        /// 获取或设置状态
        /// </summary>
        public ProductInventoryState State { get; set; }

        public string Customer { get; set; }

        public string Supplier { get; set; }

        public string Manufacture { get; set; }

        public string SerialNumber { get; set; }
        /// <summary>
        /// 获取或设置销售订单项
        /// </summary>
        public Guid? OrderItem { get; set; }
        /// <summary>
        /// 获取或设置销售订单号
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 获取或设置采购单项
        /// </summary>
        public Guid? PurchaseItem { get; set; }
        /// <summary>
        /// 获取或设置采购订单号
        /// </summary>
        public string PurchaseID { get; set; }
        /// <summary>
        /// 获取或设置收货单项
        /// </summary>
        public Guid? InventoryItem { get; set; }
        /// <summary>
        /// 获取或设置收货单号
        /// </summary>
        public string InventorySheet { get; set; }
        /// <summary>
        /// 获取或设置送货单项
        /// </summary>
        public Guid? DeliveryItem { get; set; }
        /// <summary>
        /// 获取或设置送货单号
        /// </summary>
        public string DeliverySheet { get; set; }
        /// <summary>
        /// 获取或设置次库存项的来源，库存项在出货时会分开成多项
        /// </summary>
        public Guid? SourceID { get; set; }

        public string Operator { get; set; }

        public string Memo { get; set; }
        #endregion

        #region 只读属性
        /// <summary>
        /// 获取原材料资料是否可以修改
        /// </summary>
        public bool CanEdit
        {
            get { return (Status == "整卷"); }
        }
        /// <summary>
        /// 获取原材料的状态
        /// </summary>
        public string Status
        {
            get
            {
                if (UserSettings.Current != null && Length <= UserSettings.Current.BecomeRemainlessAt) return "余料";
                else if (UserSettings.Current != null && Length < UserSettings.Current.BecomeTailAt) return "尾卷";
                else if (OriginalLength > Length) return "余卷";
                return "整卷";
                return string.Empty;
            }
        }
        #endregion

        #region 公共方法
        public SteelRoll Clone()
        {
            return this.MemberwiseClone() as SteelRoll;
        }

        public decimal? CalThick()
        {
            if (Product != null && !string.IsNullOrEmpty(Product.Specification) && Product.Density.HasValue)
            {
                try
                {
                    decimal? width = SpecificationHelper.GetWrittenWidth(Product.Specification);
                    if (width.HasValue && width > 0)
                    {
                        return OriginalWeight * 1000 * 1000 / (width.Value * OriginalLength * Product.Density.Value);
                    }
                }
                catch
                {
                }
            }
            return null;
        }
        #endregion
    }
}
