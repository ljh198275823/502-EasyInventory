using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示一个库存项
    /// </summary>
    public class ProductInventoryItem : LJH.GeneralLibrary.Core.DAL.IEntity<Guid>
    {
        #region 构造函数
        public ProductInventoryItem()
        {
        }
        #endregion

        #region 公共属性
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置仓库ID
        /// </summary>
        public string WareHouseID { get; set; }

        public WareHouse WareHouse { get; set; }
        /// <summary>
        /// 获取或设置商品ID
        /// </summary>
        public string ProductID { get; set; }

        public Product Product { get; set; }

        public string Model { get; set; }
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
        /// 获取或设置根据入库重量和长度计算出来的厚度
        /// </summary>
        public decimal? OriginalThick { get; set; }
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
        /// 获取或设置库存项的来源，库存项在出货时会分开成多项,
        /// </summary>
        public Guid? SourceID { get; set; }
        /// <summary>
        /// 获取或设置库存项的原材料项ID,如果此库存项是通过加工得到的话
        /// </summary>
        public Guid? SourceRoll { get; set; }
        /// <summary>
        /// 小件库存显示加工来源卷的入库重量，用于区别小件的来源卷
        /// </summary>
        public decimal? SourceRollWeight { get; set; }

        public string Operator { get; set; }

        public string Memo { get; set; }
        #endregion

        public ProductInventoryItem Clone()
        {
            return this.MemberwiseClone() as ProductInventoryItem;
        }

        #region 与原材料有关
        /// <summary>
        /// 获取原材料资料是否可以修改
        /// </summary>
        public bool CanEdit
        {
            get { return (State == ProductInventoryState.Inventory && Status == "整卷"); }
        }
        /// <summary>
        /// 获取原材料的状态
        /// </summary>
        public string Status
        {
            get
            {
                if (OriginalWeight == Weight) return "整卷";
                if (UserSettings.Current != null && Length <= UserSettings.Current.BecomeRemainlessAt) return "余料";
                else if (UserSettings.Current != null && Length < UserSettings.Current.BecomeTailAt) return "尾卷";
                else if (OriginalLength > Length) return "余卷";
                return "整卷";
            }
        }
        /// <summary>
        /// 计算真实厚度
        /// </summary>
        /// <returns></returns>
        public decimal? CalThick(string specification, decimal weight, decimal length, decimal density)
        {
            if (!string.IsNullOrEmpty(specification))
            {
                try
                {
                    decimal? width = SpecificationHelper.GetWrittenWidth(specification);
                    if (width.HasValue && width > 0)
                    {
                        return weight * 1000 * 1000 / (width.Value * length * density);
                    }
                }
                catch
                {
                }
            }
            return null;
        }

        /// <summary>
        /// 计算真实厚度
        /// </summary>
        /// <returns></returns>
        public decimal? CalLength(string specification, decimal weight, decimal density)
        {
            if (!string.IsNullOrEmpty(specification))
            {
                try
                {
                    decimal? width = SpecificationHelper.GetWrittenWidth(specification);
                    decimal? thick = SpecificationHelper.GetWrittenThick(specification);
                    if (width.HasValue && width > 0 && thick.HasValue && thick > 0)
                    {
                        return weight * 1000 * 1000 / (width.Value * thick.Value * density);
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