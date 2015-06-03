using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.BLL
{
    public class OperatorBLL : BLLBase<string, Operator>
    {
        #region 构造函数
        public OperatorBLL(string repUri)
            : base(repUri)
        {

        }
        #endregion

        #region 实例方法
        /// <summary>
        /// 登录验证
        /// </summary>
        public bool Authentication(string logName, string pwd)
        {
            Operator info = GetByID(logName).QueryObject;
            if (info != null)
            {
                if (info.ID == logName && info.Password == pwd)
                {
                    Operator.Current = info;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="bll"></param>
        /// <param name="email"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public CommandResult Register(string email, string userName, string password)
        {
            if (string.IsNullOrEmpty(email)) return new CommandResult(ResultCode.Fail, "用户邮箱不能为空");
            if (string.IsNullOrEmpty(password)) return new CommandResult(ResultCode.Fail, "用户密码不能为空");
            Operator o = GetByID(email).QueryObject;
            if (o != null) return new CommandResult(ResultCode.Fail, "用户邮箱已经被使用,请使用其它的邮箱");
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
            o = new Operator();
            o.ID = email;
            o.Name = !string.IsNullOrEmpty(userName) ? userName : email;
            o.Password = password;
            ProviderFactory.Create<IProvider<Operator, string>>(RepoUri).Insert(o, unitWork);
            DateTime now = DateTime.Now;
            YouhuiQuan yh = new YouhuiQuan()
            {
                ID = Guid.NewGuid().ToString(),
                CreateDate = now,
                User = email,
                From = DateTime.Today,
                To = DateTime.Today.AddMonths(1),
                Amount =100,
                Memo = "注册即送优惠券",
            };
            ProviderFactory.Create<IProvider<YouhuiQuan, string>>(RepoUri).Insert(yh, unitWork);
            return unitWork.Commit();
        }
        #endregion
    }
}
