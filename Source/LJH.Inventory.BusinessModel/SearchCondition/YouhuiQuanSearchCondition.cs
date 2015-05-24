using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class YouhuiQuanSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public string YouhuiID { get; set; }

        public string User { get; set; }

        public DateTimeRange CreateDate { get; set; }

        public string Proxy { get; set; }

        public DateTimeRange ComsumeDate { get; set; }
    }
}
