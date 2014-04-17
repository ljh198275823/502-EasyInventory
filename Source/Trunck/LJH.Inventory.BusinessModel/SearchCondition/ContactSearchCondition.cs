using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class ContactSearchCondition : LJH.GeneralLibrary.DAL.SearchCondition
    {
        public string CompanyID { get; set; }
    }
}
