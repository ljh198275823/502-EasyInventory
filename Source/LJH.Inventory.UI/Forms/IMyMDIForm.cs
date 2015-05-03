using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows .Forms ;

namespace LJH.Inventory.UI.Forms
{
    public interface IMyMDIForm
    {
        T ShowSingleForm<T>(bool mainPanel = true, bool showHeader = true) where T : Form;
    }
}
