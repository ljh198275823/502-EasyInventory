using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class InventoryCheckRecord : LJH.GeneralLibrary.Core.DAL.IEntity<Guid>
    {
        #region 构造函数
        public InventoryCheckRecord()
        {
        }
        #endregion

        #region 公共属性
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置盘点日期
        /// </summary>
        public DateTime CheckDateTime { get; set; }
        /// <summary>
        /// 获取或设置产品ID
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// 获取或设置仓库ID
        /// </summary>
        public string WarehouseID { get; set; }
        /// <summary>
        /// 获取或设置盘点产品的单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 获取或设置产品价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 获取或设置盘点时产品的账面库存数量
        /// </summary>
        public Decimal Inventory { get; set; }
        /// <summary>
        /// 获取或设置盘点的实际数量
        /// </summary>
        public decimal CheckCount { get; set; }
        /// <summary>
        /// 获取或设置盘点前账面重量
        /// </summary>
        public decimal? BeforeWeight { get; set; }
        /// <summary>
        /// 获取或设置盘点前账面长度
        /// </summary>
        public decimal? BeforeLength { get; set; }
        /// <summary>
        /// 获取或设置盘点重量
        /// </summary>
        public decimal? Weight { get; set; }
        /// <summary>
        /// 获取或设置盘点长度
        /// </summary>
        public decimal? Length { get; set; }
        /// <summary>
        /// 获取或设置盘点的库存项
        /// </summary>
        public Guid? SourceID { get; set; }

        public string Customer { get; set; }
        /// <summary>
        /// 获取或设置盘点人员
        /// </summary>
        public string Checker { get; set; }
        /// <summary>
        /// 获取或设置操作员
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        public string Memo { get; set; }
        #endregion
    }
}
