using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class AccountSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public bool? IsPublic { get; set; }

        public List<AccountType> AccountTypes { get; set; }
    }
}
