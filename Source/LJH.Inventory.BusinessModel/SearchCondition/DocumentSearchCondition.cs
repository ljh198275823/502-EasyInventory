using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class DocumentSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public DateTimeRange CreateDate { get; set; }

        public string DocumentID { get; set; }

        public string DocumentType { get; set; }

        public string Operation { get; set; }

        public List<string> Operations { get; set; }
    }
}
