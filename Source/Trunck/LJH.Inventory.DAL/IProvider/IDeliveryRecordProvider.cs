using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.DAL.IProvider
{
    public interface IDeliveryRecordProvider:IProvider <DeliveryRecord ,Guid>
    {
    }
}
