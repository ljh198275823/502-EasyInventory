using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary;
using Newtonsoft.Json;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示出库单项
    /// </summary>
    public class StackOutItem
    {
        #region 构造函数
        public StackOutItem()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置出货项ID
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置出货单ID
        /// </summary>
        public string SheetNo { get; set; }
        /// <summary>
        /// 获取或设置商品ID
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// 获取或设置单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 获取或设置出货商品的长度
        /// </summary>
        public decimal? Length { get; set; }
        /// <summary>
        /// 获取或设置同一商品多个出货项的总重
        /// </summary>
        public decimal? TotalWeight { get; set; }
        /// <summary>
        /// 获取或设置单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 获取或设置商品数量
        /// </summary>
        public decimal Count { get; set; }
        /// <summary>
        /// 获取或设置库存项, 用于直接指定某件库存出货
        /// </summary>
        public Guid? InventoryItem { get; set; }
        /// <summary>
        /// 获取或设置订单项ID
        /// </summary>
        public Guid? OrderItem { get; set; }
        /// <summary>
        /// 获取或设置订单编号
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 获取订单项添加的时间
        /// </summary>
        public DateTime? AddDate { get; set; }
        /// <summary>
        /// 获取或设置备注信息
        /// </summary>
        public string Memo { get; set; }

        public ProductInventoryItem ProductInventoryItem { get; set; }
        #endregion

        #region 扩展属性
        /// <summary>
        /// 获取或设置扩展属性
        /// </summary>
        public string Note { get; set; }

        private Dictionary<string, string> _Externals = null;

        public string GetProperty(SheetNote pn)
        {
            if (_Externals == null && !string.IsNullOrEmpty(Note)) _Externals = JsonConvert.DeserializeObject<Dictionary<string, string>>(Note);
            if (_Externals == null) return null;
            if (_Externals.ContainsKey(((int)pn).ToString())) return _Externals[((int)pn).ToString()];
            if (_Externals.ContainsKey(pn.ToString())) return _Externals[pn.ToString()];
            return null;
        }

        public void SetProperty(SheetNote pn, string value)
        {
            var key = ((int)pn).ToString();
            if (_Externals == null && !string.IsNullOrEmpty(Note)) _Externals = JsonConvert.DeserializeObject<Dictionary<string, string>>(Note);
            if (_Externals == null) _Externals = new Dictionary<string, string>();
            if (value == null && _Externals.ContainsKey(key)) _Externals.Remove(key);
            else _Externals[key] = value;
            Note = JsonConvert.SerializeObject(_Externals);
        }

        public void RemoveProperty(SheetNote pn)
        {
            var key = ((int)pn).ToString();
            if (_Externals == null && !string.IsNullOrEmpty(Note)) _Externals = JsonConvert.DeserializeObject<Dictionary<string, string>>(Note);
            if (_Externals == null) return;
            if (_Externals.ContainsKey(key)) _Externals.Remove(key);
            Note = JsonConvert.SerializeObject(_Externals);
        }
        #endregion

        /// <summary>
        /// 获取当前计算的总额
        /// </summary>
        public decimal Amount
        {
            get
            {
                decimal ret = 0;
                if (TotalWeight.HasValue && TotalWeight.Value != 0)
                {
                    ret = Math.Round(TotalWeight.Value, 3) * Price;
                }
                else
                {
                    ret = Price * Count;
                }
                return Math.Round(ret, 2);
            }
        }
    }
}
