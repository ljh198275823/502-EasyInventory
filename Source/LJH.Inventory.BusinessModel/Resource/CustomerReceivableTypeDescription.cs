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
                case CustomerReceivableType .CustomerReceivable :
                    return "应收款";
                case CustomerReceivableType.SupplierReceivable :
                    return "应付款";
                case  CustomerReceivableType.CustomerTax :
                    return "应开增值税";
                default:
                    return string.Empty;
            }
        }
    }
}
