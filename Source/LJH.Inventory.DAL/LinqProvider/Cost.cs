using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.DAL.LinqProvider
{
    internal class Cost : LJH.GeneralLibrary.Core.DAL.IEntity<Guid>
    {
        public Guid ID { get; set; }

        public string Costs { get; set; }

        public Cost Clone()
        {
            return this.MemberwiseClone() as Cost;
        }
    }
}
