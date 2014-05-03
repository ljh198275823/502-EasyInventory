using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LJH.Inventory.BusinessModel
{
    [Serializable()]
    public class Role : LJH.GeneralLibrary.Core.DAL.IEntity<string>
    {
        #region 私有变量
        //系统预定义的三种角色
        private readonly string Admin = "SYS"; //系统管理员
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 权限列表
        /// </summary>
        public string Permission { get; set; }
        /// <summary>
        /// 获取或设置备注
        /// </summary>
        public string Memo { get; set; }
        #endregion

        #region 只读属性
        /// <summary>
        /// 是否可以删除,系统默认的角色(系统管理员,卡片操作员,进出口操作员)不能删除
        /// </summary>
        public bool CanDelete
        {
            get
            {
                return ID.ToUpper() != Admin;
            }
        }

        /// <summary>
        /// 是否可以编辑,系统默认的角色(系统管理员)不能编辑
        /// </summary>
        public bool CanEdit
        {
            get
            {
                return ID.ToUpper() != Admin;
            }
        }
        /// <summary>
        /// 是否是系统管理员
        /// </summary>
        public bool IsAdmin
        {
            get { return ID.ToUpper() == Admin; }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 查看此角色是否被授予此权限
        /// </summary>
        public bool Permit(Permission right, PermissionActions action)
        {
            if (Permission == "all")
            {
                return true;
            }
            else
            {
                List<Permission> rights = new List<Permission>();
                if (!string.IsNullOrEmpty(Permission))
                {
                    foreach (string str in Permission.Split(','))
                    {
                        int i;
                        if (int.TryParse(str, out i))
                        {
                            rights.Add((Permission)i);
                        }
                    }
                }
                return rights.Exists(r => r == right);
            }
        }
        #endregion
    }
}
