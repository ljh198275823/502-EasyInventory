using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data;
using System.Text;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.DAL.Linq;

namespace LJH.Inventory.DAL.LinqProvider
{
    /// <summary>
    /// 获取服务器时间的提供者类
    /// </summary>
    public class ServerDateTimeProvider : IServerDatetimeProvider
    {
        #region 构造函数
        public ServerDateTimeProvider(string connStr, System.Data.Linq.Mapping.MappingSource ms)
        {
            _ConnStr = connStr;
            _MapSource = ms;
        }
        #endregion

        #region 私有变量
        private string _ConnStr;
        private System.Data.Linq.Mapping.MappingSource _MapSource;
        #endregion


        #region 实现IServerDateTimeProvider 接口
        /// <summary>
        /// 获取服务器时间，如果执行失败，serverDT 返回null 
        /// </summary>
        /// <param name="serverDT"></param>
        /// <returns></returns>
        public CommandResult GetServerDateTime(out DateTime? serverDT)
        {
            try
            {
                serverDT = null;
                DataContext dc = DataContextFactory.CreateDataContext(_ConnStr, _MapSource);
                var ret = dc.ExecuteQuery<DateTime>("select Now from View_Now").ToList();
                if (ret != null && ret.Count == 1)
                {
                    serverDT = ret[0];
                    return new CommandResult(ResultCode.Successful, string.Empty);
                }
                return new CommandResult(ResultCode.Fail, "获取数据库时间失败");
            }
            catch (Exception ex)
            {
                serverDT = null;
                LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
                return new CommandResult(ResultCode.Fail, ex.Message);
            }
        }
        #endregion
    }

    internal class DatebaseTime
    {
        DateTime Now { get; set; }
    }
}
