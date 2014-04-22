﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class CustomerReceivableSearchCondition : LJH.GeneralLibrary .Core .DAL .SearchCondition 
    {
        public DateTimeRange CreateDate { get; set; }

        public string CustomerID { get; set; }

        public string OrderID { get; set; }

        public string DeliverySheet { get; set; }

        public bool? Settled { get; set; }
    }
}
