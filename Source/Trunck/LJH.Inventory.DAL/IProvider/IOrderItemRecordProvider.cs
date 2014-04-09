using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.DAL.IProvider
{
    public interface IOrderItemRecordProvider:IProvider <LJH.Inventory.BusinessModel .OrderItemRecord ,Guid>
    {
    }
}
