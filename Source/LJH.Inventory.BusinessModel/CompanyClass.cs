﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示客户类型枚举
    /// </summary>
    public enum CompanyClass
    {
        /// <summary>
        /// 其它
        /// </summary>
        Other = 3,
        /// <summary>
        /// 客户
        /// </summary>
        Customer = 5,
        /// <summary>
        /// 供应商
        /// </summary>
        Supplier = 6,
        /// <summary>
        /// 代理商
        /// </summary>
        Proxy = 7,
    }
}
