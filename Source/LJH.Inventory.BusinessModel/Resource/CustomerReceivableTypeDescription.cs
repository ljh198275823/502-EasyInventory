using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.Resource
{
    public class CustomerReceivableTypeDescription
    {
        public static string GetDescription(CustomerReceivableType receivableType)
        {
            switch (receivableType)
            {
                case CustomerReceivableType .CustomerOtherReceivable :
                    return "其它应收款";
                case CustomerReceivableType .CustomerReceivable :
                    return "应收款";
                case CustomerReceivableType.SupplierOtherReceivable :
                    return "其它应付款";
                case CustomerReceivableType.SupplierReceivable :
                    return "应付款";
                default:
                    return string.Empty;
            }
        }
    }
}
