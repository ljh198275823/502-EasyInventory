using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class CustomerDaiFuSearchCondition :CustomerReceivableSearchCondition 
    {
        public bool ContainCanceled { get; set; }
    }
}
