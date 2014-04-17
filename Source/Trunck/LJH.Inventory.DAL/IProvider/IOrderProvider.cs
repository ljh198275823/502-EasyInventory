using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.DAL.IProvider
{
    public interface IOrderProvider : LJH.GeneralLibrary.DAL.IProvider<LJH.Inventory.BusinessModel.Order, string>
    {
    }
}
