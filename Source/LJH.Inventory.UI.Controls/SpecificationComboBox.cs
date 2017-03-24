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
            List<string> ps = new ProductBLL(AppSettings.Current.ConnStr).GetAllSpecifications();
            if (ps != null && ps.Count > 0)
            {
                this.Items.Add(string.Empty);
                var items = (from p in ps
                             where !string.IsNullOrEmpty(p) && SpecificationHelper.GetWrittenThick(p).HasValue && SpecificationHelper.GetWrittenWidth(p).HasValue
                             orderby p ascending
                             select p).Distinct();
                foreach (var item in items)
                {
                    this.Items.Add(item);
                }
            }
        }
        #endregion
    }
}
