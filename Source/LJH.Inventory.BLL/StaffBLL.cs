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
                id = ProviderFactory.Create<IAutoNumberCreater>(RepoUri).CreateNumber(string.Empty, 4, info.DocumentType);
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
        //public CommandResult SaveOperator(Operator info, Staff staff)
        //{
        //    IUnitWork unitWork = ProviderFactory.Create<IUnitWork>(RepoUri);
        //    List<Operator> opts = ProviderFactory.Create<IProvider<Operator, string>>(RepoUri).GetItems(null).QueryObjects;
        //    Operator original = opts.SingleOrDefault(it => it.ID == info.ID);
        //    if (original != null)
        //    {
        //        info.Name = staff.Name;
        //        info.StaffID = staff.ID;
        //        ProviderFactory.Create<IProvider<Operator, string>>(RepoUri).Update(info, original, unitWork);
        //    }
        //    else
        //    {
        //        info.Name = staff.Name;
        //        info.StaffID = staff.ID;
        //        ProviderFactory.Create<IProvider<Operator, string>>(RepoUri).Insert(info, unitWork);
        //    }
        //    foreach (var item in opts.Where(it => it.ID != info.ID && it.StaffID == staff.ID)) //将其它归属到此员工的所有操作员删除
        //    {
        //        if (item.ID != Operator.DefaultLogID)
        //        {
        //            ProviderFactory.Create<IProvider<Operator, string>>(RepoUri).Delete(item, unitWork);
        //        }
        //        else
        //        {
        //            var newV = item.Clone();
        //            newV.Name = item.ID;
        //            newV.StaffID = null;
        //            ProviderFactory.Create<IProvider<Operator, string>>(RepoUri).Update(newV, item, unitWork);
        //        }
        //    }
        //    return unitWork.Commit();
        //}
        #endregion

        #region 人员照片相关
        public QueryResult<StaffPhoto> GetPhoto(int staffID)
        {
            return ProviderFactory.Create<IProvider<StaffPhoto, int>>(RepoUri).GetByID(staffID);
        }

        public CommandResult SavePhoto(int staffID, string path)
        {
            StaffPhoto sp = new StaffPhoto(staffID, path);
            return ProviderFactory.Create<IProvider<StaffPhoto, int>>(RepoUri).Insert(sp);
        }

        public CommandResult DeletePhoto(int staffID)
        {
            StaffPhoto sp = new StaffPhoto();
            sp.ID = staffID;
            return ProviderFactory.Create<IProvider<StaffPhoto, int>>(RepoUri).Delete(sp);
        }
        #endregion
    }
}
