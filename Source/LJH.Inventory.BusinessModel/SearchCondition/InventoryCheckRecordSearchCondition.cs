using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class InventoryCheckRecordSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public DateTimeRange CheckDate { get; set; }
        public string ProductID { get; set; }
        public string WareHouseID { get; set; }
        public Guid? SourceID { get; set; }
    }
}
