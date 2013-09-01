using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.DAL.IProvider
{
    public interface IItemKeyProvider
    {
        long GetNewItemKey();

        void SaveKey(long key, IUnitWork unitWork);
    }
}
