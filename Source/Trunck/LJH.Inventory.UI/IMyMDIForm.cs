using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.UI
{
    public interface IMyMDIForm
    {
        /// <summary>
        /// 显示窗口的单个实例，如果之前已经打开过，则只是激活打开过的窗体
        /// </summary>
        /// <param name="formType"></param>
        /// <param name="mainPanel"></param>
        void ShowSingleForm(Type formType);
    }
}
