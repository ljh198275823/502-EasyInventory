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
    public partial class FrmAboat : Form
    {
        public FrmAboat()
        {
            InitializeComponent();
        }

        private void FrmAboat_Load(object sender, EventArgs e)
        {
            this.lbVersion.Text = Application.ProductVersion;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void lbVersion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
