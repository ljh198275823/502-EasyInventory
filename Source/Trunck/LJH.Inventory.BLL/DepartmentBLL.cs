using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary.Core.DAL;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.DAL.IProvider;

namespace LJH.Inventory.BLL
{
    public class DepartmentBLL : BLLBase<string, Department>
    {
        #region 构造函数
        public DepartmentBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 重写基类方法
        public override GeneralLibrary.Core.DAL.CommandResult Add(Department info)
        {
            if (string.IsNullOrEmpty(info.ID))
            {
                info.ID = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber("D", 4, "Department");
            }
            if (!string.IsNullOrEmpty(info.ID))
            {
                return base.Add(info);
            }
            else
            {
                return new CommandResult(ResultCode.Fail, "创建编号失败");
            }
        }

        public override CommandResult Delete(Department info)
        {
            List<Department> tps = ProviderFactory.Create<IProvider<Department, string>>(_RepoUri).GetItems(null).QueryObjects;
            if (tps != null && tps.Count > 0 && tps.Exists(item => item.Parent == info.ID))
            {
                return new CommandResult(ResultCode.Fail, "部门下已经有子部门，请先将所有子部门删除，再删除此部门");
            }
            IProvider<CompanyInfo, string> sp = ProviderFactory.Create<IProvider<CompanyInfo, string>>(_RepoUri);

            //if (sp.GetItems(null).QueryObjects.Count > 0)
            //{
            //    return new CommandResult(ResultCode.Fail, "已经有客户归到此部门，如果确实要删除此部门，请先更改相关客户的所属部门");
            //}
            return base.Delete(info);
        }
        #endregion
    }
}
