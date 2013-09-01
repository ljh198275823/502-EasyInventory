using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;

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
        public QueryResult<RoleInfo> GetRoleInfoByID(string roleID)
        {
            return provider.GetByID(roleID);
        }

        public QueryResultList<RoleInfo> GetAllRoles()
        {
            return provider.GetItems(null);
        }

        public CommandResult Update(RoleInfo newVal)
        {
            RoleInfo original = GetRoleInfoByID(newVal.RoleID).QueryObject;
            if (original != null)
            {
                return provider.Update(newVal, original);
            }
            else
            {
                throw new InvalidOperationException(string.Format("数据库中不存在角色\"{0}\",可能被其它操作员删除!", newVal.RoleID));
            }
        }

        public CommandResult Insert(RoleInfo info)
        {
            return provider.Insert(info);
        }

        public CommandResult Delete(RoleInfo info)
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
