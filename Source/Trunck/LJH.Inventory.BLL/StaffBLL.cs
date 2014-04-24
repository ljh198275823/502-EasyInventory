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
                if (string.IsNullOrEmpty(id) || !int.TryParse(id, out intID))
                {
                    return new CommandResult(ResultCode.Fail, "创建编号失败");
                }
                info.ID = intID;
            }
            return base.Add(info);
        }
        /// <summary>
        /// 保存某个员工的登录信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="staff"></param>
        /// <returns></returns>
        public CommandResult SaveOperator(Operator info, Staff staff)
        {
            IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(_RepoUri);
            List<Operator> opts = (new OperatorBLL(_RepoUri)).GetItems(null).QueryObjects;
            if (opts != null && opts.Count > 0)
            {
                List<Operator> items = opts.Where(item => item.StaffID == staff.ID).ToList();
                if (items != null && items.Count > 0)
                {
                    foreach (Operator opt in items)
                    {
                        ProviderFactory.Create<IProvider<Operator, string>>(_RepoUri).Delete(opt, unitWork);
                    }
                }
            }
            if (info != null)
            {
                info.Name = staff.Name;
                info.StaffID = staff.ID;
                ProviderFactory.Create<IProvider<Operator, string>>(_RepoUri).Insert(info, unitWork);
            }
            return unitWork.Commit();
        }
        #endregion

        #region 人员照片相关
        public QueryResult<StaffPhoto> GetPhoto(int staffID)
        {
            return ProviderFactory.Create<IProvider<StaffPhoto, int>>(_RepoUri).GetByID(staffID);
        }

        public CommandResult SavePhoto(int staffID, string path)
        {
            StaffPhoto sp = new StaffPhoto(staffID, path);
            return ProviderFactory.Create<IProvider<StaffPhoto, int>>(_RepoUri).Insert(sp);
        }

        public CommandResult DeletePhoto(int staffID)
        {
            StaffPhoto sp = new StaffPhoto();
            sp.ID = staffID;
            return ProviderFactory.Create<IProvider<StaffPhoto, int>>(_RepoUri).Delete(sp);
        }
        #endregion
    }
}
