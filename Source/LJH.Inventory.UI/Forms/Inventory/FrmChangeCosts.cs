using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;
using LJH.Inventory.UI.Controls;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;
using LJH.GeneralLibrary;
using LJH.Inventory.UI.Forms.General;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmChangeCosts : Form
    {
        public FrmChangeCosts()
        {
            InitializeComponent();
        }

        public CostItem Cost { get; set; }

        private void FrmChangeCosts_Load(object sender, EventArgs e)
        {

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
            txtSupplier.Text = string.Empty;
            txtSupplier.Tag = null;
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txt成本类别.Text))
            {
                MessageBox.Show("没有指定成本类别");
                return false;
            }
            if (txtPrice.DecimalValue > 0 && !rdWithoutTax.Checked && !rdWithTax.Checked)
            {
                MessageBox.Show("没有指定入库价格是否含税");
                return false;
            }
            if (txtSupplier.Tag == null)
            {
                MessageBox.Show("没有指定供应商");
                return false;
            }
            return true;
        }

        private void btnOk1_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;
            Cost = new CostItem() { Name = txt成本类别.Text, Price = txtPrice.DecimalValue, WithTax = rdWithTax.Checked, SupllierID = (txtSupplier.Tag as CompanyInfo).ID };
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
