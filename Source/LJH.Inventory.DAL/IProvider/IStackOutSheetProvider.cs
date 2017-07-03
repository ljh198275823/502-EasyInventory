using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJH.GeneralLibrary.Core.DAL;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;

namespace LJH.Inventory.DAL.IProvider
{
    public interface IStackOutSheetProvider : IProvider<StackOutSheet, string>
    {
        Dictionary<string, DateTime> 获取客户最近一次送货单时间();
        DateTime? 获取客户最近一次送货单时间(string customerID);
    }
}
