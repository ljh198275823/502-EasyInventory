using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class ProductInventorySearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        #region 公共属性
        public string WareHouseID { get; set; }

        public string WareHouseName { get; set; }

        public string ProductID { get; set; }

        public string ProductName { get; set; }

        public string CategoryID { get; set; }

        public string CategoryName { get; set; }
        #endregion
    }
}
