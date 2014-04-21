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
        /// 获取或设置商品的外文名称
        /// </summary>
        public string ForeignName { get; set; }
        /// <summary>
        /// 获取或设置简称
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// 获取或设置商品类别编号
        /// </summary>
        public string CategoryID { get; set; }
        /// <summary>
        /// 获取或设置商品类型信息
        /// </summary>
        public ProductCategory Category { get; set; }
        /// <summary>
        /// 获取或设置商品条码
        /// </summary>
        public string BarCode { get; set; }
        /// <summary>
        /// 获取或设置商品型号
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// 获取或设置商品规格
        /// </summary>
        public string Specification { get; set; }
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
        /// <summary>
        /// 获取或设置产品用于哪些客户，比如有些产品针对不同的客户有不同的物料编号
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 获取或设置产品的内部编号，主要是针对某种产品针对不同的客户有不同的编号，但在内部统计库存等时则需要用一个统一的内部编号
        /// </summary>
        public string InternalID { get; set; }
        /// <summary>
        /// 获取或设置产品的权重,主要用于产品排序，数据越大的产品排得越靠前
        /// </summary>
        public long? Point { get; set; }
        /// <summary>
        /// 获取或设置商品描述
        /// </summary>
        public string Memo { get; set; }
        #endregion
    }
}
