using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示铁皮卷切割操作记录
    /// </summary>
    public class SteelRollSliceRecord : LJH.GeneralLibrary.Core.DAL.IEntity<Guid>
    {
        #region 公共属性
        /// <summary>
        /// 获取或设置ID
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置切割时间
        /// </summary>
        public DateTime SliceDate { get; set; }
        /// <summary>
        /// 获取或设置加工的原材料卷ID
        /// </summary>
        public Guid SliceSource { get; set; }
        /// <summary>
        /// 获取或设置加工的原材料卷初始重量
        /// </summary>
        public decimal? OriginalWeight { get; set; }
        /// <summary>
        /// 获取或设置加工的原材料卷初始长度
        /// </summary>
        public decimal? OriginalLength { get; set; }
        /// <summary>
        /// 获取或设置商品类别编号
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 获取或设置商品规格
        /// </summary>
        public string Specification { get; set; }
        /// <summary>
        /// 获取或设置切割品的类型
        /// </summary>
        public string SliceType { get; set; }
        /// <summary>
        /// 获取或设置切割品的长度
        /// </summary>
        public decimal? Length { get; set; }
        /// <summary>
        /// 获取或设置小件的重量
        /// </summary>
        public decimal? Weight { get; set; }
        /// <summary>
        /// 获取或设置切割的数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 获取或设置加工前原材料的重量
        /// </summary>
        public decimal BeforeWeight { get; set; }
        /// <summary>
        /// 获取或设置加工前原料的长度
        /// </summary>
        public decimal BeforeLength { get; set; }
        /// <summary>
        /// 获取或设置加工后原材料的重量
        /// </summary>
        public decimal AfterWeight { get; set; }
        /// <summary>
        /// 获取或设置加工后原材料的长度
        /// </summary>
        public decimal AfterLength { get; set; }
        /// <summary>
        /// 获取或设置录入记录的操作员
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 获取或设置出货的客户名称(如果加工类别是出货的话)
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// 获取或设置存放仓库
        /// </summary>
        public string Warehouse { get; set; }
        /// <summary>
        /// 获取或设置加工者姓名，如果有多个人员，每个人员之间用逗号分隔
        /// </summary>
        public string Slicer { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        public string Memo { get; set; }
        #endregion

        public SteelRollSliceRecord Clone()
        {
            return this.MemberwiseClone() as SteelRollSliceRecord;
        }
    }
}
