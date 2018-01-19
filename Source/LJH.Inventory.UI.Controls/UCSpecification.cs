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
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary;

namespace LJH.Inventory.UI.Controls
{
    public partial class UCSpecification : UserControl
    {
        public UCSpecification()
        {
            InitializeComponent();
        }

        public event EventHandler SpecificationChanged;

        public void Init()
        {
            this.txtThick.Items.Clear();
            this.txtWidth.Items.Clear();
            this.txtThick.Items.Add(string.Empty);
            this.txtWidth.Items.Add(string.Empty);
            var con = new ProductSearchCondition();
            con.Models = new List<string> { ProductModel.原材料, ProductModel.开平, ProductModel.开卷, ProductModel.开吨, ProductModel.开条 };
            List<string> ps = new ProductBLL(AppSettings.Current.ConnStr).GetAllSpecifications(con);
            if (ps != null && ps.Count > 0)
            {
                var thicks = (from p in ps
                              let thick = !string.IsNullOrEmpty(p) ? SpecificationHelper.GetWritten克重(p) : null
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
                    return string.Format("{0}*{1}", thick.ToString(), txtWidth.Text);
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
                    decimal? thick = SpecificationHelper.GetWritten克重(value);
                    txtThick.Text = thick.HasValue ? thick.Value.ToString("F0") : string.Empty;
                    decimal? width = SpecificationHelper.GetWrittenWidth(value);
                    txtWidth.Text = width.HasValue ? width.Value.ToString("F0") : string.Empty;
                }
            }
        }

        public int? Selected克重
        {
            get
            {
                decimal 克重;
                if (decimal.TryParse(txtThick.Text, out 克重))
                {
                    return (int)克重;
                }
                return null;
            }
            set
            {
                if (value == null) txtThick.Text = string.Empty;
                else txtThick.Text = value.ToString();
            }
        }

        public int? SelectedWidth
        {
            get
            {
                decimal width;
                if (decimal.TryParse(txtWidth.Text, out width))
                {
                    return (int)width;
                }
                return null;
            }
            set
            {
                if (value == null) txtWidth.Text = string.Empty;
                else txtWidth.Text = value.ToString();
            }
        }

        private Dictionary<ComboBox, string> _PreText = new Dictionary<ComboBox, string>();

        private void cmb_TextChanged(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            string text = StringHelper.ToDBC(cmb.Text);
            int position = cmb.SelectionStart;
            if (!string.IsNullOrEmpty(text.Trim()))
            {
                if (text.Trim().IndexOf('-') == 0) //不显示非负数
                {
                    if (_PreText.ContainsKey(cmb)) this.Text = _PreText[cmb];
                    cmb.SelectionStart = this.Text.Length;
                    return;
                }
                if (text.Trim() != "-")
                {
                    decimal value;
                    if (!decimal.TryParse(text, out value)) //不能转换成实数
                    {
                        if (_PreText.ContainsKey(cmb)) this.Text = _PreText[cmb];
                        cmb.SelectionStart = this.Text.Length;
                        return;
                    }
                }
            }
            cmb.Text = text;
            _PreText[cmb] = text;
            cmb.SelectionStart = position;
            if (SpecificationChanged != null) this.SpecificationChanged(this, EventArgs.Empty);
        }
    }
}
