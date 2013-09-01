using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.DAL.IProvider
{
    public interface IStorageSheetProvider : IProvider<LJH.Inventory.BusinessModel.DeliverySheet, Guid>
    {
    }
}
