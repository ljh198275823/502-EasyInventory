using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.DAL.IProvider
{
    public interface IProductProvider : IProvider<LJH.Inventory.BusinessModel.Product, string>
    {
    }
}
