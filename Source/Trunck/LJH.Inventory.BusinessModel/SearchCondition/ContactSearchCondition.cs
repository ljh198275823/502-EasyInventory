using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class ContactSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public string CompanyID { get; set; }
    }
}
