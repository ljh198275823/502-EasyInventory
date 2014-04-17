using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class AttachmentSearchCondition : LJH.GeneralLibrary.DAL.SearchCondition
    {
        public string DocumentID { get; set; }

        public string DocumentType { get; set; }
    }
}
