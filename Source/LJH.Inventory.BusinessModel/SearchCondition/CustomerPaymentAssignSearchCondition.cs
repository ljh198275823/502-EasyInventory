﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class CustomerPaymentAssignSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public string PaymentID { get; set; }

        public List<Guid> ReceivableIDs { get; set; }
    }
}
