using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.Inventory.BusinessModel;
using LJH.GeneralLibrary .DAL ;

namespace LJH.Inventory.BLL
{
    public interface ISheetProcessor<T> where T : class
    {
        CommandResult ProcessSheet(T sheet, SheetOperation operation, string opt);
    }
}
