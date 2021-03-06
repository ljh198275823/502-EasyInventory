﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class WareHouse : LJH.GeneralLibrary.Core.DAL.IEntity<string>
    {
        #region 构造函数
        public WareHouse()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置仓库ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置仓库名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置父仓库
        /// </summary>
        public string Parent { get; set; }
        /// <summary>
        /// 获取或设置仓库备注
        /// </summary>
        public string Memo { get; set; }
        #endregion
    }
}
