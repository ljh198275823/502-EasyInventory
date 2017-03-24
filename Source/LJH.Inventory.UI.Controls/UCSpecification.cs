using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.UI.Controls
{
    public partial class UCSpecification : UserControl
    {
        public UCSpecification()
        {
            InitializeComponent();
        }

        public void Init()
        {
            this.txtThick.Items.Clear();
            this.txtWidth.Items.Clear();
            this.txtThick.Items.Add(string.Empty);
            this.txtWidth.Items.Add(string.Empty);
            List<string> ps = new ProductBLL(AppSettings.Current.ConnStr).GetAllSpecifications();
            if (ps != null && ps.Count > 0)
            {
                var thicks = (from p in ps
                              let thick = !string.IsNullOrEmpty(p) ? SpecificationHelper.GetWrittenThick(p) : null
                              where thick != null
                              orderby thick ascending
                              select thick.ToString()).Distinct();
                foreach (var thick in thicks)
                {
                    txtThick.Items.Add(thick);
                }

                var widths = (from p in ps
                              let width = !string.IsNullOrEmpty(p) ? SpecificationHelper.GetWrittenWidth(p) : null
                              where width != null
                              orderby width ascending
                              select width.ToString()).Distinct();
                foreach (var w in widths)
                {
                    txtWidth.Items.Add(w);
                }
            }
        }

        public string Specification
        {
            get
            {
                decimal thick = 0;
                if (decimal.TryParse(txtThick.Text, out thick))
                {
                    return string.Format("{0}*{1}", thick.ToString("F2"), txtWidth.Text);
                }
                return string.Format("{0}*{1}", txtThick.Text, txtWidth.Text);
            }
            set
            {
                if (string.IsNullOrEmpty(Specification))
                {
                    txtThick.Text = string.Empty;
                    txtWidth.Text = string.Empty;
                }
                else
                {
                    decimal? thick = SpecificationHelper.GetWrittenThick(value);
                    txtThick.Text = thick.HasValue ? thick.Value.ToString("F2") : string.Empty;
                    decimal? width = SpecificationHelper.GetWrittenWidth(value);
                    txtWidth.Text = width.HasValue ? width.Value.ToString() : string.Empty;
                }
            }
        }
    }
}
