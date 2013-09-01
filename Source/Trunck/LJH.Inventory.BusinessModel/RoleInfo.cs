using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace LJH.Inventory.BusinessModel
{
    [Serializable()]
    public class RoleInfo
    {
        //系统预定义的三种角色
        private readonly string Admin = "系统管理员"; //系统管理员

        public string RoleID { get; set; }

        public string Description { get; set; }

        private List<Permission> _rights;
        private string _myRights;

        /// <summary>
        /// 查看此角色是否被授予此权限
        /// </summary>
        public bool Permit(Permission right)
        {
            if (_myRights == "all")
            {
                return true;
            }
            else
            {
                if (_rights == null)
                {
                    _rights = new List<Permission>();
                    if (!string.IsNullOrEmpty(_myRights))
                    {
                        foreach (string str in _myRights.Split(','))
                        {
                            int i;
                            if (int.TryParse(str, out i))
                            {
                                _rights.Add((Permission)i);
                            }
                        }
                    }
                }
                return _rights.Exists(r => r == right);
            }
        }

        /// <summary>
        /// 权限列表
        /// </summary>
        public string Permission
        {
            get
            {
                return _myRights;
            }
            set
            {
                _myRights = value.ToLower();
                _rights = null;
            }
        }

        /// <summary>
        /// 是否可以删除,系统默认的角色(系统管理员,卡片操作员,进出口操作员)不能删除
        /// </summary>
        public bool CanDelete
        {
            get
            {
                return RoleID.ToUpper() != Admin;
            }
        }

        /// <summary>
        /// 是否可以编辑,系统默认的角色(系统管理员)不能编辑
        /// </summary>
        public bool CanEdit
        {
            get
            {
                return RoleID.ToUpper() != Admin;
            }
        }
        /// <summary>
        /// 是否是系统管理员
        /// </summary>
        public bool IsAdmin
        {
            get { return RoleID.ToUpper() == Admin; }
        }
    }
}
