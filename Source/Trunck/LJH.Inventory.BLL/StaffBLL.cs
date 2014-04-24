using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary .Core .DAL ;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory .DAL .IProvider ;

namespace LJH.Inventory.BLL
{
    public class StaffBLL : BLLBase<int, Staff>
    {
        #region 构造函数
        public StaffBLL(string repoUri)
            : base(repoUri)
        {
        }
        #endregion

        #region 重写基类方法
        public override CommandResult Add(Staff info)
        {
            string id = null;
            int intID = 0;
            if (info.ID == 0)
            {

                id = ProviderFactory.Create<IAutoNumberCreater>(_RepoUri).CreateNumber(string.Empty, 4, info.DocumentType);
                if (string.IsNullOrEmpty(id) || int.TryParse(id, out intID))
                {
                    return new CommandResult(ResultCode.Fail, "创建编号失败");
                }
                info.ID = intID;
            }
            return base.Add(info);
        }
        #endregion
    }
}
