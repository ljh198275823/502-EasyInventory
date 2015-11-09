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
    public partial class SpecificationComboBox : ComboBox
    {
        public SpecificationComboBox()
        {
            InitializeComponent();
        }

        public SpecificationComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region 公共方法
        public void Init()
        {
            this.Items.Clear();
            List<Product> ps = new ProductBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            if (ps != null && ps.Count > 0)
            {
                var items = (from p in ps
                             where !string.IsNullOrEmpty(p.Specification)
                             orderby p.Specification ascending
                             select p.Specification).Distinct();
                foreach (var item in items)
                {
                    this.Items.Add(item);
                }
            }
        }
        #endregion
    }
}
