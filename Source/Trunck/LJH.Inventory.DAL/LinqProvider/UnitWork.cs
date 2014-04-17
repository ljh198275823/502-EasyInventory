﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using LJH.GeneralLibrary.ExceptionHandling;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.DAL.LinqProvider
{
    /// <summary>
    /// 单元操作
    /// </summary>
    public class UnitWork : LJH.GeneralLibrary.DAL.IUnitWork
    {
        #region 构造函数
        public UnitWork(string connStr)
        {
            _Inventory = DataContextFactory.CreateDataContext(connStr, "LJH.Inventory.DAL.LinqProvider.Inventory.xml");
        }
        #endregion

        #region 私有变量
        private DataContext _Inventory;
        #endregion

        #region 实现IUnitWork接口
        /// <summary>
        /// 提交事务
        /// </summary>
        /// <returns></returns>
        public CommandResult Commit()
        {
            try
            {
                _Inventory.SubmitChanges();
                return new CommandResult(ResultCode.Successful, ResultCode.Successful.ToString());

            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "UnitWork.Commit()");
                return new CommandResult(ResultCode.Fail, ex.Message);
            }
        }

        /// <summary>
        /// 获取执行单元的数据上下文
        /// </summary>
        public DataContext DataContext
        {
            get { return _Inventory; }
        }
        #endregion
    }
}
