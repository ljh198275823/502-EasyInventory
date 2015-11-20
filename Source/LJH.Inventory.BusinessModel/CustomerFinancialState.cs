using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示客户的财务状态
    /// </summary>
    public class CustomerFinancialState
    {
        public CompanyInfo Customer { get; set; }

        public decimal Recievables { get; set; }

        public decimal Prepay { get; set; }
    }
}
