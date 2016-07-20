using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.UI.Controls
{
    public partial class CarplateComboBox : ComboBox
    {
        public CarplateComboBox()
        {
            InitializeComponent();
        }

        public CarplateComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Init()
        {
            List<string> cs = new SteelRollBLL(AppSettings.Current.ConnStr).GetAllCarplates();
            this.Items.Clear();
            this.Items.Add(string.Empty);
            if (cs != null && cs.Count > 0)
            {
                foreach (var item in cs)
                {
                    if (!string.IsNullOrEmpty(item)) this.Items.Add(item);
                }
            }
        }
    }
}
