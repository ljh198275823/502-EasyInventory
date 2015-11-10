using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// <summary>
        /// 获取或设置商品型号
        /// </summary>
        public string Model { get; set; }
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
        /// <summary>
        /// 获取或设置产品是否是服务，如果是服务的话就不用进行库存管理
        /// </summary>
        public bool? IsService { get; set; }
        /// <summary>
        /// 获取或设置商品描述
        /// </summary>
        public string Memo { get; set; }
        #endregion
    }
}
