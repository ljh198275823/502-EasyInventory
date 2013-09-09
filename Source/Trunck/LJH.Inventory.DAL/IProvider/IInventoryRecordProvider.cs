using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.DAL.IProvider
{
    public interface IInventoryRecordProvider : IProvider<LJH.Inventory.BusinessModel.InventoryRecord, Guid>
    {
    }
}
