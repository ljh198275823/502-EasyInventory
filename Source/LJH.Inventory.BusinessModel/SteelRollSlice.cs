using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class SteelRollSlice : LJH.GeneralLibrary.Core.DAL.IEntity<Guid>
    {
        #region 构造函数
        public SteelRollSlice()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置ID
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 获取或设置商品信息
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// 获取或设置库存数量
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 获取或设置待发货数量
        /// </summary>
        public decimal WaitShipping { get; set; }
        /// <summary>
        /// 获取或设置可用库存数量
        /// </summary>
        public decimal Valid { get; set; }
        /// <summary>
        /// 获取或设置已经预订的数量
        /// </summary>
        public decimal Reserved { get; set; }
        /// <summary>
        /// 获取库存总数
        /// </summary>
        public decimal Total
        {
            get
            {
                return Reserved + Valid + WaitShipping;
            }
        }
        #endregion

        #region 公共方法
        public SteelRollSlice Clone()
        {
            return this.MemberwiseClone() as SteelRollSlice;
        }
        #endregion
    }
}
