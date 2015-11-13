using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class InventoryCheckRecordSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public string ProductID { get; set; }
        public string WareHouseID { get; set; }
        public Guid? SourceID { get; set; }
    }
}
