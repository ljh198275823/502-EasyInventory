using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

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

        public string DocumentType { get { return "ProductInventory"; } }

        #region 公共属性
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置仓库ID
        /// </summary>
        public string WareHouseID { get; set; }
        /// <summary>
        /// 获取或设置商品ID
        /// </summary>
        public string ProductID { get; set; }

        public Product Product { get; set; }

        private string _Model = null;
        public string Model
        {
            get { return string.IsNullOrEmpty(_Model) ? _Model : _Model.Trim(); }
            set { _Model = value; }
        }
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
        /// 获取或设置库存当前重量
        /// </summary>
        public decimal? Weight { get; set; }
        /// <summary>
        /// 获取或设置库存当前长度
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
        /// 获取或设置加工的原材料卷初始重量
        /// </summary>
        public decimal? SourceRollWeight { get; set; }
        /// <summary>
        /// 获取或设置入库操作员
        /// </summary>
        public string Operator { get; set; }
        #endregion

        #region 与原材料有关
        /// <summary>
        /// 获取原材料的状态
        /// </summary>
        public string Status
        {
            get
            {
                if (Model == ProductModel.原材料)
                {
                    if (OriginalWeight <= Weight) return "整卷";
                    else if (Model == ProductModel.原材料 && Weight == 0) return "余料";
                    if (UserSettings.Current != null && Length <= UserSettings.Current.BecomeRemainlessAt) return "余料";
                    else if (UserSettings.Current != null && Length < UserSettings.Current.BecomeTailAt) return "尾卷";
                    return "余卷";
                }
                return null;
            }
        }
        #endregion

        /// <summary>
        /// 获取库存项的单重
        /// </summary>
        public decimal? UnitWeight
        {
            get
            {
                try
                {
                    if (Model == ProductModel.开平 || Model == ProductModel.开卷)
                    {
                        decimal? thick = this.RealThick;
                        if (!thick.HasValue) thick = this.OriginalThick;
                        if (!thick.HasValue) thick = SpecificationHelper.GetWrittenThick(Product.Specification);
                        decimal? length = this.Product.Length; //小件的长度放在产品信息中
                        decimal? width = SpecificationHelper.GetWrittenWidth(Product.Specification);
                        if (thick != null && length != null && width != null)
                        {
                            return ProductInventoryItem.CalWeight(thick.Value, width.Value, length.Value, Product.Density.Value);
                        }
                    }
                    if (Weight.HasValue && Weight.Value > 0 && Count > 0) return Weight.Value / Count;
                    if (OriginalWeight > 0 && OriginalCount > 0) return OriginalWeight.Value / OriginalCount.Value;
                    return null;
                }
                catch (Exception ex)
                {
                }
                return null;
            }
        }

        #region 成本相关属性
        public Guid? CostID { get; set; }
        public string Costs;

        private List<CostItem> _CostItems = null;

        public CostItem GetCost(string key)
        {
            if (_CostItems == null && !string.IsNullOrEmpty(Costs)) _CostItems = JsonConvert.DeserializeObject<List<CostItem>>(Costs);
            if (_CostItems == null) return null;
            var ret = _CostItems.SingleOrDefault(it => it.Name == key);
            return ret;
        }

        public List<CostItem> GetAllCosts()
        {
            if (_CostItems == null && !string.IsNullOrEmpty(Costs)) return JsonConvert.DeserializeObject<List<CostItem>>(Costs);
            if (_CostItems != null) return _CostItems.ToList();
            return null;
        }

        public void SetCost(CostItem ci)
        {
            if (_CostItems == null && !string.IsNullOrEmpty(Costs)) _CostItems = JsonConvert.DeserializeObject<List<CostItem>>(Costs);
            if (_CostItems == null) _CostItems = new List<CostItem>();
            _CostItems.RemoveAll(it => it.Name == ci.Name);
            _CostItems.Add(ci);
            Costs = JsonConvert.SerializeObject(_CostItems);
        }

        public decimal CalReceivable(CostItem ci)
        {
            if (OriginalWeight > 0) return Math.Round(OriginalWeight.Value * ci.Price, 2);
            else if (Model == ProductModel.其它产品) return Math.Round(OriginalCount.Value * ci.Price, 2);
            return 0;
        }

        public decimal CalTax(CostItem ci)
        {
            if (ci == null || ci.WithTax == false) return 0; //不含税
            if (OriginalWeight > 0) return Math.Round(OriginalWeight.Value * ci.Price, 2);
            else if (Model == ProductModel.其它产品) return Math.Round(OriginalCount.Value * ci.Price, 2);
            return 0;
        }

        public decimal CalCost(bool withTax, decimal txtRate)
        {
            return Math.Round(CalUnitCost(withTax, txtRate) * Count, 2);
        }

        public decimal CalUnitCost(bool withTax, decimal txtRate)
        {
            decimal ret = 0;
            if (_CostItems == null && !string.IsNullOrEmpty(Costs)) _CostItems = JsonConvert.DeserializeObject<List<CostItem>>(Costs);
            if (_CostItems == null) return 0;
            var uw = UnitWeight;
            if (uw == null)
            {
                if (Model == ProductModel.其它产品) uw = 1; //这里表明是按每一个产品的单价来算，而不是用吨价
                else return 0;
            }
            foreach (var fc in _CostItems)
            {
                if (fc.Name == CostItem.入库单价 && GetCost(CostItem.结算单价) != null) continue; //如果有结算单价，不再计算入库单价
                if (withTax && fc.WithTax) ret += uw.Value * fc.Price;
                else if (withTax && !fc.WithTax) ret += uw.Value * fc.Price / (1 - txtRate);  //不含税进 含税出
                else if (!withTax && fc.WithTax) ret += uw.Value * fc.Price * (1 - txtRate);  //含税进 ，不含税出
                else if (!withTax && !fc.WithTax) ret += uw.Value * fc.Price;
            }
            return Math.Round(ret, 2);
        }
        #endregion

        #region 公共方法
        public ProductInventoryItem Clone()
        {
            var ret = this.MemberwiseClone() as ProductInventoryItem;
            if (this._CostItems != null)
            {
                ret._CostItems = new List<CostItem>();
                if (this._CostItems.Count > 0) ret._CostItems.AddRange(this._CostItems.Select(it => it.Clone()));
            }
            return ret;
        }
        #endregion
    }
}