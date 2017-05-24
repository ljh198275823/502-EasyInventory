using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmMemo : Form
    {
        public FrmMemo()
        {
            InitializeComponent();
        }

        public string Memo
        {
            get { return txtMemo.Text; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMemo.Text))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请填写原因!");
            }
        }
    }
}
