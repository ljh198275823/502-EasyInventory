using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using LJH.Inventory.BusinessModel;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Attendance.DAL.LinqDataProvider
{
    public class StaffPhotoProvider : ProviderBase<StaffPhoto, int>
    {
        #region 构造函数
        public StaffPhotoProvider(string connStr, MappingSource ms)
            : base(connStr, ms)
        {
        }
        #endregion

        #region 重写基类成员
        protected override StaffPhoto GetingItemByID(int id, System.Data.Linq.DataContext dc)
        {
            return dc.GetTable<StaffPhoto>().SingleOrDefault(item => item.ID == id);
        }
        #endregion
    }
}
