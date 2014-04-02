using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示商品类型
    /// </summary>
    public class ProductCategory
    {
        #region 公共属性
        /// <summary>
        /// 获取或设置类型编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置类型名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置用于生成此类型商品编号的前缀
        /// </summary>
        public string Prefix { get; set; }
        /// <summary>
        /// 获取或设置父类别
        /// </summary>
        public string Parent { get; set; }
        /// <summary>
        /// 获取或设置类型备注
        /// </summary>
        public string Memo { get; set; }
        #endregion

        #region 公共方法
        /// <summary>
        /// 克隆自己的一个复本
        /// </summary>
        /// <returns></returns>
        public ProductCategory Clone()
        {
            return this.MemberwiseClone() as ProductCategory;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(ID))
            {
                return Name; // string.Format("{0}:{1}", ID, Name);
            }
            return string.Empty;
        }
        #endregion
    }
}
