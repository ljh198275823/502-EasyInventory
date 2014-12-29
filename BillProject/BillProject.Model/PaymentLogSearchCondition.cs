using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.BillProject.Model
{
    public class PaymentLogSearchCondition:LJH.GeneralLibrary .Core.DAL .SearchCondition 
    {
        public DateTime? LogFrom { get; set; }

        public DateTime? LogEnd { get; set; }

        public string User { get; set; }

        public string Category { get; set; }

        public string PaymentMode { get; set; }
    }
}
