using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.SearchCondition
{
    public class CustomerReceivableSearchCondition : LJH.GeneralLibrary.Core.DAL.SearchCondition
    {
        public DateTimeRange CreateDate { get; set; }

        public List<CustomerReceivableType> ReceivableTypes { get; set; }

        public List<Guid> ReceivableIDS { get; set; }

        public string CustomerID { get; set; }

        public string OrderID { get; set; }

        public string SheetID { get; set; }

        public bool? Settled { get; set; }

        /// <summary>
        /// 获取或设置出货记录查询条件中的送货单状态
        /// </summary>
        public List<SheetState> States { get; set; }
    }
}
