using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    /// <summary>
    /// 表示原料，加工品等物品的查询条件
    /// </summary>
    public class ProductSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        #region 公共属性
        /// <summary>
        /// 获取或设置要查询物品的条码
        /// </summary>
        public string BarCode { get; set; }
        /// <summary>
        /// 获取或设置要查询物品的商品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置要查询物品的商品类别
        /// </summary>
        public string CategoryID { get; set; }
        /// <summary>
        /// 获取或设置要查询物品的规格
        /// </summary>
        public string Specification { get; set; }
        /// <summary>
        /// 获取或设置要查询的产品的ID列表
        /// </summary>
        public List<string> ProductIDS { get; set; }
        #endregion
    }
}
