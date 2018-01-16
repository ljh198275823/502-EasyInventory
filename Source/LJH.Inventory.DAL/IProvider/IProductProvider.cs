using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary.Core.DAL;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition ;

namespace LJH.Inventory.DAL.IProvider
{
    public interface IProductProvider : IProvider<Product, string>
    {
        List<string> GetAllSpecifications(ProductSearchCondition con);

        List<string> GetAllNames(ProductSearchCondition con);
    }
}
