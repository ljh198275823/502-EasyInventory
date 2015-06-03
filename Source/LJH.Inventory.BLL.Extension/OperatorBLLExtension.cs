using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.Inventory .BLL ;
using LJH.Inventory.DAL.IProvider;
using LJH.GeneralLibrary .Core.DAL ;

namespace LJH.Inventory.BLL.Extension
{
    public class OperatorBLLExtension
    {
        public static CommandResult Register(this OperatorBLL bll, string email, string userName, string password)
        {
            Operator o = bll.GetByID(email).QueryObject;
            if (o != null) return new CommandResult(ResultCode.Fail, "用户邮箱已经被使用,请使用其它的邮箱");
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(bll.RepoUri);
            o = new Operator();
            o.ID = email;
            o.Name = !string.IsNullOrEmpty(userName) ? userName : email;
            o.Password = password;
            ProviderFactory.Create<IProvider<Operator, string>>(bll.RepoUri).Insert(o, unitWork);

            return unitWork.Commit();
        }
    }
}
