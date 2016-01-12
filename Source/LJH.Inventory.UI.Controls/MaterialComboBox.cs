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
    public partial class MaterialComboBox : ComboBox
    {
        public MaterialComboBox()
        {
            InitializeComponent();
        }

        public MaterialComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Init()
        {
            List<string> cs = new SteelRollBLL(AppSettings.Current.ConnStr).GetAllMaterails();
            this.Items.Clear();
            this.Items.Add(string.Empty);
            if (cs != null && cs.Count > 0)
            {
                foreach (var item in cs)
                {
                    this.Items.Add(item);
                }
            }
        }
    }
}
