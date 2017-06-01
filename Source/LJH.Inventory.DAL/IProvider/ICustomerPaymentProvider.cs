using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary.Core.DAL;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.DAL.IProvider
{
    public interface ICustomerPaymentProvider : IProvider<CustomerPayment, string>
    {
        List<string> 获取所有出票单位();
    }
}
