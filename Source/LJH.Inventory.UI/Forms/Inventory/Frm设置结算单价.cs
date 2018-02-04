using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class Frm设置结算单价 : Form
    {
        public Frm设置结算单价()
        {
            InitializeComponent();
        }

        public decimal 单价
        {
            get { return txt入库单价.DecimalValue; }
            set { txt入库单价.DecimalValue = value; }
        }

        public bool WithTax
        {
            get { return rdWithTax.Checked; }
            set
            {
                rdWithTax.Checked = value;
                rdWithoutTax.Checked = !value;
            }
        }

        public string SupplierID
        {
            get { return txtSupplier.Tag != null ? (txtSupplier.Tag as CompanyInfo).ID : null; }
        }

        public string Memo
        {
            get { return txtMemo.Text; }
            set
            {
                txtMemo.Text = value;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txt入库单价.DecimalValue < 0)
            {
                MessageBox.Show("单价不能小于零");
                return;
            }
            if (!rdWithoutTax.Checked && !rdWithTax.Checked)
            {
                MessageBox.Show("请选择是否含税");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkSupplier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Purchase.FrmSupplierMaster frm = new Purchase.FrmSupplierMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CompanyInfo s = frm.SelectedItem as CompanyInfo;
                txtSupplier.Text = s.Name;
                txtSupplier.Tag = s;
            }
        }

        private void txtSupplier_DoubleClick(object sender, EventArgs e)
        {
            txtSupplier.Tag = null;
            txtSupplier.Text = string.Empty;
        }
    }
}
