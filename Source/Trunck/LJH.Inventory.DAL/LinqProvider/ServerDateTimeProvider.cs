using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using LJH.Inventory.DAL.IProvider;
using LJH.Inventory.BusinessModel;
using LJH.GeneralLibrary.DAL;

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
        }
        #endregion

        #region 私有变量
        private string _ConnStr;
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
                using (SqlConnection con = new SqlConnection(_ConnStr))
                {
                    using (SqlCommand cmd = new SqlCommand("select getdate() ", con))
                    {
                        con.Open();
                        object o = cmd.ExecuteScalar();
                        serverDT = Convert.ToDateTime(o);
                        return new CommandResult(ResultCode.Successful, string.Empty);
                    }
                }
            }
            catch (SqlException ex)
            {
                serverDT = null;
                LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
                return new CommandResult(ResultCode.Fail, ex.Message);
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
}
