using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using LJH.GeneralLibrary.ExceptionHandling;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.Inventory.DAL.LinqProvider
{
    /// <summary>
    /// 单元操作
    /// </summary>
    public class UnitWork : LJH.GeneralLibrary.Core.DAL.Linq.LinqUnitWork
    {
        #region 构造函数
        public UnitWork(string connStr, MappingSource ms)
            : base(connStr, ms)
        {

        }
        #endregion
    }
}
