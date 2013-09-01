using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.UI.Forms
{
    public class ItemAddedEventArgs : EventArgs
    {
        public object AddedItem { get; set; }

        public ItemAddedEventArgs()
        {
        }

        public ItemAddedEventArgs(object item)
        {
            this.AddedItem = item;
        }
    }
}
