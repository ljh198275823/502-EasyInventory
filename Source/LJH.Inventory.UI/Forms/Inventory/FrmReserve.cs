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
    public partial class FrmReserve : Form
    {
        public FrmReserve()
        {
            InitializeComponent();
        }

        public List<ProductInventoryItem> ProductInventorys { get; set; }

        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sale.FrmCustomerMaster frm = new Sale.FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCustomer.Text = (frm.SelectedItem as CompanyInfo).Name;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtCustomer.Text != null)
            {
                foreach (var pi in ProductInventorys)
                {
                    var ret = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).Reserve(pi, txtCustomer.Text);
                }
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
