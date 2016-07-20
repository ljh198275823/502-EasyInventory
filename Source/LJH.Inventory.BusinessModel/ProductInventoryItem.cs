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
        #region 静态方法
        /// <summary>
        /// 计算某个规格指定长度的重量
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="length"></param>
        /// <param name="density"></param>
        /// <returns></returns>
        public static decimal CalWeight(decimal thick, decimal width, decimal length, decimal density)
        {
            return (thick * width * length * density) / (1000 * 1000);
        }

        /// <summary>
        /// 计算厚度，返回毫米为单位的厚度
        /// </summary>
        /// <returns></returns>
        public static decimal CalThick(decimal width, decimal weight, decimal length, decimal density)
        {
            return weight * 1000 * 1000 / (width * length * density);
        }

        /// <summary>
        /// 计算长度,返回米为单位的长度
        /// </summary>
        /// <returns></returns>
        public static decimal CalLength(decimal thick, decimal width, decimal weight, decimal density)
        {
            return weight * 1000 * 1000 / (width * thick * density);
        }
        #endregion

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
        /// 获取或设置根据入库重量和长度计算出来的厚度
        /// </summary>
        public decimal? OriginalThick { get; set; }
        /// <summary>
        /// 获取或设置库存单个重量
        /// </summary>
        public decimal? OriginalWeight { get; set; }
        /// <summary>
        /// 获取或设置库存单个长度
        /// </summary>
        public decimal? OriginalLength { get; set; }
        /// <summary>
        /// 获取或设置初始数量
        /// </summary>
        public decimal? OriginalCount { get; set; }
        /// <summary>
        /// 获取或设置真实厚度
        /// </summary>
        public decimal? RealThick { get; set; }
        /// <summary>
        /// 获取或设置库存单个重量
        /// </summary>
        public decimal? Weight { get; set; }
        /// <summary>
        /// 获取或设置库存单个长度
        /// </summary>
        public decimal? Length { get; set; }
        /// <summary>
        /// 获取或设置库存数量
        /// </summary>
        public decimal Count { get; set; }
        /// <summary>
        /// 获取或设置库存项的单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 获取或设置库存项的价格
        /// </summary>
        public decimal Price { get; set; }
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

        public string Position { get; set; }

        public string Material { get; set; }

        public string Carplate { get; set; }

        public string Memo { get; set; }
        #endregion

        #region 成本相关的属性
        /// <summary>
        /// 获取或设置采购价格
        /// </summary>
        public decimal? PurchasePrice { get; set; }
        /// <summary>
        /// 获取或设置采购价格中是否含税
        /// </summary>
        public bool? WithTax { get; set; }
        /// <summary>
        /// 获取或设置运输成本
        /// </summary>
        public decimal? TransCost { get; set; }
        /// <summary>
        /// 获取或设置运费是否由供应商代垫
        /// </summary>
        public bool? TransCostPrepay { get; set; }
        /// <summary>
        /// 获取或设置其它费用
        /// </summary>
        public decimal? OtherCost { get; set; }
        /// <summary>
        /// 获取或设置其它费用是否由供应商代垫
        /// </summary>
        public bool? OtherCostPrepay { get; set; }
        #endregion

        #region 与库存状态相关的公共属性
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
        /// 获取或设置入库操作员
        /// </summary>
        public string Operator { get; set; }
        #endregion

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
                if (OriginalWeight <= Weight) return "整卷";
                if (UserSettings.Current != null && Length <= UserSettings.Current.BecomeRemainlessAt) return "余料";
                else if (UserSettings.Current != null && Length < UserSettings.Current.BecomeTailAt) return "尾卷";
                return "余卷";
            }
        }
        /// <summary>
        /// 获取库存项的单重
        /// </summary>
        public decimal? UnitWeight
        {
            get
            {
                if (Weight == null) return null;
                if (Count <= 0) return null;
                return Weight / Count;
            }
        }
        #endregion

        #region 公共方法
        public ProductInventoryItem Clone()
        {
            return this.MemberwiseClone() as ProductInventoryItem;
        }
        #endregion
    }
}