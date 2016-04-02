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
    public partial class FrmCountInput : Form
    {
        public FrmCountInput()
        {
            InitializeComponent();
        }

        public decimal Count
        {
            get
            {
                return txtCount.DecimalValue;
            }
            set
            {
                txtCount.DecimalValue = value;
                txtCount.SelectAll();
            }
        }

        public decimal MaxCount
        {
            set
            {
                txtCount.MaxValue = value;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtCount.DecimalValue > 0) this.DialogResult = DialogResult.OK;
        }
    }
}
