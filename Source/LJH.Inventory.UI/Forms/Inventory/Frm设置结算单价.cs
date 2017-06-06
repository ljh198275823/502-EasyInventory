using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class Frm设置结算单价 : Form
    {
        public Frm设置结算单价()
        {
            InitializeComponent();
        }

        public decimal 结算单价
        {
            get { return txt结算单价.DecimalValue; }
            set { txt结算单价.DecimalValue = value; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
