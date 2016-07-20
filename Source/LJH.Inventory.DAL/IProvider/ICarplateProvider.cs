using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.DAL.IProvider
{
    public interface ICarplateProvider
    {
        List<string> GetItems();
    }

    public interface IMaterialProvider
    {
        List<string> GetItems();
    }
}
