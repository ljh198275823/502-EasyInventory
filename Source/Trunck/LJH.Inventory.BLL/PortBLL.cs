using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class PortBLL : LJH.GeneralLibrary.Core.BLL.BLLBase<string, Port>
    {
        #region 构造函数
        public PortBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取本国的所有港口信息,没有记录时返回空或NULL
        /// </summary>
        /// <returns></returns>
        public List<Port> GetNativePorts()
        {
            List<Port> ports = GetItems(null).QueryObjects;
            if (ports != null && ports.Count > 0)
            {
                return ports.Where(item => item.IsForeign == false).ToList();
            }
            return null;
        }
        /// <summary>
        /// 获取外国的所有港口信息,没有记录时返回空或NULL
        /// </summary>
        /// <returns></returns>
        public List<Port> GetForeignPorts()
        {
            List<Port> ports = GetItems(null).QueryObjects;
            if (ports != null && ports.Count > 0)
            {
                return ports.Where(item => item.IsForeign).ToList();
            }
            return null;
        }
        #endregion
    }
}
