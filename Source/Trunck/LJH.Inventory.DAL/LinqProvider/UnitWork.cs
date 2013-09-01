using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using LJH.GeneralLibrary.ExceptionHandling;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.DAL.LinqProvider
{
    /// <summary>
    /// 单元操作
    /// </summary>
    public class UnitWork : IUnitWork
    {
        internal  DataContext Inventory;

        public UnitWork(string connStr)
        {
            Inventory = DataContextFactory.CreateDataContext(connStr);
        }

        public CommandResult Commit()
        {
            try
            {
                Inventory.SubmitChanges();
                return new CommandResult(ResultCode.Successful,ResultCode.Successful.ToString());

            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "UnitWork.Commit()");
                return new CommandResult(ResultCode.Fail , ex.Message);
            }
        }
    }
}
