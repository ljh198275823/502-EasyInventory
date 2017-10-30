using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 获取或设置成本项
    /// </summary>
    public class CostItem
    {
        #region 静态属性
        public static readonly string 入库单价 = "入库单价";
        public static readonly string 运费 = "运费";
        public static readonly string 吊装费 = "吊装费";
        public static readonly string 加工费 = "加工费";
        public static readonly string 其它费用 = "其它费用";
        #endregion

        #region 构造函数
        public CostItem()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置单价,一般是元/吨
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 获取或设置是否含税
        /// </summary>
        public bool WithTax { get; set; }
        /// <summary>
        /// 获取或设置是否是对方垫付，计算应收时有用
        /// </summary>
        public bool Prepay { get; set; }
        /// <summary>
        /// 获取或设置供应商ID
        /// </summary>
        public string SupllierID { get; set; }
        #endregion
    }
}
