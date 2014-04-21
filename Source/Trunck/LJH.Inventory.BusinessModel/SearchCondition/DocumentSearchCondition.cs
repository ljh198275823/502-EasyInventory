using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class DocumentSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public string DocumentID { get; set; }

        public string DocumentType { get; set; }
    }
}
