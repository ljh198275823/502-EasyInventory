using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.DAL.IProvider
{
    public interface IServerDatetimeProvider
    {
        CommandResult GetServerDateTime(out DateTime? serverDT);
    }
}
