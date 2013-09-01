using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using LJH.GeneralLibrary.SoftDog;
using LJH.GeneralLibrary.ExceptionHandling;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 代表系统操作员
    /// </summary>
    public class OperatorInfo
    {
        #region 静态变量及方法
        private static LJH.GeneralLibrary.SoftDog.DSEncrypt DES = new DSEncrypt();
        private static OperatorInfo currentOperator;
        /// <summary>
        /// 获取或设置当前的操作员
        /// </summary>
        public static OperatorInfo CurrentOperator
        {
            get { return currentOperator; }
            set { currentOperator = value; }
        }
        #endregion

        #region 构造函数
        public OperatorInfo()
        {

        }
        #endregion

        #region 私有变量
        private string _Password;
        #endregion

        #region 公共属性
        /// <summary>
        /// 操作员登录名
        /// </summary>
        public string OperatorID { get; set; }
        /// <summary>
        /// 操作员名
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 操作员登录密码
        /// </summary>
        public string Password
        {
            get
            {
                if (_Password.Length > 14)
                {
                    return (new DTEncrypt()).DSEncrypt(_Password);
                }
                else
                {
                    return _Password;
                }
            }
            set
            {
                _Password = (new DTEncrypt()).Encrypt(value);
            }
        }
        /// <summary>
        /// 获取或设置操作员的部门
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// 获取或设置操作员的职位
        /// </summary>
        public string Post { get; set; }
        /// <summary>
        /// 操作员角色ID
        /// </summary>
        public string RoleID { get; set; }

        public RoleInfo Role { get; set; }
        #endregion

        #region 只读属性
        /// <summary>
        /// 操作员是否可以删除,系统内置的ADMIN操作员不可删除
        /// </summary>
        public bool CanDelete
        {
            get
            {
                return (OperatorID.ToUpper() != "ADMIN");
            }
        }

        public bool CanEdit
        {
            get
            {
                return (OperatorID.ToUpper() != "ADMIN");
            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 查看此操作员是否被授予此权限
        /// </summary>
        public bool Permit(Permission right)
        {
            if (this.Role != null)
            {
                return Role.Permit(right);
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
