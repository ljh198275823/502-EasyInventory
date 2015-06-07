using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LJH.InventoryWebAPI.Models
{
    public class ProductDTO
    {
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
        /// 获取或设置简称
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// 获取或设置商品类别编号
        /// </summary>
        public string Category { get; set; }
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