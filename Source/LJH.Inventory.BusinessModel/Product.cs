using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示一种商品
    /// </summary>
    public class Product : LJH.GeneralLibrary.Core.DAL.IEntity<string>
    {
        #region 构造函数
        public Product()
        {
        }
        #endregion

        #region 只读变量
        public readonly string DocumentType = "Product";
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置商品编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置商品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置商品类别编号
        /// </summary>
        public string CategoryID { get; set; }
        /// <summary>
        /// 获取或设置商品类型信息
        /// </summary>
        public ProductCategory Category { get; set; }

        private string _Model = null;
        public string Model
        {
            get { return string.IsNullOrEmpty(_Model) ? _Model : _Model.Trim(); }
            set { _Model = value; }
        }
        /// <summary>
        /// 获取或设置商品规格
        /// </summary>
        public string Specification { get; set; }
        /// <summary>
        /// 获取或设置商品的品牌或生产商
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// 获取或设置商品的默认单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 获取或设置商品的单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 获取或设置商品的成本价
        /// </summary>
        public decimal Cost { get; set; }

        public decimal? Weight { get; set; }

        public decimal? Length { get; set; }

        public decimal? Density { get; set; }
        /// <summary>
        /// 获取或设置产品是否是服务，如果是服务的话就不用进行库存管理
        /// </summary>
        public bool? IsService { get; set; }
        /// <summary>
        /// 获取或设置商品描述
        /// </summary>
        public string Memo { get; set; }
        #endregion

        #region 扩展属性
        /// <summary>
        /// 获取或设置扩展属性
        /// </summary>
        public string Note { get; set; }

        private Dictionary<string, string> _Externals = null;

        public string GetProperty(ProductNote pn)
        {
            if (_Externals == null && !string.IsNullOrEmpty(Note)) _Externals = JsonConvert.DeserializeObject<Dictionary<string, string>>(Note);
            if (_Externals == null) return null;
            if (_Externals.ContainsKey(((int)pn).ToString())) return _Externals[((int)pn).ToString()];
            if (_Externals.ContainsKey(pn.ToString())) return _Externals[pn.ToString()];
            return null;
        }

        public void SetProperty(ProductNote pn, string value)
        {
            var key = ((int)pn).ToString();
            if (_Externals == null && !string.IsNullOrEmpty(Note)) _Externals = JsonConvert.DeserializeObject<Dictionary<string, string>>(Note);
            if (_Externals == null) _Externals = new Dictionary<string, string>();
            if (value == null) { if (_Externals.ContainsKey(key)) _Externals.Remove(key); }
            else _Externals[key] = value;
            Note = JsonConvert.SerializeObject(_Externals);
        }

        public void RemoveProperty(ProductNote pn)
        {
            var key = ((int)pn).ToString();
            if (_Externals == null && !string.IsNullOrEmpty(Note)) _Externals = JsonConvert.DeserializeObject<Dictionary<string, string>>(Note);
            if (_Externals == null) return;
            if (_Externals.ContainsKey(key)) _Externals.Remove(key);
            Note = JsonConvert.SerializeObject(_Externals);
        }

        public decimal? GetPropertyByDecimal(ProductNote pnote)
        {
            string temp = this.GetProperty(pnote);
            decimal sq;
            if (!string.IsNullOrEmpty(temp) && decimal.TryParse(temp, out sq)) return sq;
            return null;
        }

        /// <summary>
        /// 获取某个属性值，为空时返回0
        /// </summary>
        /// <param name="pnote"></param>
        /// <returns></returns>
        public decimal GetPropertyByDecimalOrDefault(ProductNote pnote)
        {
            string temp = this.GetProperty(pnote);
            decimal sq;
            if (!string.IsNullOrEmpty(temp) && decimal.TryParse(temp, out sq)) return sq;
            return 0;
        }

        public int? GetPropertyByInt(ProductNote pnote)
        {
            string temp = this.GetProperty(pnote);
            int sq;
            if (!string.IsNullOrEmpty(temp) && int.TryParse(temp, out sq)) return sq;
            return null;
        }

        public int GetPropertyByIntOrDefault(ProductNote pnote)
        {
            string temp = this.GetProperty(pnote);
            int sq;
            if (!string.IsNullOrEmpty(temp) && int.TryParse(temp, out sq)) return sq;
            return 0;
        }

        public string 材质
        {
            get { return GetProperty(ProductNote.材质); }
            set
            {
                SetProperty(ProductNote.材质, value);
            }
        }

        public bool 是不锈钢卷材
        {
            get { return GetProperty(ProductNote.不锈钢卷材) == "1"; }
            set { SetProperty(ProductNote.不锈钢卷材, value ? "1" : null); }
        }

        public bool 是不锈钢板材
        {
            get { return GetProperty(ProductNote.不锈钢板材) == "1"; }
            set { SetProperty(ProductNote.不锈钢板材, value ? "1" : null); }
        }
        #endregion
    }
}
