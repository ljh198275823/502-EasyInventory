using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.BLL
{
    public class PortBLL
    {
        #region 构造函数
        public PortBLL(string repoUri)
        {
            _RepoUri = repoUri;
        }
        #endregion

        #region 私有变量
        private string _RepoUri;
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取本国的所有港口信息,没有记录时返回空或NULL
        /// </summary>
        /// <returns></returns>
        public List<Port> GetNativePorts()
        {
            List<Port> ports = ProviderFactory.Create<IPortProvider>(_RepoUri).GetItems(null).QueryObjects;
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
            List<Port> ports = ProviderFactory.Create<IPortProvider>(_RepoUri).GetItems(null).QueryObjects;
            if (ports != null && ports.Count > 0)
            {
                return ports.Where(item => item.IsForeign).ToList();
            }
            return null;
        }

        public CommandResult Add(Port info)
        {
            return ProviderFactory.Create<IPortProvider>(_RepoUri).Insert(info);
        }

        public CommandResult Update(Port info)
        {
            Port original = ProviderFactory.Create<IPortProvider>(_RepoUri).GetByID(info.ID).QueryObject;
            if (original != null)
            {
                return ProviderFactory.Create<IPortProvider>(_RepoUri).Update(info, original);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "记录不存在");
            }
        }

        public CommandResult Delete(Port info)
        {
            return ProviderFactory.Create<IPortProvider>(_RepoUri).Delete(info);
        }
        #endregion
    }
}
