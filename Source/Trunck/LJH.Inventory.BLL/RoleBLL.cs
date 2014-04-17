using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.BLL
{
    public class RoleBLL
    {
        #region 私有变量
        private IRoleProvider provider;
        #endregion

        #region 构造函数
        public RoleBLL(string repUri)
        {
            provider = ProviderFactory.Create<IRoleProvider>(repUri);
        }
        #endregion

        #region 公共方法
        public QueryResult<Role> GetRoleInfoByID(string roleID)
        {
            return provider.GetByID(roleID);
        }

        public QueryResultList<Role> GetAllRoles()
        {
            return provider.GetItems(null);
        }

        public CommandResult Update(Role newVal)
        {
            Role original = GetRoleInfoByID(newVal.ID).QueryObject;
            if (original != null)
            {
                return provider.Update(newVal, original);
            }
            else
            {
                throw new InvalidOperationException(string.Format("数据库中不存在角色\"{0}\",可能被其它操作员删除!", newVal.ID));
            }
        }

        public CommandResult Insert(Role info)
        {
            return provider.Insert(info);
        }

        public CommandResult Delete(Role info)
        {
            if (!info.CanDelete)
            {
                throw new InvalidOperationException(string.Format("角色 \"{0}\" 是系统默认角色,不能删除!", info.Description));
            }
            return provider.Delete(info);
        }
        #endregion
    }
}
