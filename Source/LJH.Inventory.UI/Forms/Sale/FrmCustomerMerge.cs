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

namespace LJH.Inventory.UI.Forms.Sale
{
    public partial class FrmCustomerMerge : Form
    {
        public FrmCustomerMerge()
        {
            InitializeComponent();
        }

        public CompanyInfo Source { get; set; }


        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sale.FrmCustomerMaster frm = new Sale.FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCustomer.Text = (frm.SelectedItem as CompanyInfo).Name;
                txtCustomer.Tag = frm.SelectedItem;
            }
        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            txtCustomer.Tag = null;
            txtCustomer.Text = string.Empty;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtCustomer.Tag == null)
            {
                MessageBox.Show("请选择合并到客户");
                return;
            }

            if (Source == null)
            {
                MessageBox.Show("没有选择要合并的客户");
                return;
            }

            var ret = new CompanyBLL(AppSettings.Current.ConnStr).Merge(Source.ID, (txtCustomer.Tag as CompanyInfo).ID);
            if (ret.Result == LJH.GeneralLibrary.Core.DAL.ResultCode.Successful) this.DialogResult = DialogResult.OK;
            else
            {
                MessageBox.Show(ret.Message);
            }
        }

        private void FrmCustomerMerge_Load(object sender, EventArgs e)
        {
            if (Source != null) textBox1.Text = Source.Name;
        }
    }
}
